using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class GrowthTrigger : MonoBehaviour
{
	[SerializeField] private int numOfPeopleToGrowFully = 10;
	[SerializeField] private float growthTime = 2f;
	[SerializeField] private float requiredYPos = 74f;
	[SerializeField] private ParticleSystem smokeParticles = null;
	[SerializeField] private CinemachineFreeLook flCam = null;
	private Transform graphicsTransform = null;
	private bool growing = false;
	private Vector3 graphicsOriginalPos = Vector3.zero;
	private float amountOfGrowthPerPerson = 0f;
	private float targetPos = 0f;
	private float lastTargetPos = 0f;
	private float lerpTimeValue = 0f;
	private float incrementedGrowthTime = 0f;
	private bool shakeCamera = false;
	private bool finishRepairing = false;

	private void OnTriggerStay(Collider other)
	{
		if (other.CompareTag("Person"))
		{
			if (other.GetComponent<WanderAI>().Crying)
			{
				if (!growing)
				{
					AudioManager.instance.PlaySound("RumbleGrowing");
					growing = true;
					targetPos = graphicsTransform.localPosition.y + amountOfGrowthPerPerson;
				}
			}
		}
	}

	private void Awake()
	{
		// Get the graphics transform
		graphicsTransform = transform.Find("Graphics");
	}

	// Start is called before the first frame update
	void Start()
    {
		// Get the original position of the graphics
		graphicsOriginalPos = graphicsTransform.localPosition;

		// Work out the percentage of growth each time based on the number of people it takes to fully grow
		amountOfGrowthPerPerson = (requiredYPos / numOfPeopleToGrowFully);

		// Set the last target to the current position
		lastTargetPos = graphicsOriginalPos.y;

		// Set the particles off at the start
		ParticleSystem.EmissionModule em = smokeParticles.emission;
		em.enabled = false;
	}

    // Update is called once per frame
    void Update()
    {
		// Only do this if growing and the body hasn't fully grown yet
		if (growing && graphicsTransform.localPosition.y < requiredYPos)
		{
			// Start the particles
			ParticleSystem.EmissionModule em = smokeParticles.emission;
			em.enabled = true;

			// Start the screen shake
			if (!shakeCamera)
			{
				shakeCamera = true;
				SimpleCameraShake.instance.ShakeCamera(growthTime, 2, 1);
			}

			// Smoothly move the body up from the ground
			lerpTimeValue += Time.deltaTime / growthTime;
			if (lerpTimeValue < 1)
			{
				graphicsTransform.localPosition = new Vector3(graphicsTransform.localPosition.x, Mathf.Lerp(lastTargetPos, targetPos, lerpTimeValue), graphicsTransform.localPosition.z);
			}
			else
			{
				// Stop the growing from happening
				graphicsTransform.localPosition = new Vector3(graphicsTransform.localPosition.x, targetPos, graphicsTransform.localPosition.z);
				growing = false;
				lastTargetPos = targetPos;
				lerpTimeValue = 0;
				shakeCamera = false;

				// Stop the particles
				em.enabled = false;
			}
		}
		else if(graphicsTransform.localPosition.y < requiredYPos && !finishRepairing)
		{
			finishRepairing = true;
			PlayerMovement.Instance.ChangeCamera(flCam, true);
		}
    }
}
