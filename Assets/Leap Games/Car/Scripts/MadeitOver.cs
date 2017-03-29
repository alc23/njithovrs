using UnityEngine;
using System.Collections;

public class MadeitOver : MonoBehaviour {
	
	public static bool completed = false;

	
	// Use this for initialization
	void Start () {
		
	}
	
	void OnTriggerEnter(Collider other){
		completed = true;
	}
	
	void OnTriggerExit(Collider other){
		completed = false;
	}
	
}
