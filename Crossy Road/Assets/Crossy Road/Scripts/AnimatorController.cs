using UnityEngine;
using System.Collections;

public class AnimatorController : MonoBehaviour 
{
	public PlayerController playerController;
	private Animator animator;

	void Start() {
		animator = GetComponent<Animator> ();	
	}

	void Update() {
		if (playerController.isDead) {
			animator.SetBool ("dead", true);
		}
		if (playerController.isJumpStart) {
			animator.SetBool ("jumpStart", true);
		} else if (playerController.isJumping) {
			animator.SetBool ("jump", true);
		} else {
			animator.SetBool ("jump", false);
			animator.SetBool ("jumpStart", false);
		}

		if (!playerController.isIdle) return;
	
		if (Input.GetKeyDown (KeyCode.UpArrow)) {
			gameObject.transform.rotation = Quaternion.Euler (270, 0, 0);
		}
		if (Input.GetKeyDown (KeyCode.DownArrow)) {
			gameObject.transform.rotation = Quaternion.Euler (270, 180, 0);
		}
		if (Input.GetKeyDown (KeyCode.LeftArrow)) {
			gameObject.transform.rotation = Quaternion.Euler (270, -90, 0);
		}
		if (Input.GetKeyDown (KeyCode.RightArrow)) {
			gameObject.transform.rotation = Quaternion.Euler (270, 90, 0);
		}
	}
}
