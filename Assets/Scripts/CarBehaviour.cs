using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarBehaviour : MonoBehaviour
{
    [SerializeField] Car car;
    void Start()
    {
        car.Initialize(gameObject);
    }

    void FixedUpdate()
    {
        car.FixedUpdate();
    }
}
