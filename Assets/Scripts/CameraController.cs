using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] Transform origin;
    [SerializeField] float cameraHeight;
    [SerializeField] float cameraDistance;
    [SerializeField] float rotationSpeeed;
    Vector3 mouseInput;
    void Start()
    {

    }
    void OnPreRender()
    {
        transform.position = origin.position + new Vector3(0,cameraHeight,0) + transform.rotation * new Vector3(0,0,-cameraDistance);
        mouseInput += new Vector3(0, Input.GetAxis("Horizontal") * rotationSpeeed, 0) * Time.deltaTime;
        Quaternion cameraRotation = Quaternion.Euler(mouseInput);
        transform.rotation = cameraRotation;
    }
}
