//using UnityEngine;
//using System.Collections;
//using Leap;
//
//public class LeapFlyOneHand : MonoBehaviour {
//
//	public Texture rotImg;
//	public Texture xImg;
//	public Texture yImg;
//	public Texture disconnectImg;
//
//	Hand hand;
//
//  Controller m_leapController;
//
//  void Start () {
//    m_leapController = new Controller();
//	pflySliderValue = PlayerPrefs.GetFloat ("pflySliderValue", pflySliderValue);
//	pflySliderValue2 = PlayerPrefs.GetFloat ("pflySliderValue2", pflySliderValue2); 
//	pflySliderValue3 = PlayerPrefs.GetFloat ("pflySliderValue3", pflySliderValue3);
//  }
//
//  Hand GetLeftMostHand (Frame f) {
//    float smallestVal = float.MaxValue;
//    Hand h = null;
//    for(int i = 0; i < f.Hands.Count; ++i) {
//      if (f.Hands[i].PalmPosition.ToUnity().x < smallestVal) {
//        smallestVal = f.Hands[i].PalmPosition.ToUnity().x;
//        h = f.Hands[i];
//      }
//    }
//    return h;
//  }
//  
//  Hand GetRightMostHand(Frame f) {
//    float largestVal = -float.MaxValue;
//    Hand h = null;
//    for(int i = 0; i < f.Hands.Count; ++i) {
//      if (f.Hands[i].PalmPosition.ToUnity().x > largestVal) {
//        largestVal = f.Hands[i].PalmPosition.ToUnity().x;
//        h = f.Hands[i];
//      }
//    }
//    return h;
//  }
//
//	public static float pflySliderValue = 1.0F;
//	public static float pflySliderValue2 = 2.0F;
//	public static float pflySliderValue3 = 1.0F;
//	
//	void OnGUI() {
//		if (ToggleFlyingGUI.GUIEnabled = !ToggleFlyingGUI.GUIEnabled) {
//			pflySliderValue = GUI.HorizontalSlider (new Rect (30, UnityEngine.Screen.height - 90, 100, 30), pflySliderValue, 1.0F, 3.0F);
//			GUI.DrawTexture (new Rect (140, UnityEngine.Screen.height - 95, 20, 20), rotImg);
//			pflySliderValue2 = GUI.HorizontalSlider (new Rect (30, UnityEngine.Screen.height - 60, 100, 30), pflySliderValue2, 1.0F, 5.0F);
//			GUI.DrawTexture (new Rect (140, UnityEngine.Screen.height - 65, 20, 20), xImg);
//			pflySliderValue3 = GUI.HorizontalSlider (new Rect (30, UnityEngine.Screen.height - 30, 100, 30), pflySliderValue3, 1.0F, 4.0F);
//			GUI.DrawTexture (new Rect (140, UnityEngine.Screen.height - 35, 20, 20), yImg);
//		}
//	}
//  
//  void FixedUpdate () {
//    
//    Frame frame = m_leapController.Frame();
//	float roll =  frame.Hands[0].PalmNormal.Roll; 
//
//		if (hand != Hand.Invalid) {
//			GUI.DrawTexture (new Rect (UnityEngine.Screen.width/2, UnityEngine.Screen.height/2, 800, 500), disconnectImg);
//		}
//
//	
//    if (frame.Hands.Count >= 1) {
//     	Hand leftHand = GetLeftMostHand(frame);
//     	Hand rightHand = GetRightMostHand(frame);
//      
//	 	Vector3 avgPalmForward = frame.Hands[0].Direction.ToUnity();     
//     	Vector3 handDiff = rightHand.PalmPosition.ToUnityScaled();
//
//		Vector3 newRot = transform.parent.localRotation.eulerAngles;
//   		//newRot.z = roll* 50.0f;
//		newRot.y += handDiff.x * 100.0f * pflySliderValue2;
//		//newRot.x =- (avgPalmForward.y) * 60.0f * pflySliderValue;
//
//			float forceMult = handDiff.z * 100.0f *pflySliderValue3;
//      
//      if (frame.Fingers.Count < 3) {
//        forceMult = -3.0f;
//      }
//      transform.parent.localRotation = Quaternion.Slerp(transform.parent.localRotation, Quaternion.Euler(newRot), 0.1f);
//      transform.parent.GetComponent<Rigidbody>().velocity = transform.parent.forward * forceMult;
//    }
//  }
//	public void Save(){
//		PlayerPrefs.SetFloat ("pflySliderValue", pflySliderValue);
//		PlayerPrefs.SetFloat ("pflySliderValue2", pflySliderValue2);
//		PlayerPrefs.SetFloat ("pflySliderValue3", pflySliderValue3);
//	}
//}