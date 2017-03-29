﻿using UnityEngine;
using System.Collections;
using System;
using System.IO;
using Leap;


public class CatchFruitHandValuesL : MonoBehaviour {
	
	Controller controller;
	
	public Texture disconnectedImg;
	public static bool invalidhands;
	static float timer;
	
	
	public static string fileName = string.Format("CatchFruitHandDataLeft" + DateTime.Today.ToString("MMddyyyy") + ".txt");
	
	StreamWriter sw = new StreamWriter ("Data/FruitFall/" + fileName, true);
	

	void Start (){
		controller = new Controller();
	}
	
	void OnGUI(){
		if (invalidhands = !invalidhands) {
			GUI.DrawTexture (new Rect (300, 100, 800, 500), disconnectedImg);
		}
	}
	
	
	void Update (){
		Frame frame = controller.Frame ();
		
		invalidhands = true;
		
		TimeSpan timeSpan;
		
		foreach (Hand hand in frame.Hands) {
			
			if (hand.IsValid) {
				invalidhands = false;
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
				//score count
				sw.Write ("," + FruitScoreCount.x);
				//hand x scale
//				sw.Write ("\t" + ScaleFruitFall.fruitSliderValue3);
//				//hand y scale
//				sw.Write ("\t" + ScaleFruitFall.fruitSliderValue2);
//				//hand rotation scale
//				sw.Write ("\t" + ScaleFruitFall.fruitSliderValue);
				//timer amount (algorithm scaling)
				sw.Write ("," + ReceiveTimerData.spawntime);
				//				//basket position
				//				sw.Write ("\t" + ScaleFruitFall.vScrollbarValue);
				//				//basket scale
				//				sw.Write ("\t" + ScaleFruitFall.vScrollbarValue2);

				sw.Write ("," + ScaleBasketMovementLeft.xmin);
				sw.Write ("," + ScaleBasketMovementLeft.xmax);
				sw.Write ("," + PlayerPrefs.GetFloat ("Roll"));


				sw.Write ("," + ScaleBasketMovementLeft.originscaled);
				sw.Write ("," + ScaleBasketMovementLeft.thresholdscaled);
				sw.Write ("," + ScaleBasketMovementLeft.scaled);

			}
			
			sw.Write ("\n");
		}
		
	}
	
	
	public void Complete(){
		sw.Close ();
	}
}