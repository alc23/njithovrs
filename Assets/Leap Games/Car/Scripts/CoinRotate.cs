using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinRotate : MonoBehaviour {

	public static int coinsCollected;

	public AudioSource source;

	public AudioClip collect;

	public static int lifetimeCoins;

	// Use this for initialization
	void Start () {
		lifetimeCoins = PlayerPrefs.GetInt ("carcoins");
	}
	
	void Update ()
	{
		transform.Rotate (0,75*Time.deltaTime,0); 

		if (NextCarLevel.collided == true) {
			PlayerPrefs.SetInt ("carcoins", lifetimeCoins);
		}

//		if (Input.GetKeyDown ("r"))
//			PlayerPrefs.SetInt ("carcoins", 0);

	}

	void OnCollisionEnter(Collision col){
		coinsCollected += 1;
		lifetimeCoins += 1;


		source.PlayOneShot (collect);
		Destroy (this.gameObject);
	}	
}
