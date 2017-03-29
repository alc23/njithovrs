using UnityEngine;
using System.Collections;

public class ReceiveTimerData : MonoBehaviour {

	public static float spawntime = 2f;


	public void AddTimer(){
		spawntime = spawntime + 0.2f;
	}
}
