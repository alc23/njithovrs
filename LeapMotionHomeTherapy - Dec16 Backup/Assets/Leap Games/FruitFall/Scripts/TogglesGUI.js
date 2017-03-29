#pragma strict
static var GUIEnable : boolean = false;

function Update () {
     if(Input.GetKeyDown ("t")) {
         GUIEnable = !GUIEnable;
     }
 }