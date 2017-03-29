using UnityEngine;
using System.Collections;


public class FlyingScore : MonoBehaviour {


	public AudioClip impact;
	AudioSource audio;
	public static int flyScore;
	public GUIStyle puzzleGUI;
	public GUIStyle buttonGUI;
	public float timer = 0.0f;

	void Start (){
		audio = GetComponent<AudioSource>();
	}

	void OnCollisionEnter (Collision coll){
		if(coll.gameObject.tag == "orb"){
			flyScore++;
			audio.PlayOneShot(impact);
		}
	}

	void Update(){
		timer += Time.deltaTime;
		if (timer <= 0) {
			timer = 30;
		}
	}
	
	void OnGUI(){

		GUI.Label (new Rect((Screen.width/2)-200, Screen.height - 100, 300, 150), "Score: " + flyScore.ToString(), puzzleGUI);

		if (flyScore == 5) {
			GUI.Label (new Rect (1300, 470, 300, 150), "Great!", puzzleGUI);
		}
		if (flyScore == 3) {
			GUI.Label (new Rect (1300, 470, 300, 150), "Fantastic!", puzzleGUI);
		}
		if (flyScore == 1) {
			GUI.Label (new Rect (1300, 470, 300, 150), "Great Job!", puzzleGUI);
		}
		if (flyScore == 7) {
			GUI.Label (new Rect (1300, 470, 300, 150), "Awesome!", puzzleGUI);
		}
		if (GUI.Button (new Rect (UnityEngine.Screen.width-175, UnityEngine.Screen.height-50, 100, 50), "Main Menu",buttonGUI)) {
			Application.LoadLevel ("MainMenu");
		}
	}
}