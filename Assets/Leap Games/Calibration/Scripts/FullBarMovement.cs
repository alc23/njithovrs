using UnityEngine;
using System.Collections;

public class FullBarMovement : MonoBehaviour {
	
	public float moveSpeed = .1f;
	public Vector3 pos;
	// Use this for initialization
	void Start () {
		pos = transform.position;

	}
	
	// Update is called once per frame
	void Update () {
		pos.y = -72;
		Vector3 newPos = transform.localPosition;
		newPos.x = RollCalibration1.scaledx;
		newPos.y = RollCalibration1.scaledy;
		transform.localPosition = Vector2.Lerp (pos, newPos, 1f);
	
	}
}
