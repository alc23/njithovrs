using UnityEngine;
using System.Collections;

public class ShootBall : MonoBehaviour {

	public float speed = 500000.0f; 

	public void Start() { 
		Vector3 randomDirection = new Vector3(Random.value, Random.value, Random.value); 
		transform.Rotate(randomDirection); 
	}

	public void Update() { 
		transform.position += transform.forward * speed * Time.deltaTime; 
	}
}
