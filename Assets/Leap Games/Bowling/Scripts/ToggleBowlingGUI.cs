using UnityEngine;
using System.Collections;

public class ToggleBowlingGUI : MonoBehaviour {
		
	public static bool GUIEnabled = false;
	
	void Update () {
		if (Input.GetKeyDown("t")) {
			GUIEnabled = !GUIEnabled;
		}
	}
}
