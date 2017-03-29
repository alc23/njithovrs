using UnityEngine;
using System.Collections;
using Leap;

public class MoveBall : MonoBehaviour {

  	Controller m_leapController;
	private Animator anim;
	private float jumpTimer = 0;

	public static float mazeSliderValue2 = 5.0F;
	public float mazeSliderValue3 = 5.0F;

	public Texture xImg;
	public Texture yImg;
	
  void Start () {
		m_leapController = new Controller();
	
		anim = this.gameObject.GetComponent<Animator> ();

		mazeSliderValue2 = PlayerPrefs.GetFloat ("mazeSliderValue2", mazeSliderValue2);
		mazeSliderValue3 = PlayerPrefs.GetFloat ("mazeSliderValue3", mazeSliderValue3);
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

  void OnGUI(){
		if (ToggleMazeGUI.GUIEnabled = !ToggleMazeGUI.GUIEnabled) {
			mazeSliderValue2 = GUI.HorizontalSlider (new Rect (30, UnityEngine.Screen.height - 60, 200, 30), mazeSliderValue2, 0.8F, 2.0F);
			GUI.DrawTexture (new Rect (240, UnityEngine.Screen.height - 65, 20, 20), yImg);
			GUI.Label (new Rect (30, UnityEngine.Screen.height - 85, 200, 30), "Movement Scale: " + mazeSliderValue2);


			if (GUI.Button(new Rect(30, UnityEngine.Screen.height - 120, 200, 30), "Save Scaling"))
				Save ();
			//mazeSliderValue3 = GUI.HorizontalSlider (new Rect (30, UnityEngine.Screen.height - 30, 100, 30), mazeSliderValue3, 1.0F, 5.0F);
			//GUI.DrawTexture (new Rect (140, UnityEngine.Screen.height - 35, 20, 20), xImg);
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

		Vector3 newPos = transform.parent.localPosition;
			newPos.z += handDiff.z * mazeSliderValue2 * 20;
			newPos.x += handDiff.x * mazeSliderValue3 * 20;

			float x = rightHand.PalmPosition.x;
			float z = -rightHand.PalmPosition.z;

			Vector3 target = new Vector3(x * 10, 0, z * 10);
			transform.parent.LookAt (target);		
	  		transform.parent.localPosition = Vector3.MoveTowards (transform.parent.localPosition, newPos, mazeSliderValue2 * 0.1f);
    }
  }

	public void Save(){		
		PlayerPrefs.SetFloat ("mazeSliderValue2", mazeSliderValue2);
		PlayerPrefs.SetFloat ("mazeSliderValue3", mazeSliderValue3);
	}
}
