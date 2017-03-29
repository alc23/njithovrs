using UnityEngine;
using System.Collections;

public class Destroy : MonoBehaviour
{
	void OnCollisionEnter (Collision col){
//		if (col.gameObject.tag == "Basket") {
//			Destroy (gameObject);
//		}

		if (col.gameObject.tag == "Finish") {
			Destroy (gameObject);
		}
	}
}