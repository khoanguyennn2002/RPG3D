
using UnityEngine;

public class PlayerWalk : PlayerGroundState
{
    private float speed = 1f;
    private float animSpeed = 0.5f;
    public PlayerWalk(Player player, PlayerStateMachine playerStateMachine) : base(player, playerStateMachine)
    {
    }
    public override void EnterState()
    {
        base.EnterState();
        player.SetVelocity(speed);
    }

    public override void ExitState()
    {
        base.ExitState();
        
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();
        player.Move(input,speed,isSprint);
    }

    public override void UpdatePhysics()
    {
        base.UpdatePhysics();
    }
}
