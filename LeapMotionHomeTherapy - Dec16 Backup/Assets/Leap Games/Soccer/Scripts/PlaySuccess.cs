using UnityEngine;
using System.Collections;

public class PlaySuccess : MonoBehaviour {

	public AudioClip hit;
	AudioSource audio;
	
	void Start(){
		audio = GetComponent<AudioSource> ();
	}
	
	void OnCollisionEnter(Collision col){
		audio.PlayOneShot (hit);
	}
}
