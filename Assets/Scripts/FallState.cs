using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallState : IState
{
    IHuman human;
    public FallState(IHuman human)
    {
        this.human = human;
    }
    public void OnEnter()
    {
        human.StartAnimation("Fall");
    }
    public void OnUpdate()
    {

    }
    public void OnFixedUpdate()
    {

    }
    public void OnExit()
    {

    }
    public IState NextState()
    {
        return this;
    }
}
