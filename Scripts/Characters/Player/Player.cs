using Godot;
using System;

public partial class Player : CharacterBody3D
{

    private Vector2 direction = new Vector2();
    public override void _PhysicsProcess(double delta)
    {
        int Speed = 5;
        Velocity = new Vector3(direction.X, 0, direction.Y).Normalized() * Speed;

        MoveAndSlide();
    }

    public override void _Input(InputEvent @event)
    {
        direction = Input.GetVector("MoveLeft", "MoveRight", "MoveForward", "MoveBackward");
        // base._Input(@event);
    }
}
