using UnityEngine;
using System.Collections;

public class TrafficLight : MonoBehaviour {

	public GameObject light = null;

	void OnTriggerEnter (Collider other) {
		if (other.tag.Equals ("train")) {
			light.SetActive (true);
		}
	}

	void OnTriggerExit(Collider other) {
		if (other.tag.Equals ("train")) {
			light.SetActive (false);
		}
	}
}
