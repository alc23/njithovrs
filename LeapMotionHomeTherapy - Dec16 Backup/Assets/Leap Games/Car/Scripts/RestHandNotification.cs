using UnityEngine;
using System.Collections;

public class RestHandNotification : MonoBehaviour {

	public static bool textUp = false;
	public GUIStyle carGUI;

	void OnTriggerEnter(Collider other){
		textUp = true;
	}

	void OnGUI(){
		if (textUp == true) {
			GUI.Label (new Rect (UnityEngine.Screen.width / 2 - 280, UnityEngine.Screen.height - 400, 500, 30), "Close Hand", carGUI);
			//GUI.Label (new Rect (UnityEngine.Screen.width / 2 - 280, UnityEngine.Screen.height - 100, 500, 30), "To Slow Down Car", carGUI);
		}

		if (textUp == false) {
			GUI.Label (new Rect (UnityEngine.Screen.width / 2 - 280, UnityEngine.Screen.height - 400, 500, 30), "Open Hand", carGUI);
		}
	}

	void OnTriggerExit(Collider other){
		textUp = false;
	}
}
