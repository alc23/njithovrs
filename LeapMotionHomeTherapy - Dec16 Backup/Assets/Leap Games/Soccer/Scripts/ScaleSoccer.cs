using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using Leap;
using UnityEngine;
using System.Collections;

public class ScaleSoccer : MonoBehaviour {
	
	Controller m_leapController;

	public GameObject soccerBall;

	public GUIStyle soccerGUI;
	
	public static float soccerSpawn1 = 1.0f;
	
	public static float soccerSpawn2 = 1.0f;
	
	public static float soccerSpawn3 = 1.0f;
	
	public Texture shoriz;
	public Texture svert;
	public Texture sspeed;

	public static float success = 1f;
	public static float miss;
	public static float percentage;

	public static float xmin;
	public static float xmax;
	public static float clampvalue;
	public static float scaled;
	public static float scaledspawn;
	public static float scaledy;
	public static float clampvaluey;
	public static float ymin;
	public static float ymax;

	public static float scale (float OldMin, float OldMax, float NewMin, float NewMax, float OldValue){
		float OldRange = (OldMax - OldMin);
		float NewRange = (NewMax - NewMin);
		float NewValue = (((OldValue - OldMin) * NewRange) / OldRange) + NewMin;
		
		return (NewValue);
	}


	void Awake () {

		ymin = PlayerPrefs.GetFloat ("yMin");
		ymax = PlayerPrefs.GetFloat ("yMax");
		xmin = PlayerPrefs.GetFloat ("xMin");
		xmax = PlayerPrefs.GetFloat ("xMax");

		scaledspawn = scale(-250, 250, 2F, 80F, xmax);

		m_leapController = new Controller();
		Load ();
	}

	void Start(){
		//insert character animation introducing the game
		InvokeRepeating ("SpawnWave", 0, 15 - soccerSpawn3);
	}

	Hand GetRightMostHand(Frame f) {
		float largestVal = -float.MaxValue;
		Hand h = null;
		for(int i = 0; i < f.Hands.Count; ++i) {
			if (f.Hands[i].PalmPosition.ToUnity().x > largestVal) {
				largestVal = f.Hands[i].PalmPosition.ToUnity().x;
				h = f.Hands[i];
			}
		}
		return h;
	}
	

	public static float soccerSlider = 0.1F;

	public Texture xImg;

	void OnGUI() {
			GUI.Label (new Rect (100, 80, 300, 150), "Score: " + success.ToString (), soccerGUI);
	
		if (ToggleSoccerGUI.GUIEnabled = !ToggleSoccerGUI.GUIEnabled) {
			soccerSlider = GUI.HorizontalSlider (new Rect (30, UnityEngine.Screen.height - 30, 200, 30), soccerSlider, 0.1F, 1.5F);
			GUI.DrawTexture (new Rect (240, UnityEngine.Screen.height - 35, 20, 20), xImg);

//			soccerSpawn1 = GUI.HorizontalSlider (new Rect (30, UnityEngine.Screen.height - 150, 200, 30), soccerSpawn1, 2.0F, 50.0F);
//			GUI.DrawTexture (new Rect (240, UnityEngine.Screen.height - 155, 20, 20), shoriz);
//			
			soccerSpawn2 = GUI.HorizontalSlider (new Rect (30, UnityEngine.Screen.height - 210, 200, 30), soccerSpawn2, 2.1F, 25.0F);
			GUI.DrawTexture (new Rect (240, UnityEngine.Screen.height - 215, 20, 20), svert);
			
			soccerSpawn3 = GUI.HorizontalSlider (new Rect (30, UnityEngine.Screen.height - 270, 200, 30), soccerSpawn3, 0.1F, 13.0F);
			GUI.DrawTexture (new Rect (240, UnityEngine.Screen.height - 275, 20, 20), sspeed);

			if (GUI.Button(new Rect(30, UnityEngine.Screen.height - 360, 200, 30), "Save Scaling"))
				Save ();

			GUI.Label(new Rect(30, UnityEngine.Screen.height - 50, 200, 30), "Hand Horizontal Scaling: " + soccerSlider);
			GUI.Label(new Rect(30, UnityEngine.Screen.height - 175, 200, 30), "Spawn Area Width: " + soccerSpawn1);
			GUI.Label(new Rect(30, UnityEngine.Screen.height - 230, 200, 30), "Spawn Area Height: " + soccerSpawn2);
			GUI.Label(new Rect(30, UnityEngine.Screen.height - 290, 200, 30), "Spawn Frequency: " + soccerSpawn3);
			

		}
	}
	
//	public void Preset1(){
//		soccerSlider = 1.2f;
//		soccerSpawn1 = 2.1f;
//		soccerSpawn2 = 2.0f;
//		soccerSpawn3 = 0.1f;
//
//	}
//
//	public void Preset2(){
//		soccerSlider = 0.6f;
//		soccerSpawn1 = 26.0f;
//		soccerSpawn2 = 13.0f;
//		soccerSpawn3 = 4.0f;
//
//	}
//
//	public void Preset3(){
//		soccerSlider = 0.1f;
//		soccerSpawn1 = 50.0f;
//		soccerSpawn2 = 25.0f;
//		soccerSpawn3 = 8.0f;
//
//	}


