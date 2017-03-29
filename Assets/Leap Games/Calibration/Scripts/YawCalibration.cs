using UnityEngine;
using System.Collections;
using System;
using System.IO;
using Leap;

public class YawCalibration : MonoBehaviour {
	
	Controller controller;
	
	//public float palmxPosition;
	//public float palmyPosition;
	public static float yawMax;
	public static float yawMin;
	public static float compyawup;
	public static float compyawdown;
	public GUIText calibrationGUI;
	
	public bool canclickup = false;
	public bool canclickdown = false;
	
	// Use this for initialization
	void Start () {
		controller = new Controller ();
	}
	
	// Update is called once per frame
	void Update () {

		
		compyawup = PlayerPrefs.GetFloat ("yawMax");
		compyawdown = PlayerPrefs.GetFloat ("yawMin");

		Debug.Log (compyawup + compyawdown);
		
		Frame frame = controller.Frame ();
		
		foreach (Hand hand in frame.Hands) {
			yawMin = hand.Direction.Pitch;
			yawMax = hand.Direction.Pitch;
			
			
			if (yawMax < compyawup) {
				canclickup = true;
			} else {
				canclickup = false;
			}
			
			if (yawMin < compyawdown){
				canclickdown = true;
			}else{
				canclickdown = false;
			}
		}
		
		if (Input.GetKeyDown ("space")) {
			PlayerPrefs.SetFloat ("yawMax", 200.0f);
			PlayerPrefs.SetFloat ("yawMin", 200.0f);
		}
		
	}
	
	public void ClickSaveUp(){
		
		
		//Debug.Log ("UP: " + pitchUp);
		
		//if (sphereRadius < compradius) {
		if (canclickup == true) {
			PlayerPrefs.SetFloat ("yawMax", yawMax);
			
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
		
		//Debug.Log ("Down: " + yawMin);
		
		if (canclickdown == true) {
			PlayerPrefs.SetFloat ("yawMin", yawMin);
			
			//popup that says that the new value was saved
			StartCoroutine (ShowMessage("New value saved!", 2));
		} else {
			//popup that says that this value is larger than the previous calibration,
			//to override any previous calibrations press the space bar
			StartCoroutine (ShowMessage("Value is larger than previous calibration, to override press spacebar", 3));
		}
	}
}
