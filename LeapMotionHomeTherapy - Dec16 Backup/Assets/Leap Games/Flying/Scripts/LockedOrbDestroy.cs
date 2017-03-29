using UnityEngine;
using System.Collections;

public class LockedOrbDestroy : MonoBehaviour
{
	public AudioClip orbcollect;
	AudioSource audio;
	
	public GUIStyle mazeGUI;
	public GUIStyle buttonGUI;

	void Start(){
		audio = GetComponent<AudioSource> ();
	}

	public void OnTriggerEnter (Collider other){
			audio.PlayOneShot (orbcollect);
			Destroy (gameObject);
			TriggerScore.AddScore (1);
	}
}