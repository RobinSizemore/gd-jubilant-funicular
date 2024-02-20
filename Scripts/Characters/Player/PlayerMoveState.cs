using Godot;
using System;

public partial class PlayerMoveState : Node
{
    Player player;
    public override void _Ready()
    {
        player = GetOwner<Player>();
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
        if (what == 5001)
        {
            Player characterNode = GetOwner<Player>();
            characterNode.animPlayerNode.Play(GameConstants.ANIM_MOVE);
        }
    }
}
