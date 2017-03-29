using UnityEngine;
using System.Collections;
using Leap;

public class CheckHandOpen : MonoBehaviour {


	Controller controller;
	public static float openCount= 0;
	public bool handOpen = false;
	public float strength;
	public bool flag1 = false;
	public bool flag2 = false;
	public bool flag3 = false;
	//public ParticleSystem particleSys;
	public static bool playPart = false;


	// Use this for initialization
	void Start () {
		controller = new Controller();
	}
	
	// Update is called once per frame
	void Update () {
		Frame frame = controller.Frame ();

		foreach (Hand hand in frame.Hands) {

			strength = hand.GrabStrength;

			if (strength < 0.8f){
				flag1 = true;
				flag2 = false;
				playPart = true;
			}

			if (strength > 0.8f){
				flag2 = true;
				playPart = false;
			}

			if (flag1== true && flag2 == true){
				flag3 = true;
				flag1 = false;
				flag2 = false;
				openCount += 0.5f;
				HandOpenCount.AddCount (0.5f);
			}
			else{
				flag3 = false;
			}

			foreach (Finger finger in hand.Fingers) {

			}
		}

		//Debug.Log (openCount);

		//if (handOpen = true)


	}


	IEnumerator run(){
			
			yield return new WaitForSeconds(5);
			
	

	}
}
