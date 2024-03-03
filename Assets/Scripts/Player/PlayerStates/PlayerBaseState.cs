using UnityEngine;
using Helper;

public class PlayerBaseState
{
    protected PlayerStateMachine stateMachine;
    protected PlayerStateManager stateManager;
    protected float currentAnimationVelocity, targetAnimationVelocity, animationRefVelocity;

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
        RotateTowardsMovementDirection();

        currentAnimationVelocity = Mathf.SmoothDamp(currentAnimationVelocity, targetAnimationVelocity, ref animationRefVelocity, stateManager.animationSmoothTime);
        stateManager.playerAnimator.SetFloat("Velocity", currentAnimationVelocity);
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

    private void RotateTowardsMovementDirection()
    {
        if (InputManager.MovementInput != Vector2.zero)
        {
            // Slerp rotation towards movement direction
            Quaternion targetRotation = Quaternion.LookRotation(new Vector3(InputManager.MovementInput.x, 0, InputManager.MovementInput.y));
            stateManager.playerOrientation.localRotation = Quaternion.Slerp(stateManager.playerOrientation.localRotation, targetRotation, Time.deltaTime * 15f);
        }
    }
}
