using Godot;
using System;

public partial class PlayerIdleState : Node
{
    public override void _Ready()
    {
        Player characterNode;
        characterNode = GetOwner<Player>();
        characterNode.animPlayerNode.Play(GameConstants.ANIM_IDLE);
    }
}
