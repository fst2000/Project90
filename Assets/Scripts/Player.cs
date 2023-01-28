using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : IHuman, IHumanSize, IHumanMotion
{
    Animator animator;
    IHumanState currentState;
    public IMoveSystem MoveSystem { get; private set;}

    public Player(GameObject gameObject)
    {
        animator = gameObject.GetComponent<Animator>();
        currentState = new WalkState(this);
        MoveSystem = new RigidbodyMoveSystem(gameObject, this, this);
    }
    public void StartAnimation(string state)
    {
        animator.CrossFade(state,0.1f);
    }
    public void OnUpdate()
    {
        IHumanState nextState = currentState.NextState();
        if (currentState != nextState)
        {
            currentState.OnExit();
            currentState = nextState;
            currentState.OnEnter();
        }
        currentState.OnUpdate();
    }

    public float Height => currentState.Size.Height;
    public float Radius => currentState.Size.Radius;
    public float MoveSpeed => currentState.Motion.MoveSpeed;
    public float RotationSpeed => currentState.Motion.RotationSpeed;
}
