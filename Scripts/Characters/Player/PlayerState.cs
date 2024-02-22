using Godot;

public partial class PlayerState : Node
{

    protected Player player;
    public override void _Ready()
    {
        player = GetOwner<Player>();
        SetPhysicsProcess(false);
        SetProcessInput(true);
    }

    public override void _Notification(int what)
    {
        base._Notification(what);
        if (what == GameConstants.NODE_DEACTIVATE)
        {
            SetPhysicsProcess(false);
            SetProcessInput(false);
        }
        else if (what == GameConstants.NODE_ACTIVATE)
        {
            EnterState();
            SetPhysicsProcess(true);
            SetProcessInput(true);
        }
    }

    protected virtual void EnterState()
    {

    }

}