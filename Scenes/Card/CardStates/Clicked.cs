using Godot;
using System;

public partial class Clicked : State
{
	public override void Enter()
	{
		GetNode<Label>("%State").Text = "Clicked";
		GetNode<ColorRect>("%Colorbox").Color = new Color("Green");
	}
}
