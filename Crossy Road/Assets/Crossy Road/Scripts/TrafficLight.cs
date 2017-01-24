using UnityEngine;
using System.Collections;

public class TrafficLight : MonoBehaviour {

	public GameObject trafficLight = null;

	void OnTriggerEnter (Collider other) {
		if (other.tag.Equals ("train")) {
			trafficLight.SetActive (true);
		}
	}

	void OnTriggerExit(Collider other) {
		if (other.tag.Equals ("train")) {
			trafficLight.SetActive (false);
		}
	}
}
