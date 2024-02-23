using Godot;
using System;

public partial class PlayerDashState : PlayerState
{
    [Export] private Timer dashTimerNode;
    [Export(PropertyHint.Range, "0,20")] private float dashSpeed = 10.0f;

    public override void _Ready()
    {
        base._Ready();
        dashTimerNode.Timeout += HandleDashTimeout;
    }

    protected override void EnterState()
    {
        // GD.Print("PlayerDashState");
        player.AnimPlayerNode.Play(GameConstants.ANIM_DASH);
        player.Velocity = new(player.direction.X, 0, player.direction.Y);
        if (player.Velocity == Vector3.Zero)
        {
            player.Velocity = (player.Sprite3DNode.FlipH ? Vector3.Left : Vector3.Right);
        }
        player.Velocity *= dashSpeed;
        dashTimerNode.Start();
    }

    public override void _PhysicsProcess(double delta)
    {

        player.MoveAndSlide();
        player.Flip();


    }

    private void HandleDashTimeout()
    {
        SetPhysicsProcess(false);
        player.Velocity = Vector3.Zero;
        // GD.Print("Switching to Idle...");
        player.StateMachineNode.SwitchState<PlayerIdleState>();
    }
}
