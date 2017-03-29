using UnityEngine;
using System.Collections;

public class LoadCalibLevel : MonoBehaviour {

	public string leveltoload;
	// Use this for initialization
	public void OnClick(){
		Application.LoadLevel (leveltoload);
	}
}
