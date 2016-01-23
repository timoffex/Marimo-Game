using UnityEngine;
using System.Collections;

public class BubbleSpawner : MonoBehaviour {

	public float spawnWidth;
	public float spawnHeight;

	/// <summary>
	/// At most once per frame.
	/// </summary>
	public float spawnRate = 10;
	public float spawnRateDelta;

	public GameObject bubble;
	
	private float nextSpawn;

	// Use this for initialization
	void Start () {
		PlanNextSpawn ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time >= nextSpawn) {
			SpawnBubble (RandomPosition ());
			PlanNextSpawn ();
		}
	}

	void PlanNextSpawn () {
		float maxPeriod = 1 / (spawnRate - spawnRateDelta);
		float minPeriod = 1 / (spawnRate + spawnRateDelta);
		float periodDelta = maxPeriod - minPeriod;

		nextSpawn = Time.time + minPeriod + periodDelta * Random.value;
	}

	Vector3 RandomPosition () {
		float minX = transform.position.x - spawnWidth / 2;
		float minY = transform.position.y - spawnHeight / 2;
		
		
		float x = minX + Random.value * spawnWidth;
		float y = minY + Random.value * spawnHeight;

		return new Vector3 (x, y, 0);
	}

	void SpawnBubble (Vector3 position) {
		Instantiate (bubble, position, Quaternion.identity);
	}
}
