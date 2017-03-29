using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TogglePauseMaze : MonoBehaviour {

	private Image image;

	// Use this for initialization
	void Start () {
		image = GetComponent<UnityEngine.UI.Image>();
	}
	
	// Update is called once per frame
	void Update () {

		if (HandValuesMaze.invalidhands =! HandValuesMaze.invalidhands) {
			image.enabled = !image.enabled;
		}
	}
}
