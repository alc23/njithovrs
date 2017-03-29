using UnityEngine;
using System.Collections;

public class EndLevel : MonoBehaviour {

	void OnCollisionEnter(Collision col){
		Debug.Log ("collided");
		Application.Quit ();
	}
}
