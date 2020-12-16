using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 12f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;
    private Vector3 velocity;
    private Vector3 moveInput;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    private bool isGrounded;
    public Animator anim;

    public enum enumFoot
    {
        Left,
        Right,
    }

    public GameObject leftFoot = null;
    public GameObject rightFoot = null;
    public float footprintSpacer = 1.0f;
    private Vector3 lastFootPrint;
    private enumFoot whichFoot;
    public Transform spawner;

    void Start()
    {
        //Hide Cursor
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        //SpawnDecal(leftFoot);
        //lastFootPrint = transform.position;
    }

    void Update()
    {
        // Ground Check
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0f)
        {
            velocity.y = -2f;
        }

        // Movement
        moveInput.x = Input.GetAxis("Horizontal");
        moveInput.z = Input.GetAxis("Vertical");
        moveInput.Normalize();

        Vector3 move = transform.right * moveInput.x + transform.forward * moveInput.z;
        controller.Move(move * speed * Time.deltaTime);

        if (moveInput.z != 0)
        {
            anim.SetBool("MoveForward", true);
            anim.SetBool("MoveLeft", false);
            anim.SetBool("MoveRight", false);
        }
        else
        {
            anim.SetBool("MoveForward", false);
            anim.SetBool("MoveLeft", false);
            anim.SetBool("MoveRight", false);
        }

        if (moveInput.x < 0)
        {
            anim.SetBool("MoveForward", false);
            anim.SetBool("MoveLeft", true);
            anim.SetBool("MoveRight", false);
        }
        else if (moveInput.x > 0)
        {
            anim.SetBool("MoveForward", false);
            anim.SetBool("MoveLeft", false);
            anim.SetBool("MoveRight", true);
        }

        // Jump & Gravity
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        // Footprints
        /*if (moveInput.z != 0 || moveInput.x != 0)
        {
            float distanceSinceLastFootprint = Vector3.Distance(lastFootPrint, transform.position);
            if (distanceSinceLastFootprint >= footprintSpacer)
            {
                if (whichFoot == enumFoot.Left)
                {
                    SpawnDecal(leftFoot);
                    whichFoot = enumFoot.Right;
                }
                else if (whichFoot == enumFoot.Right)
                {
                    SpawnDecal(rightFoot);
                    whichFoot = enumFoot.Left;
                }
                lastFootPrint = transform.position;
            }
        }*/
    }

    private void SpawnDecal(GameObject prefab)
    {
        GameObject decal = Instantiate(prefab);
        decal.transform.position = spawner.transform.position;
        //decal.transform.rotation = transform.rotation;
    }
}