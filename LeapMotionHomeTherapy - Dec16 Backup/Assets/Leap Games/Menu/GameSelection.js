#pragma strict


function OnGUI () {

	if (GUI.Button (Rect (Screen.width/2-225, 175, 250, 50), "Bowling Game") ) {

 		Application.LoadLevel ("BowlingTherapy");
 		}
 		
 	else if (GUI.Button (Rect (Screen.width-505, 175, 250,50), "Whack A Mole")) {

 		Application.LoadLevel ("WhackAMole");
 		}
 
 	else if (GUI.Button (Rect (60, 175, 250, 50), "Fruit Fall")) {

 		Application.LoadLevel ("FruitFallTherapy");
 		}
 
 
			
}