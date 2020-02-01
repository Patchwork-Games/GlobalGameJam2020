using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerNodeManager : MonoBehaviour
{
	public bool SafeToSpawnHere = true;

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Person"))
		{
			SafeToSpawnHere = false;
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if (other.CompareTag("Person"))
		{
			SafeToSpawnHere = true;
		}
	}
}
