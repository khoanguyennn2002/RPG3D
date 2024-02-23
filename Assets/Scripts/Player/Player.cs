using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private PlayerStateMachine StateMachine;
    [SerializeField] private PlayerIdle PlayerIdle;
    [SerializeField] private PlayerMove PlayerMove;
    private void Awake()
    {
        StateMachine = new PlayerStateMachine();
        PlayerIdle = new PlayerIdle(this,StateMachine,"idle");
    }
    void Start()
    {
        StateMachine.Initialize(PlayerIdle);

    }

    // Update is called once per frame
    void Update()
    {
        StateMachine.CurrentState.UpdateLogic();
    }
    private void FixedUpdate()
    {
        StateMachine.CurrentState.UpdatePhysics();
    }
}
