using UnityEngine;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using Leap;

public class ScaleBasketMovementLeft : MonoBehaviour {
	
	Controller m_leapController;
	
	public static float percentage;
	public static float success;
	public static float miss;
	public GameObject basket;
	
	public static bool algpercentage = false;
	
	public float timer;

	public float pos;

	public Transform rottarget;

	public GameObject cube;

	public static float calibratedroll;
	public static float originscaled;
	public static float thresholdscaled;

	public static float clampvalue;
	public static float scaled;

	public static float xmax;
	public static float xmin;

	public static float scale (float OldMin, float OldMax, float NewMin, float NewMax, float OldValue){
		float OldRange = (OldMax - OldMin);
		float NewRange = (NewMax - NewMin);
		float NewValue = (((OldValue - OldMin) * NewRange) / OldRange) + NewMin;
		
		return (NewValue);
	}
	
	void Start (){

		xmax = PlayerPrefs.GetFloat ("xMax");
		xmin = PlayerPrefs.GetFloat ("xMin");

		calibratedroll = PlayerPrefs.GetFloat ("Roll");

		m_leapController = new Controller();
//		fruitSliderValue = PlayerPrefs.GetFloat ("fruitSliderValue", fruitSliderValue);
//		fruitSliderValue2 = PlayerPrefs.GetFloat ("fruitSliderValue2", fruitSliderValue2);		
//		fruitSliderValue3 = PlayerPrefs.GetFloat ("fruitSliderValue3", fruitSliderValue3);
//		vScrollbarValue = PlayerPrefs.GetFloat ("vScrollbarValue", vScrollbarValue);
//		vScrollbarValue2 = PlayerPrefs.GetFloat ("vScrollbarValue2", vScrollbarValue2);


		catchSliderValue = PlayerPrefs.GetFloat ("catchSliderValue", catchSliderValue);
		catchSliderValue2 = PlayerPrefs.GetFloat ("catchSliderValue", catchSliderValue2);
	}
	
