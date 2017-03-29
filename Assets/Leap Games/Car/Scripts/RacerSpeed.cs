using UnityEngine;
using System.Collections;

public class RacerSpeed : MonoBehaviour {


	public float speed;

	public bool slow;



	void OnTriggerStay(Collider other){

		Debug.Log ("collided");
		if (other.gameObject.tag =="Racer") {
			slow = true;
		}
	}

	void OnTriggerExit(Collider other){
		if (other.gameObject.tag == "Racer") {
			slow = false;
		}
	}

	void Update () {
		if (slow == true){
			speed = -3.5f;
		}
		else {
			speed = -8.5f;
		}
		transform.parent.GetComponent<Rigidbody>().velocity = Vector3.forward  *  speed;
		Debug.Log (slow);

	}


}
