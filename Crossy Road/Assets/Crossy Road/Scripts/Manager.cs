using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class Manager : MonoBehaviour {

	public Text coinText = null;
	public Text distanceText = null;
	public Camera gameCamera;
	public GameObject guiGameOver = null;

	private int currentCoins = 0;
	private int currentDistance = 0;
	private bool canPlay = true;

	private static Manager s_instance;
	public static Manager instance {
		get { 
			if (s_instance == null) {
				s_instance = FindObjectOfType(typeof(Manager)) as Manager;
			}
			return s_instance;
		}
	}

	// Use this for initialization
	void Start () {
		// TODO: Level Generator start up
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void UpdateCoinCount(int val) {
		Debug.Log ("Picked up another coin for value " + val);
		currentCoins += val;
		coinText.text = currentCoins.ToString();
	}

	public void UpdateDistanceCount(int d=1) {
		Debug.Log ("Player moved forward for " + d + " points");
		currentDistance += d;
		distanceText.text = currentDistance.ToString ();

		// TODO: generate new level piece here.
	}

	public bool CanPlay() {
		return canPlay;
	}

	public void StartPlay() {
		canPlay = true;
	}

	public void GameOver() {
		gameCamera.GetComponent<CameraShake> ().Shake();
		gameCamera.GetComponent<CameraFollow> ().enabled = false;
		GUIGameover ();
	}

	void GUIGameover() {
		Debug.Log ("Game Over!");

		guiGameOver.SetActive (true);
	}

	public void PlayAgain() {
		Scene scene = SceneManager.GetActiveScene ();
		SceneManager.LoadScene (scene.name);
	}

	public void Quit() {
		Application.Quit ();
	}
}
