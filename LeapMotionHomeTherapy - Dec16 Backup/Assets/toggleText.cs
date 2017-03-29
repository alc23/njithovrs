using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class toggleText : MonoBehaviour {
	
	bool toggleCanvas;
	private Text text;
	
	// Use this for initialization
	void Start () {
		text = GetComponent<UnityEngine.UI.Text>();
	}
	
	// Update is called once per frame
	void Update(){
		if(Input.GetKeyDown("t"))
			text.enabled = !text.enabled;
		
	}
}
