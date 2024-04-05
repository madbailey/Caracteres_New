using Godot;
using System;

public partial class Colorbox : ColorRect
{
	[Signal]
	public delegate void mouseClickCardEventHandler();

    public override void _UnhandledInput(InputEvent @event)
    {
        if (@event is InputEventMouseButton buttonEvent)
		{
            if (buttonEvent.Pressed) 
			{
				GD.Print("Clicked");
			}
    	}
	}

}
