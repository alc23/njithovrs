using UnityEngine;
using System.Collections;

public class ColorIndication : MonoBehaviour {

	public static bool isclose = false;

	public Color colorStart = Color.white;
	public Color colorEnd = Color.red;

	public UnityEngine.Renderer rend;
	public GameObject go;

	// Use this for initialization
	void Awake (){
		go = this.gameObject;
	}

	void Start () {
		rend = this.gameObject.transform.GetComponent<MeshRenderer>();
		rend.enabled = false;
	}


//	void Update(){
//		if (isclose == true) {
//			rend.enabled = true;
//		} else {
//			rend.enabled = false;
//		}
//
//	}
	// Update is called once per frame
	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "Player") {
			rend.enabled = true;
		}
	}

	void OnTriggerExit (Collider other){
		if (other.gameObject.tag == "Player"){
			rend.enabled = false;
		}
	}
}
