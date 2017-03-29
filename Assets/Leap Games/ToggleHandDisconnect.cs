using UnityEngine;
using System.Collections;
using Leap;

public class ToggleHandDisconnect : MonoBehaviour {

	public Texture disconnectedImg;

	Controller controller;
	private UnityEngine.UI.Image image;

	void Start (){
		controller = new Controller();
		image = GetComponent<UnityEngine.UI.Image>();
	}

	void Update (){
		image.enabled = false;
		Debug.Log (HandValuesSoccer.invalidhands = false);

		if (HandValuesSoccer.invalidhands = false) {
			image.enabled = true;
		}
	}
}
