using Godot;
using System;

public partial class player : CharacterBody2D
{
	public const float Speed = 130.0f;
	public const float JumpVelocity = -300.0f;
	private AnimatedSprite2D _animatedSprite;

	// Get the gravity from the project settings to be synced with RigidBody nodes.
	public float gravity = ProjectSettings.GetSetting("physics/2d/default_gravity").AsSingle();

	public override void _Ready()
	{
		_animatedSprite = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
	}

	public override void _PhysicsProcess(double delta)
	{
		Vector2 velocity = Velocity;

		// Add the gravity.
		if (!IsOnFloor())
			velocity.Y += gravity * (float)delta;

		// Handle Jump.
		if (Input.IsActionJustPressed("jump") && IsOnFloor())
			velocity.Y = JumpVelocity;

		// Get the input direction and handle the movement/deceleration (-1, 0, 1).
		Vector2 direction = Input.GetVector("move_left", "move_right", "ui_up", "ui_down");
		if (direction.X > 0)
		{
			_animatedSprite.FlipH = false;
		}
		else if (direction.X < 0)
		{
			_animatedSprite.FlipH = true;
		}

		// Play animation variable
		if (IsOnFloor())
		{
			if (direction.X == 0)
			{
				_animatedSprite.Play("idle");
			}
			else
			{
				_animatedSprite.Play("run");
			}
		}
		else
		{
			_animatedSprite.Play("jumping");
		}


		if (direction != Vector2.Zero)
		{
			velocity.X = direction.X * Speed;
		}
		else
		{
			velocity.X = Mathf.MoveToward(Velocity.X, 0, Speed);
		}

		Velocity = velocity;
		MoveAndSlide();
	}
}
