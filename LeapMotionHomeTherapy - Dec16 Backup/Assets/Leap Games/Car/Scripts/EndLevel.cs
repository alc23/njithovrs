using UnityEngine;
using System.Collections;

public class EndLevel : MonoBehaviour {

	void OnTriggerEnter(Collider other){
		Debug.Log ("collided");
		Application.Quit ();
	}
}
