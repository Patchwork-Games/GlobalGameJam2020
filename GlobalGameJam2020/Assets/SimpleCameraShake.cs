using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.Events;

public class SimpleCameraShake : MonoBehaviour
{
	public static SimpleCameraShake instance;
	private float shakeElapsedTime = 0f;
	private bool shaking = false;

	// Cinemachine Shake
	private CinemachineBasicMultiChannelPerlin noise;
	private CinemachineFreeLook freeLookCam = null;

	private void Awake()
	{
		if (instance != null)
		{
			if (instance != this)
			{
				Destroy(this.gameObject);
			}
		}
		else
		{
			instance = this;
			DontDestroyOnLoad(this);
		}

		// Get the free look component
		freeLookCam = GetComponent<CinemachineFreeLook>();
	}

	// Start is called before the first frame update
	void Start()
    {
		// Get the camera noise profile
		noise = freeLookCam.GetRig(1).GetCinemachineComponent<Cinemachine.CinemachineBasicMultiChannelPerlin>();
    }

	// Update is called once per frame
	public void ShakeCamera(float duration, float amplitude, float frequency)
	{
		// Set variables at the start of the shake
		if (!shaking)
		{
			shaking = true;
			noise.m_AmplitudeGain = amplitude;
			noise.m_FrequencyGain = frequency;
			shakeElapsedTime = duration;
		}

		StartCoroutine(Shake(duration));
	}

	IEnumerator Shake(float time)
	{
		yield return new WaitForSeconds(time);
		shaking = false;
		noise.m_AmplitudeGain = 0;
		noise.m_FrequencyGain = 1;
	}
}
