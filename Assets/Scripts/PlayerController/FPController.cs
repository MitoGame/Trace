using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPController : MonoBehaviour
{
    Transform fpCamera;
    public float movespeed = 5f;
    CharacterController controller;

    [Header("Gravity and Jump Settings")]
    float velocityY;
    bool isGround;
    public Transform groundDetect;
    public float groundDistance;
    public float gravityScale;
    public float jumpHeight;
    public LayerMask groundLayer;

    void Awake()
    {
        fpCamera = transform.Find("first person");
        controller = GetComponent<CharacterController>();
    }

    void jumpAndGravity()
    {
        isGround = Physics.CheckSphere(groundDetect.position, groundDistance, groundLayer);
        if(isGround && velocityY <0)
        {
            velocityY = -2f;
        }
        if (Input.GetKeyDown(KeyCode.Space) && isGround)
        {
            velocityY = Mathf.Sqrt(jumpHeight * -2f * gravityScale);
        }
        velocityY += gravityScale * Time.deltaTime;
    }

    void Update()
    {
        jumpAndGravity();
        float forward = Input.GetAxis("Vertical");
        float Rightward = Input.GetAxis("Horizontal");
        Vector3 dir = transform.right * Rightward + transform.forward * forward;
        dir.Normalize();
        dir *= movespeed * Time.deltaTime;
        dir += velocityY * Vector3.up * Time.deltaTime;
        controller.Move(dir);   
        //transform.position += dir;
    }
}
