using UnityEngine;
using System.Collections;

public class LoadLevel : MonoBehaviour {

	void OnCollisionEnter (Collision col){
		if (col.gameObject.tag == "Player") {
			Application.LoadLevel("FlyingSceneMountain");
		}
	}
}
