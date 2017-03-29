using UnityEngine;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using Leap;

public class PickFruitHandScaling : MonoBehaviour {
	
	Controller m_leapController;
	
	public static float percentage;
	public static float success;
	public static float miss;
	public GameObject basket;

	public bool algpercentage = false;
	
	public float timer;

	public static float clampvalue;
	public static float scaled;
	public static float xmin;
	public static float xmax;

	public static float scale (float OldMin, float OldMax, float NewMin, float NewMax, float OldValue){
		float OldRange = (OldMax - OldMin);
		float NewRange = (NewMax - NewMin);
		float NewValue = (((OldValue - OldMin) * NewRange) / OldRange) + NewMin;
		
		return (NewValue);
	}

	void Start (){

		xmin = PlayerPrefs.GetFloat ("xMin");
		xmax = PlayerPrefs.GetFloat ("xMax");
		m_leapController = new Controller();
//		fruitSliderValue = PlayerPrefs.GetFloat ("fruitSliderValue", fruitSliderValue);
//		fruitSliderValue2 = PlayerPrefs.GetFloat ("fruitSliderValue2", fruitSliderValue2);		
//		fruitSliderValue3 = PlayerPrefs.GetFloat ("fruitSliderValue3", fruitSliderValue3);
		//vScrollbarValue = PlayerPrefs.GetFloat ("vScrollbarValue", vScrollbarValue);
		//vScrollbarValue2 = PlayerPrefs.GetFloat ("vScrollbarValue2", vScrollbarValue2);
	}

	
	public static void IncreaseScore (float Amount){
		success += Amount;
	}
	
	public static void IncreaseMiss (float Amount){
		miss += Amount;
	}
	
//	public static float fruitSliderValue = 1.0F;
//	public static float fruitSliderValue2 = 1.0F;
//	public static float fruitSliderValue3 = 1.0F;
	// static float vScrollbarValue = 3.0f;
	//public static float vScrollbarValue2 = 3.0f;
	
	public Texture rotImg;
	public Texture xImg;
	public Texture yImg;
	
	void OnGUI() {
		
		if (ToggleGUI.GUIEnabled = !ToggleGUI.GUIEnabled) {
			
//			fruitSliderValue = GUI.HorizontalSlider (new Rect (30, UnityEngine.Screen.height - 150, 200, 50), fruitSliderValue, 1.0F, 40.0F);
//			GUI.DrawTexture (new Rect (240, UnityEngine.Screen.height - 155, 20, 20), rotImg);	
//			fruitSliderValue2 = GUI.HorizontalSlider (new Rect (30, UnityEngine.Screen.height - 90, 200, 50),fruitSliderValue2, 1.0F, 50.0F);
//			GUI.DrawTexture (new Rect (240, UnityEngine.Screen.height - 95, 20, 20), yImg);
//			fruitSliderValue3 = GUI.HorizontalSlider (new Rect (30, UnityEngine.Screen.height - 30, 200, 30), fruitSliderValue3, 1.0F, 70.0F);
//			GUI.DrawTexture (new Rect (240, UnityEngine.Screen.height - 35, 20, 20), xImg);
			
			//vScrollbarValue = GUI.HorizontalSlider (new Rect (30, UnityEngine.Screen.height - 270, 200, 30), vScrollbarValue, -5.0f, 5.0f);
			//vScrollbarValue2 = GUI.HorizontalSlider (new Rect (30, UnityEngine.Screen.height - 330, 200, 30), vScrollbarValue2, .8f, 2.8f);
			
			
//			GUI.Label(new Rect(30, UnityEngine.Screen.height - 50, 200, 30), "Horizontal Scale: " + fruitSliderValue3);
//			GUI.Label(new Rect(30, UnityEngine.Screen.height - 110, 200, 30), "Vertical Scale: " + fruitSliderValue2);
//			GUI.Label(new Rect(30, UnityEngine.Screen.height - 170, 200, 30), "Rotation Scale: " + fruitSliderValue);
//			GUI.Label(new Rect(30, UnityEngine.Screen.height - 230, 200, 30), "Hand Scaling");
			
		//	GUI.Label(new Rect(30, UnityEngine.Screen.height - 290, 200, 30), "Basket Position");
		//	GUI.Label(new Rect(30, UnityEngine.Screen.height - 350, 200, 30), "Basket Scale");
		//	GUI.Label(new Rect(30, UnityEngine.Screen.height - 420, 200, 30), "Basket Scaling");
//			GUI.Label(new Rect(30, UnityEngine.Screen.height - 520, 200, 30), "Fruit Scaling");
//			
//			if (GUI.Button(new Rect(30, UnityEngine.Screen.height - 210, 200, 30), "Save Hand Scaling"))
//				Save ();
		}
	}

//	public void Preset1(){
//		fruitSliderValue = 30.0f;
//		fruitSliderValue2 = 50.0f;
//		fruitSliderValue2 = 70.0f;
//	}
//
//	public void Preset2(){
//		fruitSliderValue = 15.0f;
//		fruitSliderValue2 = 30.0f;
//		fruitSliderValue3 = 50.0f;
//	}
//
//	public void Preset3(){
//		fruitSliderValue = 1.0f;
//		fruitSliderValue2 = 10.0f;
//		fruitSliderValue3 = 20.0f;
//
//	}
	public void Save()
	{
//		PlayerPrefs.SetFloat ("fruitSliderValue", fruitSliderValue);
//		PlayerPrefs.SetFloat ("fruitSliderValue2", fruitSliderValue2);		
//		PlayerPrefs.SetFloat ("fruitSliderValue3", fruitSliderValue3);
		//PlayerPrefs.SetFloat ("vScrollbarValue", vScrollbarValue);
		//PlayerPrefs.SetFloat ("vScrollbarValue2", vScrollbarValue2);
	}
	
