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
	private Renderer 		chickRenderer = null;
	private bool 			isVisible = false;

	void Start() { 
		chickRenderer = chick.GetComponent<Renderer> ();
	}

	void Update() {	
		if (!Manager.instance.CanPlay ()) {
			return;
		}
		if (isDead) {
			return;
		}
		CanIdle ();
		CanMove ();
		IsVisible ();
	}

	void CanIdle() {
		if (isIdle) 
		{
			if (Input.GetKeyDown (KeyCode.UpArrow) 		||
			    Input.GetKeyDown (KeyCode.DownArrow) 	||
			    Input.GetKeyDown (KeyCode.LeftArrow) 	||
			    Input.GetKeyDown (KeyCode.RightArrow)) 		
			{
				CheckIfCanMove ();			
			}
		}
	}

	void CheckIfCanMove() 
	{	
		// raycast find if collider box in front of player
		RaycastHit hit;
		Physics.Raycast (transform.position, -chick.transform.up, out hit, colliderDistCheck);

		Debug.DrawRay (this.transform.position, -chick.transform.up * colliderDistCheck, Color.red, 0.5f);

		if (hit.collider == null || !hit.collider.tag.Equals("collider")) {
			SetMove ();
		} else {
			Debug.Log ("Hit something with collider tag");
		}
	}

	void SetMove() { 
		Debug.Log ("Hit nothing with the raycast so keep moving");

		isIdle = false;
		isMoving = true;
		isJumpStart = true;
	}

	void CanMove() {
		if (isMoving) 
		{
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
		isIdle 		= false;
		isMoving 	= false;
		isJumping 	= true;
		isJumpStart = false;
		LeanTween.move (this.gameObject, pos, moveTime).setOnComplete(MoveComplete);
	}

	void MoveComplete() 
	{ 
		isIdle = true;
		isJumping = false;
		isJumpStart = false;
	}

	void SetMoveForwardState() {
		Manager.instance.UpdateDistanceCount ();
	}

	void IsVisible() { 
		Debug.Log (chickRenderer.isVisible);
		if (chickRenderer.isVisible) {
			isVisible = true;
		}
		if (!chickRenderer.isVisible && isVisible) {
			Debug.Log ("Player off screen - Apply GotHit()");
			GotHit ();
		}
	}

	public void GotHit() { 
		isDead = true;
		ParticleSystem.EmissionModule em = particle.emission;
		em.enabled = true;

		Manager.instance.GameOver ();
	}

}
