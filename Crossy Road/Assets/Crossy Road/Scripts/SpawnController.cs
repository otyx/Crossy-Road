using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnController : MonoBehaviour {

	public bool goLeft = false;
	public bool goRight = false;
	public List <GameObject> items = new List<GameObject>();
	public List <Spawner> spawnersLeft = new List<Spawner>();
	public List <Spawner> spawnersRight = new List<Spawner>();


	// Use this for initialization
	void Start () {
		int itemId = Random.Range (0, items.Count);
		GameObject item = items [itemId];

		int direction = Random.Range (0, 2);

		goLeft = (direction == 0);
		goRight = (direction == 1);

		for (int i = 0; i < spawnersLeft.Count; i++) {
			spawnersLeft [i].item = item;
			spawnersLeft [i].goLeft = goLeft;
			spawnersLeft [i].gameObject.SetActive (goRight);
			spawnersLeft [i].spawnLeftPos = spawnersLeft [i].transform.position.x;
		}
		for (int i = 0; i < spawnersRight.Count; i++) {
			spawnersRight [i].item = item;
			spawnersRight [i].goLeft = goLeft;
			spawnersRight [i].gameObject.SetActive (goRight);
			spawnersRight [i].spawnLeftPos = spawnersRight [i].transform.position.x;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
