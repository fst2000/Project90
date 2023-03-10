using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : IHuman, IHumanSize, IHumanMotion
{
    Animator animator;
    IHumanState currentState;
    Event<IFixedUpdateHandler> fixedUpdateEvent = new Event<IFixedUpdateHandler>(subscriber => subscriber.FixedUpdate());
    Event<IUpdateHandler> updateHandler = new Event<IUpdateHandler>(subscriber => subscriber.Update());
    public IMoveSystem MoveSystem { get; private set;}
    public IController Controller{get; private set;}

    public Player(GameObject gameObject)
    {
        animator = gameObject.GetComponent<Animator>();
        currentState = new WalkState(this);
        MoveSystem = new RigidbodyMoveSystem(gameObject, this, this,fixedUpdateEvent);
        Controller = new PlayerController();
    }
    public void StartAnimation(string state)
    {
        animator.CrossFade(state,0.1f);
    }
    public void OnUpdate()
    {
        updateHandler.Call();
        IHumanState nextState = currentState.NextState();
        if (currentState != nextState)
        {
            currentState.OnExit();
            currentState = nextState;
            currentState.OnEnter();
        }
        currentState.OnUpdate();
    }
    public void OnFixedUpdate()
    {
        fixedUpdateEvent.Call();
    }

    public float Height => currentState.Size.Height;
    public float Radius => currentState.Size.Radius;
    public float MoveSpeed => currentState.Motion.MoveSpeed;
    public float RotationSpeed => currentState.Motion.RotationSpeed;
}
