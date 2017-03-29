using UnityEngine;
using System.Collections;
using System;
using System.IO;
using Leap;

public class RollCalibration1 : MonoBehaviour {
	
	Controller controller;
	
	public float palmxPosition;
	public float palmyPosition;
	public static float xmax;
	public static float xmin;
	public static float compxmax;
	public static float compxmin;
	public GUIText calibrationGUI;
	public static float clampvaluex;
	public static float clampvaluey;
	public static float scaledx;
	public static float scaledy;
	public Sprite square;
	private Vector3 handPosition;


	public static float roll;
	public static float comproll;

	public bool canclick = false;

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

		Debug.Log (roll);


		comproll = PlayerPrefs.GetFloat ("Roll");
		
		Frame frame = controller.Frame ();
		
		foreach (Hand hand in frame.Hands) {
			//Debug.Log (hand.PalmPosition.y);


			clampvaluex = Mathf.Clamp (hand.PalmPosition.x, -230, 230);
			clampvaluey = Mathf.Clamp (hand.PalmPosition.y, 120, 350);
			
			scaledx = scale(-230, 230, -640F, 640F, clampvaluex);
			scaledy = scale(120, 350, -435F, 265F, clampvaluey);

			//Debug.Log (scaled);
			roll = hand.PalmNormal.Roll;
			
			
			if (roll < comproll) {
				canclick = true;
			} else {
				canclick = false;
			}

		}
		
		if (Input.GetKeyDown ("space")) {
			PlayerPrefs.SetFloat ("Roll", 250.0f);
		}
		
	}

	
	IEnumerator ShowMessage (string message, float delay){
		calibrationGUI.text = message;
		calibrationGUI.enabled = true;
		yield return new WaitForSeconds (delay);
		calibrationGUI.enabled = false;
	}
	
	
	public void Calibrate(){
		
		Debug.Log ("Roll: " + roll);
		
		if (canclick == true) {
			PlayerPrefs.SetFloat ("Roll", roll);

			//popup that says that the new value was saved
			StartCoroutine (ShowMessage("New value saved!", 2));

		} else {
			//popup that says that this value is larger than the previous calibration,
			//to override any previous calibrations press the space bar
			StartCoroutine (ShowMessage("Value is larger than previous calibration, to override press spacebar", 3));
		}
	}
}
