
using UnityEngine;

public class WalkState : PlayerGroundState
{
    private float animSpeed = 1f;
    WeaponHoldSlot weapon;
    public WalkState(Player player, PlayerStateMachine playerStateMachine) : base(player, playerStateMachine)
    {
    }
    public override void EnterState()
    {
        base.EnterState();
        weapon = player.GetComponentInChildren<WeaponHoldSlot>();
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