	void FixedUpdate () {
		
		Frame frame = m_leapController.Frame ();
		float roll = frame.Hands [0].PalmNormal.Roll; 
		
		if (frame.Hands.Count >= 1) {


			Hand rightHand = GetRightMostHand (frame);
		
			Vector3 avgPalmForward = frame.Hands [0].Direction.ToUnity ();     
			Vector3 handDiff = rightHand.PalmPosition.ToUnity ();

			
			Vector3 newPos = transform.parent.localPosition;
			newPos.x = scaled;
			newPos.y = scaledy;


			foreach (Hand hand in frame.Hands) {
				
				//newPos.z = -hand.PalmPosition.z/10;
				//newPos.y = ((hand.PalmPosition.y/2)-16);
				
				clampvalue = Mathf.Clamp (hand.PalmPosition.x, xmin, xmax);
				
				scaled = scale(xmin, xmax, 100F, -100F, clampvalue);
			
				clampvaluey = Mathf.Clamp (hand.PalmPosition.y, ymin, ymax);

				scaledy =scale (ymin, ymax, 15F, 150F, clampvaluey);
			}

			transform.parent.localPosition = Vector3.Lerp (transform.parent.localPosition, newPos, 0.1f);
		}
	}

	void SpawnWave() {
		GameObject obj = Instantiate(soccerBall) as GameObject;
		obj.transform.position = new Vector3(UnityEngine.Random.Range (0 - scaledspawn,30 + soccerSpawn1), UnityEngine.Random.Range (50 - soccerSpawn2,70 + soccerSpawn2), 60);
		Rigidbody [] children = obj.GetComponentsInChildren<Rigidbody>();

		for(int i = 0; i < children.Length; ++i) {
			children[i].velocity = new Vector3(UnityEngine.Random.Range(5.0f, 5.1f), UnityEngine.Random.Range(5.0f, 5.1f), UnityEngine.Random.Range(250.0f, 270.1f));
			children[i].angularVelocity = new Vector3(UnityEngine.Random.Range (0.0f, 0.5f), UnityEngine.Random.Range (0.0f, 0.5f), UnityEngine.Random.Range (0.0f, 0.5f));
		}
	}

	public static void IncreaseScore (float Amount){
		success += Amount;
	}
	
	public static void IncreaseMiss (float Amount){
		miss += Amount;
	}

//	void Update(){
//		percentage = success / (success + miss);
//		
//		if (percentage < 0.75f) {
//			bool algpercentage = true;
//			soccerSlider = soccerSlider + 0.1f;
//			algpercentage = false;
//			StartCoroutine (alg ());
//			
//		} else if (percentage == 0) {
//			bool algpercentage = false;
//		} else {
//			bool algpercentage = false;
//		}
	//	}

//	IEnumerator alg(){
//		success = 0;
//		miss = 0;
//		yield return null;


//	}

	//insert character animation for when the algorithm makes it easier
	//when algorithm percentage is more than 25% miss AND its been at least x minutes 
	//insert character animation for when the algorithm makes it more difficult again
	//when algorithm percentage is less than 10% miss AND its been at least x minutes

	public void Save(){
		PlayerPrefs.SetFloat ("soccerSlider", soccerSlider);
		PlayerPrefs.SetFloat ("soccerSpawn1", soccerSpawn1);
		PlayerPrefs.SetFloat ("soccerSpawn2", soccerSpawn2);
		PlayerPrefs.SetFloat ("soccerSpawn3", soccerSpawn3);
	}

	public void Load(){
		soccerSlider = PlayerPrefs.GetFloat ("soccerSlider");
		soccerSpawn1 = PlayerPrefs.GetFloat ("soccerSpawn1");
		soccerSpawn2 = PlayerPrefs.GetFloat ("soccerSpawn2");
		soccerSpawn3 = PlayerPrefs.GetFloat ("soccerSpawn3");
	}
}