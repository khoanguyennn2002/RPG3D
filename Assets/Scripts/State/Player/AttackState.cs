using UnityEngine;

public class AttackState : PlayerGroundState
{
    private float comboTimeout = 0.8f;
    private float lastComboTime;
    private int currentCombo = 0;
    private int maxComboCount = 3;
    private bool isAttack;

    private CharacterStatsManager statsManager;
    public AttackState(Player player, PlayerStateMachine playerStateMachine) : base(player, playerStateMachine)
    {

    }

    public override void EnterState()
    {
        base.EnterState();
        statsManager = GameManager.Instance.statsManager;
        Attack();
    }

    public override void ExitState()
    {
        base.ExitState();
        player.Anim.SetInteger("Mode", 0);
        currentCombo = 0;
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();
        if (Time.time > lastComboTime + comboTimeout && !isAttack)
        {
            if(!player.HaveWeapon())
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
            else
            {
                playerStateMachine.ChangeState(player.CombatState);
            }
        }
        else if (player.inputHandler.IsCombatInput && !isAttack)
        {
            Attack();
        }
        //if(Time.time > lastComboTime + 0.45f)
        //{
        //    player.inputHandler.IsCombatInput = false;
        //}    
    }

    public override void UpdatePhysics()
    {
        base.UpdatePhysics();
    }

    private void Attack()
    {
        if (isAttack && !player.inputHandler.IsCombatInput)
        {
            return;
        }
        lastComboTime = Time.time;
        isAttack = true;
        player.inputHandler.IsCombatInput = false;
        switch (currentCombo)
        {
            case 0:
                player.Anim.SetInteger("Mode", (int)Mode.PunchRight);
                break;
            case 1:
                player.Anim.SetInteger("Mode", (int)Mode.PunchLeft);
                break;
            case 2:
                player.Anim.SetInteger("Mode", (int)Mode.Kick);
                break;
        }
        player.Anim.SetTrigger("ModeOn");
        currentCombo++;

        if (currentCombo >= maxComboCount)
        {
            currentCombo = 0;
        }
    }
    public void FinishAttack()
    {
        isAttack = false;
    }
}
