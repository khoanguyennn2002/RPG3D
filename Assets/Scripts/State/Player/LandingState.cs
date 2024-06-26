using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandingState : PlayerGroundState
{
    public LandingState(Player player, PlayerStateMachine playerStateMachine) : base(player, playerStateMachine)
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
    }
    public override void UpdatePhysics()
    {
        base.UpdatePhysics();
    }
}
