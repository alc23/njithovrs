using UnityEngine;
using System.Collections;
using System;
using System.IO;
using Leap;

public class PitchHandValuesFly : MonoBehaviour {
	
	public string output;
	Controller controller;
	
	public Texture disconnectedImg;
	public static bool invalidhands;
	
	static float timer;

	public static string fileName = string.Format("PitchHandFlyData" + DateTime.Today.ToString("MMddyyyy") + ".txt");
	
	StreamWriter sw = new StreamWriter ("Data/Flying/" + fileName, true);
	
	void Start (){
		controller = new Controller();
	}
	
	void OnGUI(){
		if (invalidhands = !invalidhands) {
			GUI.DrawTexture (new Rect (300, 100, 800, 500), disconnectedImg);
		}
	}
	
	void Update (){
		Debug.Log (invalidhands);
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

				//orb collection score
				sw.Write("," + TriggerScore.mazeScore);
				//Pitch sensitivity
				//sw.Write("," + GestureLocknoX.pitchflySliderValue);
				//Origin Rotation
				sw.Write("," +GestureLocknoX.pitchflySliderValue2);
				//Flying speed scale
				sw.Write("," + GestureLocknoX.pitchflySliderValue3);
				//Calibrated pitch max
				sw.Write("," + PlayerPrefs.GetFloat("pitchUp"));
				//Calibrated pitch min
				sw.Write("," + PlayerPrefs.GetFloat ("pitchDown"));
				//scaled pitch value
				sw.Write("," + GestureLocknoX.scaled);
				sw.Write("\n");
			}
			
		}
	}
	public void Complete(){
		sw.Close ();
	}
}