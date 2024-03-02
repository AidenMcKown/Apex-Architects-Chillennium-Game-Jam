using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Helper;

public class PlayerBaseState
{
    protected PlayerStateMachine stateMachine;
    protected PlayerStateManager stateManager;

    public PlayerBaseState(PlayerStateMachine _stateMachine, PlayerStateManager _stateManager)
    {
        stateMachine = _stateMachine;
        stateManager = _stateManager;
    }

    public virtual void Enter()
    {
        string stateName = this.ToString();
        Debug.Log("Entering " + stateName);
    }

    public virtual void LogicUpdate()
    {

    }

    public virtual void PhysicsUpdate()
    {
        if (Physics.Raycast(stateManager.feetTransform.position, -stateManager.transform.up, out RaycastHit hit, stateManager.suspensionRestDistance, stateManager.groundLayer))
        {
            Suspension.ApplySuspensionForce(stateManager.rb, hit, stateManager.springStrength, stateManager.springDamper, stateManager.suspensionRestDistance);
        }
    }

    public virtual void Exit()
    {

    }
}
