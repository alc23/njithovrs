using UnityEngine;
using System.Collections;

public class SphereCollision : MonoBehaviour {

	public bool flag1 = false;
	public bool flag2 = false;
	public bool flag3 = false;
	public static int timescomplete = 0;

	// Use this for initialization
	void Start () {
	
	}


	void OnCollisionEnter() { 
		if (gameObject.tag == "wall1") {
			flag1 = true;
		}
		if (gameObject.tag == "wall2") {
			flag2 = true;
		}
	}

	void Update () {
		if (flag1 == true && flag2 == true) {
			flag3 = true;
		} else {
			flag3 = false;
		}

		if (flag3 == true) {
			flag1 = false;
			flag2 = false;
			timescomplete += 1;
		}
	}
}
