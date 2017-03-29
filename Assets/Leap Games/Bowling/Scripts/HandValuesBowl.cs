using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;
using Leap;

public class HandValuesBowl : MonoBehaviour {
	
	Controller controller;
	int round;
	public Texture disconnectedImg;
	public static bool invalidhands;
	public static int rounds;
	public static float lifetimeOfThisHandObject;
	public static string fileName = string.Format("HandBowlingData" + DateTime.Today.ToString("MMddyyyy") + ".txt");

	StreamWriter sw = new StreamWriter ("Data/Bowling/" + fileName, true);

	void Start (){
		controller = new Controller();
	}

	void OnGUI(){
		if (!invalidhands) {
			GUI.DrawTexture (new Rect (0, 0, UnityEngine.Screen.width, UnityEngine.Screen.height), disconnectedImg);
		}
	}

	public static void IncreaseRounds(int amount){
		rounds += amount;
	}
	
	static float timer;
	
	void Update (){
		Frame frame = controller.Frame ();
		invalidhands = false;
		
		TimeSpan timeSpan;
		
		foreach (Hand hand in frame.Hands) {
			
			if (frame.Hands.Count > 0) {
				invalidhands = !invalidhands;
				timer += Time.deltaTime;
				timeSpan = TimeSpan.FromSeconds (timer);
				//string output = String.Format("{0}:{1}:{2}",timeSpan.Minutes,timeSpan.Seconds, timeSpan.Milliseconds);
				
				
				float lifetimeOfThisHandObject = hand.TimeVisible;
				Vector normal = hand.PalmNormal;
				Vector direction = hand.Direction;
				
				//long milliseconds = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
				
				long milliseconds = timeSpan.Minutes * 60000 + timeSpan.Seconds * 1000 + timeSpan.Milliseconds;
			
				sw.Write (DateTime.Now.ToString ("h:mm:ss tt"));

			sw.Write(milliseconds);

			sw.Write ("," + hand.PalmPosition.x);
			sw.Write ("," + hand.PalmPosition.y);
			sw.Write ("," + hand.PalmPosition.z);

			sw.Write ("," + hand.PalmNormal.x);
			sw.Write ("," + hand.PalmNormal.y);
			sw.Write ("," + hand.PalmNormal.z);

				Debug.Log(hand.PalmNormal);
			
			sw.Write ("," + hand.WristPosition.x);
			sw.Write ("," + hand.WristPosition.y);
			sw.Write ("," + hand.WristPosition.z);

			foreach (Finger finger in hand.Fingers) {
				//BONE TRANSLATION:  TYPE_THUMB == 0, TYPE_INDEX == 1, TYPE MIDDLE == 2, TYPE_RING == 3, TYPE_PINKY == 4
				
				//sw.WriteLine ("FingerID: " + finger.Id, finger.Type().ToString ());
				
				Bone bone;

				foreach (Bone.BoneType boneType in (Bone.BoneType[]) Enum.GetValues(typeof(Bone.BoneType))) {
					bone = finger.Bone (boneType);

					sw.Write ("," + bone.PrevJoint.x);
					sw.Write ("," + bone.PrevJoint.y);
					sw.Write ("," + bone.PrevJoint.z);
				}
				sw.Write("," + finger.TipPosition.x);
				sw.Write("," + finger.TipPosition.y);
				sw.Write("," + finger.TipPosition.z);
				}
				//score
				sw.Write ("," + BowlingScore.score);
				//hand depth scaling
				//sw.Write ("," + ScaleBowling.bowlingSliderValue);
				//times played
				sw.Write ("," + rounds);
			}
			sw.Write("\n");
		}

	}
	public void Complete(){
		sw.Close ();
	}
}