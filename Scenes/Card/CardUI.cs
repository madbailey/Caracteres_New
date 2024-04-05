using Godot;
using System;


public partial class CardUI : Control
{
	[Signal]
	public delegate void reparentRequestedEventHandler(); 

	public override void _Ready()
	{
		this.MouseEntered += _on_mouse_entered;
	}

	private void _on_mouse_entered()
	{
		GD.Print("Mouse Entered CARD");
	}

}

