using UnityEngine;
using System.Collections;

public class RacerSpeed : MonoBehaviour {


	public float speed;

	void Update () {
		transform.parent.GetComponent<Rigidbody>().velocity = Vector3.forward  *  -8.5f;
	}

}
