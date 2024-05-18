using Godot;
using System;

public partial class slime : Node2D
{
	private RayCast2D _raycastRight;
	private RayCast2D _raycastLeft;
	private AnimatedSprite2D _animatedSprite;
	const int SPEED = 60;
	int direction = 1;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_raycastRight = GetNode<RayCast2D>("RayCastRight");
		_raycastLeft = GetNode<RayCast2D>("RayCastLeft");
		_animatedSprite = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if (_raycastRight.IsColliding())
		{
			direction = -1;
			_animatedSprite.FlipH = true;
		}
		if (_raycastLeft.IsColliding())
		{
			direction = 1;
			_animatedSprite.FlipH = false;
		}

		var newPosition = Position;
		newPosition.X += direction * SPEED * (float)delta;
		Position = newPosition;
	}
}
