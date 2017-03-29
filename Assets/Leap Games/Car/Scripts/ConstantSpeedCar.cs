using UnityEngine;
using System.Collections;
using Leap;
using Leap.Unity;


public class ConstantSpeedCar : MonoBehaviour {

	public Texture rotImg;
	public Texture xImg;
	public Texture yImg;
	Controller m_leapController;
	public static float closevalue;
	public static float openvalue;
	public static float finalval;

	public bool isLeft = false;
	public bool gestureLeft = false;
	public bool isRight = false;
	public bool gestureRight = false;
	public static float getPos;

	public Vector3 newPos;
	public Vector3 getCarPos;

	public float handopenThreshold;


	public GameObject go;
	//public Rigidbody rb = go.GetComponent<Rigidbody>();


	void Start () {
		closevalue = PlayerPrefs.GetFloat ("sphereRadiusclose1");
		openvalue = PlayerPrefs.GetFloat ("sphereRadiusopen1");
		m_leapController = new Controller();



	}


	public static float scale (float OldMin, float OldMax, float NewMin, float NewMax, float OldValue){
		float OldRange = (OldMax - OldMin);
		float NewRange = (NewMax - NewMin);
		float NewValue = (((OldValue - OldMin) * NewRange) / OldRange) + NewMin;

		return (NewValue);
	}

	void FixedUpdate () {

		handopenThreshold = openvalue * .85f;

		getPos= go.transform.position.x;

		if (getPos > -903f){
			isLeft = true;
			isRight = false;
		}

		else if (getPos <-903f){
			isRight = true;
			isLeft = false;
		}


		float pos = GetComponentInParent<Rigidbody> ().position.x;

		Frame frame = m_leapController.Frame();
		if (frame.Hands.Count >= 1) {
			getCarPos = go.transform.position;
			Vector3 newRot = transform.parent.localRotation.eulerAngles;

			foreach (Hand hand in frame.Hands) {

				float roll = hand.PalmNormal.Roll;

				if (hand.GrabAngle > handopenThreshold) {
					go.GetComponent<Rigidbody>().velocity = Vector3.forward  * -.2f;
				}
					
			}

		}

	}

}