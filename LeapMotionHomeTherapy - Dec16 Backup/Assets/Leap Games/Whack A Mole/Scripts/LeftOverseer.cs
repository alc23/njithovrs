using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LeftOverseer : MonoBehaviour {
	public List<ReactorCore> ReactorCores;	
	bool Managing = false;
	public AudioSource MusicPlayer;
	public string levelToLoad = "MainMenu";
	public int RoundLength = 800;
	public int RoundDuration = 800;
	
	bool CountingTime = true;
	bool RoundOver = false;
	
	float TimePassed = 0;
	
	public GUISkin mySkin;
	public GUIStyle buttonStyle;

	public static int score = 0;
	
	bool paused = false;

	void Start () {
		if (null != ReactorCores){
			foreach(ReactorCore Core in ReactorCores){
				Core.ControlState = ReactorCore.RodStatus.MovingDown;
			}
		}


		Preferences PlayerPrefs = new Preferences();
		if (PlayerPrefs.LoadPreferences ()){
			if (PlayerPrefs.Volume != -2.0f){
				AudioListener.volume = PlayerPrefs.Volume;
			}
			
			if (!PlayerPrefs.Music){
				if (null != MusicPlayer){
					MusicPlayer.Stop();
				}
			}
		}

		RoundDuration = RoundLength;
		StartCoroutine(RoundTimer());
		StartCoroutine(CalculateScore ());
	
	}

	void Update () {
		
		if (!Managing)
		{
			StartCoroutine(ManageReactors());
		}
		ProcessKeyInput();
	
	}

	public GUIStyle moleGUI1;
	public GUIStyle moleGUI2;
	public GUIStyle moleGUI3;
	public GUIStyle moleGUI4;


	void OnGUI()
	{
		GUI.Button (new Rect (Screen.width - 150, 60, 150, 20), "Score: " , moleGUI2);
		GUI.Button (new Rect (Screen.width-120, 115, 150, 20), score.ToString (), moleGUI3);
	
		if (score == 10) {
			GUI.Button (new Rect (1140, 275, 150, 20), "Great Job!", moleGUI4);
		}
	}

	IEnumerator CalculateScore(){
				
		score = 0;
		foreach (ReactorCore Core in ReactorCores){
			if (null != Core){
				score += Core.TimesFixed;
			}
		}

		yield return new WaitForSeconds(0.3f);
		if (RoundDuration > 0){
			StartCoroutine(CalculateScore());
		}
	}
	
	public ReactorCore SelectCore(List<ReactorCore> Cores){

		ReactorCore SelectedCore = null;
		
		if (null != Cores){
			int ChosenCore = Random.Range(0, Cores.Count);
			
			SelectedCore = Cores[ChosenCore];
		}
		
		if (null != SelectedCore) {
			return SelectedCore;
		}else{
			return null;
		}
	}
	

	IEnumerator ManageReactors(){

		Managing = true;
		yield return new WaitForSeconds(WAMScalingLeft.LwamSliderValue4);
		int tries = 3;
		ReactorCore NewUpCore = SelectCore (ReactorCores);

		if (null != NewUpCore){
			if (NewUpCore.ControlState == ReactorCore.RodStatus.Down){
				NewUpCore.ControlState = ReactorCore.RodStatus.Selected;

			}else{

				while ((tries > 0) && (NewUpCore.ControlState != ReactorCore.RodStatus.Down)){
					tries -= 1;
					NewUpCore = SelectCore(ReactorCores);
				}				
				NewUpCore.ControlState = ReactorCore.RodStatus.Selected;				
			}
		}
		Managing = false;
	}
	
	void Volume(bool up){

		float volume = AudioListener.volume;
		if (up){
			volume += 0.05f;
			
			if (volume > 1.0f){
				volume = 1.0f;
			}
		}else{

			volume -= 0.05f;
			
			if (volume < 0){
				volume = 0;
			}
		}		
		AudioListener.volume = volume;
	}


	void ProcessKeyInput(){

		if ((Input.GetKeyDown(KeyCode.Equals)) || (Input.GetKeyDown(KeyCode.Plus)) || (Input.GetKeyDown(KeyCode.KeypadPlus))){
			Volume (true);
		}
		
		if ((Input.GetKeyDown(KeyCode.Minus)) || (Input.GetKeyDown(KeyCode.KeypadMinus))){
			Volume (false);
		}
		
		if (Input.GetKeyDown(KeyCode.Space)){
			MusicManager ();
		}
		
		if (Input.GetKeyDown (KeyCode.P)){
		if (Time.timeScale == 1.0f)
				Time.timeScale = 0.0f;
			else
				Time.timeScale = 1.0f;
			if (!paused)
				paused = true;
			else
				paused = false;
		}
		
		TimePassed += Time.deltaTime;
		if (TimePassed > 10.0f){
			Preferences SavePrefs = new Preferences();
			if (null != MusicPlayer){
				SavePrefs.Music = MusicPlayer.isPlaying;
			}
			
			SavePrefs.Volume = AudioListener.volume;
			
			SavePrefs.SavePreferences();
			TimePassed = 0;
		}
	}	
		void MusicManager(){
		if (null != MusicPlayer){
			if (MusicPlayer.isPlaying){
				MusicPlayer.Stop ();
			}else{
				MusicPlayer.Play ();
			}
		}
	}
	
	IEnumerator RoundTimer(){
		yield return new WaitForSeconds(1.0f);
		if (CountingTime)
		{
			RoundDuration -= 1;
			if ((RoundDuration > 0) && (CountingTime))
			{
				StartCoroutine(RoundTimer());
			}

		}
	}

}
