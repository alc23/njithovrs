using UnityEngine;
using System.Collections;

public class GroundCollision : MonoBehaviour {

	public static int blockSuccess;

	void OnCollisionEnter (Collision col){
			ScaleSoccer.IncreaseScore(1);
		blockSuccess ++;
	}
}