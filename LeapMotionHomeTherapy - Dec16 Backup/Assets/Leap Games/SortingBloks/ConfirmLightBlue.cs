using UnityEngine;
using System.Collections;

public class ConfirmLightBlue : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}



	void OnCollisionEnter(Collision col){
		if (col.gameObject.tag == "Finish") {
		GetComponent<Renderer>().material.color = Color.blue;
		}
	}
	


}
