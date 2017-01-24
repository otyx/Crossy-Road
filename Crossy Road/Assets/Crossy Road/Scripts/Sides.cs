using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sides : MonoBehaviour {

	public Camera mainCamera = null;
	
	// Update is called once per frame
	void Update () {
		Vector3 pos = new Vector3 (gameObject.transform.position.x, gameObject.transform.position.y, mainCamera.transform.position.z);
		gameObject.transform.position = pos;
		
	}
}
