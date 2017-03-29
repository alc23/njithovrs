using UnityEngine;
using System.Collections;

public class CameraShake : MonoBehaviour {
 
	public float duration;
	public float magnitude;

	public GUIStyle soccerGUI;

	public static float blockMiss;
	public AudioClip hit;
	AudioSource audio;
	
	void Start(){
		audio = GetComponent<AudioSource> ();
	}

	void OnCollisionEnter(Collision col){
		audio.PlayOneShot(hit);
		StartCoroutine ("Shake");
		blockMiss ++;
		ScaleSoccer.IncreaseMiss (1);
		GameObject.Destroy (col.gameObject);
	}

//	void OnGUI(){
//		GUI.Label (new Rect (100, 80, 300, 150), "Missed: " + blockMiss.ToString (), soccerGUI);
//	}
	
	IEnumerator Shake() {
	
		float elapsed = 0.0f;
		Vector3 originalCamPos = Camera.main.transform.position;
		while (elapsed < duration) {
			
			elapsed += Time.deltaTime;          
			
			float percentComplete = elapsed / duration;         
			float damper = 1.0f - Mathf.Clamp(4.0f * percentComplete - 3.0f, 0.0f, 1.0f);

			float x = Random.value * 6.0f - 1.0f;
			float y = Random.value * 6.0f - 1.0f;
			x *= magnitude * damper;
			y *= magnitude * damper;
			
			Camera.main.transform.position = new Vector3(originalCamPos.x + x, originalCamPos.y + y, originalCamPos.z);
			yield return null;
		}
		
		Camera.main.transform.position = originalCamPos;
	}
}