using EstudoGodot.Scripts.Interfaces;
using Godot;
using System;

public partial class Espada : Node,IArma
{
    public int Dano { get { return 10; } set => throw new NotImplementedException(); }
    public string Nome { get { return "Espada"; } set => throw new NotImplementedException(); }
    public float IntervaloAtaque { get { return 1.0f; } set => throw new NotImplementedException(); }
    public string Icone { get => "res://sprites/Icones/image_221.png"; set => throw new NotImplementedException(); }

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

    public void Atacar()
    {
        Player.Instance.AnimacaoAtaqueMelee();
    }
}