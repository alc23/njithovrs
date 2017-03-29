using UnityEngine;
using System.Collections;

public class UnfreezeFruit : MonoBehaviour {

	// Use this for initialization

	public Rigidbody rb;

	void OnCollisionEnter(Collision col){
		rb.useGravity = true;

		if (col.gameObject.tag == "Basket") {
			rb.constraints = RigidbodyConstraints.FreezeAll;
		}	
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
