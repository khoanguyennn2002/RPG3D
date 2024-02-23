
public class PlayerState 
{
    protected Player player;
    protected PlayerStateMachine playerStateMachine;

    private string animName;

   public PlayerState(Player player, PlayerStateMachine playerStateMachine, string animName)
    {
        this.player = player;
        this.playerStateMachine = playerStateMachine;
        this.animName = animName;
    }

    public virtual void EnterState()
    {
        // player.Anim.SetBool(animName, true);
        // Debug.Log(animName);
    }
    public virtual void ExitState()
    {
        //player.Anim.SetBool(animName, false);
    }
    public virtual void UpdateLogic() { }
    public virtual void UpdatePhysics() { }
}
