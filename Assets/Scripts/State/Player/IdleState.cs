using UnityEngine;
public class IdleState : PlayerGroundState
{
    WeaponHoldSlot weapon;
    public IdleState(Player player, PlayerStateMachine playerStateMachine) : base(player, playerStateMachine)
    {
    }
    public override void EnterState()
    {
        base.EnterState();
        weapon = player.GetComponentInChildren<WeaponHoldSlot>();
        player.Anim.SetTrigger("StateOn");
        player.Anim.SetInteger("State", (int)State.Move);
        //Debug.Log("Idle State");
    }
    public override void ExitState()
    {
        base.ExitState();
    }
    public override void UpdateLogic()
    {
        base.UpdateLogic();
        if (movementInput.magnitude != 0f)
        {
            playerStateMachine.ChangeState(player.RunState);
        }
        if (weapon.HaveWeapon() && player.inputHandler.IsSwordDrawn)
        {
            playerStateMachine.ChangeState(player.CombatState);
        }
    }
    public override void UpdatePhysics()
    {
        base.UpdatePhysics();
    }
}