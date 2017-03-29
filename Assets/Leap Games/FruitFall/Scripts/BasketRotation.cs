using UnityEngine;
using System.Collections;

public class BasketRotation : MonoBehaviour {

	// Use this for initialization
	public static bool allowrotate;

	void OnTriggerEnter (Collider other){
		//if (other.gameObject.tag == "Basket") {
		allowrotate = true;
		//}
	}
	void OnTriggerExit (Collider other){
		//if (other.gameObject.tag == "Basket") {

		allowrotate = !allowrotate;
		//}
		//}
	}
	// Update is called once per frame
	void Update () {
		//Debug.Log (allowrotate);
	}
}
