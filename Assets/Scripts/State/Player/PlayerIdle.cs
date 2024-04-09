using UnityEngine;
public class PlayerIdle : PlayerGroundState
{
    public PlayerIdle(Player player, PlayerStateMachine playerStateMachine) : base(player, playerStateMachine)
    {
    }
    public override void EnterState()
    {
        base.EnterState();
        player.Anim.SetBool("isMove", false);
       // Debug.Log("Idle State");
    }
    public override void ExitState()
    {
        base.ExitState();
    }
    public override void UpdateLogic()
    {
        base.UpdateLogic();
     
        if (input.magnitude != 0f)
        {
            playerStateMachine.ChangeState(player.RunState);
        }
    }
    public override void UpdatePhysics()
    {
        base.UpdatePhysics();
    }
}
