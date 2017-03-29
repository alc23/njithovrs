using UnityEngine;
using System.Collections;
using System;
using System.IO;
using Leap;

public class SpeedHandData : MonoBehaviour {
	
	public string output;
	Controller controller;
	
	public Texture disconnectedImg;
	public static bool invalidhands;
	
	static float timer;
	public static string fileName = string.Format("TestingHandOpenSpeedData" + DateTime.Today.ToString("MMddyyyy") + ".txt");
	
	StreamWriter sw = new StreamWriter ("Data/Testing/" + fileName, true);
	
	void Start (){
		controller = new Controller();
	}
	
	void OnGUI(){
		if (!invalidhands) {
			GUI.DrawTexture (new Rect (0, 0, UnityEngine.Screen.width, UnityEngine.Screen.height), disconnectedImg);
		}
	}
	
	void Update (){
		Frame frame = controller.Frame ();
		
		invalidhands = false;
		
		TimeSpan timeSpan;
		
		foreach (Hand hand in frame.Hands) {
			
			if (hand.IsValid) {
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
				
				sw.Write ("," + hand.WristPosition.x);
				sw.Write ("," + hand.WristPosition.y);
				sw.Write ("," + hand.WristPosition.z);
				
				foreach (Finger finger in hand.Fingers) {
					
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
				
				sw.Write ("," + hand.SphereRadius);
				
//				//	Debug.Log (hand.SphereRadius);
//				//car speed MPH
//				sw.Write ("," + Speed.vel);
//				//timer that the patient sees 
//				sw.Write ("," + Speed.timer);
//				//if car is flipped (meaning game restarts as well
//				sw.Write ("," + FlipRestart.flipped);
				sw.Write ("," + PlayerPrefs.GetFloat ("sphereRadiusclose"));
				sw.Write ("," + PlayerPrefs.GetFloat ("sphereRadiusopen"));
				
				
			}
			sw.Write("\n");
			
		}
		
	}
	public void Complete(){
		sw.Close ();
	}
}