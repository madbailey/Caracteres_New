using Godot;
using System;
using System.Numerics;


public partial class Hover : State
{
	private int originalColorZIndex;
    private int originalLabelZIndex;
	private Godot.Vector2 originalMinimumSize;

	public override void Enter()
	{
		ColorRect color = GetNode<ColorRect>("%Colorbox");
		Label label = GetNode<Label>("%State");
		label.Text = "Hover";
		color.Color = new Color("Gold");
		
		color.GetMinimumSize();
		 // Store the original Z indices
        originalColorZIndex = color.ZIndex;
        originalLabelZIndex = label.ZIndex;

		originalMinimumSize = color.CustomMinimumSize;
		GD.Print("Original Minimum Size: " + originalMinimumSize);
		color.CustomMinimumSize = originalMinimumSize * 1.05f;

		color.ZIndex = 500;
		label.ZIndex = 501;
	}
	public void _on_colorbox_mouse_exited()
	{
		if(fsm.GetStateName() != "Hover")
		{
			return;
		}
		else
		{
			Exit();
			GetNode<ColorRect>("%Colorbox").CustomMinimumSize = originalMinimumSize;
			fsm.TransitionTo("Base");
		}
		
	
	}
	public void _on_button_pressed()
	{
        GD.Print("Clicked Button");
		Exit();
		fsm.TransitionTo("Clicked");
			
    }

	public override void Exit()
    {
		GD.Print("Exiting Hover");
        // Restore the original Z indices
        GetNode<ColorRect>("%Colorbox").ZIndex = originalColorZIndex;
        GetNode<Label>("%State").ZIndex = originalLabelZIndex;
		
    }
}
