using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowthTrigger : MonoBehaviour
{
	[SerializeField] private int numOfPeopleToGrowFully = 10;
	[SerializeField] private float growthTime = 2f;
	[SerializeField] private float requiredYPos = 74f;
	private Transform graphicsTransform = null;
	private int growCounter = 0;
	private Vector3 graphicsOriginalPos = Vector3.zero;
	private float percentageOfGrowthPerPerson = 0f;
	private float elapsedGrowthTime = 0f;
	private GameObject previousPerson = null;
	private float targetPos = 0f;
	private float lastTargetPos = 0f;
	private float lerpTimeValue = 0f;
	private float growthStartPos = 0f; 

	private void OnTriggerStay(Collider other)
	{
		if (other.CompareTag("Person"))
		{
			if (other.GetComponent<WanderAI>().Crying && other.gameObject != previousPerson)
			{
				if (growCounter == 0)
				{
					growthStartPos = graphicsTransform.position.y;
				}
				growCounter++;
				previousPerson = other.gameObject;
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
		graphicsOriginalPos = graphicsTransform.position;

		// Work out the percentage of growth each time based on the number of people it takes to fully grow
		percentageOfGrowthPerPerson = (numOfPeopleToGrowFully / requiredYPos);
	}

    // Update is called once per frame
    void Update()
    {
		// Set the grow time
		if (growCounter > 0)
		{
			elapsedGrowthTime += growthTime;
			targetPos = lastTargetPos + percentageOfGrowthPerPerson;
			lastTargetPos = targetPos;
			growCounter--;
		}

		// Count down the timer
		if (elapsedGrowthTime > 0)
		{
			elapsedGrowthTime -= Time.deltaTime;
			if (elapsedGrowthTime <= 0)
			{
				// Time has ran out
			}

			lerpTimeValue += Time.deltaTime / growthTime;
			graphicsTransform.position = new Vector3(graphicsTransform.position.x, Mathf.Lerp(growthStartPos, targetPos, lerpTimeValue), graphicsTransform.position.z);
		}
    }
}
