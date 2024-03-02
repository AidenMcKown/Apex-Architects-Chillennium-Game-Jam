using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SprintState : PlayerBaseState
{
    public SprintState(PlayerStateMachine _stateMachine, PlayerStateManager _stateManager) : base(_stateMachine, _stateManager)
    {
        stateMachine = _stateMachine;
        stateManager = _stateManager;
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    public override void Exit()
    {
        base.Exit();
    }
}
