using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundState : PlayerState
{
    protected Vector3 input { get; private set; }
    protected bool isSprint { get; private set; }
    protected bool canJump { get; private set; }
    public PlayerGroundState(Player player, PlayerStateMachine playerStateMachine) : base(player, playerStateMachine)
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
        input = player.input.MoveInput;
        isSprint = player.input.isShiftPressed;
        canJump = player.input.isJumpPressed;
        player.GroundCheck();
       
        if (/*input.sqrMagnitude <= 0.01f*/ input.magnitude < 0.5f)
        {
            player.Anim.SetFloat("Vertical", 0, 0.2f, Time.deltaTime);
        }
        if (canJump)
        {
            playerStateMachine.ChangeState(player.JumpState);
        }
        player.GetVelocityY();
    }

    public override void UpdatePhysics()
    {
        base.UpdatePhysics();
    }
}
