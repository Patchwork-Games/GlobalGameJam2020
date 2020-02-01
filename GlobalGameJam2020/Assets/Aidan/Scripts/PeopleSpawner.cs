using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeopleSpawner : MonoBehaviour
{
    [SerializeField] private float minSpawnTime = 5f;
	[SerializeField] private float maxSpawnTime = 10f;
	[SerializeField] private GameObject playerObject = null;
	[SerializeField]private Vector3 positionOfffsetFromPlayer = Vector3.zero;
	private ObjectPooling peoplePool = null;
	private int numOfNodes = 0;
	private bool timeSet = false;
	private float randomSpawnTime = 0f;
	private float elapsedSpawnTime = 0f;


	private void Awake()
	{
		// Get the object pooling script from this object
		peoplePool = GetComponent<ObjectPooling>();
		if (peoplePool == null)
		{
			Debug.Log("Missing object pooling script on People spawner!");
		}

		// Get the number of spawn nodes
		foreach (Transform t in transform)
			numOfNodes++;
	}

	private void Update()
	{
		// Set the time randomly for the next person to spawn
		if (!timeSet)
		{
			timeSet = true;
			randomSpawnTime = Random.Range(minSpawnTime, maxSpawnTime);
			elapsedSpawnTime = randomSpawnTime;
		}

		// Count down to spawn time
		if (elapsedSpawnTime > 0)
		{
			elapsedSpawnTime -= Time.deltaTime;
			if (elapsedSpawnTime <= 0)
			{
				// The timer has ran out, spawn a person at a random spawn node
				SpawnPerson();
				timeSet = false;
			}
		}

		// Set the spawner to be at the players position
		transform.position = playerObject.transform.position + positionOfffsetFromPlayer;
	}

	private void SpawnPerson()
	{
		// Pick a random node to spawn at
		int randomNodeNum = 0;
		
		// Pick a random node and check if it is safe to spawn at, if not find an available spawn location
		randomNodeNum = Random.Range(0, numOfNodes);
		if (!transform.GetChild(randomNodeNum).GetComponent<SpawnerNodeManager>().SafeToSpawnHere)
		{
			int counter = 0;
			foreach(Transform t in transform)
			{
				if (t.GetComponent<SpawnerNodeManager>().SafeToSpawnHere)
				{
					randomNodeNum = counter;
				}
				counter++;
			}
		}

		// A node has been found, use this as the spawn position
		Transform randomNode = transform.GetChild(randomNodeNum).transform;

		// Retrieve a new instance from the pool and set it's position
		GameObject newPerson = peoplePool.RetrieveInstance();
		if (newPerson != null)
		{
			newPerson.transform.position = randomNode.position;
			newPerson.GetComponent<WanderAI>().playerObject = playerObject;
			randomNode.GetComponent<SpawnerNodeManager>().SafeToSpawnHere = false;
		}
	}
}
