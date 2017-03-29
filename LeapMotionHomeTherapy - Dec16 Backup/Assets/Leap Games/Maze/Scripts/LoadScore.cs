using UnityEngine;
using System.Collections;

public class LoadScore : MonoBehaviour {

	public static int mazeScore;

	// Use this for initialization
	void OnTriggerEnter(Collider other){
		Load ();
	}

	// Update is called once per frame
	void Load () {
		mazeScore = PlayerPrefs.GetInt ("MazeScore");
	}
}
