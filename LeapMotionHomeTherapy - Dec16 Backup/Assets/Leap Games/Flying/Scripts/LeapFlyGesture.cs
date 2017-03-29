using UnityEngine;
using System.Collections;
using Leap;

public class LeapFlyGesture : MonoBehaviour {

	public Texture rotImg;
	public Texture xImg;
	public Texture yImg;
  	Controller m_leapController;

  void Start () {
    m_leapController = new Controller();
	gflySliderValue = PlayerPrefs.GetFloat ("gflySliderValue", gflySliderValue);
	gflySliderValue2 = PlayerPrefs.GetFloat ("gflySliderValue", gflySliderValue2);
	gflySliderValue3 = PlayerPrefs.GetFloat ("gflySliderValue", gflySliderValue3);
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

	public static float gflySliderValue = 1.0F;
	public static float gflySliderValue2 = 2.0F;
	public static float gflySliderValue3 = 1.0F;
	
	void OnGUI() {
		if (ToggleFlyingGUI.GUIEnabled = !ToggleFlyingGUI.GUIEnabled) {
			gflySliderValue = GUI.HorizontalSlider (new Rect (30, UnityEngine.Screen.height - 90, 100, 30), gflySliderValue, 1.0F, 5.0F);
			GUI.DrawTexture (new Rect (140, UnityEngine.Screen.height - 95, 20, 20), rotImg);
			gflySliderValue2 = GUI.HorizontalSlider (new Rect (30, UnityEngine.Screen.height - 60, 100, 30), gflySliderValue2, 1.0F, 5.0F);
			GUI.DrawTexture (new Rect (140, UnityEngine.Screen.height - 65, 20, 20), xImg);
			gflySliderValue3 = GUI.HorizontalSlider (new Rect (30, UnityEngine.Screen.height - 30, 100, 30), gflySliderValue3, 1.0F, 2.0F);
			GUI.DrawTexture (new Rect (140, UnityEngine.Screen.height - 35, 20, 20), yImg);
		}
	}

  	void FixedUpdate () {
    
    Frame frame = m_leapController.Frame();
	float roll =  frame.Hands[0].PalmNormal.Roll; 
    if (frame.Hands.Count >= 1) {
		
     	Hand leftHand = GetLeftMostHand(frame);
     	Hand rightHand = GetRightMostHand(frame);
      

	 	Vector3 avgPalmForward = frame.Hands[0].Direction.ToUnity();     
     	Vector3 handDiff = rightHand.PalmPosition.ToUnityScaled();

      
		Vector3 newRot = transform.parent.localRotation.eulerAngles;
   		newRot.z = roll* 10.0f * gflySliderValue3;
			newRot.y += handDiff.x * 100.0f * gflySliderValue2 ;
			newRot.x = -(avgPalmForward.y - 0.1f) * 60.0f * gflySliderValue ;

	foreach (Hand hand in frame.Hands) {

	transform.parent.GetComponent<Rigidbody>().velocity = transform.parent.forward * hand.SphereRadius * 0.2f;
	}
    transform.parent.localRotation = Quaternion.Slerp(transform.parent.localRotation, Quaternion.Euler(newRot), 0.1f);
    }
  }

	public void Save(){
		PlayerPrefs.SetFloat ("gflySliderValue", gflySliderValue);
		PlayerPrefs.SetFloat ("gflySliderValue2", gflySliderValue2);
		PlayerPrefs.SetFloat ("gflySliderValue3", gflySliderValue3);
	}
}