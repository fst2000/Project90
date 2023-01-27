using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : IHuman
{
    Transform transform;
    Rigidbody rigidbody;
    CapsuleCollider capsuleCollider;
    Animator animator;

    IState currentState;

    Vector3 moveInput;

    float walkSpeed;
    float rotationSpeed;
    float jumpForce;
    public Player(GameObject gameObject)
    {
        this.animator = gameObject.GetComponent<Animator>();

        transform = gameObject.GetComponent<Transform>();
        rigidbody = gameObject.AddComponent<Rigidbody>();
        rigidbody.freezeRotation = true;
        rigidbody.collisionDetectionMode = CollisionDetectionMode.Continuous;
        rigidbody.interpolation = RigidbodyInterpolation.Interpolate;

        capsuleCollider = gameObject.AddComponent<CapsuleCollider>();
        capsuleCollider.height = 1.8f;
        capsuleCollider.center = new Vector3(0, 0.9f, 0);
        capsuleCollider.radius = 0.2f;

        walkSpeed = 3.2f;
        rotationSpeed = 3f;
        jumpForce = 1f;
    }
    public void StartAnimation(string state)
    {
        animator.CrossFade(state,0.1f);
    }
    public void OnUpdate()
    {
        IState nextState = currentState.NextState();
        if (currentState != nextState)
        {
            currentState.OnExit();
            currentState = nextState;
            currentState.OnEnter();
        }
        currentState.OnUpdate();
    }
    public void OnFixedUpdate()
    {
        currentState.OnFixedUpdate();
    }
    public void UpdateInput()
    {
        moveInput = new Vector3(Input.GetAxis("Horizontal"), Input.GetKeyDown(KeyCode.Space)? 1 : 0, Input.GetAxis("Vertical"));
    }
    public void WalkFixed()
    {
        float velocityY = rigidbody.velocity.y;
        rigidbody.velocity = transform.forward * Input.GetAxis("Vertical") * walkSpeed + new Vector3(0, velocityY, 0);
        transform.rotation = Quaternion.Euler(0,Input.GetAxis("Horizontal") * rotationSpeed,0) * transform.rotation;
    }
    
    public void Jump()
    {
        rigidbody.AddForce(0,jumpForce, 0, ForceMode.VelocityChange);
    }
}
