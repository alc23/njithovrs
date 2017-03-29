using UnityEngine;
using System.Collections;

public class MagnetCatch : MonoBehaviour {

	public GameObject basket;
	public Vector3 newPosition;
	private Transform trans;
	// Use this for initialization
	void Awake () {
		trans = transform;
	}

	void OnCollisionEnter (Collision col){
		if (col.gameObject.tag == "Basket") {
			trans.position = newPosition;
		}

	// Update is called once per frame
//	void Update () {
//		//trans.position = Vector3.Lerp (trans.position, basket.transform.position, Time.deltaTime * 1.5f);
//
//		if (Mathf.Abs (basket.transform.position.y - trans.position.y) < 0.01 && Mathf.Abs (basket.transform.position.x - trans.position.x) < 0.01 )
//			trans.position = newPosition;
//
//	}
	}
}