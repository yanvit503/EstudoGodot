using EstudoGodot.Scripts.Interfaces;
using Godot;
using System;

public partial class Arco : Node, IArma
{
    public int Dano { get => 100; set { } }
    public string Nome { get => "Arco"; set { } }
    public float IntervaloAtaque { get => 1.5f; set {  } }
    public string Icone { get => "res://sprites/Icones/image_216.png"; set => throw new NotImplementedException(); }

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
        GD.Print("Atirando com o arco");
    }
}