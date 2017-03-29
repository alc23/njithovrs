using UnityEngine;
using System.Collections;

public class Speed : MonoBehaviour {

	public GUIStyle carGUI;
	public static float vel;
	public static float timer = 0.0f;


	public static bool countsTime = false;

	// Update is called once per frame

	void Start(){
		
		countsTime = true;

	}
		


	void Update () {

		if (NextCarLevel.collided == true) {
			countsTime = false;
		}

		Rigidbody rb = GetComponent <Rigidbody> ();
		vel = 2.5f * rb.velocity.magnitude;	

		if (countsTime == true) {
			timer += Time.deltaTime;
		}


	}

	void OnGUI(){
		GUI.Label (new Rect (80, 80, 300, 150), "Speed: " +  vel.ToString ("0") + "MPH", carGUI);
		GUI.Label (new Rect (80, 30, 300, 150), "Time: " + timer.ToString ("00:00"), carGUI);	
		GUI.Label (new Rect (80, 130, 300, 150), "Coins Collected: " + CoinRotate.coinsCollected, carGUI);
		GUI.Label (new Rect (80, 180, 300, 150), "Lifetime Coins: " + CoinRotate.lifetimeCoins, carGUI);
	}
}
