using UnityEngine;
using System.Collections;
using Leap;

public class GestureUpDown : MonoBehaviour {
	
	public Texture rotImg;
	public Texture xImg;
	public Texture yImg;
	Controller m_leapController;
	public static float closevalue;
	public static float openvalue;
	public static float clampvalue;
	public static float handsphere;
	public static float scaled;

	public static float scale (float OldMin, float OldMax, float NewMin, float NewMax, float OldValue){
		float OldRange = (OldMax - OldMin);
		float NewRange = (NewMax - NewMin);
		float NewValue = (((OldValue - OldMin) * NewRange) / OldRange) + NewMin;
		
		return (NewValue);
	}

	void Awake(){

		openvalue = PlayerPrefs.GetFloat ("sphereRadiusopen");
		closevalue = PlayerPrefs.GetFloat ("sphereRadiusclose");
	}

	void Start () {

		//insert character animation introduction
		m_leapController = new Controller();
		//pitchflySliderValue = PlayerPrefs.GetFloat ("pitchflySliderValue", pitchflySliderValue);
		//pitchflySliderValue2 = PlayerPrefs.GetFloat ("pitchflySliderValue2", pitchflySliderValue2);
		pitchflySliderValue3 = PlayerPrefs.GetFloat ("pitchflySliderValue3", pitchflySliderValue3);

	}
	
	Hand GetLeftMostHand(Frame f) {
		float smallestVal = float.MaxValue;
		Hand h = null;
		for(int i = 0; i < f.Hands.Count; ++i) {
			if (f.Hands[i].PalmPosition.ToUnity().x < smallestVal) {
				smallestVal = f.Hands[i].PalmPosition.ToUnity().x;
				h = f.Hands[i];
			}
		}
		return h;
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
	
	public static float pitchflySliderValue = 1.0F;
	public static float pitchflySliderValue2 = 0F;
	public static float pitchflySliderValue3 = 10F;
	
	void OnGUI() {
		if (ToggleFlyingGUI.GUIEnabled = !ToggleFlyingGUI.GUIEnabled) {
			//pitchflySliderValue = GUI.HorizontalSlider (new Rect (30, UnityEngine.Screen.height - 120, 200, 30), pitchflySliderValue, 1.0F, 2.0F);
			//GUI.DrawTexture (new Rect (140, UnityEngine.Screen.height - 95, 20, 20), rotImg);
			//pitchflySliderValue2 = GUI.HorizontalSlider (new Rect (30, UnityEngine.Screen.height - 60, 200, 30), pitchflySliderValue2, 0F, 0.4F);
			//GUI.DrawTexture (new Rect (140, UnityEngine.Screen.height - 65, 20, 20), xImg);
			
			pitchflySliderValue3 = GUI.HorizontalSlider (new Rect (30, UnityEngine.Screen.height - 260, 200, 30), pitchflySliderValue3, 5F, 18F);
			
			//GUI.Label(new Rect(30, UnityEngine.Screen.height - 190, 100, 30), "Hand Scaling");
			//GUI.Label(new Rect(30, UnityEngine.Screen.height - 80, 200, 30), "Origin Scale: " + pitchflySliderValue2);
			//GUI.Label(new Rect(30, UnityEngine.Screen.height - 140, 200, 30), "Sensitivity: " + pitchflySliderValue);
			GUI.Label(new Rect(30, UnityEngine.Screen.height - 280, 200, 30), "Flying Speed: " + pitchflySliderValue3);
			if (GUI.Button(new Rect(30, UnityEngine.Screen.height - 340, 200, 30), "Save Scaling"))
				Save ();
			GUI.Label(new Rect(30, UnityEngine.Screen.height - 380, 200, 30), "Leap Pitch Fly Scaling");
			
			
		}
	}
	
	void Update () {

		if (TriggerScore.mazeScore == 1) {
			//insert character animation reminder
		}
		
		Frame frame = m_leapController.Frame();
		float roll =  frame.Hands[0].PalmNormal.Roll; 
		if (frame.Hands.Count >= 1) {
			
			Hand leftHand = GetLeftMostHand (frame);
			Hand rightHand = GetRightMostHand (frame);
			
			
			Vector3 avgPalmForward = frame.Hands [0].Direction.ToUnity ();     
			Vector3 handDiff = rightHand.PalmPosition.ToUnityScaled ();
			
			Vector3 newRot = transform.parent.localRotation.eulerAngles;
			//	newRot.z = roll* 10.0f * gflySliderValue3;
			//	newRot.y += handDiff.x * 100.0f * gflySliderValue2 ;


			
			foreach (Hand hand in frame.Hands) {

				//Debug.Log (clampvalue);

				//clampvalue = Mathf.Clamp (hand.SphereRadius, closevalue, openvalue);
				
				//scaled = scale(closevalue, openvalue, 60F, -60F, clampvalue);

				scaled = scale(openvalue, closevalue, 36F, -70F, hand.SphereRadius);

				//Debug.Log ("scale" + scaled);
				newRot.x = scaled;

				transform.parent.GetComponent<Rigidbody>().velocity = transform.parent.forward  * pitchflySliderValue3;
				
				transform.parent.localRotation = Quaternion.Slerp (transform.parent.localRotation, Quaternion.Euler (newRot), 0.1f);

				}
			}
		}
		
		public void Save(){
			PlayerPrefs.SetFloat ("pitchflySliderValue", pitchflySliderValue);
			PlayerPrefs.SetFloat ("pitchflySliderValue2", pitchflySliderValue2);
			PlayerPrefs.SetFloat ("pitchflySliderValue3", pitchflySliderValue3);
		}
	}