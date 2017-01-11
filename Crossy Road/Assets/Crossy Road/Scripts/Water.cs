using UnityEngine;
using System.Collections;

public class Water : MonoBehaviour {
	bool hitWater = false;

	void OnTriggerStay(Collider other) {
		if (hitWater)
			return;
		if (other.tag.Equals ("Player")) {
			PlayerController controller = other.GetComponent<PlayerController> ();

			if (!controller.parentedToObject && !controller.isJumping) {
				Debug.Log ("Player fell into water");
				hitWater = true;
				controller.GotSoaked ();
			}
		}
	}
}
