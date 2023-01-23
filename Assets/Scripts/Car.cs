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
    [SerializeField] float forceValue = 0.1f;
    [SerializeField] float accelerationForce;
    Wheel[] wheels;
    public void Initialize(GameObject gameObject)
    {
        rigidbody = gameObject.GetComponent<Rigidbody>();
        carCollider = gameObject.AddComponent<BoxCollider>();
        carCollider.center = new Vector3(0,0.35f,0.15f);
        carCollider.size = new Vector3(1.6f,1.15f,4f);
        wheelFL.Initialize(radius, dampingForce,forceValue, 0);
        wheelFR.Initialize(radius, dampingForce, forceValue, 0);
        wheelBL.Initialize(radius, dampingForce, forceValue, accelerationForce);
        wheelBR.Initialize(radius, dampingForce, forceValue, accelerationForce);
        wheels = new Wheel[] {wheelFL, wheelFR, wheelBL, wheelBR};
    }

    public void FixedUpdate() 
    {
        foreach(var wheel in wheels)
        {
            wheel.FixedUpdate();
        }
    }
}
