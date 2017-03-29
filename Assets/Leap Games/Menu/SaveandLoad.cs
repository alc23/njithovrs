using UnityEngine;
using System.Collections;

public class SaveandLoad : MonoBehaviour {


	void onSaveGame(){
		//GameControl.control.Save ();

	}

	void onLoad(){

		//GameControl.control.Load ();
	}

	void onLoadGame(){
		Application.LoadLevel ("MainMenu");
	}

//	void onPlayerSave(){
//		GameControl.control.
//	}

	// Use this for initialization
//	void OnGUI(){
//	
//		if(GUI.Button (new Rect (Screen.width/2 -130, 175, 80, 50), "Save Score"))
//		{
//			GameControl.control.Save();
//		}
//
////		if(GUI.Button (new Rect (Screen.width -320, Screen.height -30, 80, 20), "End Session"))
////		{
////			HandValues.Complete();
////		}
//
//	
//
//		if(GUI.Button (new Rect (Screen.width/2 + 50, 175, 80, 50), "Load Score"))
//		{
//			GameControl.control.Load();
//		}
//	}

}