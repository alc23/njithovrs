using UnityEngine;
using System.Collections;

public class BallProximity : MonoBehaviour {
	
	private Light myLight;
	
	void Start(){
		myLight = GetComponent<Light> ();
	}
	
	void OnTriggerEnter (Collider other){
		myLight.enabled = true;
	}
	
	
	void OnTriggerExit (Collider other){
		myLight.enabled = false;
	}
	
}
