using UnityEngine;
using System.Collections;
using Leap;

public class ScaleBowling : MonoBehaviour {
	
	Controller m_leapController;
	public Texture yImg;
	public Texture disconnectedImg;
	public static float bowlingSliderValue = 1.0F;
	Hand hand;

	void Start () {
		m_leapController = new Controller();
		bowlingSliderValue = PlayerPrefs.GetFloat ("bowlingSliderValue", bowlingSliderValue);
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

	void OnGUI() {
		if (ToggleBowlingGUI.GUIEnabled = !ToggleBowlingGUI.GUIEnabled) {
			bowlingSliderValue = GUI.HorizontalSlider (new Rect (30, UnityEngine.Screen.height - 60, 200, 30), bowlingSliderValue, 1.0F, 50.0F);
			GUI.DrawTexture (new Rect (240, UnityEngine.Screen.height - 65, 20, 20), yImg);

			GUI.Label(new Rect(30, UnityEngine.Screen.height - 80, 100, 30), "Depth Scale");

			GUI.Label(new Rect(30, UnityEngine.Screen.height - 130, 200, 30), "Hand Scaling: " + bowlingSliderValue);

			GUI.Label(new Rect(30, UnityEngine.Screen.height - 240, 100, 30), "Pin Location");

			GUI.Label(new Rect(30, UnityEngine.Screen.height - 290, 100, 30), "Pin Scaling");

			if (GUI.Button(new Rect(30, UnityEngine.Screen.height - 110, 200, 30), "Save Hand Scaling"))
				Save ();
		}
	}


//	public void Preset1(){
//		bowlingSliderValue = 40.0f;
//	}
//
//	public void Preset2(){
//		bowlingSliderValue = 20.0f;
//	}
//
//	public void Preset3(){
//		bowlingSliderValue = 1.0f;
//	}
//
//	public void ClickPreset1(){
//		bowlingSliderValue = 50.0f;
//	}
//
//	public void ClickPreset2(){
//		bowlingSliderValue = 30.0f;
//	}
//
//	public void ClickPreset3(){
//		bowlingSliderValue = 10.0f;
//	}

	void FixedUpdate () {
		Frame frame = m_leapController.Frame ();
		float roll = frame.Hands [0].PalmNormal.Roll; 


		if (frame.Hands.Count <1) {
			GUI.DrawTexture (new Rect (UnityEngine.Screen.width/2, UnityEngine.Screen.height/2, 800, 500), disconnectedImg);
		}

		
		if (frame.Hands.Count >= 1) {

			Hand rightHand = GetRightMostHand (frame);

			Vector3 avgPalmForward = frame.Hands [0].Direction.ToUnity ();     
			Vector3 handDiff = rightHand.PalmPosition.ToUnityScaled ();

			Vector3 newPos = transform.parent.localPosition;
			newPos.z = handDiff.z * 0.3f;

			transform.parent.localPosition = Vector3.Lerp (transform.parent.localPosition, newPos, 0.1f);
		}
	}

	public void Save(){
		PlayerPrefs.SetFloat ("bowlingSliderValue", bowlingSliderValue);
	}
}
