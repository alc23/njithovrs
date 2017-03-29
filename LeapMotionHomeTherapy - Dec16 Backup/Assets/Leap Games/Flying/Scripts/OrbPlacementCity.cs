using UnityEngine;
using System.Collections;

public class OrbPlacementCity : MonoBehaviour {
	
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
		x = UnityEngine.Random.Range (-1450, 300);
		y = UnityEngine.Random.Range(-2, 40);
		z = UnityEngine.Random.Range(-750, 850);
		return new Vector3(x,y,z);
	}
}