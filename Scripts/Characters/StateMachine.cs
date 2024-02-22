using Godot;
using System;

public partial class StateMachine : Node
{
    [Export] private Node currentState;
    [Export] private Node[] states;

    public override void _Ready()
    {
        currentState.Notification(5001);
    }

    public void SwitchState<T>()
    {
        foreach (Node state in states)
        {
            if (state is T)
            {
                // GD.Print("Canceling Current State of " + currentState.Name);
                currentState.Notification(GameConstants.NODE_DEACTIVATE);
                currentState = state;
                // GD.Print("Activating New State of " + currentState.Name);
                currentState.Notification(GameConstants.NODE_ACTIVATE);
                return;
            }
        }
    }

}
