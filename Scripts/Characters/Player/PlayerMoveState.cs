using Godot;
using System;

public partial class PlayerMoveState : PlayerState
{

    public override void _PhysicsProcess(double delta)
    {

        if (player.direction == Vector2.Zero)
        {
            // GD.Print("Switching to Idle...");
            player.stateMachineNode.SwitchState<PlayerIdleState>();
            return;
        }

        player.Velocity = new Vector3(player.direction.X, 0, player.direction.Y).Normalized() * player.Speed;
        player.MoveAndSlide();
        player.Flip();

    }

    public override void _Input(InputEvent @event)
    {
        if (Input.IsActionJustPressed(GameConstants.INPUT_DASH))
        {
            // GD.Print("Switching to Dash...");
            player.stateMachineNode.SwitchState<PlayerDashState>();
        }
    }

    protected override void EnterState()
    {
        // GD.Print("PlayerMoveState");
        player.animPlayerNode.Play(GameConstants.ANIM_MOVE);
    }
}
