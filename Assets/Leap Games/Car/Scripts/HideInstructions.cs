using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HideInstructions : MonoBehaviour {

	public bool timerUp = false;
	public float timer;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		timer += Time.deltaTime;

		if (timer > 10f) {
			timerUp = true;
		}
	

		if (timerUp == true) {
			this.gameObject.GetComponent<Image> ().enabled = false;
		}
	}
}
