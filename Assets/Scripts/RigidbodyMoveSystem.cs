using UnityEngine;

public class RigidbodyMoveSystem : IMoveSystem, IFixedUpdateHandler
{
    Rigidbody rigidbody;
    Transform transform;
    CapsuleCollider capsuleCollider;
    IHumanSize size;
    IHumanMotion motion;
    float jumpForce;
    bool isOnGround;

    Vector3 desiredVelocity;
    public RigidbodyMoveSystem(GameObject gameObject, IHumanSize size, IHumanMotion motion, IEvent<IFixedUpdateHandler> fixedUpdateEvent)
    {
        rigidbody = gameObject.AddComponent<Rigidbody>();
        rigidbody.freezeRotation = true;
        rigidbody.collisionDetectionMode = CollisionDetectionMode.Continuous;
        rigidbody.interpolation = RigidbodyInterpolation.Interpolate;

        transform = gameObject.transform;

        capsuleCollider = gameObject.AddComponent<CapsuleCollider>();
        capsuleCollider.height = size.Height;
        capsuleCollider.center = new Vector3(0, size.Height * 0.5f, 0);
        capsuleCollider.radius = size.Radius;

        this.size = size;
        this.motion = motion;
        fixedUpdateEvent.Subscribe(this);
    }
    public void FixedUpdate()
    {
        rigidbody.velocity = new Vector3(desiredVelocity.x,rigidbody.velocity.y,desiredVelocity.z);
    }
    public bool IsOnGround()
    {
        return isOnGround;
    }

    public void DesiredVelocityChange(Vector3 direction)
    {
        direction = direction.normalized;
        desiredVelocity = direction * motion.MoveSpeed;
    }
}

