var target : Transform; 
var pinScrollbarValue : float;

function Start (){
	pinScrollbarValue = PlayerPrefs.GetInt ("pinScrollbarValue", pinScrollbarValue);
}

function OnGUI () { 
	if (TogglesBowlingGUI.GUIEnable == true){
		pinScrollbarValue = GUI.HorizontalScrollbar (Rect (30, Screen.height-220, 200, 30), pinScrollbarValue, 1.0, 5.0, 14.0); 
	
	if (GUI.Button(Rect(30,UnityEngine.Screen.height - 270, 200 ,30),"Save Pin Scaling"))
			Save();
	}
}

function Update () { 
	target.position.z = pinScrollbarValue; 
}

function Save(){
	PlayerPrefs.SetInt ("pinScrollbarValue", pinScrollbarValue);
}