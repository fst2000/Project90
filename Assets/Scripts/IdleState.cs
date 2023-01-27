using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : IState
{
    Player player;
    public IdleState(Player player)
    {
        this.player = player;
    }
    public IState NextState()
    {
        throw new System.NotImplementedException();
    }

    public void OnEnter()
    {
        throw new System.NotImplementedException();
    }

    public void OnExit()
    {
        throw new System.NotImplementedException();
    }

    public void OnUpdate()
    {
        throw new System.NotImplementedException();
    }
    public void OnFixedUpdate()
    {

    }
}
