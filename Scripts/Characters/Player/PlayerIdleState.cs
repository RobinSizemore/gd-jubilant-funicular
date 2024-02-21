using Godot;
using System;

public partial class PlayerIdleState : Node
{

    Player characterNode;

    public override void _Ready()
    {
        characterNode = GetOwner<Player>();
        SetPhysicsProcess(false);
        SetProcessInput(false);
    }

    public override void _PhysicsProcess(double delta)
    {

        if (characterNode.direction != Vector2.Zero)
        {
            characterNode.stateMachineNode.SwitchState<PlayerMoveState>();
        };

    }

    public override void _Notification(int what)
    {
        base._Notification(what);
        if (what == GameConstants.NODE_DEACTIVATE)
        {
            SetPhysicsProcess(false);
            SetProcessInput(false);
        }
        else if (what == GameConstants.NODE_ACTIVATE)
        {
            characterNode.animPlayerNode.Play(GameConstants.ANIM_IDLE);
            SetPhysicsProcess(true);
            SetProcessInput(true);
        }
    }

    public override void _Input(InputEvent @event)
    {
        if (Input.IsActionJustPressed(GameConstants.INPUT_DASH))
        {
            GD.Print("Dash");
            characterNode.stateMachineNode.SwitchState<PlayerDashState>();
        }
    }
}
