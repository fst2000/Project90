using UnityEngine;

public class RigidbodyMoveSystem : IMoveSystem
{
    Rigidbody rigidbody;
    CapsuleCollider capsuleCollider;
    IHumanSize size;
    IHumanMotion motion;
    float jumpForce;
    bool isOnGround;

    Vector3 desiredVelocity;
    public RigidbodyMoveSystem(GameObject gameObject, IHumanSize size, IHumanMotion motion)
    {
        rigidbody = gameObject.AddComponent<Rigidbody>();
        rigidbody.freezeRotation = true;
        rigidbody.collisionDetectionMode = CollisionDetectionMode.Continuous;
        rigidbody.interpolation = RigidbodyInterpolation.Interpolate;

        capsuleCollider = gameObject.AddComponent<CapsuleCollider>();
        capsuleCollider.height = size.Height;
        capsuleCollider.center = new Vector3(0, size.Height * 0.5f, 0);
        capsuleCollider.radius = size.Radius;

        this.size = size;
        this.motion = motion;
    }
    public bool IsOnGround()
    {
        return isOnGround;
    }

    public void Move(Vector3 direction)
    {
        direction = direction.normalized;
        desiredVelocity = direction * motion.MoveSpeed;
    }
}

