using UnityEngine;
using System.Collections;

public class ChangeColorCollision : MonoBehaviour {

	void OnCollisionEnter(Collision col){
		//if (col.gameObject.tag == "") {
			GetComponent<Renderer>().material.color = Color.green;
		//}
	}

	void OnCollisionExit (Collision col){
		//if (col.gameObject.tag == "") {
			GetComponent<Renderer> ().material.color = Color.white;
		//}
	}

}
