using UnityEngine;
using System.Collections;

public class BasketProximity : MonoBehaviour {
	
	private Light myLight;
	private int count;
	
	void Start(){
		myLight = GetComponent<Light> ();
	}
	
	void OnTriggerEnter (Collider other){
		//if (other.gameObject.tag == "fruit") {
			myLight.enabled = true;
			count = count + 1;
		//}
	}
//
//	void Update(){
//		if (count == 1) {
//			//insert character animation that reminds to drop fruit in the other basket
//		}
//	}

	
	void OnTriggerExit (Collider other){
			myLight.enabled = false;
		}

}
