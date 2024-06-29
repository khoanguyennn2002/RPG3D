
using UnityEngine;
using UnityEngine.AI;

public abstract class AIState 
{
    protected Enemy enemy;
    protected AIStateMachine enemyStateMachine;
    protected EnemyData enemyData;
    protected NavMeshAgent agent;

    protected float timer;
    public AIState(Enemy enemy, AIStateMachine enemyStateMachine, EnemyData enemyData, NavMeshAgent agent)
    {
        this.enemy = enemy;
        this.enemyStateMachine = enemyStateMachine;
        this.enemyData = enemyData;
        this.agent = agent;
    }

    public virtual void EnterState() { timer = Time.time; }

    public virtual void ExitState() { }


    public virtual void UpdateLogic() { }
    public virtual void UpdatePhysics() { }
}
