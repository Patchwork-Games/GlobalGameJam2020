using System.Collections;
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
    public bool interact = false;
    public bool bButton = false;


    //jumping variables
    [SerializeField] private float groundDistance = 0.4f;
    [SerializeField] private float gravity = -55.81f;
    [SerializeField] private LayerMask groundMask = ~0;
    public bool isGrounded;

    public bool beckon = false;
    public bool finger = false;
    private bool canMove = true;
    private bool walkingSound = false;

    Rigidbody rb;


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

        rb = GetComponent<Rigidbody>();

        controls = new InputMaster();
        

    }


    void InteractButton()
    {
        interact = true;

		int randomNumber = Random.Range(0, 5);

		switch (randomNumber)
		{
			case 0:
				AudioManager.instance.PlaySound("HandBeckon1");
				break;
			case 1:
				AudioManager.instance.PlaySound("HandBeckon2");
				break;
			case 2:
				AudioManager.instance.PlaySound("HandBeckon3");
				break;
			case 3:
				AudioManager.instance.PlaySound("HandBeckon4");
				break;
			case 4:
				AudioManager.instance.PlaySound("HandBeckon5");
				break;
			default:
				break;
		}
		
    }

    void StopInteractButton()
    {
        interact = false;
    }

    void BButton()
    {
        bButton = true;

		AudioManager.instance.PlaySound("MiddleFinger");
		AudioManager.instance.PauseSound("LightMusicTrack");
		AudioManager.instance.UnPauseSound("HeavyMetal");
    }

    
    void StopBButton()
    {
        bButton = false;

		AudioManager.instance.UnPauseSound("LightMusicTrack");
		AudioManager.instance.PauseSound("HeavyMetal");
	}


    private void OnEnable()
    {
        controls.Player.Movement.performed += context => moveDirection = context.ReadValue<Vector2>();
        controls.Player.Movement.canceled += context => moveDirection = context.ReadValue<Vector2>();
        controls.Player.CameraMovement.performed += context => camMoveDirection = context.ReadValue<Vector2>();
        controls.Player.CameraMovement.canceled += context => camMoveDirection = context.ReadValue<Vector2>();
        controls.Player.Interact.performed += context => InteractButton();
        controls.Player.Interact.canceled += context => StopInteractButton();
        controls.Player.BButton.performed += context => BButton();
        controls.Player.BButton.canceled += context => StopBButton();
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Player.Movement.performed -= context => moveDirection = context.ReadValue<Vector2>();
        controls.Player.Movement.canceled -= context => moveDirection = context.ReadValue<Vector2>();
        controls.Player.CameraMovement.performed -= context => camMoveDirection = context.ReadValue<Vector2>();
        controls.Player.CameraMovement.canceled -= context => camMoveDirection = context.ReadValue<Vector2>();
        controls.Player.Interact.performed -= context => InteractButton();
        controls.Player.Interact.canceled -= context => StopInteractButton();
        controls.Player.BButton.performed -= context => BButton();
        controls.Player.BButton.canceled -= context => StopBButton();
        controls.Disable();
    }


    private void Start()
    {
        state = PlayerState.MOVING;
        anim.SetBool("Walking", false);
        isGrounded = true;
    }


    private void Update()
    {
        if (interact)
        {
            beckon = true;
            canMove = false;
            anim.SetBool("Walking", false);
        }
        else
        {
            beckon = false;
            canMove = true;
        }
        if (bButton)
        {
            finger = true;
        }
        else
        {
            finger = false;
        }
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
                    Debug.DrawRay(transform.position, new Vector3(0, -(groundDistance), 0), Color.green);
                    //check if on ground
                    if (!Physics.Raycast(transform.position, -Vector3.up, groundDistance))
                    {
                        isGrounded = false;
                    }
                    else isGrounded = true;

                    if (isGrounded && velocity.y < 0)
                    {
                        velocity.y = -2f;
                    }

                    if (canMove)
                    {
                        Move();
                    }
                    
                    Gravity();
                    MoveCamera();
                    break;
                }

                

            default:
                break;
        }
        //stop holding A
    }



    private void OnTriggerStay(Collider other)
    {
        if (beckon)
        {
            if (other.CompareTag("Person"))
            {
                other.GetComponent<WanderAI>().Beckoned = true;
			}
        }

        if (finger)
        {
            if (other.CompareTag("Person"))
            {
                other.GetComponent<WanderAI>().Crying = true;
			}
        }

    }


    void Move()
    {
        //get camera forward
        camForward = Vector3.Normalize(transform.position - mainCamera.transform.position);
        camForward.y = 0;
        camRight = Vector3.Cross(new Vector3(0, 1, 0), camForward);

        //move character acording to input
        Vector3 move = (camRight * moveDirection.x) + (camForward * moveDirection.y);

        rb.velocity = (move * walkSpeed * Time.deltaTime);

        if (move.x != 0 || move.z != 0) transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(move), 7f * Time.deltaTime);


        
        //make character walk if getting input
        if (moveDirection.x > 0.01 || moveDirection.x < -0.01 || moveDirection.y > 0.01 || moveDirection.y < -0.01)
        {
            anim.SetBool("Walking", true);
            if (!walkingSound)
            {
                AudioManager.instance.SetPitch("HandWalkingFirstStep", .8f);
                AudioManager.instance.PlaySound("HandWalkingFirstStep");
                walkingSound = true;
            }

            
        }
        else
        {
            anim.SetBool("Walking", false);
            AudioManager.instance.StopSound("HandWalkingFirstStep");
            walkingSound = false;
        }
    }

    void Gravity()
    {
        velocity.y += gravity * Time.deltaTime;
        //controller.Move(velocity * Time.deltaTime);
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
