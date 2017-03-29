using UnityEngine;
using System.Collections;

public class RestartOnHit : MonoBehaviour {

	public static bool restarted = false;
	public string levelToLoad;

	void OnTriggerEnter (Collider other){
		if(other.gameObject.tag == "Finish"){
			StartCoroutine(ReloadGame ());
			HandValuesBowl.IncreaseRounds(1);
		}
	}

	IEnumerator ReloadGame (){

		yield return new WaitForSeconds (4);
		restarted = true;
		Application.LoadLevel (levelToLoad);
	}
}