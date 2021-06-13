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
    float mouseX = 0;
    float mouseY = 0;

    public Transform playerBody;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {

        if (Inventory.isInventoryVisible || Inventory.isCharacterVisible) {
            mouseX = 0;
            mouseY = 0;

        } else {
            mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * sensitivityCoeff * Time.deltaTime;
            mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * sensitivityCoeff * Time.deltaTime;
        }

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
