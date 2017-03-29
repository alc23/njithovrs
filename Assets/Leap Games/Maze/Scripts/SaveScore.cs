using UnityEngine;
using System.Collections;

public class SaveScore : MonoBehaviour {

	void OnTriggerEnter(Collider other){
		Save ();

		Debug.Log ("Saved");
	}
	
	public void Save(){
		PlayerPrefs.SetInt ("MazeScore", MazeScore.mazeScore);
	}
}
