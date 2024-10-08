using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerState : MonoBehaviour
{
    protected PlayerStateMachine stateMachine;
    protected PlayerController playerController;

    public PlayerState(PlayerStateMachine stateMachine)
    {
        this.stateMachine = stateMachine;
        this.playerController = stateMachine.PlayerController;
    }

    public virtual void Enter() { }
    public virtual void Exit() { }
    public virtual void Update() { }
    public virtual void FixedUpdate() { }

    protected void CheckTransitions()
    {
        if(playerController.isGrounded())
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                stateMachine.TransitionToState(new JumpingState(stateMachine));
            }
            else if(Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
            {
                stateMachine.TransitionToState(new MovingState(stateMachine));
            }
            else
            {
                stateMachine.TransitionToState(new IdleState(stateMachine));
            }
        }
        else
        {
            if(playerController.GetVerticalVelocity() > 0)
            {
                stateMachine.TransitionToState(new JumpingState(stateMachine));
            }
            else
            {
                stateMachine.TransitionToState(new FallingState(stateMachine));
            }
        }
    }
}

public class IdleState : PlayerState
{
    public IdleState(PlayerStateMachine stateMachine) : base(stateMachine) { }

    public override void Update()
    {
        CheckTransitions();
    }
}

public class MovingState : PlayerState
{
    public MovingState(PlayerStateMachine stateMachine) : base(stateMachine) { }

    public override void Update()
    {
        CheckTransitions();
    }

    public override void FixedUpdate()
    {
        playerController.HandleMovement();
    }
}

public class JumpingState : PlayerState
{
    public JumpingState(PlayerStateMachine stateMachine) : base(stateMachine) { }

    public override void Update()
    {
        CheckTransitions();
    }

    public override void FixedUpdate()
    {
        playerController.HandleMovement();
    }
}

public class FallingState : PlayerState
{
    public FallingState(PlayerStateMachine stateMachine) : base(stateMachine) { }

    public override void Update()
    {
        CheckTransitions();
    }

    public override void FixedUpdate()
    {
        playerController.HandleMovement();
    }
}
