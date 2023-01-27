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

    Transform carTransform;
    Transform wheelTransform;
    Rigidbody carRigidbody;

    float radius;
    float forceValue;
    float dampingForce;
    float accelerationForce;

    Vector3 position;
    Quaternion rotation;
    RaycastHit hit;
    Vector3 hitPoint;
    public void Initialize(float radius, float dampingForce, float forceValue, float accelerationForce)
    {
        wheelTransform = wheelGameObj.transform;
        carTransform = carGameObj.transform;
        position = wheelTransform.position;
        rotation = wheelTransform.rotation;
        carRigidbody = carGameObj.GetComponent<Rigidbody>();
        this.radius = radius;
        this.dampingForce = dampingForce;
        this.forceValue = forceValue;
        this.accelerationForce = accelerationForce;
        hitPoint = position - carTransform.TransformDirection(Vector3.up * hit.distance);
    }

    public void FixedUpdate()
    {
        UpdateRotation(UnityEngine.Input.GetAxis("Horizontal") * 45);
        if (Physics.Raycast(position, -carTransform.up, out hit, radius))
        {
            Damping();
            Accelerating(UnityEngine.Input.GetAxis("Vertical"));
            Frictioning();
        }
    }
    private void Damping()
    {
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
        carRigidbody.AddForceAtPosition(wheelTransform.forward * accelerationForce * input, position - hitPoint, ForceMode.VelocityChange);
    }

    private void Frictioning()
    {
        float frictionScalar = Vector3.Dot(wheelTransform.right, -carRigidbody.GetPointVelocity(position)) * 1000;
        carRigidbody.AddForceAtPosition(wheelTransform.right * frictionScalar, position - hitPoint);
    }
    private void UpdateRotation(float angle)
    {
        wheelTransform.rotation = Quaternion.Lerp(wheelTransform.rotation, Quaternion.Euler(0,angle,0), 0.1f);
    }
}
