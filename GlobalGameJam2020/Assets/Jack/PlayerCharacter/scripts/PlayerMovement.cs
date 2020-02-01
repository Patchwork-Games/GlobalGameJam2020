﻿using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{

    public static PlayerMovement Instance { get; private set; }



    public enum PlayerState
    {
        MOVING,
        INTERACTING
    }
    public PlayerState state;

    public Animator anim = null;

    //camera variables
    public GameObject mainCamera = null;
    Vector3 camForward = Vector3.zero;
    Vector3 camRight = Vector3.zero;
    Vector2 camMoveDirection = Vector2.zero; //for moving camera with controller


    //movement variables
    [SerializeField] private float walkSpeed = 8f;
    Vector2 moveDirection = Vector2.zero;
    Vector3 velocity = Vector3.zero;


    //button variables
    public InputMaster controls = null;
    [SerializeField] private CharacterController controller = null;
    public bool interact = false;
    private bool jump = false;


    //jumping variables
    [SerializeField] private float groundDistance = 0.4f;
    [SerializeField] private float gravity = -55.81f;
    [SerializeField] private LayerMask groundMask = ~0;
    [SerializeField] private int jumpsMax = 1;
    [SerializeField] private float jumpForce = 10f;
    private int jumps = 0;
    public bool isGrounded;
    private float distanceGround;
    




    private void Awake()
    {
        if (Instance != null)
        {
            if (Instance != this)
            {
                Destroy(gameObject);
            }
        }
        else
        {
            Instance = this;
        }



        controls = new InputMaster();
        controls.Player.Movement.performed += context => moveDirection = context.ReadValue<Vector2>();
        controls.Player.Movement.canceled += context => moveDirection = context.ReadValue<Vector2>();
        controls.Player.CameraMovement.performed += context => camMoveDirection = context.ReadValue<Vector2>();
        controls.Player.CameraMovement.canceled += context => camMoveDirection = context.ReadValue<Vector2>();
        controls.Player.Interact.performed += context => InteractButton();

    }


    void InteractButton()
    {
        interact = true;
    }



    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }


    private void Start()
    {
        state = PlayerState.MOVING;

        controller = GetComponent<CharacterController>();
        anim.SetBool("Walking", false);
        isGrounded = true;
        distanceGround = GetComponent<CharacterController>().bounds.extents.y;
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        //state machine
        switch (state)
        {
            //normal movement
            case PlayerState.MOVING:
                {
                    Debug.DrawRay(transform.position, new Vector3(0, -(distanceGround + groundDistance), 0), Color.green);
                    //check if on ground
                    if (!Physics.Raycast(transform.position, -Vector3.up, distanceGround + groundDistance))
                    {
                        isGrounded = false;
                        jumps = 0;
                    }
                    else isGrounded = true;

                    if (isGrounded && velocity.y < 0)
                    {
                        velocity.y = -2f;
                    }
               

                    Move();
                    Gravity();
                    MoveCamera();
                    break;
                }





            //throwing stone
            case PlayerState.INTERACTING:
                {
                    if (isGrounded)
                    {
                        anim.SetBool("Walking", false);
                        MoveCamera();
                    }
                    else
                    {
                        state = PlayerState.MOVING;
                    }
                    break;
                }
                

            default:
                break;
        }
        //stop holding A
        interact = false;
    }


    void Move()
    {
        //get camera forward
        camForward = Vector3.Normalize(transform.position - mainCamera.transform.position);
        camForward.y = 0;
        camRight = Vector3.Cross(new Vector3(0, 1, 0), camForward);

        Debug.Log("move dir x " + moveDirection.x);
        Debug.Log("move dir y " + moveDirection.y);
        //move character acording to input
        Vector3 move = (camRight * moveDirection.x) + (camForward * moveDirection.y);

        controller.Move(move * walkSpeed * Time.deltaTime);
        if (move.x != 0 || move.z != 0) transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(move), 7f * Time.deltaTime);


        
        //make character walk if getting input
        if (moveDirection.x > 0.01 || moveDirection.x < -0.01 || moveDirection.y > 0.01 || moveDirection.y < -0.01)
        {
            anim.SetBool("Walking", true);
        }
        else
        {
            anim.SetBool("Walking", false);
        }
    }

    void Gravity()
    {
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }


    void MoveCamera()
    {
        //move camera
        if (camMoveDirection.x != 0)
        {
            mainCamera.GetComponent<CinemachineFreeLook>().m_XAxis.m_InputAxisName = "CameraMovement";
            mainCamera.GetComponent<CinemachineFreeLook>().m_XAxis.m_MaxSpeed = 300;
        }
        else
        {
            mainCamera.GetComponent<CinemachineFreeLook>().m_XAxis.m_InputAxisName = "Mouse X";
            mainCamera.GetComponent<CinemachineFreeLook>().m_XAxis.m_MaxSpeed = 300;
        }

        mainCamera.GetComponent<CinemachineFreeLook>().m_XAxis.m_InputAxisValue = camMoveDirection.x;
    }




    public void ChangeCamera(CinemachineFreeLook cam, bool above)
    {
        if (above)
        {
            cam.Priority = mainCamera.GetComponent<CinemachineFreeLook>().Priority + 1;
        }
        else
        {
            cam.Priority = mainCamera.GetComponent<CinemachineFreeLook>().Priority - 1;
        }
        
    }
}