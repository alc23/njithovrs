using UnityEngine;
using System.Collections;

public class PickFruitScore : MonoBehaviour {

	public GUIStyle fruitGUI;

	public static int pickingScore = 0;
	public static int incorrectScore;

	public static void AddScore(int amount){
		pickingScore = pickingScore + amount;	
	}

	void Start(){
		//insert character animation that introduces this game
	}
	
	void OnGUI(){
		GUI.Label (new Rect ((Screen.width / 2) - 55, Screen.height - 100, 600, 650), "Score: " + pickingScore.ToString (), fruitGUI);
	}	

	void Update(){
		//Debug.Log (pickingScore);
		if (pickingScore == 10) {
			//insert movie texture character animation congratulations
		}

		if (pickingScore == -1) {
			//insert movie texture character animation that reminds them to sort the correct fruit in the basket
		} 
	}
}