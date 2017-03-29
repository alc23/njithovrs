using UnityEngine;
using System.Collections;

public class NextFlyingLevel : MonoBehaviour {

	public string levelToLoad = " ";
	
	public void OnTriggerEnter (Collider other){
		if (other.gameObject.tag == "Player") {
			Application.LoadLevel (levelToLoad);
			Debug.Log("HIT");
		}
	}
}