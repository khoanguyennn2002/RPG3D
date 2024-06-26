using UnityEngine;
public class SprintState : PlayerGroundState
{
    public SprintState(Player player, PlayerStateMachine playerStateMachine) : base(player, playerStateMachine)
    {
    }
    public override void EnterState()
    {
        base.EnterState();
        player.Anim.SetInteger("State", (int)State.Move);
    }
    public override void ExitState()
    {
        base.ExitState();
    }
    public override void UpdateLogic()
    {
        base.UpdateLogic();
        player.Move(movementInput);
        if(!isSprintPressed)
        {
            playerStateMachine.ChangeState(player.RunState);
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
