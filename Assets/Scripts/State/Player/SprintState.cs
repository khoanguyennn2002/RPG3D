using UnityEngine;
public class SprintState : PlayerGroundState
{
    WeaponHoldSlot weaponHoldSlot;
    public SprintState(Player player, PlayerStateMachine playerStateMachine) : base(player, playerStateMachine)
    {
    }
    public override void EnterState()
    {
        base.EnterState();
        weaponHoldSlot = player.GetComponentInChildren<WeaponHoldSlot>();
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
        if (weaponHoldSlot.HaveWeapon()&& player.inputHandler.IsSwordDrawn)
        {
            playerStateMachine.ChangeState(player.CombatState);
        }
    }
    public override void UpdatePhysics()
    {
       base.UpdatePhysics();
    }
}
