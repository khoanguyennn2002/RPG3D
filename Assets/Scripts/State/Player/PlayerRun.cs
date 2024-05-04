using UnityEngine;
public class PlayerRun : PlayerGroundState
{
    private float speed = 2f;
    private float animSpeed = 0.8f;
    public PlayerRun(Player player, PlayerStateMachine playerStateMachine) : base(player, playerStateMachine)
    {
    }

    public override void EnterState()
    {
        base.EnterState();
        player.SetVelocity(animSpeed);
        player.Anim.SetBool("isMove", true);
        //Debug.Log("Run State");
    }

    public override void ExitState()
    {
        base.ExitState();
       
    }
    public override void UpdateLogic()
    {
        base.UpdateLogic();
        player.Move(input, speed, pressSprint);
        if(pressSprint)
        {
            playerStateMachine.ChangeState(player.SprintState);
        }
        if(input.magnitude <= 0f)
        {
            playerStateMachine.ChangeState(player.IdleState);
        }
    }

    public override void UpdatePhysics()
    {
        base.UpdatePhysics();
    }
}
