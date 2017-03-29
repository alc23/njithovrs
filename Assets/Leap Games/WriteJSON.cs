//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//
//public class WriteJSON : MonoBehaviour {
//
//	private int GameID = 1;
//	private int Session = 1;
//	private string TimeS = "12:32:43pm";
//	private float[] PalmPos = new float[]{1f,2f,3f};
//	private float[] PalmNorm = new float[]{1f,2f,3f};
//	private float[] WristPos = new float[]{1f,2f,3f};
//	private float[] thumb = new float[]{1f,2f,3f};
//	private float[] index = new float[]{1f,2f,3f};
//	private float[] middle = new float[]{1f,2f,3f};
//	private float[] ring = new float[]{1f,2f,3f};
//	private float[] pinky = new float[]{1f,2f,3f};
//
//	public HandDataClass HandDataStream = new HandDataClass(1,1,"12:32:43pm",new float[]{1f,2f,3f},new float[]{1f,2f,3f},new float[]{1f,2f,3f},new float[]{1f,2f,3f},new float[]{1f,2f,3f},new float[]{1f,2f,3f},new float[]{1f,2f,3f},new float[]{1f,2f,3f});
//	string HandDataJson; 
//
//
//	// Use this for initialization
//	void Start () {
//
//		HandDataJson = JsonUtility.ToJson(HandDataStream);
//		Debug.Log (HandDataJson);
//	}
//	
//	// Update is called once per frame
//	void Update () {
//		
//	}
//}
//
//public class HandDataClass{
//	public int GID;
//	public int seesion;
//	public string timeStamp;
//	public float[] palm;
//	public float[] norm;
//	public float[] wrist;
//	public float[] thumb;
//	public float[] index;
//	public float[] middle;
//	public float[] ring;
//	public float[] pinky;
//
//	public HandDataClass(int GID, int session, string timeStamp, float[] palm, float[] norm, float[] wrist, float[] thumb, float[] index, float[] middle, float[] ring, float[] pinky)
//	{
//		this.GID = GID;
//		this.seesion = session;
//		this.timeStamp = timeStamp;
//		this.palm = palm;
//		this.norm = norm;
//		this.wrist = wrist;
//		this.thumb = thumb;
//		this.index = index;
//		this.middle = middle;
//		this.ring = ring;
//		this.pinky = pinky;
//	}
//}
