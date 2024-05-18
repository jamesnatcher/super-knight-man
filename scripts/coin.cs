using Godot;
using System;

public partial class coin : Area2D
{
	private Node _gameManager;
	private AnimationPlayer _animationPlayer;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_gameManager = GetNode<Node>("%GameManager");
		_animationPlayer = GetNode<AnimationPlayer>("AnimationPlayer");
	}

	private void _on_body_entered(Node2D body)
	{
		_gameManager.Call("AddPoint");
		_animationPlayer.Play("pickup");
	}
}
