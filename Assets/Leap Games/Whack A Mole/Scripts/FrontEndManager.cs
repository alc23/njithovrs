using UnityEngine;
using System.Collections;

public class FrontEndManager : MonoBehaviour {
	public GUISkin mySkin;
	bool ShowMenu = false;
	bool waiting = false;
	
	void OnGUI()
	{
		if (null != mySkin)
		{
			GUI.skin = mySkin;	
			if (!ShowMenu){
				GUI.Box (new Rect(0, 0, Screen.width, Screen.height), "", "SplashPage");
				if (!waiting){
					StartCoroutine(MenuDelay(2.0f));
				}
			}
			if (ShowMenu){
				GUI.Box (new Rect(0, 0, 1024, 410), "Meltdown Madness!", "MenuBox");
				if (GUI.Button(new Rect((Screen.width/2) - (510/2), 184, 510, 51), "Play Meltdown Madness", "ReactorStatusNominal"))
					Application.LoadLevel("ReactorRoom");
				
				if (GUI.Button (new Rect((Screen.width/2) - (510/2), 250, 510, 51), "Quit Meltdown Madness", "ReactorStatusVenting"))
					Application.Quit();
			}
		}
	}
	
	IEnumerator MenuDelay(float seconds){
		waiting = true;
		yield return new WaitForSeconds(seconds);
		ShowMenu = true;
		waiting = false;
	}
}
