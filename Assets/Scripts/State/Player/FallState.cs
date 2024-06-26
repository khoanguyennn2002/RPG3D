
public class FallState : AirState
{
    public FallState(Player player, PlayerStateMachine playerStateMachine) : base(player, playerStateMachine)
    {
    }
    public override void EnterState()
    {
        base.EnterState();
        player.Anim.SetTrigger("StateOn");
        player.Anim.SetInteger("State", (int)State.Fall);
    }
    public override void ExitState()
    {
        base.ExitState();
    }
    public override void UpdateLogic()
    {
        base.UpdateLogic();
        player.MoveInAir(movementInput);
        if(player.GroundCheck())
        {
            if(movementInput.magnitude >= 0.01f)
            {
                playerStateMachine.ChangeState(player.RunState);
            }
            else
            {
                playerStateMachine.ChangeState(player.IdleState);
            }
        }
    }
    public override void UpdatePhysics()
    {
        base.UpdatePhysics();
    }
}
