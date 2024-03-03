using System.Collections;
using UnityEngine;

public class RunState : PlayerBaseState
{
    private float footstepTimer;

    public RunState(PlayerStateMachine _stateMachine, PlayerStateManager _stateManager) : base(_stateMachine, _stateManager)
    {
        stateMachine = _stateMachine;
        stateManager = _stateManager;
    }

    public override void Enter()
    {
        base.Enter();
        targetAnimationVelocity = 0.5f;
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

        footstepTimer += Time.deltaTime;
        if (footstepTimer >= stateManager.runFootstepInterval)
        {
            footstepTimer = 0;
            PlayFootstepSound();
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

    private void PlayFootstepSound()
    {
        stateManager.footstepAudioSource.PlayOneShot(stateManager.footstepSounds[Random.Range(0, stateManager.footstepSounds.Count)]);
    }
}
