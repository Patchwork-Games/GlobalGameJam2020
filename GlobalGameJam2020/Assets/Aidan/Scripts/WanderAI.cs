using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderAI : MonoBehaviour
{
	// Values that can be modified in the editor
	[SerializeField] private float minTimeBetweenStateChange = 2f;
	[SerializeField] private float maxTimeBetweenStateChange = 5f;
	[SerializeField] private float rotationSpeed = 1f;
	[SerializeField] private float walkingSpeed = 100f;

	// Components
	private Rigidbody rb = null;

	// Time variables for changing states
	private bool timeSet = false;
	private float randomTimeSelected = 0f;
	private float elapsedTimeBetweenStates = 0f;

	// Avoiding people
	private bool tooCloseToPeople = false;
	private Vector3 directionToPerson = Vector3.zero;

	// Enum for the wander state
	public enum WanderState
	{
		IDLE = 0,
		WALK_UP = 1,
		WALK_DOWN = 2,
		WALK_LEFT = 3,
		WALK_RIGHT = 4,
		AVOID_OTHERS = 5,
		NUM_STATES = 6
	}
	public WanderState CurrentState { get; set; }

	private void Awake()
	{
		// Get the rigidbody component
		rb = GetComponent<Rigidbody>();
		if (rb == null)
		{
			Debug.Log("Missing Rigidbody component on WanderAI object!");
		}
	}

	// Start is called before the first frame update
	void Start()
	{
		CurrentState = WanderState.IDLE;
	}

	// Update is called once per frame
	void Update()
	{
		// Set the random time
		if (!timeSet)
		{
			timeSet = true;
			randomTimeSelected = Random.Range(minTimeBetweenStateChange, maxTimeBetweenStateChange);
			elapsedTimeBetweenStates = randomTimeSelected;
		}

		// Count down the timer
		if (elapsedTimeBetweenStates > 0)
		{
			elapsedTimeBetweenStates -= Time.deltaTime;
			if (elapsedTimeBetweenStates <= 0)
			{
				// Change state
				ChangeToRandomState();
				timeSet = false;
			}
		}

		// If the person is too close to another person change them to the avoiding people state
		if (tooCloseToPeople)
		{
			CurrentState = WanderState.AVOID_OTHERS;
		}

		// Change what the AI does depending on the state
		switch (CurrentState)
		{
			case WanderState.IDLE:
				UpdateIdle();
				break;
			case WanderState.WALK_UP:
				Walk(new Vector3(0, 0, 1));
				break;
			case WanderState.WALK_DOWN:
				Walk(new Vector3(0, 0, -1));
				break;
			case WanderState.WALK_LEFT:
				Walk(new Vector3(-1, 0, 0));
				break;
			case WanderState.WALK_RIGHT:
				Walk(new Vector3(1, 0, 0));
				break;
			case WanderState.AVOID_OTHERS:
				Walk(-directionToPerson);
				break;
			default:
				break;
		}
	}

	private void ChangeToRandomState()
	{
		CurrentState = (WanderState)Random.Range(0, (int)WanderState.NUM_STATES);
	}

	private void UpdateIdle()
	{
		// Should stand still, maybe have an idle animation
	}

	private void Walk(Vector3 direction)
	{
		// Make the person face the right direction and start moving in that direction
		float singleStep = rotationSpeed * Time.deltaTime;
		Vector3 newDirection = Vector3.RotateTowards(transform.forward, direction, singleStep, 0.0f);
		transform.rotation = Quaternion.LookRotation(newDirection);
		rb.velocity = walkingSpeed * transform.forward;

		// Draw a ray the new direction
		Debug.DrawRay(transform.position, newDirection, Color.red);

		// Play walking animation
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Person"))
		{
			tooCloseToPeople = true;
			directionToPerson = other.transform.position - transform.position;
			directionToPerson = new Vector3(directionToPerson.x, 0, directionToPerson.z);
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if (other.CompareTag("Person"))
		{
			tooCloseToPeople = false;
		}
	}

}
