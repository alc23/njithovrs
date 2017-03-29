using UnityEngine;
using System.Collections;

public class Bobbing : MonoBehaviour {

	void Update () {
		GetComponent<Rigidbody>().velocity = Vector3.up * Mathf.Sin(Time.time);
		GetComponent<Rigidbody>().angularVelocity = Vector3.up;
	}
}
