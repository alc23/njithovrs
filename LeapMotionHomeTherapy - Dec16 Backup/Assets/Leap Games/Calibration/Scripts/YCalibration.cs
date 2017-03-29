using UnityEngine;
using System.Collections;
using System;
using System.IO;
using Leap;

public class YCalibration : MonoBehaviour {
	
	Controller controller;
	
	public float palmxPosition;
	public float palmyPosition;
	public static float ymax;
	public static float ymin;
	public static float compymax;
	public static float compymin;
	public GUIText calibrationGUI;
	public static float clampvalue;
	public static float scaled;
	public Sprite square;
	private Vector3 handPosition;
	
	public bool canclickmax = false;
	public bool canclickmin = false;

	public static float scale (float OldMin, float OldMax, float NewMin, float NewMax, float OldValue){
		float OldRange = (OldMax - OldMin);
		float NewRange = (NewMax - NewMin);
		float NewValue = (((OldValue - OldMin) * NewRange) / OldRange) + NewMin;
		
		return (NewValue);
	}

	//new range aka square value is mapped from -692 to 692
	//old range is leap hand position x valye from -250 to 250


	
	// Use this for initialization
	void Start () {
		controller = new Controller ();
	}
	
	// Update is called once per frame
	void Update () {

		
		compymax = PlayerPrefs.GetFloat ("yMax");
		compymin = PlayerPrefs.GetFloat ("yMin");
		
		Frame frame = controller.Frame ();
		
		foreach (Hand hand in frame.Hands) {


			clampvalue = Mathf.Clamp (hand.PalmPosition.y, 90, 350);
			
			scaled = scale(90, 350, -428F, 294F, clampvalue);

			//Debug.Log (scaled);
			ymin = hand.PalmPosition.y;
			ymax = hand.PalmPosition.y;
			
			
			if (ymax < compymax) {
				canclickmax = true;
			} else {
				canclickmax = false;
			}
			
			if (ymin > compymin){
				canclickmin = true;
			}else{
				canclickmin = false;
			}
		}
		
		if (Input.GetKeyDown ("space")) {
			PlayerPrefs.SetFloat ("yMax", 500.0f);
			PlayerPrefs.SetFloat ("yMin", -500.0f);
		}
		
	}
	
	public void ClickSaveUp(){
		
		
		//Debug.Log ("Max: " + ymax);
		
		//if (sphereRadius < compradius) {
		if (canclickmax == true) {
			PlayerPrefs.SetFloat ("yMax", ymax);
			
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
		
		//Debug.Log ("Min: " + ymin);
		
		if (canclickmin == true) {
			PlayerPrefs.SetFloat ("yMin", ymin);

			//popup that says that the new value was saved
			StartCoroutine (ShowMessage("New value saved!", 2));

		} else {
			//popup that says that this value is larger than the previous calibration,
			//to override any previous calibrations press the space bar
			StartCoroutine (ShowMessage("Value is larger than previous calibration, to override press spacebar", 3));
		}
	}
}
