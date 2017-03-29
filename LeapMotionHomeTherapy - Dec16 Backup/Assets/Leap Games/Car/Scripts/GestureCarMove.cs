using UnityEngine;
using System.Collections;
using Leap;

public class GestureCarMove : MonoBehaviour {
	
	public Texture rotImg;
	public Texture xImg;
	public Texture yImg;
	Controller m_leapController;
	public static float closevalue;
	public static float openvalue;
	public static float finalval;

	public static float scale (float OldMin, float OldMax, float NewMin, float NewMax, float OldValue){
		float OldRange = (OldMax - OldMin);
		float NewRange = (NewMax - NewMin);
		float NewValue = (((OldValue - OldMin) * NewRange) / OldRange) + NewMin;

		return (NewValue);
	}
	
	void Start () {
		closevalue = PlayerPrefs.GetFloat ("sphereRadiusclose");
		openvalue = PlayerPrefs.GetFloat ("sphereRadiusopen");
		m_leapController = new Controller();
		//pitchflySliderValue = PlayerPrefs.GetFloat ("pitchflySliderValue", pitchflySliderValue);
		//pitchflySliderValue2 = PlayerPrefs.GetFloat ("pitchflySliderValue", pitchflySliderValue2);
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
	
//	public static float pitchflySliderValue = 1.0F;
//	public static float pitchflySliderValue2 = 0F;
	
//	void OnGUI() {
//		if (ToggleFlyingGUI.GUIEnabled = !ToggleFlyingGUI.GUIEnabled) {
//			pitchflySliderValue = GUI.HorizontalSlider (new Rect (30, UnityEngine.Screen.height - 90, 100, 30), pitchflySliderValue, 1.0F, 2.0F);
//			GUI.DrawTexture (new Rect (140, UnityEngine.Screen.height - 95, 20, 20), rotImg);
//			pitchflySliderValue2 = GUI.HorizontalSlider (new Rect (30, UnityEngine.Screen.height - 60, 100, 30), pitchflySliderValue2, 0F, 0.4F);
//			GUI.DrawTexture (new Rect (140, UnityEngine.Screen.height - 65, 20, 20), xImg);
//		}
//	}

	
	void FixedUpdate () {
		
		Frame frame = m_leapController.Frame();
		float roll =  frame.Hands[0].PalmNormal.Roll; 
		if (frame.Hands.Count >= 1) {
			
			Hand leftHand = GetLeftMostHand(frame);
			Hand rightHand = GetRightMostHand(frame);
			

			Vector3 avgPalmForward = frame.Hands[0].Direction.ToUnity();     
			Vector3 handDiff = rightHand.PalmPosition.ToUnityScaled();
			
			Vector3 newRot = transform.parent.localRotation.eulerAngles;

			//	newRot.z = roll* 10.0f * gflySliderValue3;
			//	newRot.y += handDiff.x * 100.0f * gflySliderValue2 ;
			//newRot.x = -(avgPalmForward.y + pitchflySliderValue2) * 60.0f * pitchflySliderValue ;
			
			foreach (Hand hand in frame.Hands) {

				float scaled = scale(openvalue, closevalue, 30F, 200F, hand.SphereRadius);
			//	Debug.Log ("scaled" + scaled);
			//	Debug.Log ("close" + closevalue);
			//	Debug.Log ("open" + openvalue);
			//	Debug.Log ("hand" + hand.SphereRadius);
				transform.parent.GetComponent<Rigidbody>().velocity = Vector3.forward  *scaled * -.14f;

				finalval = scaled;

			}
			//transform.parent.localRotation = Quaternion.Slerp(transform.parent.localRotation, Quaternion.Euler(newRot), 0.1f);
		}
		
	}
	
//	public void Save(){
//		PlayerPrefs.SetFloat ("pitchflySliderValue", pitchflySliderValue);
//		PlayerPrefs.SetFloat ("pitchflySliderValue2", pitchflySliderValue2);
//	}
}