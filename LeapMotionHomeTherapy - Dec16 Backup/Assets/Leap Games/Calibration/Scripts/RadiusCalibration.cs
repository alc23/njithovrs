using UnityEngine;
using System.Collections;
using System;
using System.IO;
using Leap;

public class RadiusCalibration : MonoBehaviour {

	Controller controller;

	public float palmxPosition;
	public float palmyPosition;
	public static float sphereRadiusopen;
	public static float sphereRadiusclose;
	public static float compradiusopen;
	public static float compradiusclose;
	public GUIText calibrationGUI;

	public bool canclickopen = false;
	public bool canclickclose = false;

	// Use this for initialization
	void Start () {
		controller = new Controller ();
	}
	
	// Update is called once per frame
	void Update () {

		compradiusopen = PlayerPrefs.GetFloat ("sphereRadiusopen");
		compradiusclose = PlayerPrefs.GetFloat ("sphereRadiusclose");

		Debug.Log (compradiusclose);
		Debug.Log (compradiusopen);

		Frame frame = controller.Frame ();

		foreach (Hand hand in frame.Hands) {
			sphereRadiusopen =  hand.SphereRadius;
			sphereRadiusclose = hand.SphereRadius;
	

			if (sphereRadiusopen < compradiusopen) {
				canclickopen = true;
			} else {
				canclickopen = false;
			}

			if (sphereRadiusclose < compradiusclose){
				canclickclose = true;
			}else{
				canclickclose = false;
			}
		}

		if (Input.GetKeyDown ("space")) {
			PlayerPrefs.SetFloat ("sphereRadiusopen", 200.0f);
			PlayerPrefs.SetFloat ("sphereRadiusclose", 200.0f);
		}

	}

	public void ClickSaveOpen(){
	

		Debug.Log ("SR = " + sphereRadiusopen);

		//if (sphereRadius < compradius) {
		if (canclickopen == true) {
			PlayerPrefs.SetFloat ("sphereRadiusopen", sphereRadiusopen);

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
	

	public void ClickSaveClose(){
		if (canclickclose == true) {
			PlayerPrefs.SetFloat ("sphereRadiusclose", sphereRadiusclose);
			//popup that says that the new value was saved
			StartCoroutine (ShowMessage("New value saved!", 2));
		} else {
			//popup that says that this value is larger than the previous calibration,
			//to override any previous calibrations press the space bar
			StartCoroutine (ShowMessage("Value is larger than previous calibration, to override press spacebar", 3));
		}
	
	}
}
