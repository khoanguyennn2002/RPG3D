

using UnityEngine;
using UnityEngine.AI;

public class EnemyIdleState : AIState
{
    public EnemyIdleState(Enemy enemy, AIStateMachine enemyStateMachine, EnemyData enemyData, NavMeshAgent agent) : base(enemy, enemyStateMachine, enemyData, agent)
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
        timer += Time.deltaTime;
        if(timer > 5)
        {
            enemy.StateMachine.ChangeState(enemy.EnemyWalk);
        }    
    }

    public override void UpdatePhysics()
    {
        base.UpdatePhysics();
    }
}
