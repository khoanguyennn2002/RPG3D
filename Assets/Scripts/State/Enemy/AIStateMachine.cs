

public class AIStateMachine 
{
    public AIState CurrentState { get; private set; }
    public void Initialize(AIState startState)
    {
        CurrentState = startState;
        CurrentState.EnterState();
    }
    public void ChangeState(AIState newState)
    {
        CurrentState.ExitState();
        CurrentState = newState;
        CurrentState.EnterState();
    }
}
