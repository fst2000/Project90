using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Player player;
    void Start()
    {
        player = new Player(gameObject);
    }

    void Update()
    {
       player.OnUpdate();
    }
    void FixedUpdate()
    {
        player.OnFixedUpdate();
    }
}
