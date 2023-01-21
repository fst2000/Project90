using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastTest : MonoBehaviour
{
    RaycastHit hit = new RaycastHit();
    new Rigidbody rigidbody;
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Physics.Raycast(transform.position, -transform.up, out hit);
        rigidbody.AddForce(transform.up * (transform.localScale.y - hit.distance) * 10);
    }
}
