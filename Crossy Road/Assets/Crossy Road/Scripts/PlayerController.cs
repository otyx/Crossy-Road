using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour 
{
	public 	float 			moveDistance = 1;
	public 	float 			moveTime = 0.0f;
	public 	float 			colliderDistCheck = 1;
	public 	bool 			isIdle = true;
	public 	bool 			isDead = false;
	public 	bool 			isMoving = false;
	public 	bool 			isJumping = false;
	public 	bool 			isJumpStart = false;
	public 	ParticleSystem 	particle = null;
	public 	GameObject 		chick = null;
	private Renderer 		renderer = null;
	private bool 			isVisible = false;

	void Start() { }
	void Update() {	
		CanMove ();
	}
	void CanIdle() { }
	void CheckIfCanMove() {	}
	void SetMove() { }

	void CanMove() {
		if (isMoving) {
			if (Input.GetKeyUp (KeyCode.UpArrow)) {
				Moving (new Vector3 (transform.position.x, transform.position.y, transform.position.z + moveDistance));
				SetMoveForwardState ();
			} else if (Input.GetKeyUp (KeyCode.DownArrow)) {
				Moving (new Vector3 (transform.position.x, transform.position.y, transform.position.z - moveDistance));
			} else if (Input.GetKeyUp (KeyCode.LeftArrow)) {
				Moving (new Vector3 (transform.position.x - moveDistance, transform.position.y, transform.position.z));
			} else if (Input.GetKeyUp (KeyCode.RightArrow)) {
				Moving (new Vector3 (transform.position.x + moveDistance, transform.position.y, transform.position.z));
			}
		}
	}

	void Moving(Vector3 pos) {
		LeanTween.move (this.gameObject, pos, moveTime);
	}

	void MoveComplete() { }

	void SetMoveForwardState() { }
	void IsVisible() { }
	public void GotHit() { }

}
