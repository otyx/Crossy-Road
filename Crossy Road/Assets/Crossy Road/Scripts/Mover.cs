using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour {

	public float speed = 1.0f;
	public float moveDirection = 0f ; // or use an enum with LEFT and RIGHT
	public bool parentOnTrigger = true; // e.g. log so move with when jump on
	public bool hitBoxOnTrigger = false; // kill when hit?
	public GameObject moverObject = null;

	private Renderer moverRenderer = null;
	private bool isVisible = false;

	// Use this for initialization
	void Start () {
		moverRenderer = moverObject.GetComponent<Renderer> ();
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.Translate (speed * Time.deltaTime, 0, 0);
		IsVisible ();
	}

	void IsVisible() {	
		if (moverRenderer.isVisible) {
			isVisible = true;
		}
		if (!moverRenderer.isVisible && isVisible) {
			//Debug.Log ("Remove object - no longer seen by camera: " + name);
			Destroy (this.gameObject);
		}
	}

	void OnTriggerEnter(Collider other) {
		if (other.tag.Equals ("Player")) {
			Debug.Log ("Enter"); 
			if (parentOnTrigger) {
				Debug.Log ("--> Parent to me");
				other.transform.parent = this.transform;
			}
			if (hitBoxOnTrigger) {
				other.GetComponent<PlayerController> ().GotHit ();
			}

		}
	}

	void OnTriggerExit(Collider other) {
		if (other.tag.Equals ("Player")) {
			if (parentOnTrigger) {
				Debug.Log ("Exit");
				other.transform.parent = null;
			}
		}
	}
}
