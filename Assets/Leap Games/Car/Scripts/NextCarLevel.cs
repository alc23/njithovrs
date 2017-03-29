using UnityEngine;
using System.Collections;

public class NextCarLevel : MonoBehaviour {

	public string levelToLoad = "";
	//public static int mazeScore;
	public Texture endgameImg;
	public static bool collided = false;

	public GUIStyle carGUI;

	void Start (){

		collided = false;

	}


	void OnCollisionEnter (Collision coll){

			collided = true;
			//insert character animation here that congratulates them for reaching the goal/next level

			StartCoroutine (LoadLevel());
			//Load ();

	}

//	void Load () {
//		mazeScore = PlayerPrefs.GetInt ("MazeScore");
//	}

	void OnGUI(){
		if (collided == true) {
			GUI.Label (new Rect (UnityEngine.Screen.width / 2 - 280, UnityEngine.Screen.height - 400, 500, 30), "Loading Next Level!", carGUI);
			GUI.Label (new Rect (UnityEngine.Screen.width / 2 - 280, UnityEngine.Screen.height - 320, 500, 30), "Time Completed: " +Speed.timer.ToString ("00:00"), carGUI);
		}
	}

	IEnumerator LoadLevel(){
		yield return new WaitForSeconds(2);
		Application.LoadLevel (levelToLoad);
	}


}
