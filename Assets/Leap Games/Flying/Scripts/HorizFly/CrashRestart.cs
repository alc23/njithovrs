using UnityEngine;
using System.Collections;

public class CrashRestart : MonoBehaviour {
	
	public static int flipped;
	
	void Start(){
		flipped = 0;
	}
	
	void Update(){
		
		//Debug.Log (transform.eulerAngles.x);
		if (transform.eulerAngles.x > 30 && transform.eulerAngles.x <180) {
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
