using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public Material[] colors;

	private int colorSelect;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter(Collision col){


	}

	void OnCollisionExit (Collision col){


	}



	public void StartGame(){
		colorSelect = Random.Range (0, colors.Length);
	}


}
