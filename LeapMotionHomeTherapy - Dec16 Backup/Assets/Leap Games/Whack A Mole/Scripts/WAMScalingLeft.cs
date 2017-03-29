using UnityEngine;
using System.Collections;
using Leap;

public class WAMScalingLeft : MonoBehaviour {
	
	Controller m_leapController;
	Hand hand;
	public Texture disconnectedImg;
	public bool handinvalid;

	void Start () {
		m_leapController = new Controller();
		LwamSliderValue = PlayerPrefs.GetFloat ("LwamSliderValue", LwamSliderValue);
		LwamSliderValue2 = PlayerPrefs.GetFloat ("LwamSliderValue2", LwamSliderValue2);
		LwamSliderValue3 = PlayerPrefs.GetFloat ("LwamSliderValue3", LwamSliderValue3);
		LwamSliderValue4 = PlayerPrefs.GetFloat ("LwamSliderValue4", LwamSliderValue4);
		LwamSliderValue5 = PlayerPrefs.GetFloat ("LwamSliderValue5", LwamSliderValue5);
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

	public static float LwamSliderValue = 1.0F;
	public static float LwamSliderValue2 = 1.0F;
	public static float LwamSliderValue3 = 1.0F;
	public static float LwamSliderValue4;
	public static float LwamSliderValue5;
	
	public Texture rotImg;
	public Texture xImg;
	public Texture yImg;
	public Texture timerImg;
	

	void OnGUI() {
		if (ToggleWAMGUI.GUIEnabled = !ToggleWAMGUI.GUIEnabled) {
		
			LwamSliderValue = GUI.HorizontalSlider (new Rect (30, UnityEngine.Screen.height - 240, 200, 30), LwamSliderValue, 1.0F, -120.0F);
			GUI.DrawTexture (new Rect (240, UnityEngine.Screen.height - 245, 20, 20), rotImg);	
			LwamSliderValue2 = GUI.HorizontalSlider (new Rect (30, UnityEngine.Screen.height - 180, 200, 30), LwamSliderValue2, 1.0F, 40.0F);
			GUI.DrawTexture (new Rect (240, UnityEngine.Screen.height - 185, 20, 20), yImg);
			LwamSliderValue3 = GUI.HorizontalSlider (new Rect (30, UnityEngine.Screen.height - 120, 200, 30), LwamSliderValue3, 1.0F, 60.0F);
			GUI.DrawTexture (new Rect (240, UnityEngine.Screen.height - 125, 20, 20), xImg);

			LwamSliderValue4 = GUI.HorizontalSlider (new Rect (30, UnityEngine.Screen.height - 340, 200, 30), LwamSliderValue4, 0.2F, 4.0F);
			GUI.DrawTexture (new Rect (240, UnityEngine.Screen.height - 345, 20, 20), timerImg);

			LwamSliderValue5 = GUI.HorizontalSlider (new Rect (30, UnityEngine.Screen.height - 60, 200, 50), LwamSliderValue5, -2.0F, -1.0F);


			GUI.Label (new Rect (30, UnityEngine.Screen.height - 140,200, 30), "Horizontal Scale: " + LwamSliderValue3);
			GUI.Label (new Rect (30, UnityEngine.Screen.height - 200, 200, 30), "Depth Scale: " + LwamSliderValue2);
			GUI.Label (new Rect (30, UnityEngine.Screen.height - 260, 200, 30), "Rotation Scale: " + LwamSliderValue);
			GUI.Label (new Rect (30, UnityEngine.Screen.height - 300, 150, 30), "Hand/Hammer Scaling");
			GUI.Label (new Rect (30, UnityEngine.Screen.height - 450, 100, 30), "Mole Scaling");
			GUI.Label (new Rect (30, UnityEngine.Screen.height - 365, 200, 30), "Pop Up Frequency: " + LwamSliderValue4);
			GUI.Label (new Rect (30, UnityEngine.Screen.height - 80, 200, 30), "Rotation Target: " + LwamSliderValue5 * -45f + " degrees");

			//if (handinvalid == true) {
				
			//}

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
	}

	IEnumerator ScaleTime(){
		LwamSliderValue4 = LwamSliderValue4 + 0.001f;
		//wamSliderValue = wamSliderValue + 0.002f;

		yield return null;
	}

	void FixedUpdate () {
		
		Frame frame = m_leapController.Frame ();
		float roll = frame.Hands [0].PalmNormal.Roll; 

//		if (hand != Hand.Invalid) {
//			handinvalid = true;
//
//			Debug.Log ("invalid");
//		}


		
		if (frame.Hands.Count >= 1) {
			//Hand leftHand = GetLeftMostHand(frame);
			Hand rightHand = GetRightMostHand (frame);
			
			Vector3 avgPalmForward = frame.Hands [0].Direction.ToUnity ();     
			Vector3 handDiff = rightHand.PalmPosition.ToUnityScaled ();

			
			Vector3 newRot = transform.parent.localRotation.eulerAngles;
			newRot.z = roll * LwamSliderValue;

			Vector3 newPos = transform.parent.localPosition;
			newPos.z = handDiff.z * LwamSliderValue2;
			newPos.x = handDiff.x * LwamSliderValue3;

			transform.parent.localRotation = Quaternion.Slerp (transform.parent.localRotation, Quaternion.Euler (newRot), 0.1f);
			transform.parent.localPosition = Vector3.Lerp (transform.parent.localPosition, newPos, 0.1f);
		}
	}

	public void Save()
	{
		PlayerPrefs.SetFloat ("LwamSliderValue", LwamSliderValue);
		PlayerPrefs.SetFloat ("LwamSliderValue2", LwamSliderValue2);
		PlayerPrefs.SetFloat ("LwamSliderValue3", LwamSliderValue3);
		PlayerPrefs.SetFloat ("LwamSliderValue4", LwamSliderValue4);
		PlayerPrefs.SetFloat ("LwamSliderValue5", LwamSliderValue5);
	}
}
