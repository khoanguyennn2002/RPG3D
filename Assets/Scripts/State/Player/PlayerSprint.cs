using UnityEngine;
public class PlayerSprint : PlayerGroundState
{
    public float speed = 3f;
    private float animSpeed = 1f;
    public PlayerSprint(Player player, PlayerStateMachine playerStateMachine) : base(player, playerStateMachine)
    {
    }
    public override void EnterState()
    {
        base.EnterState();
        player.SetVelocity(animSpeed);
    }
    public override void ExitState()
    {
        base.ExitState();
    }
    public override void UpdateLogic()
    {
        base.UpdateLogic();
        player.Move(input,speed, pressSprint);
        if(!pressSprint)
        {
            playerStateMachine.ChangeState(player.RunState);
        }
    }
    public override void UpdatePhysics()
    {
       base.UpdatePhysics();
    }
}
