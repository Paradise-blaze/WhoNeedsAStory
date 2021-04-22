using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    [SerializeField]
    public float mouseSensitivity = 1200f;
    [SerializeField]
    public int sensitivityCoeff = 1;
    float xRotation = 0f;

    public Transform playerBody;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * sensitivityCoeff * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * sensitivityCoeff * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
