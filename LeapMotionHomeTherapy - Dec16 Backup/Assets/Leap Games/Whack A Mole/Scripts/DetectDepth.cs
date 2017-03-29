using UnityEngine;
using System.Collections;

public class DetectDepth : MonoBehaviour {

	private Light myLight;

	void Start(){
		myLight = GetComponent<Light> ();
	}

	void OnTriggerEnter (Collider other){

		Debug.Log ("triggered");
		if (other.gameObject.tag == "mole") {
			myLight.enabled = true;
			Debug.Log("light");
		}
	}
	
	void OnTriggerExit (Collider other){
		if (other.gameObject.tag == "mole") {
			myLight.enabled = false;
		}
	}
}
