using UnityEngine;
using System.Collections;

public class CollideRestart : MonoBehaviour {
	public static bool reset = false;

	void OnCollisionEnter(Collision col){

		reset = true;
		StartCoroutine (LoadLevel ());
	}


	IEnumerator LoadLevel(){
		yield return new WaitForSeconds (3);
		Application.Quit ();
	}
}
