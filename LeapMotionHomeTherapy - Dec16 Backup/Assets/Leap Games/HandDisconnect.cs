//using UnityEngine;
//using System.Collections;
//using Leap;
//
//public class HandDisconnect : MonoBehaviour {
//	
//	public bool handinvalid;
//	public Texture disconnectedImg;
//	
//	// Use this for initialization
//	
//	public void onFrame(Controller controller){
//		Frame frame = controller.frame ();
//		Hand hand = frame.hands ().get (0);
//		
//		Debug.Log (frame.hand ().count ());
//	}
//	
//	void OnGUI(){
//		
//		if (handinvalid == true) {
//			GUI.DrawTexture (new Rect (0, 0, 800, 500), disconnectedImg);
//		}
//	}
//	
//	// Update is called once per frame
//	void Update () {
//		
//		
//		
//		//		if (hand != Hand.Invalid) {
//		//			handinvalid = true;
//		//
//		//			Debug.Log ("invalid");
//		//		}
//		
//		//		if (controller.Frame().Hands.Count = 0){
//		//			handinvalid = true;
//		//			Debug.Log ("invald hand");
//		//		}
//		
//		
//	}
//}
