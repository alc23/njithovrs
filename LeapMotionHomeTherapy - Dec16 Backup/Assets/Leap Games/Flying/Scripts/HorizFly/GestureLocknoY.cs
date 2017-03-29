using UnityEngine;
using System.Collections;
using Leap;

public class GestureLocknoY : MonoBehaviour {

	public Texture rotImg;
	public Texture xImg;
	public Texture yImg;
  	Controller m_leapController;

	public float xmax;
	public float xmin;

	public float xhand;

	public static float horizflySliderValue = 12.0F;
	public static float horizflySliderValue2 = 2.0F;
	public static float horizflySliderValue3 = 1.0F;

	public static float clampvalue;
	public static float scaled;

	public static float scale (float OldMin, float OldMax, float NewMin, float NewMax, float OldValue){
		float OldRange = (OldMax - OldMin);
		float NewRange = (NewMax - NewMin);
		float NewValue = (((OldValue - OldMin) * NewRange) / OldRange) + NewMin;
		
		return (NewValue);
	}


  void Start () {
		xmax = PlayerPrefs.GetFloat ("xMax");
		xmin = PlayerPrefs.GetFloat ("xMin");

		//insert character animation here that introduces instructions
   		 m_leapController = new Controller();
		
		horizflySliderValue = PlayerPrefs.GetFloat ("horizflySliderValue", horizflySliderValue);
		horizflySliderValue2 = PlayerPrefs.GetFloat ("horizflySliderValue2", horizflySliderValue2);
		horizflySliderValue3 = PlayerPrefs.GetFloat ("horizflySliderValue3", horizflySliderValue3);

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
	

	void OnGUI() {
		if (ToggleFlyingGUI.GUIEnabled = !ToggleFlyingGUI.GUIEnabled) {
//			gflySliderValue = GUI.HorizontalSlider (new Rect (30, UnityEngine.Screen.height - 90, 200, 30), gflySliderValue, 1.0F, 5.0F);
//			GUI.DrawTexture (new Rect (140, UnityEngine.Screen.height - 95, 20, 20), rotImg);
			horizflySliderValue2 = GUI.HorizontalSlider (new Rect (30, UnityEngine.Screen.height - 120, 200, 30), horizflySliderValue2, 1.0F, 5.0F);
			//GUI.DrawTexture (new Rect (140, UnityEngine.Screen.height - 65, 20, 20), xImg);
			horizflySliderValue3 = GUI.HorizontalSlider (new Rect (30, UnityEngine.Screen.height - 60, 200, 30), horizflySliderValue3, 1.0F, 2.0F);
			//GUI.DrawTexture (new Rect (140, UnityEngine.Screen.height - 35, 20, 20), yImg);

			horizflySliderValue = GUI.HorizontalSlider (new Rect (30, UnityEngine.Screen.height - 180, 200, 30), horizflySliderValue, 10.0f, 18.0f);

			GUI.Label(new Rect(30, UnityEngine.Screen.height - 80, 200, 30), "Roll Scale: " + horizflySliderValue3);
			GUI.Label(new Rect(30, UnityEngine.Screen.height - 140, 200, 30), "Sensitivity: " + horizflySliderValue2);
			GUI.Label(new Rect(30, UnityEngine.Screen.height - 200, 200, 30), "Speed: " + horizflySliderValue);


			if (GUI.Button(new Rect(30, UnityEngine.Screen.height - 290, 200, 30), "Save Scaling"))
				Save ();

			GUI.Label(new Rect(30, UnityEngine.Screen.height - 380, 200, 30), "Leap Horizontal Fly Scaling");


		}
	}

  	void FixedUpdate () {

		if (TriggerScore.mazeScore == 1) {
			//insert character animation reminder
		}
    
    Frame frame = m_leapController.Frame();
	float roll =  frame.Hands[0].PalmNormal.Roll; 
    if (frame.Hands.Count >= 1) {
		
     	Hand leftHand = GetLeftMostHand(frame);
     	Hand rightHand = GetRightMostHand(frame);
      

	 	Vector3 avgPalmForward = frame.Hands[0].Direction.ToUnity();     
     	Vector3 handDiff = rightHand.PalmPosition.ToUnityScaled();

      
		Vector3 newRot = transform.parent.localRotation.eulerAngles;
   		newRot.z = roll* 20.0f * horizflySliderValue3;
		newRot.y += scaled;
			//newRot.x = -(avgPalmForward.y - 0.1f) * 60.0f * gflySliderValue ;

	foreach (Hand hand in frame.Hands) {

		clampvalue = Mathf.Clamp (hand.PalmPosition.x, -250, 250);
				
		scaled = scale(-250, 250, -10F, 10F, clampvalue);

	transform.parent.GetComponent<Rigidbody>().velocity = transform.parent.forward * horizflySliderValue;
	}

    transform.parent.localRotation = Quaternion.Slerp(transform.parent.localRotation, Quaternion.Euler(newRot), 0.1f);
    }
  }
	void Update(){
		xhand = XCalibration.scaled;
	}

	public void Save(){
		PlayerPrefs.SetFloat ("horizflySliderValue", horizflySliderValue);
		PlayerPrefs.SetFloat ("horizflySliderValue2", horizflySliderValue2);
		PlayerPrefs.SetFloat ("horizflySliderValue3", horizflySliderValue3);
	}
}