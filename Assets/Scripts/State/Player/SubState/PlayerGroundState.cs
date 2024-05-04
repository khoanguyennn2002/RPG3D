using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundState : PlayerState
{
    private bool isJumping = false;
    protected Vector3 input { get; private set; }
    protected bool pressSprint { get; private set; }
    protected float jumpButtonPressedTime { get; private set; }
    protected float lastGroundedTime { get; private set; }
    private float jumpCooldown = 0.2f;

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
        pressSprint = player.input.isShiftPressed;
        jumpButtonPressedTime = player.input.jumpButtonPressedTime;
        player.GroundCheck();
        if(player.GroundCheck())
        {
            lastGroundedTime = Time.time;
        }

        if (/*input.sqrMagnitude <= 0.01f*/ input.magnitude < 0.5f)
        {
            player.Anim.SetFloat("Vertical", 0, 0.2f, Time.deltaTime);
        }
        if (Time.time - lastGroundedTime <= jumpCooldown)
        {
            if (Time.time - jumpButtonPressedTime <= jumpCooldown)
            {
                jumpButtonPressedTime = Time.time;
                playerStateMachine.ChangeState(player.JumpState);
            }
        }
    }

    public override void UpdatePhysics()
    {
        base.UpdatePhysics();
    }
}
