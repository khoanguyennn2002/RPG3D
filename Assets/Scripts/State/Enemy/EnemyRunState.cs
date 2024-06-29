using UnityEngine.AI;

public class EnemyRunState : AIState
{
    public EnemyRunState(Enemy enemy, AIStateMachine enemyStateMachine, EnemyData enemyData, NavMeshAgent agent) : base(enemy, enemyStateMachine, enemyData, agent)
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
