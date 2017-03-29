//using UnityEngine;
//using System.Collections;
//using System;
//using System.Runtime.Serialization.Formatters.Binary;
//using System.IO;
//
//public class GameControl : MonoBehaviour {
//
//
//	public static GameControl control;
//	private static float overallscore = 0;
//	private static float overalltime = 0;
//	private static string username;
//	private static float thisscore = 0;
//	private static float thistime = 0;
//
//
//
//	void Awake () {
//		if(control == null)
//		{
//			DontDestroyOnLoad(gameObject);
//			control = this;
//		}
//
//		else if (control != this)
//		{
//			Destroy(gameObject);
//		}
//
//	}
//	
//
//	public static void IncreaseScore(int Amount)
//	{
//		overallscore += Amount;
//		thisscore += Amount;
//	}
//
//	public static void IncreaseTime(float Amount)
//	{
//		overalltime += Amount;
//		thistime += Amount;
//	}
//
//	public static void SaveName (string Amount)
//	{
//		username = Amount;
//	}	
//
//	void OnGUI()
//	{
//
//
//		GUI.Label (new Rect(10,(Screen.height - 50),400,30), "Player: " + username);
//		GUI.Label (new Rect(10,(Screen.height - 20),400,30), "Total Time: " + overalltime + "    /  This Session: " + thistime);
//		GUI.Label (new Rect(10,(Screen.height - 35),400,30), "Total Score: " + overallscore+ "  /  This Session: " + thisscore);
//
//	}
//
//	public void Save()
//	{
//		BinaryFormatter bf = new BinaryFormatter ();
//		FileStream file = File.Create (Application.dataPath + "/playerInfo.txt");
//	
//		PlayerData data = new PlayerData ();
//		data.overalltime = overalltime;
//		data.overallscore = overallscore;
//		data.username = username;
//
//		bf.Serialize (file, data);
//		file.Close ();
//
//
//
//
//
//
//
//
//
//
//
//
//
////
////		FileStream file2 = File.Create (Application.dataPath + "/converted.txt");
////		data.time = time;
////		data.overallscore = overallscore;
////		data.username = username;
////		bf.Serialize (file2, data);
////
////		file2.Close ();
////
////		Debug.Log (username);
//
//	}
//
//	public void onLoadGame(){
//		Application.LoadLevel ("MainMenu");
//	}
//
//
////		//Read file to byte array
////	
////		FileStream stream = File.OpenRead(Application.dataPath + "/playerInfo.txt");
////		byte[] fileBytes= new byte[stream.Length];
////		
////		stream.Read(fileBytes, 0, fileBytes.Length);
////		stream.Close();
////		//Begins the process of writing the byte array back to a file
////		z
//
//
//
//
//
////		using (Stream datafile = File.OpenWrite(Application.dataPath + "/converted.txt"))
////		{
////			datafile.Write(fileBytes, 0, fileBytes.Length);
////		}
//
//
//
//
//
//	public void Load()
//	{
////		if (File.Exists (Application.dataPath + "/converted.txt")) {
////			BinaryFormatter bf2 = new BinaryFormatter ();
////			FileStream file2 = File.Open (Application.dataPath + "/converted.txt", FileMode.Open);
////			PlayerData data2 = (PlayerData)bf2.Deserialize (file2);
////			FileStream file3 = File.Create (Application.dataPath + "/converted2.txt");
////			file3.Close ();
////		}
//
//		if (File.Exists (Application.dataPath + "/playerInfo.txt")) {
//			BinaryFormatter bf = new BinaryFormatter ();
//			FileStream file = File.Open (Application.dataPath + "/playerInfo.txt", FileMode.Open);
//			PlayerData data = (PlayerData)bf.Deserialize (file);
//			file.Close ();
//
//			overalltime = data.overalltime;
//			overallscore = data.overallscore;
//			username = data.username;
//
//		}
//	}
//	
//
//}
//
//
//
//[Serializable]
//class PlayerData
//{
//	public float overalltime;
//	public float overallscore;
//	public string username;
//}