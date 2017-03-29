using UnityEngine;
using System.Collections;

public class BowlingScore : MonoBehaviour {
	
	public static int bowlScore;
	public Transform[] allPins; 
	string levelToLoad = "Bowling";
	string levelToLoad2 = "MainMenu";
	public GUIStyle myGUI;
	public GUIStyle buttonGUI;
	public AudioClip success;
	AudioSource audio;
	public static int score;

	void Start (){
		audio = GetComponent<AudioSource>();
	}
	
	public int CountScore() {
		
		int bowlScore = 0;
		
		for (int p=0; p<allPins.Length; p++) {
			Vector3 pinsUpVector = allPins [p].up;
			if (Vector3.Angle (pinsUpVector, Vector3.up) > 13f)
				bowlScore++;
		}
		return bowlScore;
	}
	
	void OnGUI () {
		
		GUI.Button (new Rect (80, 80, 150, 20), "Pins Hit: " + CountScore (), myGUI); 
		
		if (CountScore () == 10) {
			//audio.PlayOneShot(success);
			GUI.Button (new Rect ((Screen.width)/2-67, (Screen.height)-200, 150, 20), "STRIKE!", myGUI);
		}
		
//		if (GUI.Button (new Rect (UnityEngine.Screen.width - 175, UnityEngine.Screen.height - 90, 100, 100), "Reset Pins",buttonGUI)) {
//			
//			Application.LoadLevel (levelToLoad);
//			
//		}
		
	}



	void Update(){
		score = CountScore ();
	}
	
}