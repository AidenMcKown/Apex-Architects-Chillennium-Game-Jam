using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerStateManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField] public Rigidbody rb;
    [SerializeField] public LayerMask groundLayer;
    [SerializeField] public Transform playerOrientation;
    [SerializeField] public Transform feetTransform;
    private PlayerStateMachine stateMachine;

    [Header("States")]
    private IdleState idleState;
    private RunState runState;
    private SprintState sprintState;

    [Header("Suspension Settings")]
    [SerializeField] public float springStrength = 5000f;
    [SerializeField] public float springDamper = 40f;
    [SerializeField] public float suspensionRestDistance = .8f;

    void Start()
    {
        stateMachine = new PlayerStateMachine();
        idleState = new IdleState(stateMachine, this);
        runState = new RunState(stateMachine, this);
        sprintState = new SprintState(stateMachine, this);

        stateMachine.Initialize(idleState);
    }

    void Update()
    {
        stateMachine.CurrentState.LogicUpdate();
    }

    void FixedUpdate()
    {
        stateMachine.CurrentState.PhysicsUpdate();
    }
}
