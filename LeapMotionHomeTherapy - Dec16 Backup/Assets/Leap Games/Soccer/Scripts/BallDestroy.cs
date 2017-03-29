using UnityEngine;
using System.Collections;

public class BallDestroy : MonoBehaviour{

	void OnCollisionEnter (Collision col){
		if (col.gameObject.tag == "Finish") {
			Destroy (this.gameObject);
		}
	}
}