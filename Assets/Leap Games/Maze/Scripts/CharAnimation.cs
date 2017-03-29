using UnityEngine;
using System.Collections;

public class CharAnimation : MonoBehaviour {
	private Animator anim;

	void Start () {
		anim = this.gameObject.GetComponent<Animator> ();
	}

	void Update () {
		Rigidbody rb = GetComponent <Rigidbody> ();
		float vel = rb.velocity.magnitude;

		if (rb.velocity.magnitude == 0) {
			anim.SetInteger ("Speed", 0);
		}else anim.SetInteger ("Speed", 2);

		if (vel >10){
			//insert character animation that says character has fallen, try again from the beginning of the level
		}
	}
}
