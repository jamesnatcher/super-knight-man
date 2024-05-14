using Godot;
using System;

public partial class killzone : Area2D
{
	private Timer _timer;
	
	private void _on_ready()
	{
		_timer = GetNode<Timer>("Timer");
		GD.Print("initial");
	}
	
	private void _on_body_entered(Node2D body)
	{
		GD.Print("whatever");
		_timer.Start();
	}
	
	private void _on_timer_timeout()
	{
		GetTree().ReloadCurrentScene();
	}
}
