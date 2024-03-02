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
    public PlayerStateMachine stateMachine;

    [Header("States")]
    public IdleState idleState;
    public RunState runState;
    public SprintState sprintState;

    [Header("Suspension Settings")]
    [SerializeField] public float springStrength = 5000f;
    [SerializeField] public float springDamper = 40f;
    [SerializeField] public float suspensionRestDistance = .8f;

    [Header("Movement Settings")]
    [SerializeField] public float runSpeed = 5f;
    [SerializeField] public float sprintSpeed = 10f;

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
