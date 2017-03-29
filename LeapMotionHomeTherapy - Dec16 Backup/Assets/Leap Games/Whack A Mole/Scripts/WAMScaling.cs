using UnityEngine;
using System.Collections;
using Leap;

public class WAMScaling : MonoBehaviour {
	
	Controller m_leapController;
	Hand hand;
	public Texture disconnectedImg;
	public bool handinvalid;

	public static float calibratedroll;
	public static float originscaled;
	public static float thresholdscaled;
	
	public static float clampvalue;
	public static float scaled;
	public static float clampvalueroll;
	public static float scaledroll;
	
	public static float xmax;
	public static float xmin;
	public static float maxroll;

	void Start () {
		m_leapController = new Controller();
		maxroll = PlayerPrefs.GetFloat ("Roll");
		xmax = PlayerPrefs.GetFloat ("xMax");
		xmin = PlayerPrefs.GetFloat ("xMin");
		wamSliderValue = PlayerPrefs.GetFloat ("wamSliderValue", wamSliderValue);
		wamSliderValue2 = PlayerPrefs.GetFloat ("wamSliderValue2", wamSliderValue2);
		wamSliderValue3 = PlayerPrefs.GetFloat ("wamSliderValue3", wamSliderValue3);
		wamSliderValue4 = PlayerPrefs.GetFloat ("wamSliderValue4", wamSliderValue4);
		wamSliderValue5 = PlayerPrefs.GetFloat ("wamSliderValue5", wamSliderValue5);
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

	public static float wamSliderValue = 1.0F;
	public static float wamSliderValue2 = 1.0F;
	public static float wamSliderValue3 = 1.0F;
	public static float wamSliderValue4;
	public static float wamSliderValue5;
	
	public Texture rotImg;
	public Texture xImg;
	public Texture yImg;
	public Texture timerImg;

	public static float scale (float OldMin, float OldMax, float NewMin, float NewMax, float OldValue){
		float OldRange = (OldMax - OldMin);
		float NewRange = (NewMax - NewMin);
		float NewValue = (((OldValue - OldMin) * NewRange) / OldRange) + NewMin;
		
		return (NewValue);
	}

	void OnGUI() {
		if (ToggleWAMGUI.GUIEnabled = !ToggleWAMGUI.GUIEnabled) {
		
			wamSliderValue = GUI.HorizontalSlider (new Rect (30, UnityEngine.Screen.height - 240, 200, 30), wamSliderValue, 2.0F, 12.0F);
			//GUI.DrawTexture (new Rect (240, UnityEngine.Screen.height - 245, 20, 20), rotImg);	
			//wamSliderValue2 = GUI.HorizontalSlider (new Rect (30, UnityEngine.Screen.height - 180, 200, 30), wamSliderValue2, 1.0F, 40.0F);
			//GUI.DrawTexture (new Rect (240, UnityEngine.Screen.height - 185, 20, 20), yImg);
			//wamSliderValue3 = GUI.HorizontalSlider (new Rect (30, UnityEngine.Screen.height - 120, 200, 30), wamSliderValue3, 1.0F, 60.0F);
			//GUI.DrawTexture (new Rect (240, UnityEngine.Screen.height - 125, 20, 20), xImg);

			wamSliderValue4 = GUI.HorizontalSlider (new Rect (30, UnityEngine.Screen.height - 340, 200, 30), wamSliderValue4, 0.2F, 4.0F);
			GUI.DrawTexture (new Rect (240, UnityEngine.Screen.height - 345, 20, 20), timerImg);

			wamSliderValue5 = GUI.HorizontalSlider (new Rect (30, UnityEngine.Screen.height - 60, 200, 50), wamSliderValue5, -2.0F, -1.0F);


			//GUI.Label (new Rect (30, UnityEngine.Screen.height - 140,200, 30), "Horizontal Scale: " + wamSliderValue3);
			//GUI.Label (new Rect (30, UnityEngine.Screen.height - 200, 200, 30), "Depth Scale: " + wamSliderValue2);
			GUI.Label (new Rect (30, UnityEngine.Screen.height - 260, 200, 30), "Time Up: " + wamSliderValue);
			GUI.Label (new Rect (30, UnityEngine.Screen.height - 300, 150, 30), "Hand/Hammer Scaling");
			//GUI.Label (new Rect (30, UnityEngine.Screen.height - 450, 100, 30), "Mole Scaling");
			GUI.Label (new Rect (30, UnityEngine.Screen.height - 365, 200, 30), "Pop Up Frequency: " + wamSliderValue4);
			GUI.Label (new Rect (30, UnityEngine.Screen.height - 80, 200, 30), "Rotation Target: " + wamSliderValue5 * -45f + " degrees");


			if (GUI.Button(new Rect(30, UnityEngine.Screen.height - 410, 200, 30), "Save Hand Scaling"))
				Save ();

		}


		if (handinvalid == true) {
			GUI.DrawTexture (new Rect (0, 0, 800, 500), disconnectedImg);
		}
	}



	void Update(){
		if (DetectMoles.molesUp >= 3) {
			StartCoroutine (ScaleTime ());
		}

		if (wamSliderValue4 > 3f) {
			//insert character script to remind them not to let the moles stay up for too long
		}
	
		if (wamSliderValue4 > 6f) {

			//insert character script to let them know that the moles are being slowed down
		}

		if (wamSliderValue4 > 12f) {
			//puts cap on how the timer increasing
			wamSliderValue4 = 12f;
		}
	}

	IEnumerator ScaleTime(){
		wamSliderValue4 = wamSliderValue4 + 0.001f;
		//wamSliderValue = wamSliderValue + 0.002f;

		yield return null;
	}

	void FixedUpdate () {
		
		Frame frame = m_leapController.Frame ();
		float roll = frame.Hands [0].PalmNormal.Roll; 


		
		if (frame.Hands.Count >= 1) {
			//Hand leftHand = GetLeftMostHand(frame);
			Hand rightHand = GetRightMostHand (frame);
			
			Vector3 avgPalmForward = frame.Hands [0].Direction.ToUnity ();     
			Vector3 handDiff = rightHand.PalmPosition.ToUnityScaled ();

			
			Vector3 newRot = transform.parent.localRotation.eulerAngles;
			newRot.z = scaledroll;

			Vector3 newPos = transform.parent.position;

			newPos.x = scaled;
			newPos.y = 0.2F;

			foreach (Hand hand in frame.Hands) {
				newPos.z = -hand.PalmPosition.z/20-2;
				//newPos.y = (hand.PalmPosition.y/100);
				
				//clampvalue = Mathf.Clamp (hand.PalmPosition.x, xmin, xmax);
				
				scaled = scale(xmin, xmax, -10F, 8F, hand.PalmPosition.x);

				//clampvalueroll = Mathf.Clamp (roll, 0.5f, maxroll);
				
				scaledroll = scale(0, maxroll, 0.5f, -3F, hand.PalmNormal.Roll);
			
			}

			transform.parent.localRotation = Quaternion.Slerp (transform.parent.localRotation, Quaternion.Euler (newRot), 0.1f);
			transform.parent.position = Vector3.Lerp (transform.parent.position, newPos, 0.1f);
		}
	}

	public void Save()
	{
		PlayerPrefs.SetFloat ("wamSliderValue", wamSliderValue);
		PlayerPrefs.SetFloat ("wamSliderValue2", wamSliderValue2);
		PlayerPrefs.SetFloat ("wamSliderValue3", wamSliderValue3);
		PlayerPrefs.SetFloat ("wamSliderValue4", wamSliderValue4);
		PlayerPrefs.SetFloat ("wamSliderValue5", wamSliderValue5);
	}
}
