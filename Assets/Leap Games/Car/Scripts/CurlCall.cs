using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurlCall : MonoBehaviour {

	// Use this for initialization
	void Start () {
		string url = "http://ec2-54-245-43-22.us-west-2.compute.amazonaws.com/";
		WWW www = new WWW (url);
		StartCoroutine (WaitForRequest (www));
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator WaitForRequest(WWW www){

		yield return www;

	}
}
