using System.Collections.Generic;
using UnityEngine;

public class PlayerStateManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField] public Rigidbody rb;
    [SerializeField] public LayerMask groundLayer;
    [SerializeField] public Transform playerOrientation;
    [SerializeField] public Transform feetTransform;
    [SerializeField] public AudioSource footstepAudioSource;
    [SerializeField] public List<AudioClip> footstepSounds;
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
    [SerializeField] public float runFootstepInterval = 0.5f;
    [SerializeField] public float sprintFootstepInterval = 0.3f;

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
