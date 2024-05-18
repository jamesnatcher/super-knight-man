using Godot;
using System;

public partial class gameManager : Node
{
	int score = 0;
	private Label _scoreLabel;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_scoreLabel = GetNode<Label>("ScoreLabel");
	}

	public void AddPoint()
	{
		score += 1;
		_scoreLabel.Text = "You made it! You collected " + score.ToString() + " coins!";
	}
}
