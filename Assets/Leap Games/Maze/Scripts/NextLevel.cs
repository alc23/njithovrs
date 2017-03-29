using UnityEngine;
using System.Collections;

public class NextLevel : MonoBehaviour {

	public string levelToLoad = "";
	public static int mazeScore;


	void OnCollisionEnter (Collision coll){
		if (coll.gameObject.tag == "Player"){
			//insert character animation here that congratulates them for reaching the goal/next level
			Application.LoadLevel (levelToLoad);
			Load ();
		}
	}

	
	void Load () {
		mazeScore = PlayerPrefs.GetInt ("MazeScore");
	}
}
