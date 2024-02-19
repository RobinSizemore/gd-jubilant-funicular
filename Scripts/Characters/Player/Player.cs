using Godot;
using System;
using System.ComponentModel.DataAnnotations;

public partial class Player : CharacterBody3D
{

    [ExportGroup("Required Nodes")]
    [Export] private AnimationPlayer animPlayerNode;
    [Export] private Sprite3D sprite3DNode;

    public float Speed = 5.0f;

    public override void _Ready()
    {

        animPlayerNode.Play(GameConstants.ANIM_IDLE);

        GD.Print(animPlayerNode.Name);
        GD.Print(sprite3DNode.Name);
    }


    private Vector2 direction = new Vector2();
    public override void _PhysicsProcess(double delta)
    {
        Velocity = new Vector3(direction.X, 0, direction.Y).Normalized() * Speed;

        MoveAndSlide();
    }

    public override void _Input(InputEvent @event)
    {
        direction = Input.GetVector(GameConstants.MOVE_LEFT, GameConstants.MOVE_RIGHT, GameConstants.MOVE_FORWARD, GameConstants.MOVE_BACKWARD);
        if (direction == Vector2.Zero)
        {
            animPlayerNode.Play(GameConstants.ANIM_IDLE);
        }
        else
        {
            animPlayerNode.Play(GameConstants.ANIM_MOVE);
        }
        // base._Input(@event);
    }
}
