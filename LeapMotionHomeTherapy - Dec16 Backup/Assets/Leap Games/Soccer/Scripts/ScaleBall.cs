using UnityEngine;
using System.Collections;


public class ScaleBall : MonoBehaviour {

	public GameObject sBall;

	void Start () {
		Load ();
	}

	public float soccerSlider2 = 1.0F;

	void OnGUI() {
		if (ToggleSoccerGUI.GUIEnabled = !ToggleSoccerGUI.GUIEnabled) {
			soccerSlider2 = GUI.HorizontalSlider (new Rect (30, UnityEngine.Screen.height - 60, 100, 30), soccerSlider2, 0.1F, 5.0F);
		}
	}	
	
	void Update () {
		sBall.transform.localScale = new Vector3 (soccerSlider2, soccerSlider2, soccerSlider2);
	}
	
	public void Save(){		
		PlayerPrefs.SetFloat ("soccerSlider2", soccerSlider2);
	}
	
	public void Load(){
		soccerSlider2 = PlayerPrefs.GetFloat ("soccerSlider2");
	}
}