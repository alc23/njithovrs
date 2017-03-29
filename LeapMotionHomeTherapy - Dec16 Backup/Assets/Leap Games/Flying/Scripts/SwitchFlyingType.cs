using UnityEngine;
using System.Collections;

public class SwitchFlyingType : MonoBehaviour {

	public GameObject gobject;
	LeapFlyOneHand script;
	LeapFlyGesture script2;

	void OnGUI() {
		if (GUI.Button (new Rect (UnityEngine.Screen.width - 145, UnityEngine.Screen.height - 30, 60 , 30), "Gesture")) {
			script = gobject.GetComponent<LeapFlyOneHand>();
			script.enabled = false;
			script2 = gobject.GetComponent<LeapFlyGesture>();
			script2.enabled = true;

			LeapFlyGesture.gflySliderValue = PlayerPrefs.GetFloat ("gflySliderValue", LeapFlyGesture.gflySliderValue);
			LeapFlyGesture.gflySliderValue2 = PlayerPrefs.GetFloat ("gflySliderValue2", LeapFlyGesture.gflySliderValue2);
			LeapFlyGesture.gflySliderValue3 = PlayerPrefs.GetFloat ("gflySliderValue3", LeapFlyGesture.gflySliderValue3);
		}
		
		if (GUI.Button (new Rect (UnityEngine.Screen.width - 80, UnityEngine.Screen.height - 30, 60 , 30), "Position")) {

			script = gobject.GetComponent<LeapFlyOneHand>();

			script.enabled = true;

			script2 = gobject.GetComponent<LeapFlyGesture>();
		
			script2.enabled = false;

			LeapFlyOneHand.pflySliderValue = PlayerPrefs.GetFloat ("pflySliderValue", LeapFlyOneHand.pflySliderValue);
			LeapFlyOneHand.pflySliderValue2 = PlayerPrefs.GetFloat ("pflySliderValue2", LeapFlyOneHand.pflySliderValue2);
			LeapFlyOneHand.pflySliderValue3 = PlayerPrefs.GetFloat ("pflySliderValue3", LeapFlyOneHand.pflySliderValue3);
		}

		Rigidbody rb = GetComponent <Rigidbody> ();
		GUI.Label (new Rect (UnityEngine.Screen.width - 130, UnityEngine.Screen.height - 60, 100, 30), "Speed: " + rb.velocity.magnitude*3);
	}
}