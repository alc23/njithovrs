using UnityEngine;
using System.Collections;

public class ReloadBowling : MonoBehaviour {

	public void Click(){

		Application.LoadLevel ("Bowling");
		HandValuesBowl.IncreaseRounds(1);
	}
}
