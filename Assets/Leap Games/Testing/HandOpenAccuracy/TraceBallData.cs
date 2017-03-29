using UnityEngine;
using System.Collections;
using System;
using System.IO;
using Leap;
using Leap.Unity;

public class TraceBallData : MonoBehaviour {
	
	public string output;
	Controller controller;
	
	public Texture disconnectedImg;
	public static bool invalidhands;
	
	static float timer;
	public static string fileName = string.Format("TestingHandsOpenAccuracyData" + DateTime.Today.ToString("MMddyyyy") + ".txt");
	
	StreamWriter sw = new StreamWriter ("Data/Testing/" + fileName, true);

	[SerializeField]
	private float _minSphereRadius = .03f; //meters
	[SerializeField]
	private float _maxSphereRadius = .1f; //meters
	[SerializeField]
	IHandModel HandModel;

	private float _sphereRadius = 0;
	private Vector _sphereCenter = Vector.Zero;

	void OnDrawGizmos () {
		Gizmos.DrawWireSphere(SphereCenter, SphereRadius);
	}

	private void calculateSphere(){
		Hand hand = HandModel.GetLeapHand();
		_sphereRadius = _minSphereRadius + (_maxSphereRadius - _minSphereRadius) * (1 - hand.GrabStrength);
		_sphereCenter = hand.PalmPosition + hand.PalmNormal * _sphereRadius;
	}

	public float SphereRadius{
		get{
			calculateSphere();
			return _sphereRadius;
		}
	}

	public Vector3 SphereCenter{
		get{
			calculateSphere();
			return _sphereCenter.ToVector3();
		}
	}


	
	void Start (){
		controller = new Controller();

		if(HandModel == null){
			HandModel = gameObject.GetComponentInParent<IHandModel>();
		} 
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
				
				sw.Write ("," + _sphereRadius);
				
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