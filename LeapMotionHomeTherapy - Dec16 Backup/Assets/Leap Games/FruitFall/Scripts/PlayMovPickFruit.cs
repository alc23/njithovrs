﻿using UnityEngine;
using System.Collections;

[RequireComponent (typeof(AudioSource))]

public class PlayMovPickFruit: MonoBehaviour {
	
	public MovieTexture movie1;
	public MovieTexture movie2;
	public MovieTexture movie3;
	public MovieTexture movie4;
	public MovieTexture movie5;
	public int chosen;
	
	void Update(){
		
		
		//hand is missing
		if (PickFruitHandData.invalidhands == true) {
			chosen = 1;
		}
		
		//hand is returned
		if (PickFruitHandData.invalidhands == false) {
			chosen = 2;
		}
		
		
		//when a strike is scored
		if (PickFruitScore.pickingScore > 2 && PickFruitScore.pickingScore < 4) {
			chosen = 3;
		}

		if (PickFruitScore.pickingScore > 10 && PickFruitScore.pickingScore < 12) {
			chosen = 4;
		}

		if (PickFruitScore.pickingScore < 0) {
			chosen = 5;
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
		
		//		if (Input.GetKeyDown (KeyCode.K)) {
		//			chosen = 3;
		//		}
		//		
		
		switch (chosen){
		case 1: StartCoroutine (PlayClip1());
			StartCoroutine (Wait1(8));
			break;
		case 2: StartCoroutine (PlayClip2());
			StartCoroutine (Wait2(5));
			break;
		case 3: StartCoroutine (PlayClip3());
			StartCoroutine (Wait3(4));
			break;
		case 4: StartCoroutine (PlayClip4());
			StartCoroutine (Wait4(4));
			break;
		case 5: StartCoroutine (PlayClip5());
			StartCoroutine (Wait5(4));
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

	IEnumerator PlayClip5(){
		if (movie5.isPlaying == false) {
			GetComponent<Renderer> ().material.mainTexture = movie5;
			movie5.Play ();
			GetComponent<AudioSource> ().clip = movie5.audioClip;
			GetComponent<AudioSource> ().Play ();
		}
		yield return null;
	}
	
	IEnumerator Wait5(float duration){
		yield return new WaitForSeconds (duration);
		movie5.Stop ();
	}
}