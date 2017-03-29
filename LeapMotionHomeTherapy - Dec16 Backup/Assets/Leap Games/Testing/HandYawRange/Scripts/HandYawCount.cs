using UnityEngine;
using System.Collections;

using UnityEngine.UI;

public class HandYawCount : MonoBehaviour {
	
	Text count;
	public static float countTxt;
	public int number;
	// Use this for initialization
	void Start () {
		count = GetComponent<Text>();
	}
	
	public static void AddCount(float amount){
		countTxt = countTxt + amount;	
	}
	
	// Update is called once per frame
	void Update () {
		count.text = countTxt.ToString();
		
		//Debug.Log (countTxt);

		if (countTxt >= 5) {
			Application.Quit ();
		}
	}
}
