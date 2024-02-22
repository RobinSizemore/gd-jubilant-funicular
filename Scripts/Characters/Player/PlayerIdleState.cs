using Godot;
using System;

public partial class PlayerIdleState : PlayerState
{

    public override void _PhysicsProcess(double delta)
    {

        if (player.direction != Vector2.Zero)
        {
            // GD.Print("Switching to Move...");
            player.stateMachineNode.SwitchState<PlayerMoveState>();
        };

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
        // GD.Print("PlayerIdleState");
        player.animPlayerNode.Play(GameConstants.ANIM_IDLE);
    }
}
