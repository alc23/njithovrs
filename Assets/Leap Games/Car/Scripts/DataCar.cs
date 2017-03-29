//using System;
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine.Networking;
//using UnityEngine;
//using Leap;
//using Leap.Unity;
//
//[Serializable]
//public class ResponseClass{
//	public string status;
//	public string username;
//	public string role;
//	public string sessionId;
//}
//
//public class DataCar : MonoBehaviour {
//
//	ResponseClass response = new ResponseClass();
//
//	private int GID = 1;
//	private int session = 1;
//	private string timeStamp = "123456";
//	private float[] palm = new float[]{1f,2f,3f};
//	private float[] norm = new float[]{1f,2f,3f};
//	private float[] wrist = new float[]{1f,2f,3f};
//	private float[] thumb = new float[]{1f,2f,3f};
//	private float[] index = new float[]{1f,2f,3f};
//	private float[] middle = new float[]{1f,2f,3f};
//	private float[] ring = new float[]{1f,2f,3f};
//	private float[] pinky = new float[]{1f,2f,3f};
//
//	public HandDataClass HandDataStream = new HandDataClass(1,1,"12:32:43pm",new float[]{1f,2f,3f},new float[]{1f,2f,3f},new float[]{1f,2f,3f},new float[]{1f,2f,3f},new float[]{1f,2f,3f},new float[]{1f,2f,3f},new float[]{1f,2f,3f},new float[]{1f,2f,3f});
//	string HandDataJson; 
//
//	Controller controller;
//	public static bool invalidhands;
//
//	// Use this for initialization
//	void Start () {
//		controller = new Controller ();
//		StartCoroutine (Upload());
//
//		HandDataJson = JsonUtility.ToJson(HandDataStream);
//		Debug.Log (HandDataJson);
//	}
//
//	IEnumerator Upload(){
//		WWWForm form = new WWWForm ();
//		form.AddField("type", "auth");
//		form.AddField ("username", "dkehoe");
//		form.AddField ("password", "12345");
//
//		UnityWebRequest www = UnityWebRequest.Post ("http://ec2-54-245-43-22.us-west-2.compute.amazonaws.com/rpc/auth.php", form);
//		yield return www.Send();
//
//		if(www.isError){
//			Debug.Log(www.error);
//		}
//		else{
//			response = JsonUtility.FromJson<ResponseClass>(www.downloadHandler.text);
//			Debug.Log (response.status);
//			Debug.Log (response.username);
//			Debug.Log (response.role);
//			Debug.Log (response.sessionId);
//			}
//	}
//
//	public class HandDataClass{
//		public int GID;
//		public int session;
//		public string timeStamp;
//		public float[] palm;
//		public float[] norm;
//		public float[] wrist;
//		public float[] thumb;
//		public float[] index;
//		public float[] middle;
//		public float[] ring;
//		public float[] pinky;
//
//		public HandDataClass(int GID, int session, string timeStamp, float[] palm, float[] norm, float[] wrist, float[] thumb, float[] index, float[] middle, float[] ring, float[] pinky)
//		{
//			this.GID = GID;
//			this.session = session;
//			this.timeStamp = timeStamp;
//			this.palm = palm;
//			this.norm = norm;
//			this.wrist = wrist;
//			this.thumb = thumb;
//			this.index = index;
//			this.middle = middle;
//			this.ring = ring;
//			this.pinky = pinky;
//		}
//	}
//
//	// Update is called once per frame
//	void Update () {
//		Frame frame = controller.Frame ();
//
//		foreach (Hand hand in frame.Hands){
//			if (frame.Hands.Count > 0){
//				invalidhands = !invalidhands;
//
//				GID = 9;
//				session = response.sessonId;
//				timeStamp = Epoch.Current();
//				palm = hand.PalmPosition;
//				norm = hand.PalmNormal;
//				wrist = hand.WristPosition;
//				var fingersArray = new Array ("");
//
//				foreach (Finger finger in hand.Fingers) {
//					Bone bone;
//					foreach (Bone.BoneType boneType in (Bone.BoneType[]) Enum.GetValues(typeof(Bone.BoneType))) {
//						bone = finger.Bone (boneType);
//						fingersArray.Add (bone.PrevJoint + ",");
//					}
//					fingersArray.Add ();
//				}
//	}
//}
