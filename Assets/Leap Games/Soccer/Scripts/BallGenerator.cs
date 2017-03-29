using UnityEngine;
using System.Collections;

public class BallGenerator : MonoBehaviour {

	public GameObject soccerBall;

	public float soccerSpawn1 = 1.0f;
	public float soccerSpawn2 = 1.0f;
	public float soccerSpawn3 = 1.0f;

	public Texture shoriz;
	public Texture svert;
	public Texture sspeed;


	void OnGUI(){
		if (ToggleSoccerGUI.GUIEnabled == true) {

			soccerSpawn1 = GUI.HorizontalSlider (new Rect (30, UnityEngine.Screen.height - 90, 100, 30), soccerSpawn1, 2.0F, 50.0F);
			GUI.DrawTexture (new Rect (140, UnityEngine.Screen.height - 95, 20, 20), shoriz);

			soccerSpawn2 = GUI.HorizontalSlider (new Rect (30, UnityEngine.Screen.height - 120, 100, 30), soccerSpawn2, 2.1F, 15.0F);
			GUI.DrawTexture (new Rect (140, UnityEngine.Screen.height - 125, 20, 20), svert);

			soccerSpawn3 = GUI.HorizontalSlider (new Rect (30, UnityEngine.Screen.height - 150, 100, 30), soccerSpawn3, 0.1F, 8.0F);
			GUI.DrawTexture (new Rect (140, UnityEngine.Screen.height - 155, 20, 20), sspeed);
		}
	}

	void Awake(){
		soccerSpawn1 = PlayerPrefs.GetFloat ("soccerSpawn1");
		soccerSpawn2 = PlayerPrefs.GetFloat ("soccerSpawn2");
		soccerSpawn3 = PlayerPrefs.GetFloat ("soccerSpawn3");

	}

	void Start () {
		InvokeRepeating("SpawnWave", 0, 10 - soccerSpawn3);
	}

	void SpawnWave() {
		GameObject obj = Instantiate(soccerBall) as GameObject;
		obj.transform.position = new Vector3(Random.Range (0 - soccerSpawn1,30 + soccerSpawn1), Random.Range (50 - soccerSpawn2,70 + soccerSpawn2), 60);
		Rigidbody [] children = obj.GetComponentsInChildren<Rigidbody>();

		for(int i = 0; i < children.Length; ++i) {
			children[i].velocity = new Vector3(Random.Range(5.0f, 5.1f), Random.Range(5.0f, 5.1f), Random.Range(250.0f, 270.1f));
			children[i].angularVelocity = new Vector3(Random.Range (0.0f, 0.5f), Random.Range (0.0f, 0.5f), Random.Range (0.0f, 0.5f));
		}
	}

	public void Save(){
		PlayerPrefs.SetFloat ("soccerSpawn1", soccerSpawn1);
		PlayerPrefs.SetFloat ("soccerSpawn2", soccerSpawn2);
		PlayerPrefs.SetFloat ("soccerSpawn3", soccerSpawn3);
	}
}