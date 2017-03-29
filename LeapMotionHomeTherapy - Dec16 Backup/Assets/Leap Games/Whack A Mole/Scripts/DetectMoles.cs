using UnityEngine;
using System.Collections;

public class DetectMoles : MonoBehaviour {

	public static int molesUp;

	void OnTriggerEnter (Collider other){
		if (other.gameObject.tag == "mole") {
			molesUp++;
		}
	}

	void OnTriggerExit (Collider other){
		if (other.gameObject.tag == "mole") {
			molesUp--;
		}
	}

	void Update(){
		//Debug.Log (molesUp);
	}
}
