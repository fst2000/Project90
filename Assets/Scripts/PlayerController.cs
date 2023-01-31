using UnityEngine;
public class PlayerController : IController
{
    public Vector2 MoveInput => new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
}