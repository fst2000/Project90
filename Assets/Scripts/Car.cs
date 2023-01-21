using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Car
{
    Rigidbody rigidbody;
    BoxCollider carCollider;

    [SerializeField] Wheel wheelFL;
    [SerializeField] Wheel wheelFR;
    [SerializeField] Wheel wheelBL;
    [SerializeField] Wheel wheelBR;
    [SerializeField] float radius;
    [SerializeField] float dampingForce;
    [SerializeField] float forceX = 0.1f;
    Wheel[] wheels;
    public void Initialize(GameObject gameObject)
    {
        rigidbody = gameObject.GetComponent<Rigidbody>();
        carCollider = gameObject.AddComponent<BoxCollider>();
        carCollider.center = new Vector3(0,0.25f,0);
        carCollider.size = new Vector3(1,1,2);
        wheelFL.Initialize(radius, dampingForce,forceX);
        wheelFR.Initialize(radius, dampingForce, forceX);
        wheelBL.Initialize(radius, dampingForce, forceX);
        wheelBR.Initialize(radius, dampingForce, forceX);
        wheels = new Wheel[] {wheelFL, wheelFR, wheelBL, wheelBR};
    }

    public void FixedUpdate() 
    {
        foreach(var wheel in wheels)
        {
            wheel.Damping();
        }
    }
}
