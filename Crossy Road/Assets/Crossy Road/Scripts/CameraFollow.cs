using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	public bool autoMove = true;
	public GameObject player = null;
	public float speed = 0.25f;

	// where is the camera in relation to the player
	public Vector3 offset = new Vector3(3, 6,-3);
	Vector3 depth = Vector3.zero;
	Vector3 pos = Vector3.zero;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void LateUpdate () {
		if (!Manager.instance.CanPlay ()) return;

		if (autoMove) {
			depth = this.gameObject.transform.position += new Vector3 (0, 0, speed * Time.deltaTime);
			pos = Vector3.Lerp (gameObject.transform.position, player.transform.position + offset, Time.deltaTime);
			gameObject.transform.position = new Vector3 (pos.x, pos.y, depth.z);
		} else {
			// centre camera on player
			pos = Vector3.Lerp (gameObject.transform.position, player.transform.position + offset, Time.deltaTime);
			gameObject.transform.position = new Vector3 (pos.x, pos.y, pos.z);
		}
	}
}
