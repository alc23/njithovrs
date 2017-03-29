using UnityEngine;
using System.Collections;

public class SphereSaveScore : MonoBehaviour {
	
	void OnCollisionEnter(Collision other){
		Save ();

	}
	
	public void Save(){
		PlayerPrefs.SetInt ("MazeScore", MazeScore.mazeScore);
	}
}