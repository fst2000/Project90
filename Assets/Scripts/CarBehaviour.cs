using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarBehaviour : MonoBehaviour, IVehicle
{
    Event fixedUpdate;
    [SerializeField] Vector3 boxColliderCenter;
    [SerializeField] Vector3 boxColliderSize;
    [SerializeField] Wheel[] wheels;
    [SerializeField] float wheelRadius;
    void Start()
    {
        fixedUpdate = new Event();
        gameObject.AddComponent<Rigidbody>();
        BoxCollider boxCollider = gameObject.AddComponent<BoxCollider>();
        boxCollider.center = boxColliderCenter;
        boxCollider.size = boxColliderSize;
        foreach(var wheel in wheels) wheel.Initialize(fixedUpdate,gameObject, wheelRadius);
    }
    void FixedUpdate() => fixedUpdate.Call();
}
