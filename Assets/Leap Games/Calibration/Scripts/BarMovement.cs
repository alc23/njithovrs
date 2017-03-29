using UnityEngine;
using System.Collections;

public class BarMovement : MonoBehaviour {
	
	public float moveSpeed = .1f;
	public Vector3 pos;
	// Use this for initialization
	void Start () {
		pos = transform.position;
		pos.x = pos.y = -72;

	}
	
	// Update is called once per frame
	void Update () {
		pos.y = -72;
		Vector3 newPos = transform.localPosition;
		newPos.x = XCalibration.scaled;
		newPos.y = -72;
		transform.localPosition = Vector2.Lerp (pos, newPos, 1f);
	
	}
}
