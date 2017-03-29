using UnityEngine;
using System.Collections;

public class OrbDestroy : MonoBehaviour
{
	public AudioClip orbcollect;
	AudioSource audio;

	void Start(){
		audio = GetComponent<AudioSource> ();
	}

	void OnCollisionEnter (Collision col){
		if (col.gameObject.tag == "Player") {
			audio.PlayOneShot(orbcollect);
			Destroy (gameObject);
		}
	}
}