using UnityEngine;
using System.Collections;

public class Coin : MonoBehaviour {


	public int coinValue = 1;
	public AudioClip audioClip= null;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other) {
		if (other.tag.Equals ("Player")) {
			//Debug.Log ("Player picked up a coin");

			Manager.instance.UpdateCoinCount (coinValue);
			gameObject.GetComponent<AudioSource> ().PlayOneShot (audioClip);

			Destroy (this.gameObject,audioClip.length);
		}
	}
}
