using UnityEngine;
using System.Collections;

public class Speed : MonoBehaviour {

	public GUIStyle carGUI;
	public static float vel;
	public static float timer = 0.0f;

	// Update is called once per frame
	void Update () {
		Rigidbody rb = GetComponent <Rigidbody> ();
		vel = 2.5f * rb.velocity.magnitude;	
		timer += Time.deltaTime;

	}

	void OnGUI(){
		GUI.Label (new Rect (80, 80, 300, 150), "Speed: " +  vel.ToString ("0") + "MPH", carGUI);
		GUI.Label (new Rect (80, 30, 300, 150), "Time: " + timer.ToString ("00:00"), carGUI);	
	}
}
