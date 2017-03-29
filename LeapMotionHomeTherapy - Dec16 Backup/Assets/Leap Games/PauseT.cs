using UnityEngine;
using System.Collections;

public class PauseT : MonoBehaviour {

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.T))
		{
			if (Time.timeScale == 1)
			{
				Time.timeScale = 0;
			}
			else
			{
				Time.timeScale = 1;
			}
		}
	}
}
