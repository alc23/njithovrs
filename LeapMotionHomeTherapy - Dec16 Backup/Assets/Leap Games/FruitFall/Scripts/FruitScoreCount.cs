using UnityEngine;
using System.Collections;


public class FruitScoreCount : MonoBehaviour {

	public AudioClip impact;
	AudioSource audio;

	public static float x;
	public string levelToLoad = "Main Menu";
	public GUIStyle fruitGUI;
	public GUIStyle buttonGUI;

	void Start (){
		audio = GetComponent<AudioSource>();
	}

	void OnCollisionEnter (Collision coll){
		if(coll.gameObject.tag == "fruit"){
			x++;
			//print("x" +x);
			ScaleFruitFall.IncreaseScore(1);
			audio.PlayOneShot(impact);
		}
	}

	void Update(){
		if (x == 1) {
			//insert character animation reminder to face the palm back up
		}
	}

	void OnGUI(){
			GUI.Label (new Rect(80, 50, 600, 650), "Score: " + x.ToString(), fruitGUI);
			if (x==5) {
				GUI.Label (new Rect (1300,470,300,150), "Great!", fruitGUI);
			}
			if (x==3) {
				GUI.Label (new Rect (1300,470,300,150), "Fantastic!", fruitGUI);
			}
			if (x==1) {
				GUI.Label (new Rect (1300,470,300,150), "Great Job!", fruitGUI);
			}
			//if (GUI.Button (new Rect (UnityEngine.Screen.width-175, UnityEngine.Screen.height-75, 100, 50), "MainMenu", buttonGUI)) {
			//	Application.LoadLevel (levelToLoad);
		//}
	}
}