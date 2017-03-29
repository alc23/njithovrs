using UnityEngine;
using System.Collections;

public class TriggerScore : MonoBehaviour {
	public static int mazeScore;

	public GUIStyle mazeGUI;

	// Use this for initialization
	public static void AddScore(int Amount){
		mazeScore += Amount;
	}

	void OnGUI(){
		GUI.Label (new Rect (100, 50, 600, 650), "Score: " + mazeScore.ToString (), mazeGUI);

	}

	void Update(){
		Debug.Log (mazeScore);
	}
}
