using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public static MouseLook instance;

    public float mouseSensitivity = 100f;
    private float xRotation = 0f;
    public bool stopLook;

    public Transform body;

    private void Awake()
    {
        instance = this;
    }


    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        if (!stopLook)
        {
            transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
            body.Rotate(Vector3.up * mouseX);
        }
    }
}