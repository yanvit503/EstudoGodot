using EstudoGodot.Scripts.Interfaces;
using Godot;
using System;
using System.Collections.Generic;
using System.Linq;

public partial class ArmasController : Node
{
    IArma _armaAtual;

    List<IArma> _armas = new List<IArma>();

    Timer _timer;

    public bool podeAtacar = true,atacando = false;

    public static ArmasController Instance;

    public override void _Ready()
    {
        Instance = this;

        AtualizaListaArmas();

        _timer = GetNode<Timer>("Timer");
        _timer.Timeout += OnTimerTimeout;
    }

    private void OnTimerTimeout()
    {
        podeAtacar = true;
        atacando = false;
    }

    public override void _Process(double delta)
    {
        if (Input.IsActionJustPressed("Ataque"))
            if (podeAtacar)
            {
                _armaAtual.Atacar();

                _timer.Start();
                podeAtacar = false;
                atacando = true;
            }

        VerificaTrocaDeArma();
    }

    public void AtualizaListaArmas()
    {
        foreach (var child in GetChildren())
        {
            if (child is IArma arma)
                _armas.Add(arma);
        }
    }

    private void VerificaTrocaDeArma()
    {
        var slots = InputMap.GetActions().Where(x => x.ToString().Contains("Slot"));

        foreach (var slot in slots)
        {
            if (Input.IsActionJustPressed(slot))
            {
                var slotIndex = Convert.ToInt32(slot.ToString().Split('t')[1]) - 1;

                SelecionarArma(slotIndex);
            }
        }
    }

    void SelecionarArma(int index)
    {
        if (_armaAtual != _armas[index])
        {
            _armaAtual = _armas[index];

            _timer.WaitTime = _armaAtual.IntervaloAtaque;

            UIController.Instance.SelectionarArma(_armaAtual);

            GD.Print(_armaAtual.Nome);
        }
    }
}