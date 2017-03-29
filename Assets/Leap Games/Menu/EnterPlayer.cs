using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EnterPlayer : MonoBehaviour {

	public static string playername;
	
	void Start ()
	{
		var input = gameObject.GetComponent<InputField>();
		var se= new InputField.SubmitEvent();
		se.AddListener(SubmitName);
		input.onEndEdit = se;
		
		//or simply use the line below, 
		//input.onEndEdit.AddListener(SubmitName);  // This also works
	}
	
	void SubmitName(string username)
	{
		Debug.Log("Hello " + username);

		playername = username;

		//GameControl.SaveName (username);
	}


}