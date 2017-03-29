//using UnityEngine;
//using System.Collections;
//
//public class GroundManager : MonoBehaviour {
//	public AudioClip impact;
//	AudioSource audio;
//	public static float groundFruit = 0;
//	
//	void Start (){
//		audio = GetComponent<AudioSource>();
//	}
//	
//	void OnCollisionEnter (Collision coll){
//		if(coll.gameObject.tag == "fruit"){
//			audio.PlayOneShot(impact);
//			groundFruit++;
//			ScaleFruitFall.IncreaseMiss(1);
//		}
//	}
//}
