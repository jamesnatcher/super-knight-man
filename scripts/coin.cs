using Godot;
using System;

public partial class coin : Area2D
{
	private void _on_body_entered(Node2D body)
	{
		this.QueueFree();
	}
}
