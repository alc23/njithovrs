#pragma strict


static var renderedCameraTexture : Texture2D;
public var materialCameraView : Material;

function Awake(){
	renderedCameraTexture = new Texture2D(Screen.width, Screen.height);
	materialCameraView.mainTexture = renderedCameraTexture;

}

function OnPostRender(){
	renderedCameraTexture.ReadPixels(Rect(0,0, Screen.width, Screen.height), 0,0);
	renderedCameraTexture.Apply();
	}
