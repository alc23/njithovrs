using UnityEngine;
using System.Collections;

public class PickUpBlock : MonoBehaviour {

	public GameObject spawnObject;
	public GameObject objSpawn;

	public bool isCreated = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter(Collision col){

	}

	void OnCollisionExit(Collision col){
		if (!isCreated) {
			objSpawn = Instantiate (spawnObject, new Vector3 (0, 2, 0), Quaternion.identity) as GameObject;
			isCreated = true;
			StartCoroutine (respawn());
		}

	}

	IEnumerator respawn(){
		yield return new WaitForSeconds (2);
		isCreated = false;
	}

}
