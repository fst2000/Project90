using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Wheel
{
    [SerializeField] GameObject wheelGameObj;
    [SerializeField] GameObject carGameObj;
    float dampingForce;
    Transform wheelTransform;
    Transform carTransform;
    Rigidbody carRigidbody;
    float radius;
    float forceX;
    public void Initialize(float radius, float dampingForce, float forceX)
    {
        wheelTransform = wheelGameObj.transform;
        carTransform = carGameObj.transform;
        carRigidbody = carGameObj.GetComponent<Rigidbody>();
        this.radius = radius;
        this.dampingForce = dampingForce;
        this.forceX = forceX;
    }

    public void Damping()
    {
        Vector3 position = wheelTransform.position;
        if (Physics.Raycast(position, -carTransform.up, out RaycastHit hit, radius))
        {
            float forceMultiplier = Vector3.Dot(carTransform.up, carRigidbody.GetPointVelocity(position)) * forceX;
            forceMultiplier = Mathf.Max((radius - hit.distance)/ radius - forceMultiplier, 0);
            if (forceMultiplier > 0)
            {
                carRigidbody.AddForceAtPosition(carTransform.up * forceMultiplier * dampingForce,position, ForceMode.VelocityChange);
            }
        }
    }
}
