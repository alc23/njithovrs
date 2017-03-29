#pragma strict


function OnCollisionEnter (col : Collision){
    GetComponent.<Rigidbody>().drag = 1;
    GetComponent.<Rigidbody>().mass = 6;
    GetComponent(Light).enabled = false;  
}