using Godot;
using System;

public partial class PlayerMoveState : Node
{
    Player player;
    public override void _Ready()
    {
        player = GetOwner<Player>();
        SetPhysicsProcess(false);
        SetProcessInput(true);
    }

    public override void _PhysicsProcess(double delta)
    {

        if (player.direction == Vector2.Zero)
        {
            player.stateMachineNode.SwitchState<PlayerIdleState>();
        }
    }

    public override void _Notification(int what)
    {

        base._Notification(what);
        if (what == GameConstants.NODE_ACTIVATE)
        {
            player.animPlayerNode.Play(GameConstants.ANIM_MOVE);
            SetPhysicsProcess(true);
            SetProcessInput(true);
        }
        else if (what == GameConstants.NODE_DEACTIVATE)
        {
            SetPhysicsProcess(false);
            SetProcessInput(false);
        }
    }

    public override void _Input(InputEvent @event)
    {
        if (Input.IsActionJustPressed(GameConstants.INPUT_DASH))
        {
            GD.Print("Dash");
            player.stateMachineNode.SwitchState<PlayerDashState>();
        }
    }
}
