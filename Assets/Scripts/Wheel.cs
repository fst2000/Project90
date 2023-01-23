using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.Windows;

[System.Serializable]
public class Wheel
{
    [SerializeField] GameObject wheelMesh;
    [SerializeField] GameObject wheelGameObj;
    [SerializeField] GameObject carGameObj;
    float accelerationForce;
    Transform wheelTransform;
    Transform carTransform;
    Rigidbody carRigidbody;
    float radius;
    float forceValue;
    float dampingForce;
    RaycastHit hit;
    public void Initialize(float radius, float dampingForce, float forceValue, float accelerationForce)
    {
        wheelTransform = wheelGameObj.transform;
        carTransform = carGameObj.transform;
        carRigidbody = carGameObj.GetComponent<Rigidbody>();
        this.radius = radius;
        this.dampingForce = dampingForce;
        this.forceValue = forceValue;
        this.accelerationForce = accelerationForce;
    }

    public void FixedUpdate()
    {
        if (Physics.Raycast(wheelTransform.position, -carTransform.up, out hit, radius))
        {
            Damping();
            Accelerating(UnityEngine.Input.GetAxis("Vertical"));
        }
    }
    private void Damping()
    {
        Vector3 position = wheelTransform.position;
            wheelMesh.transform.position = position - carTransform.rotation * (Vector3.up * hit.distance - Vector3.up * radius);
            float forceMultiplier = Vector3.Dot(carTransform.up, carRigidbody.GetPointVelocity(position)) * forceValue;
            forceMultiplier = Mathf.Max((radius - hit.distance)/ radius - forceMultiplier, 0);
            if (forceMultiplier > 0)
            {
                carRigidbody.AddForceAtPosition(carTransform.up * forceMultiplier * dampingForce,position, ForceMode.VelocityChange);
            }
    }

    private void Accelerating(float input)
    {
        carRigidbody.AddForceAtPosition(wheelTransform.forward * accelerationForce * input,wheelTransform.position - carTransform.TransformDirection(Vector3.up * hit.distance), ForceMode.VelocityChange);
    }
}
