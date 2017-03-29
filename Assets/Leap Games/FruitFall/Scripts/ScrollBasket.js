 #pragma strict

import System.Runtime.Serialization.Formatters.Binary;
import System.Runtime.Serialization;
import System.IO;

var target : Transform; 
var vScrollbarValue : float;
var vScrollbarValue2 : float;

function Start(){
	vScrollbarValue = PlayerPrefs.GetFloat ("vScrollbarValue");
	vScrollbarValue2 = PlayerPrefs.GetFloat ("vScrollbarValue2");
}

function OnGUI () { 
	if (TogglesGUI.GUIEnable == true){
		vScrollbarValue = GUI.HorizontalScrollbar (Rect (30, Screen.height-270, 200, 30), vScrollbarValue, 1.0, -5.0, 5.0); 
		vScrollbarValue2 = GUI.HorizontalScrollbar (Rect (30, Screen.height - 330, 200, 30), vScrollbarValue2, 1.0, 1.5, 4.0);
		if (GUI.Button(Rect(30,UnityEngine.Screen.height - 390, 200 ,30),"Save Basket Scaling"))
			Save();
	}
	
	}


function Update () { 
	target.position.x = vScrollbarValue; 
	target.localScale.x = vScrollbarValue2;
	//target.localScale.y = vScrollbarValue2;
	//target.localScale.z = vScrollbarValue2;
}

function Save(){
	PlayerPrefs.SetFloat ("vScrollbarValue", vScrollbarValue);
	PlayerPrefs.SetFloat ("vScrollbarValue2", vScrollbarValue2);
}


 