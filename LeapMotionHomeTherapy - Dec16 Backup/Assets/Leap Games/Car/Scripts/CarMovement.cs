using UnityEngine;
using System.Collections;
using Leap;

public class CarMovement : MonoBehaviour {
	
	public Texture rotImg;
	public Texture xImg;
	public Texture yImg;
	Controller m_leapController;
	
	void Start () {
		m_leapController = new Controller ();
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
	
	void FixedUpdate () {
		
		Frame frame = m_leapController.Frame();
		float roll =  frame.Hands[0].PalmNormal.Roll; 
		if (frame.Hands.Count >= 1) {
			
			Hand leftHand = GetLeftMostHand(frame);
			Hand rightHand = GetRightMostHand(frame);
			

			Vector3 avgPalmForward = frame.Hands[0].Direction.ToUnity();     
			Vector3 handDiff = rightHand.PalmPosition.ToUnityScaled();
			
			Vector3 newRot = transform.parent.localRotation.eulerAngles;

			foreach (Hand hand in frame.Hands) {
				transform.parent.GetComponent<Rigidbody>().velocity = Vector3.forward * handDiff.z * -160f;
			}
		
		}
		
	}

}