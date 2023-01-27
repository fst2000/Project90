using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkState : IState
{
    Player player;
    public WalkState(Player player)
    {
        this.player = player;
    }
    public void OnEnter()
    {
        player.StartAnimation("Walk");
    }
    public void OnUpdate()
    {
        player.UpdateInput();
    }
    public void OnFixedUpdate()
    {
        player.WalkFixed();
    }
    public void OnExit()
    {
        
    }
    IState IState.NextState()
    {
        return new IdleState(player);
    }
}
