using UnityEngine;
using System.Collections;

public class OrbPlacement : MonoBehaviour {
	
	public GameObject sphere;
	public int numberOfCubes;
	
	void Start () {
		PlaceCubes();
	}
	
	void PlaceCubes(){
		for(int i = 0; i < numberOfCubes;i++){
			Instantiate(sphere,GeneratedPosition(),Quaternion.identity);
		}
	}
	Vector3 GeneratedPosition(){
		int x,y,z;
		x = UnityEngine.Random.Range (-40, 580);
		y = UnityEngine.Random.Range(10, 35);
		z = UnityEngine.Random.Range(-50, 570);
		return new Vector3(x,y,z);
	}
}