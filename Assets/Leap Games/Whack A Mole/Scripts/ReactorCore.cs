using UnityEngine;
using System.Collections;
using Leap;

public class ReactorCore : MonoBehaviour {

	public GameObject ControlRod;
	public Transform UpPosition;
	public Transform DownPosition;
	public AudioSource SelectSound;
	public Light CoreGlow;
	public Color NominalColor;
	public Color StabilizingColor;
	public Color DestabilizingColor;
	public Color VentingColor;
	public Color RodFailureColor;

	private bool switchallow = false;

	private float uptimer = 0;

	Controller controller;
	
	public enum RodStatus
	{
		Up,
		MovingUp,
		Selected,
		MovingDown,
		Down
	}
	
		
	public RodStatus ControlState = RodStatus.Up;
	float VentingTime = 2;
	bool venting = false;
	bool handMoveUp;
	bool handMoveDown;

	float angleTime = 0;

	public int TimesFixed = 0;
	public float wamSliderValue5;
	
	// Use this for initialization
	void Start () {
		controller = new Controller();
		wamSliderValue5 = PlayerPrefs.GetFloat ("wamSliderValue5");
	}
	
	// Update is called once per frame
	void Update () {

		if (switchallow == true) {
			uptimer += Time.deltaTime;
		}

		Debug.Log (uptimer);
		if (uptimer > WAMScaling.wamSliderValue) {
			switch (ControlState) {
			case RodStatus.Up:
				ControlState = RodStatus.MovingDown;
				
				
				if (venting) {
					venting = false;
					VentingTime = 0;
				}
				//TimesFixed += 1;
				break;
			case RodStatus.MovingUp:
				ControlState = RodStatus.MovingDown;
				if (venting) {
					venting = false;
					VentingTime = 0;
				}
				//TimesFixed += 1;
				
				break;
			default:
				break;
			}
		}

		//Debug.Log (handMoveUp);
		ProcessCoreState();
		HandCheck ();

	}


	void HandCheck (){

		Frame frame = controller.Frame ();


		foreach (Hand hand in frame.Hands) {


			//Debug.Log (hand.PalmNormal.Roll);

		if (hand.PalmNormal.Roll >= 0.2){
			handMoveDown = true;
		}
		
		else if (hand.PalmNormal.Roll >= WAMScaling.wamSliderValue5){
			handMoveUp = true;
		}
	}
}

	void OnTriggerEnter (Collider other){
		switchallow = true;

	}

	void OnTriggerExit (Collider other){
		switchallow = false;

		uptimer = 0;
	}

	void OnCollisionEnter (Collision col) {
	


		//write something that keeps the mole up for x seconds, scale timer algorithm
		//after x seconds, re enable Overseer.managing
		//or if collision, then reenable overseer.managing
		//possible box collider that detects when any mole is up, thenol disables overseer.managing whenever there is a mole up
		//red light that follows which mole is up/whenver the mole collides with the box collider 

		if (null != SelectSound)
		{
			SelectSound.PlayOneShot(SelectSound.clip);
		}


		if ((handMoveDown == true) && (handMoveUp == true)){
			//Debug.Log (handMoveUp);
			handMoveDown = false;
			handMoveUp = false;

			switch (ControlState)
			{
			case RodStatus.Up:
				ControlState = RodStatus.MovingDown;

							
				if (venting)
				{
					venting = false;
					VentingTime = 0;
				}
				else
					TimesFixed += 1;
				break;
				case RodStatus.MovingUp:
				ControlState = RodStatus.MovingDown;
				if (venting)
				{
					venting = false;
					VentingTime = 0;
				}
				else
					TimesFixed += 1;

				break;
			default:
				break;

			//}
		}
	}

}
	
	void ProcessCoreState()
	{
			switch(ControlState)
		{
		case RodStatus.Up:
			if (null != CoreGlow)
			{
				CoreGlow.color = Color.Lerp (CoreGlow.color, VentingColor, Time.deltaTime);
			}
			if (venting)
			{
				VentingTime += Time.deltaTime;
			
				if (VentingTime >= 2.0f)
				{
					venting = false;
					// The code to do something when it's been venting for 2 seconds should go here.
				
				}
			}
			break;
			
		case RodStatus.MovingDown:
			if (null != CoreGlow)
			{
				CoreGlow.color = Color.Lerp (CoreGlow.color, StabilizingColor, Time.deltaTime);
			}
			if (!ControlRod.transform.localPosition.Equals(DownPosition.localPosition))
			{
				ControlRod.transform.localPosition = Vector3.Lerp (ControlRod.transform.localPosition, DownPosition.localPosition, Time.deltaTime);
				float distance = Vector3.Distance(ControlRod.transform.localPosition, DownPosition.localPosition);
				if (distance <= 0.025f)
				{
					ControlRod.transform.localPosition = DownPosition.localPosition;
					ControlRod.transform.localPosition = new Vector3(DownPosition.localPosition.x, DownPosition.localPosition.y, DownPosition.localPosition.z);
				}
				
			}
			else
			{
				ControlState = RodStatus.Down;
			}
			break;
			
		case RodStatus.Selected:
			if (null != CoreGlow)
			{
				CoreGlow.color = Color.Lerp (CoreGlow.color, DestabilizingColor, Time.deltaTime);
			}
			ControlState = RodStatus.MovingUp;
			ControlRod.transform.localPosition = Vector3.Lerp (ControlRod.transform.localPosition, UpPosition.localPosition, Time.deltaTime);
			break;
			
		case RodStatus.MovingUp:
			if (null != CoreGlow)
			{
				CoreGlow.color = Color.Lerp (CoreGlow.color, RodFailureColor, Time.deltaTime);
			}
			
			if (!ControlRod.transform.localPosition.Equals(UpPosition.localPosition))
			{
				ControlRod.transform.localPosition = Vector3.Lerp (ControlRod.transform.localPosition, UpPosition.localPosition, Time.deltaTime);
				float distance = Vector3.Distance(ControlRod.transform.localPosition, UpPosition.localPosition);
				if (distance <= 0.025f)
				{
					ControlRod.transform.localPosition = UpPosition.localPosition;
					ControlRod.transform.localPosition = new Vector3(UpPosition.localPosition.x, UpPosition.localPosition.y, UpPosition.localPosition.z);
				}
			}
			else
			{
				ControlState = RodStatus.Up;
			
				venting = true;
			}
			break;
			
		default:
			if (null != CoreGlow)
			{
				CoreGlow.color = Color.Lerp (CoreGlow.color, NominalColor, Time.deltaTime);
			}
			break;
		}
	
	}

}
