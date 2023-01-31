using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
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
}
