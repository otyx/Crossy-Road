using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

	public Transform startPos = null;

	// spawn time based
	public float delayMin = 1.5f;
	public float delayMax = 5.0f; 
	public float speedMin = 1;
	public float speedMax = 4;

	// spawn at start
	public bool useSpawnPlacement = false; // if false then obj is a mover
	public int minSpawnCount = 4;
	public int maxSpawnCount = 20;

	private float lastTime = 0;
	private float delayTime = 0;
	private float speed = 0;

	[HideInInspector]	public GameObject item = null;
	[HideInInspector]	public bool goLeft = false;
	[HideInInspector]	public float spawnLeftPos = 0;
	[HideInInspector]	public float spawnRightPos = 0;


	void Start() {
		if (useSpawnPlacement) {
			int spawnCount = Random.Range (minSpawnCount, maxSpawnCount);
			for (int i = 0; i < spawnCount; i++) {
				SpawnItem ();
			}
		} else {
			speed = Random.Range (speedMin, speedMax);
		}

	}

	void Update() {
		if (useSpawnPlacement) return;
		if (Time.time > lastTime + delayTime) {
			lastTime = Time.time;
			delayTime = Random.Range (delayMin, delayMax);

			SpawnItem ();
		}

	}

	void SpawnItem() {
		Debug.Log ("Spawn Item");
		GameObject obj = Instantiate (item) as GameObject;
		obj.transform.position = GetSpawnPosition ();

		float direction = 0;
		if (goLeft) {
			direction = 180;
		}

		if (!useSpawnPlacement) {
			obj.GetComponent<Mover> ().speed = speed;
			obj.transform.rotation = obj.transform.rotation * Quaternion.Euler (0, direction, 0);
		}
	}

	Vector3 GetSpawnPosition() {
		if (useSpawnPlacement) {
			return new Vector3 (Random.Range(spawnLeftPos, spawnRightPos), startPos.position.y, startPos.position.z);
		} else {
			return startPos.position;
		}
	}
}
