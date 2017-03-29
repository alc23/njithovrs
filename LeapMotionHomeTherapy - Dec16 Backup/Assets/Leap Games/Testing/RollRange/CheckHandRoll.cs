using UnityEngine;
using System.Collections;
using Leap;

public class CheckHandRoll : MonoBehaviour {
	
	
	Controller controller;
	public static float openCount= 0;
	public bool handOpen = false;
	public float roll;
	public float rollcal;
	public bool flag1 = false;
	public bool flag2 = false;
	public bool flag3 = false;
	public static bool playPart = false;
	
	void Awake(){
		rollcal = PlayerPrefs.GetFloat ("Roll");
	}
	// Use this for initialization
	void Start () {
		controller = new Controller();
	}
	
	// Update is called once per frame
	void Update () {
		Frame frame = controller.Frame ();
		
		foreach (Hand hand in frame.Hands) {
			
			roll = hand.PalmNormal.Roll;
			
			if (roll < rollcal){
				flag1 = true;
				flag2 = false;
				playPart = true;
			}
			
			if (roll > 0){
				flag2 = true;
				playPart = false;
			}
			
			if (flag1== true && flag2 == true){
				flag3 = true;
				flag1 = false;
				flag2 = false;
				openCount += 0.5f;
				HandOpenCount.AddCount (0.5f);
			}
			else{
				flag3 = false;
			}
			
			foreach (Finger finger in hand.Fingers) {
				
			}
		}
		
		//Debug.Log (openCount);
		
		//if (handOpen = true)
		
		
	}
	
	
	IEnumerator run(){
		
		yield return new WaitForSeconds(5);
		
		
		
	}
}
