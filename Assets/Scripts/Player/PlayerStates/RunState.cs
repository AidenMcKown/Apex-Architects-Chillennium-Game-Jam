using System.Collections;
using System.Collections.Generic;
using UnityEditor.Callbacks;
using UnityEngine;

public class RunState : PlayerBaseState
{
    public RunState(PlayerStateMachine _stateMachine, PlayerStateManager _stateManager) : base(_stateMachine, _stateManager)
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

        if (InputManager.MovementInput == Vector2.zero)
        {
            // Switch to idle state
            stateMachine.ChangeState(stateManager.idleState);
            return;
        }

        if (InputManager.SprintInput)
        {
            // Switch to sprint state
            stateMachine.ChangeState(stateManager.sprintState);
            return;
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();

        Vector3 movementVector = new Vector3(InputManager.MovementInput.x, 0, InputManager.MovementInput.y);

        stateManager.rb.AddForce(stateManager.runSpeed * Time.fixedDeltaTime * movementVector);
    }

    public override void Exit()
    {
        base.Exit();
    }
}
