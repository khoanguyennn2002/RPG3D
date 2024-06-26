using UnityEngine;
public class RunState : PlayerGroundState
{
    private float animSpeed = 0.7f;
    public RunState(Player player, PlayerStateMachine playerStateMachine) : base(player, playerStateMachine)
    {
    }
    public override void EnterState()
    {
        base.EnterState();
        player.SetVelocity(animSpeed);
        if (player.Anim.GetInteger("State") != 1)
        {
            player.Anim.SetTrigger("StateOn");
            player.Anim.SetInteger("State", (int)State.Move);
        }
    }
    public override void ExitState()
    {
        base.ExitState();
        player.SetVelocity(1);
    }
    public override void UpdateLogic()
    {
        base.UpdateLogic();
        player.Move(movementInput);
      
        if(isSprintPressed)
        {
            playerStateMachine.ChangeState(player.SprintState);
        }
        if (player.Anim.GetFloat("Vertical") == 0f)
        {
            playerStateMachine.ChangeState(player.IdleState);
        }
        if (player.HaveWeapon() && player.inputHandler.IsSwordDrawn)
        {
            playerStateMachine.ChangeState(player.CombatState);
        }
    }

    public override void UpdatePhysics()
    {
        base.UpdatePhysics();
    }
}
