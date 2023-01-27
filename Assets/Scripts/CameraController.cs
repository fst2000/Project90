using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] Transform origin;
    [SerializeField] float height = 1f;
    [SerializeField] float distance = 3f;
    [SerializeField] float speed = 0.1f;
    [SerializeField] float slope;
    void LateUpdate()
    {
        UnityEngine.Cursor.visible = false;
        UnityEngine.Cursor.lockState = CursorLockMode.Locked;
        Vector3 mouseInput = new Vector3(-Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X"));
        Quaternion cameraRotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(origin.transform.forward) * Quaternion.Euler(slope, 0, 0),speed);
        Vector3 cameraPosition = origin.position + origin.rotation * new Vector3(0, height, 0) + cameraRotation * new Vector3(0, 0, -distance); ;
        Vector3 cameraRotatedPosition = cameraRotation * cameraPosition;
        transform.rotation = cameraRotation;
        transform.position = cameraPosition;
    }
}
