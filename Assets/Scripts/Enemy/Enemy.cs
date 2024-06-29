using System;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField] private EnemyData enemyData;
    #region State
    public AIStateMachine StateMachine { get; private set; }
    public EnemyIdleState EnemyIdle { get; private set; }

    public EnemyWalkState EnemyWalk { get; private set; }

    public EnemyRunState EnemyRun { get; private set; }
    #endregion

    private int health;
    public int Health
    {
        get { return health; }
        set { health = value; }
    }
    private int level;

    public int Level { get { return level; } set
        {
            level = value;
        }}
    public Animator animator { get; private set; }

    public NavMeshAgent agent { get; private set; }
    public Vector3 spawnPosition { get;  private set; }
    public float areaRadius { get; private set; }
    public float areaHeigth { get; private set; }

    public Action UpdateHealth;
    private void Awake()
    {
    animator = GetComponent<Animator>();
    agent = GetComponent<NavMeshAgent>();
    StateMachine = new AIStateMachine();
    EnemyIdle = new EnemyIdleState(this, StateMachine, enemyData, agent);
    EnemyWalk = new EnemyWalkState(this, StateMachine, enemyData, agent);
    EnemyRun = new EnemyRunState(this, StateMachine, enemyData, agent);
    StateMachine.Initialize(EnemyIdle);
    spawnPosition = transform.position;
    SetProfile();
    }
    private void Update()
    {
        StateMachine.CurrentState.UpdateLogic();
    }
    private void FixedUpdate()
    {
        StateMachine.CurrentState.UpdatePhysics();
    }

    public void SetSpawnPosition(Vector3 spawPos)
    {
        spawnPosition = spawPos;
    }
    public void SetRadiusHeigth(float radius, float heigth)
    {
        areaRadius = radius;
        areaHeigth = heigth;
    }

    public void SetProfile()
    {
        Level = UnityEngine.Random.Range(enemyData.minLevel,enemyData.maxlevel + 1);
        Health = enemyData.baseHealth + (10 * Level);
    }    
    public void TakeDamage(int dame)
    {
        Health -= dame;

        UpdateHealth.Invoke();
        if (Health <= 0)
        {
            Die();
        }
    }

    public void Die()
    {

    }
}
