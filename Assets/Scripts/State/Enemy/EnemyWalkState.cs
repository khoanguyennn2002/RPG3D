using UnityEditor.TextCore.Text;
using UnityEngine;
using UnityEngine.AI;

public class EnemyWalkState : AIState
{
    private Vector3 targetPosition;
    private float waitTime;
    private bool isWalk = true;

    public EnemyWalkState(Enemy enemy, AIStateMachine enemyStateMachine, EnemyData enemyData, NavMeshAgent agent)
        : base(enemy, enemyStateMachine, enemyData, agent)
    {
    }

    public override void EnterState()
    {
        base.EnterState();
        SetRandomTargetPosition();
        waitTime = 0f;
        agent.isStopped = false;
   

    }
public override void ExitState()
    {
        base.ExitState();
        isWalk = false;
        enemy.animator.SetBool("isWalking", !isWalk);
        enemy.animator.SetFloat("Movement", 0);
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();

        // Example transition to another state if conditions are met
        // For instance, if the enemy sees the player, switch to chase state
        // if (enemy.CanSeePlayer())
        // {
        //     stateMachine.ChangeState(enemy.ChaseState);
        // }

        // Check if we need to set a new target position
        if (waitTime > 0f)
        {
            waitTime -= Time.deltaTime;
            if (waitTime <= 0f)
            {
                agent.isStopped = false;
                SetRandomTargetPosition();
            }
        }
      else if (agent.remainingDistance <= agent.stoppingDistance)
        {
            agent.isStopped = true;
            enemy.animator.SetBool("isWalking", !isWalk);
            enemy.animator.SetFloat("Movement", 0);
            waitTime = Random.Range(3, 10);
        }
        else
        {
            agent.isStopped = false;
        }

    }

    private void SetRandomTargetPosition()
    {
        // Generate a random direction within the walk radius
        Vector3 randomDirection = Random.insideUnitSphere * enemy.areaRadius;
        randomDirection += enemy.spawnPosition;
        randomDirection = enemy.spawnPosition + Vector3.ClampMagnitude(randomDirection - enemy.spawnPosition, enemy.areaRadius);

        // Sample for a valid NavMesh position
        NavMeshHit hit;
        if (NavMesh.SamplePosition(randomDirection, out hit, 
            enemy.areaRadius, NavMesh.AllAreas))
        {
            targetPosition = hit.position;
            agent.SetDestination(targetPosition);
            enemy.animator.SetFloat("Movement", 1);
            enemy.animator.SetBool("isWalking", isWalk);
   
        }
        else
        {
            Debug.LogWarning("Failed to find a valid NavMesh position for the enemy.");
        }
    }

}