	Hand GetRightMostHand(Frame f) {
		float largestVal = -float.MaxValue;
		Hand h = null;
		for(int i = 0; i < f.Hands.Count; ++i) {
			if (f.Hands[i].PalmPosition.ToUnity().x > largestVal) {
				largestVal = f.Hands[i].PalmPosition.ToUnity().x;
				h = f.Hands[i];
			}
		}
		return h;
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
//	public static float vScrollbarValue = 3.0f;
//	public static float vScrollbarValue2 = 3.0f;
	public static float catchSliderValue = -0.5f;
	public static float catchSliderValue2 = 1.0f;
	
	public Texture rotImg;
	public Texture xImg;
	public Texture yImg;
	
	void OnGUI() {
		
		if (ToggleGUI.GUIEnabled = !ToggleGUI.GUIEnabled) {

//			fruitSliderValue = GUI.HorizontalSlider (new Rect (30, UnityEngine.Screen.height - 150, 200, 50), fruitSliderValue, 1.0F, 40.0F);
//			GUI.DrawTexture (new Rect (240, UnityEngine.Screen.height - 155, 20, 20), rotImg);	
//			fruitSliderValue2 = GUI.HorizontalSlider (new Rect (30, UnityEngine.Screen.height - 90, 200, 50),fruitSliderValue2, 1.0F, 40.0F);
//			GUI.DrawTexture (new Rect (240, UnityEngine.Screen.height - 95, 20, 20), yImg);
//			fruitSliderValue3 = GUI.HorizontalSlider (new Rect (30, UnityEngine.Screen.height - 30, 200, 30), fruitSliderValue3, 1.0F, 60.0F);
//			GUI.DrawTexture (new Rect (240, UnityEngine.Screen.height - 35, 20, 20), xImg);
//			
//			vScrollbarValue = GUI.HorizontalSlider (new Rect (30, UnityEngine.Screen.height - 270, 200, 30), vScrollbarValue, -5.0f, 5.0f);
//			vScrollbarValue2 = GUI.HorizontalSlider (new Rect (30, UnityEngine.Screen.height - 330, 200, 30), vScrollbarValue2, .8f, 2.8f);
//			
//			

			catchSliderValue = GUI.HorizontalSlider (new Rect (30, UnityEngine.Screen.height -150, 200, 50), catchSliderValue, -1, -0.5f);
			GUI.DrawTexture (new Rect (240, UnityEngine.Screen.height - 155, 20, 20), rotImg);
			GUI.Label(new Rect(30, UnityEngine.Screen.height - 170, 200, 30), "Palm Upright Scale: " + catchSliderValue);

			catchSliderValue2 = GUI.HorizontalSlider (new Rect (30, UnityEngine.Screen.height -90, 200, 50), catchSliderValue2, 0, 40f);
			GUI.DrawTexture (new Rect (240, UnityEngine.Screen.height - 95, 20, 20), rotImg);
			GUI.Label(new Rect(30, UnityEngine.Screen.height - 110, 200, 30), "Origin Scale: " + catchSliderValue2);

//			GUI.Label(new Rect(30, UnityEngine.Screen.height - 50, 200, 30), "Horizontal Scale: " + fruitSliderValue3);
//			GUI.Label(new Rect(30, UnityEngine.Screen.height - 110, 200, 30), "Vertical Scale: " + fruitSliderValue2);
//			GUI.Label(new Rect(30, UnityEngine.Screen.height - 170, 200, 30), "Rotation Scale: " + fruitSliderValue);
//			GUI.Label(new Rect(30, UnityEngine.Screen.height - 230, 200, 30), "Hand Scaling");
//			
//			GUI.Label(new Rect(30, UnityEngine.Screen.height - 290, 200, 30), "Basket Position");
//			GUI.Label(new Rect(30, UnityEngine.Screen.height - 350, 200, 30), "Basket Scale");
//			GUI.Label(new Rect(30, UnityEngine.Screen.height - 420, 200, 30), "Basket Scaling");
//			GUI.Label(new Rect(30, UnityEngine.Screen.height - 520, 200, 30), "Fruit Scaling");
//			
			if (GUI.Button(new Rect(30, UnityEngine.Screen.height - 210, 200, 30), "Save Scaling"))
				Save ();
		}
	}

	public void Preset1(){
//		catchSliderValue = 30.0f;
//		catchSliderValue2 = 50.0f;

	}
	
	public void Preset2(){
//		catchSliderValue = 15.0f;
//		catchSliderValue2 = 30.0f;

	}
	
	public void Preset3(){
//		catchSliderValue = 1.0f;
//		catchSliderValue2 = 10.0f;

		
	}

	public void Save()
	{
		PlayerPrefs.SetFloat ("catchSliderValue", catchSliderValue);
		PlayerPrefs.SetFloat ("catchSliderValue2", catchSliderValue2);
//		PlayerPrefs.SetFloat ("fruitSliderValue", fruitSliderValue);
//		PlayerPrefs.SetFloat ("fruitSliderValue2", fruitSliderValue2);		
//		PlayerPrefs.SetFloat ("fruitSliderValue3", fruitSliderValue3);
//		PlayerPrefs.SetFloat ("vScrollbarValue", vScrollbarValue);
//		PlayerPrefs.SetFloat ("vScrollbarValue2", vScrollbarValue2);
	}
	
//	void Update (){
//
////		Debug.Log (basket.transform.eulerAngles);
//		
//	//	basket.transform.localScale = new Vector3 (vScrollbarValue2, 2, 2);
//		
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
//	}
	
	IEnumerator alg(){
		success = 0;
		miss = 0;


		yield return null;
	}

	void FixedUpdate () {
		timer = Time.deltaTime;
		
		percentage = success / (success + miss);
		
		if (percentage < 0.75f) {
			bool algpercentage = true;
			//fruitSliderValue = fruitSliderValue + 0.96f;
			//fruitSliderValue2 = fruitSliderValue2 + 1.2f;
			//fruitSliderValue3 = fruitSliderValue3 + 1.8f;
			algpercentage = false;
			StartCoroutine(alg ());
			
		} else if (percentage == 0) {
			bool algpercentage = false;
		} else {
			bool algpercentage = false;
		}
		

		Frame frame = m_leapController.Frame ();
		float roll = frame.Hands [0].PalmNormal.Roll; 
		
		if (frame.Hands.Count >= 1) {
			//Hand leftHand = GetLeftMostHand(frame);
			Hand rightHand = GetRightMostHand (frame);
			
			Vector3 avgPalmForward = frame.Hands [0].Direction.ToUnity ();     
			Vector3 handDiff = rightHand.PalmPosition.ToUnityScaled ();
			
			Vector3 newRot = transform.parent.localRotation.eulerAngles;
			newRot.z = roll;
			
			Vector3 newPos = transform.parent.localPosition;
			//newPos.z = handDiff.z * fruitSliderValue2 *1.5f ;
			//newPos.x = handDiff.x * fruitSliderValue3 *1.5f;
			newPos.y = handDiff.y * 30f;
			
			foreach (Hand hand in frame.Hands) {

				clampvalue = Mathf.Clamp (hand.PalmPosition.x, xmin, xmax);
				
				scaled = scale(xmin, xmax, -10F, 10F, clampvalue);

				//Vector3 to = new Vector3(90,270, 0);
				Vector3 orig = new Vector3(0,0,0);

//				Vector3 to = basket.transform.localRotation.eulerAngles;
//				//to.x = (Mathf.Abs (roll) * 150f);
//
//				to.z = roll *-150f;
//				to.x = 0f;
//				to.y = 0f;

				float posx = hand.PalmPosition.x;
				float posz = hand.PalmPosition.z;

				//Vector3 newbasketrot = basket.transform.localRotation.eulerAngles;
				//newbasketrot.z = (3-roll) * 50.0f;
				
				//basket.transform.position = new Vector3 (-5 +pinch * 10f, -1,0);

				//cube.transform.position  = new Vector3 (-6, -5 * hand.PalmNormal.Roll, -3.5f);

//				if(hand.PalmNormal.x > -0.5f && hand.PalmNormal.y > -0.2f && hand.PalmNormal.z > -0.2f){
//				basket.transform.position = new Vector3 (posx/12, 1.2f, 0 + -posz /14);
//				}

//				if(hand.PalmNormal.x > catchSliderValue && hand.PalmNormal.y > -0.2f && hand.PalmNormal.z > -0.2f){
//						basket.transform.position = new Vector3 (posx/12, 1.2f, 0 - (posz /14));
//				}
				if(hand.PalmNormal.x > thresholdscaled && hand.PalmNormal.y > -0.2f && hand.PalmNormal.z > -0.2f){
					basket.transform.position = new Vector3 (scaled, 1.2f, 0 - (posz /14));
				}
				
				//originclampvalue = Mathf.Clamp (, -230, 230);
			
				originscaled = scale(3F, 1.5F, 1f, 40F, calibratedroll);
				thresholdscaled = scale (3F, 1.5F, -0.8f, -1.5f, calibratedroll);



				Debug.Log (originscaled);
				
//				Debug.Log (roll);
				//if(BasketRotation.allowrotate == true){
				//	if(hand.PalmNormal.y <-.2){
				//basket.transform.Rotate(Vector3.down * ((0- hand.PalmNormal.Roll)/10));
						//basket.transform.localRotation = Quaternion.Slerp (basket.transform.localRotation, Quaternion.Euler (to), Time.deltaTime);
					//}

					//	basket.transform.rotation = Quaternion.AngleAxis (-105-(roll*35f), Vector3.back);
					//basket.transform.rotation = Quaternion.Euler (new Vector3 (0,0, 180-catchSliderValue2-((Mathf.Abs (roll))*65f)));
					//Debug.Log (Mathf.Abs (roll));

				basket.transform.rotation = Quaternion.Euler (new Vector3 (0,0, 180+originscaled+((Mathf.Abs (roll))*65f)));

//					Vector3 relativepos = rottarget.position - transform.position;
//					basket.transform.rotation = Quaternion.LookRotation (relativepos);
//				
//					basket.transform.position = Vector3.Lerp (transform.parent.localPosition, newPos, 0.1f);
					//}
				//}

				//else {
				//	basket.transform.eulerAngles = orig;
				//}

			}

				//basket.transform.Rotate (Vector3.down * ((3- hand.PalmNormal.Roll)/10));
				//Debug.Log (hand.PalmNormal.Roll);
				//basket.transform.localRotation = Quaternion.Slerp(basket.transform.localRotation, Quaternion.Euler(newbasketrot), 0.1f);
			}
			
//			transform.parent.localRotation = Quaternion.Slerp (transform.parent.localRotation, Quaternion.Euler (newRot), 0.1f);
//			transform.parent.localPosition = Vector3.Lerp (transform.parent.localPosition, newPos, 0.1f);
//			
			//transform.parent.GetComponent<Rigidbody>().velocity = transform.parent.forward * forceMult;
		}
	}

		

