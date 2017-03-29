#pragma strict

function OnCollisionEnter (col : Collision){
	if (col.gameObject.tag == "fruit")
	{
		Spawn_Cube.IncreaseMiss(1.0f);
		}
}