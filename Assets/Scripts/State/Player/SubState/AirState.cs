
using UnityEngine;

public class AirState : PlayerState
{
    protected float gravity = -9.81f;
    protected Vector3 movementInput { get; private set; }
    protected bool isSprint { get; private set; }

    public AirState(Player player, PlayerStateMachine playerStateMachine) : base(player, playerStateMachine)
    {
    }
    public override void EnterState()
    {
        base.EnterState();
    }

    public override void ExitState()
    {
        base.ExitState();

    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();
        movementInput = player.inputHandler.MovementInput;
        isSprint = player.inputHandler.IsSprintPressed;
        player.GroundCheck();
        player.HandleGravity(gravity);
    }

    public override void UpdatePhysics()
    {
        base.UpdatePhysics();
  
    }
}
