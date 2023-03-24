using UnityEngine;
using System;
[System.Serializable]
public class Wheel : IWheel
{
    [SerializeField] Transform wheelTransform;
    float radius;
    Rigidbody carRigidbody;
    Transform carTransform;
    Vector3 localOriginPosition;
    public void Initialize(IEvent fixedUpdate, GameObject car, float radius)
    {
        fixedUpdate.Subscribe(FixedUpdate);
        this.carRigidbody = car.GetComponent<Rigidbody>();
        this.radius = radius;
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
        Vector3 touchPoint = wheelTransform.position - wheelTransform.up  * radius;

        carRigidbody.AddForceAtPosition(carTransform.up * (radius - raycastHit.distance), touchPoint, ForceMode.VelocityChange);

        Vector3 wheelDampingPosition = originPosition + carTransform.up * (radius -raycastHit.distance);
        wheelTransform.position = wheelDampingPosition;
    }
}