using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallState : AirState
{
    public FallState(Player player, PlayerStateMachine playerStateMachine) : base(player, playerStateMachine)
    {
    }
    public override void EnterState()
    {
        base.EnterState();
        player.Anim.SetBool("isFall",true);
    }
    public override void ExitState()
    {
        base.ExitState();
        player.Anim.SetBool("isFall", false);
    }
    public override void UpdateLogic()
    {
        base.UpdateLogic();
        player.MoveInAir(input);
        if (player.GroundCheck() && !player.Anim.GetBool("isMove"))
        {
            playerStateMachine.ChangeState(player.IdleState);
        }
        else if(player.GroundCheck() && player.Anim.GetBool("isMove"))
        {
            playerStateMachine.ChangeState(player.RunState);
        }
    }
    public override void UpdatePhysics()
    {
        base.UpdatePhysics();
    }
}
