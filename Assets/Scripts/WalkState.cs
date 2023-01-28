using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkState : IHumanState
{
    IHuman human;
    public IHumanSize Size{get; private set;}
    public IHumanMotion Motion{get; private set;}
    public WalkState(IHuman human)
    {
        this.human = human;
    }
    public void OnEnter()
    {
        human.StartAnimation("Walk");
    }
    public void OnUpdate()
    {

    }
    public void OnExit()
    {
        
    }
    IHumanState IHumanState.NextState()
    {
        return this;
    }
}
