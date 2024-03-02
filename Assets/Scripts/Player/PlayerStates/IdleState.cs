using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : PlayerBaseState
{
    public IdleState(PlayerStateMachine _stateMachine, PlayerStateManager _stateManager) : base(_stateMachine, _stateManager)
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

        if (InputManager.MovementInput != Vector2.zero)
        {
            if (InputManager.SprintInput)
            {
                // Switch to sprint state
                stateMachine.ChangeState(stateManager.sprintState);
                return;
            }
            // Switch to run state
            stateMachine.ChangeState(stateManager.runState);
            return;
        }
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
