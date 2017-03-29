using UnityEngine;
using System.Collections;
using System;
using System.IO;
using Leap;

public class PitchCalibration : MonoBehaviour {

	Controller controller;

	public float palmxPosition;
	public float palmyPosition;
	public static float pitchUp;
	public static float pitchDown;
	public static float comppitchup;
	public static float comppitchdown;
	public GUIText calibrationGUI;

	public bool canclickup = false;
	public bool canclickdown = false;

	// Use this for initialization
	void Start () {
		controller = new Controller ();
	}
	
	// Update is called once per frame
	void Update () {

		comppitchup = PlayerPrefs.GetFloat ("pitchUp");
		comppitchdown = PlayerPrefs.GetFloat ("pitchDown");

		Frame frame = controller.Frame ();

		foreach (Hand hand in frame.Hands) {
			pitchDown = hand.Direction.Pitch;
			pitchUp = hand.Direction.Pitch;
	

			if (pitchUp < comppitchup) {
				canclickup = true;
			} else {
				canclickup = false;
			}

			if (pitchDown < comppitchdown){
				canclickdown = true;
			}else{
				canclickdown = false;
			}
		}

		if (Input.GetKeyDown ("space")) {
			PlayerPrefs.SetFloat ("pitchUp", 200.0f);
			PlayerPrefs.SetFloat ("pitchDown", 200.0f);
		}

	}

	public void ClickSaveUp(){
	

		Debug.Log ("UP: " + pitchUp);

		//if (sphereRadius < compradius) {
		if (canclickup == true) {
			PlayerPrefs.SetFloat ("pitchUp", pitchUp);

			//popup that says that the new value was saved
			StartCoroutine (ShowMessage("New value saved!", 2));

		} else {
			//popup that says that this value is larger than the previous calibration,
			//to override any previous calibrations press the space bar
			StartCoroutine (ShowMessage("Value is larger than previous calibration, to override press spacebar", 3));
		}
	}

	IEnumerator ShowMessage (string message, float delay){
		calibrationGUI.text = message;
		calibrationGUI.enabled = true;
		yield return new WaitForSeconds (delay);
		calibrationGUI.enabled = false;
	}
	

	public void ClickSaveDown(){

		Debug.Log ("Down: " + pitchDown);

		if (canclickdown == true) {
			PlayerPrefs.SetFloat ("pitchDown", pitchDown);
		
			//popup that says that the new value was saved
			StartCoroutine (ShowMessage("New value saved!", 2));
		} else {
			//popup that says that this value is larger than the previous calibration,
			//to override any previous calibrations press the space bar
			StartCoroutine (ShowMessage("Value is larger than previous calibration, to override press spacebar", 3));
		}
	}
}
