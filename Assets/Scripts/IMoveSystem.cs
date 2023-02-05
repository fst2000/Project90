using UnityEngine;

public interface IMoveSystem
{
    void DesiredVelocityChange(Vector3 direction);
    bool IsOnGround();
   
}
