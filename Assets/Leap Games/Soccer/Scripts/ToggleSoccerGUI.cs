using UnityEngine;
using System.Collections;

public class ToggleSoccerGUI : MonoBehaviour {
	
	public static bool GUIEnabled = false;
	
	void Update () {
		if (Input.GetKeyDown("t")) {
			GUIEnabled = !GUIEnabled;
		}
	}
}
