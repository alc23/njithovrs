using UnityEngine;
using System.Collections;

public class YBarMovement : MonoBehaviour {
	
	public float moveSpeed = .1f;
	public Vector3 pos;
	// Use this for initialization
	void Start () {
		pos = transform.position;
		//pos.x = pos.y = -72;

	}
	
	// Update is called once per frame
	void Update () {
		pos.x = 408f;
		Vector3 newPos = transform.localPosition;
		newPos.y = YCalibration.scaled;
		newPos.x = 408f;
		transform.localPosition = Vector2.Lerp (pos, newPos, 1f);
	
	}
}