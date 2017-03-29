using UnityEngine;
using System.Collections;


public class MazeScore : MonoBehaviour {

	public AudioClip impact;
	AudioSource audio;

	public static int mazeScore;
	
	public GUIStyle mazeGUI;
	public GUIStyle buttonGUI;

	void Start (){
		//insert character animation introduction 


		//mazeScore = NextLevel.mazeScore;
		audio = GetComponent<AudioSource>();
	}


	void OnCollisionEnter (Collision coll)
	{
		if(coll.gameObject.tag == "orb"){
			mazeScore++;
			audio.PlayOneShot(impact);
		}
	}
	
	public float timer = 0.0f;

	void Update(){
		timer += Time.deltaTime;
		if (timer <= 0) {
			timer = 30;
		}

		if (mazeScore == 15) {
			//insert character animation here that talks about the goal
		}
	}
	
	void OnGUI(){

		GUI.Label (new Rect(50, 50, 300, 150), "Score: " + mazeScore.ToString(), mazeGUI);

		if (mazeScore == 5) {
			GUI.Label (new Rect (1300, 470, 300, 150), "Great!", mazeGUI);
		}
		if (mazeScore == 20) {
			GUI.Label (new Rect (1300, 470, 300, 150), "Fantastic!", mazeGUI);
		}
		if (mazeScore == 40) {
			GUI.Label (new Rect (1300, 470, 300, 150), "Great Job!",mazeGUI);
		}

		if (mazeScore == 60) {
			GUI.Label (new Rect (1300, 470, 300, 150), "Awesome!", mazeGUI);
		}

		if (mazeScore == 50) {
			GUI.Label (new Rect (1300, 470, 300, 150), "Keep Going!", mazeGUI);
		}
	}
}