	void Update (){
		
		//basket.transform.localPosition = new Vector3 (vScrollbarValue, -1,-3);
		//basket.transform.localScale = new Vector3 (vScrollbarValue2,2, 2);
		
//		timer = Time.deltaTime;
//		
//		percentage = success / (success + miss);
//		
//		if (percentage < 0.75f) {
//			bool algpercentage = true;
//			//fruitSliderValue = fruitSliderValue + 0.96f;
//			//fruitSliderValue2 = fruitSliderValue2 + 1.2f;
//			//fruitSliderValue3 = fruitSliderValue3 + 1.8f;
//			algpercentage = false;
//			StartCoroutine(alg ());
//			
//		} else if (percentage == 0) {
//			bool algpercentage = false;
//		} else {
//			bool algpercentage = false;
//		}

	}

//	
//	IEnumerator alg(){
//		success = 0;
//		miss = 0;
//		yield return null;
//	}
	
	void FixedUpdate () {
		
		Frame frame = m_leapController.Frame ();
		float roll = frame.Hands [0].PalmNormal.Roll; 
		
		if (frame.Hands.Count >= 1) {

			
			Vector3 newRot = transform.parent.localRotation.eulerAngles;
			newRot.z = roll;
			
			Vector3 newPos = transform.parent.localPosition;
		//	newPos.z = handDiff.z * fruitSliderValue2 *1.5f;
			newPos.x = scaled;


			foreach (Hand hand in frame.Hands) {

				newPos.z = -hand.PalmPosition.z/10;
				newPos.y = (hand.PalmPosition.y/1000)-2;
				
				scaled = scale(xmin, xmax, -15F, 15F,hand.PalmPosition.x);
			}
			transform.parent.localRotation = Quaternion.Slerp (transform.parent.localRotation, Quaternion.Euler (newRot), 0.1f);
			transform.parent.localPosition = Vector3.Lerp (transform.parent.localPosition, newPos, 0.1f);
			
			//transform.parent.GetComponent<Rigidbody>().velocity = transform.parent.forward * forceMult;
		}
	}
}	