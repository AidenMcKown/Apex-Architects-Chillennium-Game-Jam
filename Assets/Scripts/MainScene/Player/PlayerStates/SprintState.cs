using UnityEngine;

public class SprintState : PlayerBaseState
{
    private float footstepTimer;

    public SprintState(PlayerStateMachine _stateMachine, PlayerStateManager _stateManager) : base(_stateMachine, _stateManager)
    {
        stateMachine = _stateMachine;
        stateManager = _stateManager;
    }

    public override void Enter()
    {
        base.Enter();
        targetAnimationVelocity = 1f;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (InputManager.SprintInput == false)
        {
            if (InputManager.MovementInput == Vector2.zero)
            {
                // Switch to idle state
                stateMachine.ChangeState(stateManager.idleState);
                return;
            }
            // Switch to run state
            stateMachine.ChangeState(stateManager.runState);
            return;
        }

        footstepTimer += Time.deltaTime;
        if (footstepTimer >= stateManager.sprintFootstepInterval)
        {
            footstepTimer = 0;
            PlayFootstepSound();
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();

        Vector3 movementVector = new Vector3(InputManager.MovementInput.x, 0, InputManager.MovementInput.y);

        stateManager.rb.AddForce(stateManager.sprintSpeed * Time.fixedDeltaTime * movementVector);
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
