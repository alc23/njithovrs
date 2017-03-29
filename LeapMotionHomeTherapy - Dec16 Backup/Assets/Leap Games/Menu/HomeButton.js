#pragma strict

function OnGUI(){

if (GUI.Button (Rect (Screen.width - 120 , Screen.height - 50, 80, 20), "Main Menu")) {

 		Application.LoadLevel ("MainMenu");
 	}
 }