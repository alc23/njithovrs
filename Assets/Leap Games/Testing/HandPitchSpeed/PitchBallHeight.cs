//using UnityEngine;
//using System.Collections;
//using Leap;
using UnityEngine;
using System.Collections;
using Leap;

public class PitchBallHeight : MonoBehaviour {
	
	Controller m_leapController;
	public static float minvalue;
	public static float maxvalue;
	public static float clampvalue;
	public static float handsphere;
	public static float scaled;

	float timeLeft = 10.0f;
	
	public static float scale (float OldMin, float OldMax, float NewMin, float NewMax, float OldValue){
		float OldRange = (OldMax - OldMin);
		float NewRange = (NewMax - NewMin);
		float NewValue = (((OldValue - OldMin) * NewRange) / OldRange) + NewMin;
		
		return (NewValue);
	}
	
	void Awake(){
		
		maxvalue = PlayerPrefs.GetFloat ("pitchUp");
		minvalue = PlayerPrefs.GetFloat ("pitchDown");
	}
	
	void Start () {
		//insert character animation introduction
		m_leapController = new Controller();

	}

	
	void Update () {
		
		Vector3 newPos = transform.localPosition;
		
		Frame frame = m_leapController.Frame ();
		
		foreach (Hand hand in frame.Hands) {
			
			//clampvalue = Mathf.Clamp (hand.SphereRadius, closevalue, openvalue);
			
			//scaled = scale(closevalue, openvalue, 60F, -60F, clampvalue);
			
			scaled = scale(minvalue, maxvalue, 11F, 17.3F, hand.Direction.Pitch);
			
			if (scaled >17.3f){
				scaled = 17.3f;
			}
			
			if (scaled <11f){
				scaled = 11f;
				
			}
			
			Debug.Log ("scale" + scaled);
			newPos.y = scaled;
			transform.localPosition = Vector3.Lerp (transform.localPosition, newPos, 10f);
		}

		timeLeft -= Time.deltaTime;
		if (timeLeft < 0) {
			Application.Quit ();
		}
	}
}



