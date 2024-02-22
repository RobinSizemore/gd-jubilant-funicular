using Godot;
using System;

public partial class PlayerDashState : Node
{
    private Player characterNode;
    [Export] private Timer dashTimerNode;
    [Export] private float dashSpeed = 10.0f;


    public override void _Ready()
    {
        characterNode = GetOwner<Player>();
        dashTimerNode.Timeout += HandleDashTimeout;
        SetPhysicsProcess(false);
    }

    public override void _PhysicsProcess(double delta)
    {

        characterNode.MoveAndSlide();
        characterNode.Flip();


    }

    public override void _Notification(int what)
    {
        base._Notification(what);

        if (what == 5001)
        {
            SetPhysicsProcess(true);
            characterNode.animPlayerNode.Play(GameConstants.ANIM_DASH);
            characterNode.Velocity = new Vector3(characterNode.direction.X, 0, characterNode.direction.Y).Normalized() * dashSpeed;
            if (characterNode.Velocity == Vector3.Zero)
            {
                characterNode.Velocity = (characterNode.sprite3DNode.FlipH ? Vector3.Left : Vector3.Right) * dashSpeed;
            }
            dashTimerNode.Start();
        }
    }

    private void HandleDashTimeout()
    {
        SetPhysicsProcess(false);
        characterNode.Velocity = Vector3.Zero;
        characterNode.stateMachineNode.SwitchState<PlayerIdleState>();
    }
}
