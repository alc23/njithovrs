using UnityEngine;
using System.Collections;

public class OrbLockVert2 : MonoBehaviour {
	
	public GameObject sphere;
	public int numberOfObjects;
	
	void Start () {
		PlaceObjects();
	}
	
	void PlaceObjects(){
		for(int i = 0; i < numberOfObjects;i++){
			Instantiate(sphere,GeneratedPosition(),Quaternion.identity);
		}
	}

	Vector3 GeneratedPosition(){
		int x,y,z;
		x = 236;
		y = UnityEngine.Random.Range(-2, 30);
		z = UnityEngine.Random.Range(36, 483);
		return new Vector3(x,y,z);
	}
}