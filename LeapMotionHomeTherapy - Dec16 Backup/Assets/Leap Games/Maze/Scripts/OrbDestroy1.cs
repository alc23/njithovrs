using UnityEngine;
using System.Collections;

public class OrbDestroy1 : MonoBehaviour{

	void OnCollisionEnter (Collision col){
		if (col.gameObject.tag == "Player") {
			Destroy (gameObject);
		}
	}
}