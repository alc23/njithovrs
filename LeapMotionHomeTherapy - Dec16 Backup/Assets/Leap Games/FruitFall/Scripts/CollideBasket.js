#pragma strict

function OnCollisionEnter (col : Collision){
	if (col.gameObject.tag == "fruit")
	{
		Spawn_Cube.IncreaseSuccess(1.0f);
	}
}