using UnityEngine;
using System.Collections;

[RequireComponent (typeof(AudioSource))]

public class PlayMovBowling: MonoBehaviour {
	
	public MovieTexture movie1;
	public MovieTexture movie2;
	public MovieTexture movie3;
	public MovieTexture movie4;
	public int chosen;


	void Awake(){
		chosen = 4;
	}

	void Update(){

		//hand is missing
		if (HandValuesBowl.invalidhands == true) {
			chosen = 1;
		}

		//hand is returned
		if (HandValuesBowl.invalidhands == false) {
			chosen = 2;
		}

		//when a strike is scored
		if (BowlingScore.score > 9) {
			chosen = 3;
		}

		//when the level is reset, "good job, lets bowl again!"
//		if (RestartOnHit.restarted == true){
//			chosen = 4;
//		}
		//		if (Input.GetKeyDown (KeyCode.H)) {
		//			chosen = 1;
		//		}
		//		if (Input.GetKeyDown (KeyCode.J)) {
		//			chosen = 2;
		//		}

		switch (chosen){
		case 1: StartCoroutine (PlayClip1());
			StartCoroutine (Wait1(10));
			break;
		case 2: StartCoroutine (PlayClip2());
			StartCoroutine (Wait2(2));
			break;
		case 3: StartCoroutine (PlayClip3());
			StartCoroutine (Wait3(3));
			break;
		case 4: StartCoroutine (PlayClip4());
			StartCoroutine (Wait3(10));
			break;
		}
	}
	
	IEnumerator PlayClip1(){
		if (movie1.isPlaying == false) {
			GetComponent<Renderer>().material.mainTexture = movie1;
			movie1.Play ();
			GetComponent<AudioSource>().clip = movie1.audioClip;
			GetComponent<AudioSource>().Play ();
		}
		yield return null;
	}
	
	IEnumerator Wait1(float duration){
		yield return new WaitForSeconds(duration);
		movie1.Stop ();
	}
	
	IEnumerator PlayClip2(){
		if (movie2.isPlaying== false) {
			GetComponent<Renderer>().material.mainTexture = movie2;
			movie2.Play ();
			GetComponent<AudioSource>().clip = movie2.audioClip;
			GetComponent<AudioSource>().Play ();
		}
		yield return null;
	}
	
	IEnumerator Wait2(float duration){
		yield return new WaitForSeconds(duration);
		movie2.Stop ();
	}
	
	IEnumerator PlayClip3(){
		if (movie3.isPlaying==false){
			GetComponent<Renderer>().material.mainTexture = movie3;
			movie3.Play ();
			GetComponent<AudioSource>().clip = movie3.audioClip;
			GetComponent<AudioSource>().Play ();
		}
		yield return null;
	}
	
	IEnumerator Wait3(float duration){
		yield return new WaitForSeconds(duration);
		movie3.Stop ();
	}

	IEnumerator PlayClip4(){
		if (movie4.isPlaying == false) {
			GetComponent<Renderer> ().material.mainTexture = movie4;
			movie4.Play ();
			GetComponent<AudioSource> ().clip = movie4.audioClip;
			GetComponent<AudioSource> ().Play ();
		}
		yield return null;
	}

	IEnumerator Wait4(float duration){
		yield return new WaitForSeconds (duration);
		movie4.Stop ();
	}
}
