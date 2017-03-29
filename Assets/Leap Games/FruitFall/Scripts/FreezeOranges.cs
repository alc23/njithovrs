using UnityEngine;
using System.Collections;

public class FreezeOranges : MonoBehaviour {

	public RigidbodyConstraints constraints;
	// Use this for initialization
	void Start () {
	
	}

	void OnCollisionEnter(Collision col){
		constraints = RigidbodyConstraints.FreezePositionY;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
