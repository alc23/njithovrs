﻿using UnityEngine;
using System.Collections;
using UnityEngine;
using System.Collections;
using System;
using System.IO;
using Leap;

public class GesturePitchHandValuesFly : MonoBehaviour {
	
	public string output;
	Controller controller;
	
	public Texture disconnectedImg;
	public static bool invalidhands;
	
	static float timer;
	public static string fileName = string.Format("GestureHandFlyData" + DateTime.Today.ToString("MMddyyyy") + ".txt");
	
	StreamWriter sw = new StreamWriter ("Data/Flying/" + fileName, true);
	
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
				sw.Write (milliseconds);
			
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
				
					sw.Write ("," + finger.TipPosition.x);
					sw.Write ("," + finger.TipPosition.y);
					sw.Write ("," + finger.TipPosition.z);
				}
				sw.Write ("," + hand.SphereRadius);
				Debug.Log (hand.SphereRadius);
			}
			sw.Write ("," + TriggerScore.mazeScore);
			//sw.Write ("\t" + GestureLocknoX.pitchflySliderValue);
			//sw.Write ("\t" + GestureLocknoX.pitchflySliderValue2);
			//plane speed
			sw.Write ("," + GestureLocknoX.pitchflySliderValue3);
			//calibrated value for hand closing
			sw.Write ("," + PlayerPrefs.GetFloat("sphereRadiusclose"));
			//calibrated value for hand opening
			sw.Write ("," + PlayerPrefs.GetFloat("sphereRadiusopen"));
			//scaled plane movement
			sw.Write ("," + GestureUpDown.scaled);
			//sw.Write ("\t" + GestureUpDown.finalval);

			sw.Write ("\n");
		}
	}
	public void Complete(){
		sw.Close ();
	}
}