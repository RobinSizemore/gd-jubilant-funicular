using Godot;
using System;

public partial class PlayerDashState : Node
{
    Player player;
    public override void _Ready()
    {
        player = GetOwner<Player>();
        SetPhysicsProcess(false);
    }

    public override void _PhysicsProcess(double delta)
    {

        if (player.direction == Vector2.Zero)
        {
            player.stateMachineNode.SwitchState<PlayerDashState>();
        }
    }

    public override void _Notification(int what)
    {

        base._Notification(what);
        if (what == GameConstants.NODE_ACTIVATE)
        {
            player.animPlayerNode.Play(GameConstants.ANIM_DASH);
            SetPhysicsProcess(true);
        }
        else if (what == GameConstants.NODE_DEACTIVATE)
        {
            SetPhysicsProcess(false);
        }

    }
}
