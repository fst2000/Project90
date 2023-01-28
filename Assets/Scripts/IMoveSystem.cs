using UnityEngine;

public interface IMoveSystem
{
    void Move(Vector3 direction);
    bool IsOnGround();
   
}
