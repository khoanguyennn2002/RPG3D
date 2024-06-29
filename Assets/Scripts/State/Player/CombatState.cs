using UnityEngine;

public class CombatState : PlayerGroundState
{
    private float animSpeed = 0.7f;
    public CombatState(Player player, PlayerStateMachine playerStateMachine) : base(player, playerStateMachine)
    {
    }
    public override void EnterState()
    {
        base.EnterState();
        player.SetVelocity(animSpeed);
    }
    public override void ExitState()
    {
        base.ExitState();
        player.SetVelocity(1);
    }
    public override void UpdateLogic()
    {
        base.UpdateLogic();
        HandleCombatMovement();
        player.Move(movementInput);
        if (!player.inputHandler.IsSwordDrawn)
        {
            if(movementInput.magnitude >= 0.01f)
            {
                playerStateMachine.ChangeState(player.RunState);
            }
            else
            {
                playerStateMachine.ChangeState(player.IdleState);
            }
        }
    }
    public override void UpdatePhysics()
    {
        base.UpdatePhysics();
    }
    private void HandleCombatMovement()
    {
        bool isMoving = movementInput.magnitude >= 0.01f;
        bool isSwordDrawn = player.inputHandler.IsSwordDrawn;

        if (isMoving && isSwordDrawn)
        {
            if (player.Anim.GetInteger("State") != (int)State.Move)
            {
                player.Anim.SetTrigger("StateOn");
                player.Anim.SetInteger("State", (int)State.Move);
            }
        }
    }
}
