using Godot;
using System;

public partial class Base : State
{
	private CardUI _cardUI;

	public override void _Ready()
	{
		GD.Print("Base Ready");
		_cardUI = GetParent().GetParent() as CardUI;  // Get the grandparent node and cast it to cardUI
		if (_cardUI == null) GD.Print("cardUI is null");

		GD.Print("Connecting to MouseEntered and MouseExited");
	}

	
	public override void Enter()
	{

		GetNode<Label>("%State").Text = "Base";
		GetNode<ColorRect>("%Colorbox").Color = new Color("Red");
	}
    public void _on_colorbox_mouse_entered()
	{
		GD.Print("Mouse Entered Base");
		fsm.TransitionTo("Hover");
		
	}
}
