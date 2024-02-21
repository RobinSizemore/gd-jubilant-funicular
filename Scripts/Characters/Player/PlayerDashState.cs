using Godot;
using System;

public partial class PlayerDashState : Node
{
    Player characterNode;
    [Export] Timer dashTimerNode;
    public override void _Ready()
    {
        characterNode = GetOwner<Player>();
        SetPhysicsProcess(false);
        dashTimerNode.Timeout += HandleDashTimeout;
    }

    public override void _PhysicsProcess(double delta)
    {

        if (characterNode.direction == Vector2.Zero)
        {
            characterNode.stateMachineNode.SwitchState<PlayerDashState>();
        }
    }

    public override void _Notification(int what)
    {

        base._Notification(what);
        if (what == GameConstants.NODE_ACTIVATE)
        {
            characterNode.animPlayerNode.Play(GameConstants.ANIM_DASH);
            SetPhysicsProcess(true);
            dashTimerNode.Start();
        }
        else if (what == GameConstants.NODE_DEACTIVATE)
        {
            SetPhysicsProcess(false);
        }

    }

    private void HandleDashTimeout()
    {
        characterNode.stateMachineNode.SwitchState<PlayerIdleState>();
    }
}
