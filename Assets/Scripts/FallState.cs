using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallState : IHumanState
{
    IHuman human;

    public IHumanSize Size => throw new System.NotImplementedException();

    public IHumanMotion Motion => throw new System.NotImplementedException();

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
    public IHumanState NextState()
    {
        return this;
    }
}
