using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TogglePause : MonoBehaviour {

	bool toggleCanvas;
	private Image image;

	// Use this for initialization
	void Start () {
		image = GetComponent<UnityEngine.UI.Image>();
	}
	
	// Update is called once per frame
	void Update(){
		if(Input.GetKeyDown("t"))
			image.enabled = !image.enabled;

	}
}
