using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopyPosition : MonoBehaviour
{
    [SerializeField] Transform origin;
    void Start()
    {
        transform.position = origin.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
