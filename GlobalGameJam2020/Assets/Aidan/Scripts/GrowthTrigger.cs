using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using EZCameraShake;

public class GrowthTrigger : MonoBehaviour
{
	[SerializeField] private int numOfPeopleToGrowFully = 10;
	[SerializeField] private float growthTime = 2f;
	[SerializeField] private float requiredYPos = 74f;
	[SerializeField] private CinemachineFreeLook cmFreeCam;
	private Transform graphicsTransform = null;
	private bool growing = false;
	private Vector3 graphicsOriginalPos = Vector3.zero;
	private float amountOfGrowthPerPerson = 0f;
	private float targetPos = 0f;
	private float lastTargetPos = 0f;
	private float lerpTimeValue = 0f;
	private float incrementedGrowthTime = 0f;
	private CinemachineBasicMultiChannelPerlin noise = null;
	public AnimationCurve curveShake = null;

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

		lastTargetPos = graphicsOriginalPos.y;
	}

    // Update is called once per frame
    void Update()
    {
		if (growing && graphicsTransform.localPosition.y < requiredYPos)
		{
			lerpTimeValue += Time.deltaTime / growthTime;
			if (lerpTimeValue < 1)
			{
				graphicsTransform.localPosition = new Vector3(graphicsTransform.localPosition.x, Mathf.Lerp(lastTargetPos, targetPos, lerpTimeValue), graphicsTransform.localPosition.z);
				StartCoroutine(ShakeItBaby());
			}
			else
			{
				AudioManager.instance.StopSound("RumbleGrowing");
				graphicsTransform.localPosition = new Vector3(graphicsTransform.localPosition.x, targetPos, graphicsTransform.localPosition.z);
				growing = false;
				lastTargetPos = targetPos;
				lerpTimeValue = 0;
			}
		}
    }

	IEnumerator ShakeItBaby()
	{
		noise.m_AmplitudeGain = curveShake.Evaluate(lerpTimeValue);
		yield return null;
	}
}
