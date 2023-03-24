using UnityEngine;
using System;
[System.Serializable]
public class Wheel : IWheel
{
    [SerializeField] Transform wheelTransform;
    float radius;
    float dampingForce;
    float dampingClamp;
    Rigidbody carRigidbody;
    Transform carTransform;
    Vector3 localOriginPosition;
    public void Initialize(IEvent fixedUpdate, GameObject car, float radius, float dampingForce, float dampingClamp)
    {
        fixedUpdate.Subscribe(FixedUpdate);
        this.carRigidbody = car.GetComponent<Rigidbody>();
        this.radius = radius;
        this.dampingForce = dampingForce;
        this.dampingClamp = dampingClamp;
        carTransform = car.transform;
        localOriginPosition = wheelTransform.localPosition;
        
    }
    void FixedUpdate()
    {
        Ray ray = new Ray(carTransform.TransformPoint(localOriginPosition), -carTransform.up);
        RaycastHit raycastHit;
        
        if(Physics.Raycast(ray, out raycastHit) && raycastHit.distance < radius)
        {
            Damping(raycastHit);
        }
    }
    void Damping(RaycastHit raycastHit)
    {
        Vector3 originPosition = carTransform.TransformPoint(localOriginPosition);
        Vector3 touchPoint = originPosition - carTransform.up * raycastHit.distance;
        float velocityDot = Vector3.Dot(carRigidbody.GetPointVelocity(originPosition),carTransform.up);
        float dampingImmersion = (radius - raycastHit.distance) / radius;

        carRigidbody.AddForceAtPosition(carTransform.up * Mathf.Max(dampingImmersion - velocityDot * dampingClamp,0) * dampingForce, touchPoint, ForceMode.VelocityChange);

        Vector3 wheelDampingPosition = originPosition + carTransform.up * (radius -raycastHit.distance);
        wheelTransform.position = wheelDampingPosition;
    }
}