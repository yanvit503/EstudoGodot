using EstudoGodot.Scripts.Interfaces;
using Godot;
using System;

public partial class UIController : Node2D
{
	[Export]
	Sprite2D IconeArma { get; set; }

	[Export]
	Texture2D TexturaArco { get; set; }

	public static UIController Instance;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Instance = this;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public void SelectionarArma(IArma arma)
	{
		IconeArma.Texture = (Texture2D)GD.Load(arma.Icone);
	}
}