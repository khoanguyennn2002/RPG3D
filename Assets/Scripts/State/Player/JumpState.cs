using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpState : AirState
{
    private float jumpForce = 1.5f;
    public JumpState(Player player, PlayerStateMachine playerStateMachine) : base(player, playerStateMachine)
    {
    }
    public override void EnterState()
    {
        base.EnterState();
        player.Anim.SetBool("isMove",false);
        player.Jump(jumpForce, gravity);
    }
    public override void ExitState()
    {
        base.ExitState();
    }
    public override void UpdateLogic()
    {
        base.UpdateLogic();
        player.MoveInAir(input);
        if (!player.GroundCheck() && player.GetVelocityY() <= 0)
        {
          playerStateMachine.ChangeState(player.FallState);
        }
    }
    public override void UpdatePhysics()
    {
        base.UpdatePhysics();
    }
}
