using UnityEngine;
using System.Collections;

public class GameOver : MonoBehaviour {

	public string levelToLoad = "";

	void OnTriggerEnter (Collider other){
		//if (other.gameObject.tag == "Player"){
			Debug.Log ("fell");
			Application.LoadLevel (levelToLoad);
			MazeScore.mazeScore = LoadScore.mazeScore;
		//}
	}
}
