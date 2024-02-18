using Godot;
using System;

public partial class Player : CharacterBody3D
{
    public override void _PhysicsProcess(double delta)
    {
        GD.Print("Player Physics Process");
        // base._PhysicsProcess(delta);
    }

    public override void _Input(InputEvent @event)
    {
        GD.Print("Player Input: " + @event.ToString());
        // base._Input(@event);
    }
}
