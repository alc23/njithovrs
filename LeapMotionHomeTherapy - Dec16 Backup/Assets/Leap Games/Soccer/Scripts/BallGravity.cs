using UnityEngine;
using System.Collections;

public class BallGravity : MonoBehaviour {

	public GameObject gobject;

	void OnCollisionEnter(Collision col){
			Rigidbody rb = GetComponent <Rigidbody>();

			rb.angularVelocity = Vector3.zero;
			rb.freezeRotation = true;
	}
}


