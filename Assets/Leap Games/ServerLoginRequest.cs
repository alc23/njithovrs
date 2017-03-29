using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine;

[Serializable]
public class ResponseClass
{
	public string status;
	public string username;
	public string role;
	public string sessionId;
}

public class ServerLoginRequest : MonoBehaviour {

	ResponseClass response = new ResponseClass(); 

	// Use this for initialization
	void Start () {
		StartCoroutine(Upload());
	}

	IEnumerator Upload() {
		WWWForm form = new WWWForm();
		form.AddField("type", "auth");
		form.AddField("username","dkehoe");
		form.AddField("password","12345");


		UnityWebRequest www = UnityWebRequest.Post("http://ec2-54-245-43-22.us-west-2.compute.amazonaws.com/rpc/auth.php", form);
		yield return www.Send();

		if(www.isError) {
			Debug.Log(www.error);
		}
		else {
			response = JsonUtility.FromJson<ResponseClass>(www.downloadHandler.text);
			Debug.Log (response.status);
			Debug.Log (response.username);
			Debug.Log (response.role);
			Debug.Log (response.sessionId);
		}
	}
}
