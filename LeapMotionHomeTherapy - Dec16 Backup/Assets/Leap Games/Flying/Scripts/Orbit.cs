using UnityEngine;
using System.Collections;

public class Orbit : MonoBehaviour {
	public Transform m_center;
	public Vector3 m_initVelocity = Vector3.zero;

	void Start () {
		GetComponent<Rigidbody>().velocity = m_initVelocity;
	}

	void FixedUpdate () {
		GetComponent<Rigidbody>().velocity += (m_center.position - transform.position).normalized * 0.5f;
	}
}
