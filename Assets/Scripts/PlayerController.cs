using UnityEngine;
public class PlayerController : IController
{
    public float MoveInput{get;private set;}
    public float RotationInput{get;private set;}
    public PlayerController()
    {
        MoveInput = Input.GetAxis("Vertical");
        RotationInput = Input.GetAxis("Horizontal");
    }
}