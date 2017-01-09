using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelGenerator : MonoBehaviour {

	public List<GameObject> platform = new List <GameObject> ();
	public bool disabled = false;

	private float lastPos = 0;
	private float lastScale = 0;

	public void GeneratePiece() {
		if (disabled)
			return;
		int idx = Random.Range (0, platform.Count);
		GameObject obj = GameObject.Instantiate (platform [idx]) as GameObject;

		float offset = lastPos + (lastScale * 0.5f);
		offset += obj.transform.localScale.z * 0.5f;
		Vector3 pos = new Vector3 (0, platform[idx].transform.position.y, offset);
		obj.transform.position = pos;

		lastPos = obj.transform.position.z;
		lastScale = obj.transform.localScale.z;

		obj.transform.parent = this.transform;
	}

	public void GeneratePieces(int num) {
		if (disabled) return;
		for (int i = 0; i < num; i++) {
			GeneratePiece ();
		}
	}
}
