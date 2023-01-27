using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkState : IState
{
    IHuman human;
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
    IState IState.NextState()
    {
        return this;
    }
}
