using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    IState istate;
    Player player;
    void Start()
    {
        player = new Player(gameObject);
        istate = new WalkState(player);
        istate.OnEnter();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        istate.OnUpdate();
    }
}
