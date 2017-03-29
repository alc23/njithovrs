
using UnityEngine;
using System.Collections;
using Leap;
using Leap.Unity;

public class BallHeight : MonoBehaviour {

	Controller m_leapController;
	public static float closevalue;
	public static float openvalue;
	public static float clampvalue;
	public static float handsphere;
	public static float scaled;
	public float timeLeft = 10.0f;
	
	public static float scale (float OldMin, float OldMax, float NewMin, float NewMax, float OldValue){
		float OldRange = (OldMax - OldMin);
		float NewRange = (NewMax - NewMin);
		float NewValue = (((OldValue - OldMin) * NewRange) / OldRange) + NewMin;
		
		return (NewValue);
	}

	[SerializeField]
	private float _minSphereRadius = .03f; //meters
	[SerializeField]
	private float _maxSphereRadius = .1f; //meters
	[SerializeField]
	IHandModel HandModel;

	private float _sphereRadius = 0;
	private Vector _sphereCenter = Vector.Zero;

	public float SphereRadius{
		get{
			calculateSphere();
			return _sphereRadius;
		}
	}

	public Vector3 SphereCenter{
		get{
			calculateSphere();
			return _sphereCenter.ToVector3();
		}
	}
	void Awake(){
		
		openvalue = PlayerPrefs.GetFloat ("sphereRadiusopen");
		closevalue = PlayerPrefs.GetFloat ("sphereRadiusclose");
	}
	
	void Start () {
		
		//insert character animation introduction
		m_leapController = new Controller ();

		if(HandModel == null){
			HandModel = gameObject.GetComponentInParent<IHandModel>();
		}  

		
	}

	void OnDrawGizmos () {
		Gizmos.DrawWireSphere(SphereCenter, SphereRadius);
	}

	private void calculateSphere(){
		Hand hand = HandModel.GetLeapHand();
		_sphereRadius = _minSphereRadius + (_maxSphereRadius - _minSphereRadius) * (1 - hand.GrabStrength);
		_sphereCenter = hand.PalmPosition + hand.PalmNormal * _sphereRadius;
	}

	void Update () {

		Vector3 newPos = transform.localPosition;

		Frame frame = m_leapController.Frame ();
		
		foreach (Hand hand in frame.Hands) {

				
				Debug.Log ("working");
				
				//clampvalue = Mathf.Clamp (hand.SphereRadius, closevalue, openvalue);
				
				//scaled = scale(closevalue, openvalue, 60F, -60F, clampvalue);
				
			scaled = scale(openvalue, closevalue, 11F, 17.3F, _sphereRadius);

				if (scaled >17.3f){
					scaled = 17.3f;

				}

				if (scaled <11f){
					scaled = 11f;
					
				}
				
				Debug.Log ("scale" + scaled);
				newPos.y = scaled;
				
				transform.localPosition = Vector3.Lerp (transform.localPosition, newPos, 10f);
			}
		timeLeft -= Time.deltaTime;
		if (timeLeft < 0) {
			Application.Quit ();
		}
		}
	}
	


