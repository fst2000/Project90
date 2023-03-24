using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarBehaviour : MonoBehaviour, IVehicle
{
    Event fixedUpdate;
    [SerializeField] Vector3 boxColliderCenter;
    [SerializeField] Vector3 boxColliderSize;
    [SerializeField] Wheel[] wheels;
    [SerializeField] float carMass;
    [SerializeField] float wheelRadius;
    [SerializeField] float dampingForce;
    [SerializeField] float dampingClamp;
    void Start()
    {
        fixedUpdate = new Event();
        Rigidbody rigidbody = gameObject.AddComponent<Rigidbody>();
        rigidbody.mass = carMass;
        
        
        BoxCollider boxCollider = gameObject.AddComponent<BoxCollider>();
        boxCollider.center = boxColliderCenter;
        boxCollider.size = boxColliderSize;
        foreach(var wheel in wheels) wheel.Initialize(fixedUpdate,gameObject, wheelRadius, dampingForce, dampingClamp);
    }
    void FixedUpdate() => fixedUpdate.Call();
}
