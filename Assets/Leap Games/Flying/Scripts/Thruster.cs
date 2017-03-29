using UnityEngine;
using System.Collections;

public class Thruster : MonoBehaviour {

	void FixedUpdate () {
		Vector3 newRot = transform.localRotation.eulerAngles;
		newRot.x = transform.parent.GetComponent<Rigidbody>().velocity.magnitude * 7.0f;
		transform.localRotation = Quaternion.Euler(newRot);

	}
}
