using UnityEngine;
using System.Collections;

public class DetectApples : MonoBehaviour {

	// Use this for initialization
	void OnCollisionEnter (Collision col){

		if (col.gameObject.tag == "apple") {
			PickFruitScore.AddScore(1);

			//Debug.Log ("correct");
		}

		if (col.gameObject.tag == "Orange") {
			PickFruitScore.AddScore(-1);
		}
	}               
}