using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisionControll : MonoBehaviour
{
    public float mouseSensitiveX = 100f;
    public float mouseSensitiveY = 200f;
    public Transform playerBody;
    float verticalRotation = 0f;

    void Awake()
    {
        playerBody = transform.parent;
        Cursor.lockState = CursorLockMode.Locked;
    }
    void Start()
    {

    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitiveX * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitiveY * Time.deltaTime;
        verticalRotation -= mouseY;
        verticalRotation = Mathf.Clamp(verticalRotation,-80f,80f);
        transform.localRotation = Quaternion.Euler(verticalRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
