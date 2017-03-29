#pragma strict

var cube: GameObject;
var spawn_position;
var timer = 0.0;
var spawntime = 2.0;
var parentobject: GameObject;

public static var miss : float = 1.0;
public static var success : float= 3.0;
public static var percentage : float = 0.0;
var algpercentage : boolean = false;

public static function IncreaseMiss(amount : float){
	miss = miss + amount;
}

public static function IncreaseSuccess (amount : float){
	success = success + amount;
}

function OnGUI () { 
	if (TogglesGUI.GUIEnable == true){
		
GUI.Label(new Rect(30, UnityEngine.Screen.height - 450, 200, 30), "Time Between Fruit: " + spawntime + " seconds");
	}
}


function Update () {

	timer += Time.deltaTime;
	
	if(timer > spawntime){
		spawn_cube();
		timer = 0.0;
	}
	
	var percentage : float = (miss / (success + miss));

	
	if (percentage > 0.25f) {
		algpercentage = true;
	
	}else if (percentage == 0) {
			algpercentage = false;
	}else {
			algpercentage = false;
	}
	
	if (algpercentage ==true){
		StartCoroutine(ALGReset());
		algpercentage = false;
	}
}

function ALGReset(){
	
	miss = 1;
	success = 3;
	spawntime += 0.2f;
	parentobject.SendMessage("AddTimer");
	
	if (spawntime > 8.0f){
		spawntime = 8.0f;
	}
	yield;
}

function spawn_cube (){
	spawn_position = Vector3(Random.Range(-5.0, 5.0), 7, 0);
	var temp_spawn_cube = Instantiate(cube, spawn_position, Quaternion.identity);
}