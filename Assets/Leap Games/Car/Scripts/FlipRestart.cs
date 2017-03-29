using UnityEngine;
using System.Collections;

public class FlipRestart : MonoBehaviour {

	public static int flipped;

	void Start(){
		flipped = 0;
	}

	void Update(){


		if (Vector3.Dot (transform.up, Vector3.up) < -.8) {
			//Debug.Log ("flipped");
			StartCoroutine (LoadLevel ());
			flipped = 1;
		} else {
			flipped = 0;
		}
	}


	IEnumerator LoadLevel(){
		yield return new WaitForSeconds (2);
		Application.LoadLevel (Application.loadedLevel);
	}
}
