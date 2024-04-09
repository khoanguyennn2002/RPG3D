using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

public class AirState : PlayerState
{
    protected float gravity = -9.81f;
    protected Vector3 input { get; private set; }
    protected bool isSprint { get; private set; }

    public AirState(Player player, PlayerStateMachine playerStateMachine) : base(player, playerStateMachine)
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
        player.GroundCheck();
        player.HandleGravity(gravity);
       
    }

    public override void UpdatePhysics()
    {
        base.UpdatePhysics();
    }
}
