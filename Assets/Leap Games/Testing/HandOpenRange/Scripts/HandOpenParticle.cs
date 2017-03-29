using UnityEngine;
using System.Collections;

public class HandOpenParticle : MonoBehaviour {

	public ParticleSystem particleSys;
	public static float partgo;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		partgo = CheckHandOpen.openCount;

		if (partgo > 4) {
			particleSys.Play ();
			particleSys.enableEmission = true;
		} else {
			particleSys.Stop ();
			particleSys.enableEmission = false;
		}
	

		Debug.Log (partgo);
//		if (CheckHandOpen.playPart == true) {
//			particleSys.Play ();
//			particleSys.enableEmission = true;
//		} else if (CheckHandOpen.playPart == false){
//			particleSys.Stop ();
//			particleSys.enableEmission = false;
//		}
	}
}
