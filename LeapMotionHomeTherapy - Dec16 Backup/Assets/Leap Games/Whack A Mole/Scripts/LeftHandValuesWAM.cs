using UnityEngine;
using System.Collections;
using System;
using System.IO;
using Leap;


public class LeftHandValuesWAM : MonoBehaviour {
	
	Controller controller;
	public Texture disconnectedImg;
	public static bool invalidhands;

	static float timer;
	public static string fileName = string.Format("LeftWAMHandData" + DateTime.Today.ToString("MMddyyyy") + ".txt");
	
	StreamWriter sw = new StreamWriter ("Data/WhackAMole/" + fileName, true);
	
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
			Debug.Log (invalidhands);
			
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
		
				//score
				sw.Write ("," + Overseer.score);
				//hand x scale
			//	sw.Write ("," + WAMScalingLeft.LwamSliderValue3);
				//hand depth scale
			//	sw.Write ("," + WAMScalingLeft.LwamSliderValue2);
				//hand rot scale
			///	sw.Write ("," + WAMScalingLeft.LwamSliderValue);
				//timer amount (scale up whenever there are more than half the moles up
			//	sw.Write ("," + WAMScalingLeft.LwamSliderValue4);
				//target angle
			//	sw.Write ("," + WAMScalingLeft.LwamSliderValue5 * -45f);
				//indicate left handed
				//sw.Write ("," + "0");
				sw.Write ("," + WAMScaling.wamSliderValue4);
				//target angle
				sw.Write ("," + WAMScaling.wamSliderValue5 * -45f);
				sw.Write ("," + WAMScaling.xmin);
				sw.Write ("," + WAMScaling.xmax);
				sw.Write ("," + WAMScaling.scaled);
				sw.Write ("," + WAMScaling.maxroll);
				sw.Write ("," + WAMScaling.scaledroll);
				sw.Write ("\n");
			}
		}
		
	}
	public void Complete(){
		sw.Close ();
	}
}