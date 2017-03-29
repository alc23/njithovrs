
using UnityEngine;
using System.Collections;
using Leap;

public class RollTraceBall : MonoBehaviour {
	
	Controller m_leapController;
	public static float upvalue;
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
		
		upvalue = PlayerPrefs.GetFloat ("Roll");
	}
	
	void Start () {


		//insert character animation introduction
		m_leapController = new Controller();
		
		
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
	
	void Update () {
		
		Vector3 newPos = transform.localPosition;
		
		Frame frame = m_leapController.Frame ();
		
		foreach (Hand hand in frame.Hands) {
			
			
			Debug.Log ("working");
			
			//clampvalue = Mathf.Clamp (hand.SphereRadius, closevalue, openvalue);
			
			//scaled = scale(closevalue, openvalue, 60F, -60F, clampvalue);
			
			scaled = scale(0, upvalue, -66F, -15F,hand.PalmNormal.Roll);
			
			//			if (scaled >-66f){
			//				scaled = -66f;
			//				
			//			}
			//			
			//			if (scaled <-15f){
			//				scaled = -15f;
			//				
			//			}
			
			Debug.Log ("scale" + scaled);
			newPos.y = scaled;
			newPos.x += Time.deltaTime * 3;
			
			transform.localPosition = Vector3.Lerp (transform.localPosition, newPos, 5f);
			
			if (newPos.x >= 135){
				Application.Quit ();
			}

			Debug.Log ( hand.PalmNormal.Roll);
		}
	}
}



