using UnityEngine;
using System.Collections;

public class PlayHit : MonoBehaviour {

	public AudioClip impact;
	AudioSource audio;
	
	void Start (){
		audio = GetComponent<AudioSource>();
	}

	void OnCollisionEnter (Collision coll){
		if(coll.gameObject.tag == "Pins"){	
			audio.PlayOneShot(impact);
		}
	}
}
