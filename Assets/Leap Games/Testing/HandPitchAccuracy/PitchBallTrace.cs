using UnityEngine;
using System.Collections;
using Leap;

public class PitchBallTrace : MonoBehaviour {
	
	Controller m_leapController;
	public static float minvalue;
	public static float maxvalue;
	public static float clampvalue;
	public static float handpitch;
	public static float scaled;
	
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
			
			
			scaled = scale(minvalue, maxvalue, -66F, -15F, hand.Direction.Pitch);
			
			
			Debug.Log ("scale" + scaled);
			newPos.y = scaled;
			newPos.x += Time.deltaTime * 3;
			
			transform.localPosition = Vector3.Lerp (transform.localPosition, newPos, 5f);

			if (newPos.x >= 140){
				Application.Quit ();
			}
		}
	}
}