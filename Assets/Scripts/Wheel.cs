using UnityEngine;
[System.Serializable]
public class Wheel : IWheel
{
    [SerializeField] Transform wheelTransform;
    float radius;
    Rigidbody carRigidbody;
    public void Initialize(IEvent fixedUpdate, GameObject car, float radius)
    {
        fixedUpdate.Subscribe(FixedUpdate);
        this.carRigidbody = car.GetComponent<Rigidbody>();
        this.radius = radius;
        
    }
    void FixedUpdate()
    {
        Damping();
    }
    void Damping()
    {
        Ray ray = new Ray(wheelTransform.position, -wheelTransform.up);
        RaycastHit raycastHit;
        
        if(Physics.Raycast(ray, out raycastHit))
        {

        }
        Debug.Log(raycastHit.distance);
    }
}