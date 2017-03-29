using UnityEngine;
using System.Collections;

[RequireComponent (typeof(AudioSource))]

public class PlayMovCar: MonoBehaviour {

	public MovieTexture movie1;
	public MovieTexture movie2;
	public MovieTexture movie3;
	public MovieTexture movie4;
	public int chosen;

	void Update(){

//		if (GestureHandValuesCar.invalidhands == true) {
//			chosen = 2;
//		}

		if (RestHandNotification.textUp == true) {
			chosen = 1;
		}


		if (MadeitOver.completed == true) {
			chosen = 3;
		}

		if (FlipRestart.flipped == 1) {
			chosen = 4;
		}

//		if (Input.GetKeyDown (KeyCode.H)) {
//			chosen = 1;
//		}
//		if (Input.GetKeyDown (KeyCode.J)) {
//			chosen = 2;
//		}



		switch (chosen){
			case 1: StartCoroutine (PlayClip1());
			StartCoroutine (Wait1(4));
			break;
//			case 2: StartCoroutine (PlayClip2());
//			StartCoroutine (Wait2(10));
//			break;
			case 3: StartCoroutine (PlayClip3());
			StartCoroutine (Wait3(2));
			break;
			case 4: StartCoroutine (PlayClip3());
			StartCoroutine (Wait4(3));
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

//	IEnumerator PlayClip2(){
//		if (movie2.isPlaying== false) {
//			GetComponent<Renderer> ().material.mainTexture = movie2;
//			movie2.Play ();
//			GetComponent<AudioSource> ().clip = movie2.audioClip;
//			GetComponent<AudioSource> ().Play ();
//		}
//		yield return null;
//	}

	IEnumerator Wait2(float duration){
		yield return new WaitForSeconds(duration);
		movie2.Stop ();
	}

	IEnumerator PlayClip3(){
		if (movie3.isPlaying==false) {
			GetComponent<Renderer> ().material.mainTexture = movie3;
			movie3.Play ();
			GetComponent<AudioSource> ().clip = movie3.audioClip;
			GetComponent<AudioSource> ().Play ();
		}
		yield return null;
	}

	IEnumerator Wait3(float duration){
		yield return new WaitForSeconds(duration);
		movie3.Stop ();
	}
	IEnumerator PlayClip4(){
		if (movie3.isPlaying==false) {
			GetComponent<Renderer> ().material.mainTexture = movie4;
			movie4.Play ();
			GetComponent<AudioSource> ().clip = movie4.audioClip;
			GetComponent<AudioSource> ().Play ();
		}
		yield return null;
	}
	
	IEnumerator Wait4(float duration){
		yield return new WaitForSeconds(duration);
		movie4.Stop ();
	}
}

//
////	public WWW w;
////
////	void Start(){
////
////		MovieTexture movieTexture;
////		AudioSource audio = gameObject.GetComponent<AudioSource> ();
////		//WWW file = new WWW ("LeapGames/Car" + CharacterTest3.ogg); //example.mp4 or example.ogg
////		w = new WWW ("file://" + Application.dataPath + "LeapGames/Car/CharacterTest3.ogv");
////
////		if (w.movie != null) {
////			movieTexture = w.movie;
////			gameObject.GetComponent<Renderer> ().material.mainTexture = movieTexture;
////			audio.clip = movieTexture.audioClip;
////			movieTexture.Play ();
////			audio.Play ();
////		} else if (w.audioClip != null) {
////			audio.clip = w.audioClip;
////			audio.Play ();
////		}
////	}
//
//	public MovieTexture movie1;
//	public MovieTexture movie2;
//	public MovieTexture movie3;
//
//	public int chosen;
//
//		 
//	int arrayPos = 0;
//
//
//	void Update(){
//		if(movie1.isPlaying == false) {
//			movie1.Stop ();
//		}
//		if(movie2.isPlaying == false) {
//			movie2.Stop ();
//		}
//		if(movie3.isPlaying == false) {
//			movie3.Stop ();
//		}
//
//		switch (chosen) {
//		case 1:
//			GetComponent<Renderer>().material.mainTexture = movie1;
//
//			GetComponent<AudioSource>().clip = movie1.audioClip;                                                                                      
//			//GetComponent<AudioSource> ().Play ();
//			if (movie1 != null) {
//				movie1.Play();
//				//	GetComponent<AudioSource> ().Stop ();
//			}
//
//			break;
//		case 2:
//			GetComponent<Renderer>().material.mainTexture = movie2;
//			movie2.Play ();
//			GetComponent<AudioSource>().clip = movie2.audioClip;                                                                                      
//			//GetComponent<AudioSource> ().Play ();
//			if (movie2 != null) {
//				movie2.Play();
//				//	GetComponent<AudioSource> ().Stop ();
//			}
//
//
//
//			break;
//		case 3:
//			GetComponent<Renderer>().material.mainTexture = movie3;
//			movie3.Play ();
//			GetComponent<AudioSource>().clip = movie3.audioClip;                                                                                      
//			if (movie3!= null) {
//				movie3.Play();
//				//	GetComponent<AudioSource> ().Stop ();
//			}
//
//
//			break;
////		case 4:
////			GetComponent<Renderer> ().material.mainTexture = movie4;
////			movie4.Play ();
////			GetComponent<AudioSource>().clip = movie4.audioClip;                                                                                      
////			GetComponent<AudioSource> ().Play ();
//		
//		}
//
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
//
//		if (GetComponent<AudioSource> ().clip != null)
//			GetComponent<AudioSource> ().Play ();
//	}
//
//
////		if (Input.GetKeyDown (KeyCode.H)) {
////			GetComponent<Renderer> ().material.mainTexture = handdisconnect;
////			intro.Play ();
////			GetComponent<AudioSource> ().clip = handdisconnect.audioClip;
////			GetComponent<AudioSource> ().Play ();
////		}
////		if (handdisconnect.isPlaying == false) {
////			handdisconnect.Stop ();
////			GetComponent<AudioSource> ().Stop ();
////		}
//
//
//
//
//
//
//}
//	
//
//
////
////		MovieTexture movie = GetComponent<Renderer> ().material.mainTexture as MovieTexture;
////		GetComponent<AudioSource> ().clip = movie.audioClip;
////		GetComponent<AudioSource> ().Play ();
////		movie.Play ();
////
////
////		MovieTexture movie2 = GetComponent <Renderer>().material.SetTexture as mov
////	}
////
////}
//
////
////using UnityEngine;
////using System.Collections;
////
////[RequireComponent (typeof(AudioSource))]
////
////public class PlayMov: MonoBehaviour {
////	
////	//	public WWW w;
////	//
////	//	void Start(){
////	//
////	//		MovieTexture movieTexture;
////	//		AudioSource audio = gameObject.GetComponent<AudioSource> ();
////	//		//WWW file = new WWW ("LeapGames/Car" + CharacterTest3.ogg); //example.mp4 or example.ogg
////	//		w = new WWW ("file://" + Application.dataPath + "LeapGames/Car/CharacterTest3.ogv");
////	//
////	//		if (w.movie != null) {
////	//			movieTexture = w.movie;
////	//			gameObject.GetComponent<Renderer> ().material.mainTexture = movieTexture;
////	//			audio.clip = movieTexture.audioClip;
////	//			movieTexture.Play ();
////	//			audio.Play ();
////	//		} else if (w.audioClip != null) {
////	//			audio.clip = w.audioClip;
////	//			audio.Play ();
////	//		}
////	//	}
////	
////	public MovieTexture intro;
////	public MovieTexture second;
////	public MovieTexture handdisconnect;
////	
////	
////	
////	
////	int arrayPos = 0;
////	
////	void Start(){
////		
////		
////	}
////	
////	void Update(){
////		
////		//Debug.Log (intro.isPlaying);
////		
////		
////		if (Input.GetKeyDown (KeyCode.U)) {
////			GetComponent<Renderer> ().material.mainTexture = intro;
////			intro.Play ();
////			GetComponent<AudioSource> ().clip = intro.audioClip;
////			GetComponent<AudioSource> ().Play ();
////			
////		}
////		
////		if (intro.isPlaying == false) {
////			intro.Stop ();
////			GetComponent<AudioSource> ().Stop ();
////		}
////		
////		if (Input.GetKeyDown (KeyCode.V)) {
////			GetComponent<Renderer> ().material.mainTexture = second;
////			intro.Play ();
////			GetComponent<AudioSource> ().clip = second.audioClip;
////			GetComponent<AudioSource> ().Play ();
////		}
////		if (second.isPlaying == false) {
////			second.Stop ();
////			GetComponent<AudioSource> ().Stop ();
////		}
////		
////		//		if (Input.GetKeyDown (KeyCode.H)) {
////		//			GetComponent<Renderer> ().material.mainTexture = handdisconnect;
////		//			intro.Play ();
////		//			GetComponent<AudioSource> ().clip = handdisconnect.audioClip;
////		//			GetComponent<AudioSource> ().Play ();
////		//		}
////		//		if (handdisconnect.isPlaying == false) {
////		//			handdisconnect.Stop ();
////		//			GetComponent<AudioSource> ().Stop ();
////		//		}
////		
////		
////		
////		
////		
////	}
////}
////
////
////
//////
//////		MovieTexture movie = GetComponent<Renderer> ().material.mainTexture as MovieTexture;
//////		GetComponent<AudioSource> ().clip = movie.audioClip;
//////		GetComponent<AudioSource> ().Play ();
//////		movie.Play ();
//////
//////
//////		MovieTexture movie2 = GetComponent <Renderer>().material.SetTexture as mov
//////	}
//////
//////}
////
////
////
////
////
////
////
////
////
