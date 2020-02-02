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
	[SerializeField] private float despawnDistance = 50f;
	[SerializeField] private ParticleSystem heartParticles = null;
	[SerializeField] private ParticleSystem cryingParticles = null;
	[HideInInspector] public ObjectPooling personSmokePool = null;

	// Components
	private Rigidbody rb = null;
	[HideInInspector] public GameObject playerObject = null;

	// Time variables for changing states
	private bool timeSet = false;
	private float randomTimeSelected = 0f;
	private float elapsedTimeBetweenStates = 0f;

	// Avoiding people
	private bool tooCloseToPeople = false;
	private Vector3 directionToPerson = Vector3.zero;

	// Beckoning
	[SerializeField] private float beckonedTime;
	public bool Beckoned { get; set; } = false;
	private float elapsedBeckonTime = 0f;
	private Vector3 dirToPlayer = Vector3.zero;
	private bool startedBeckoning = false;

	// Crying
	[SerializeField] private float timeToCryFor = 3f;
	private float elapsedCryingTime = 0f;
	public bool Crying { get; set; }
	private bool startedCrying = false;

	//Dying
	private bool startedSmokeParticles = false;

	// Enum for the wander state
	public enum WanderState
	{
		IDLE = 0,
		WALK_UP = 1,
		WALK_DOWN = 2,
		WALK_LEFT = 3,
		WALK_RIGHT = 4,
		NUM_RANDOM_STATES = 5,
		AVOID_OTHERS = 6,
		CRYING = 7,
		FOLLOWING_PLAYER = 8
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
		ChangeToRandomState();
		elapsedCryingTime = timeToCryFor;
		elapsedBeckonTime = beckonedTime;
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

		// If the player has beckoned, the state should change to the follow player state
		if (Beckoned)
		{
			CurrentState = WanderState.FOLLOWING_PLAYER;
		}

		// If the player has flipped off the person, they should cry
		if (Crying)
		{
			CurrentState = WanderState.CRYING;
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
			case WanderState.FOLLOWING_PLAYER:
				UpdateBeckoning();
				break;
			case WanderState.CRYING:
				UpdateCrying();
				break;
			default:
				break;
		}

		// If the person gets too far from the player the person should despawn
		if (Vector3.Distance(transform.position, playerObject.transform.position) >= despawnDistance)
		{
			gameObject.SetActive(false);
		}

		if (CurrentState != WanderState.CRYING)
		{
			startedCrying = false;
		}

		if (CurrentState != WanderState.FOLLOWING_PLAYER)
		{
			startedBeckoning = false;
		}
	}

	private void ChangeToRandomState()
	{
		CurrentState = (WanderState)Random.Range(0, (int)WanderState.NUM_RANDOM_STATES);
	}

	private void UpdateIdle()
	{
		// Should stand still, maybe have an idle animation
		rb.velocity = Vector3.zero;
	}

	private void UpdateCrying()
	{
		// Should stand still with a crying animation, then disappear after a certain time
		rb.velocity = Vector3.zero;

		if (elapsedCryingTime > 0)
		{
			elapsedCryingTime -= Time.deltaTime;
			if (elapsedCryingTime <= 0)
			{
				// Stop crying and despawn
				gameObject.SetActive(false);
				elapsedCryingTime = timeToCryFor;
				Crying = false;
				Beckoned = false;
				ChangeToRandomState();
			}
			else if (elapsedCryingTime <= 1 && !startedSmokeParticles)
			{
				startedSmokeParticles = true;
				GameObject newParticleObject = personSmokePool.RetrieveInstance();
				newParticleObject.GetComponent<ParticleSystem>().Play();
				newParticleObject.transform.position = transform.position - new Vector3(0,2,0);
			}
		}

		if (!startedCrying)
		{
			startedCrying = true;

			int randomNumber = Random.Range(0, 3);

			switch (randomNumber)
			{
				case 0:
					AudioManager.instance.PlaySound("Cry1");
					break;
				case 1:
					AudioManager.instance.PlaySound("Cry2");
					break;
				case 2:
					AudioManager.instance.PlaySound("Cry3");
					break;
				default:
					break;
			}

			cryingParticles.Play();
		}
	}

	private void UpdateBeckoning()
	{
		// Should start following the plaer until the timer runs out, then the player has to beckon again
		if (elapsedBeckonTime > 0)
		{
			elapsedBeckonTime -= Time.deltaTime;
			if (elapsedBeckonTime <= 0)
			{
				// Go back to randomly wandering
				elapsedBeckonTime = beckonedTime;
				Beckoned = false;
			}
			else
			{
				// Make the AI move in the direction of the player
				Vector3 dirToPlayer = Vector3.Normalize(playerObject.transform.position - transform.position);
				dirToPlayer = new Vector3(dirToPlayer.x, 0, dirToPlayer.z);
				Walk(dirToPlayer);
			}
		}

		if (!startedBeckoning)
		{
			startedBeckoning = true;

			int randomNumber = Random.Range(0, 4);

			switch (randomNumber)
			{
				case 0:
					AudioManager.instance.PlaySound("Ooh1");
					break;
				case 1:
					AudioManager.instance.PlaySound("Ooh2");
					break;
				case 2:
					AudioManager.instance.PlaySound("Ooh3");
					break;
				case 3:
					AudioManager.instance.PlaySound("Ooh4");
					break;
				default:
					break;
			}

			heartParticles.Play();
		}

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
			directionToPerson = Vector3.Normalize(other.transform.position - transform.position);
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
