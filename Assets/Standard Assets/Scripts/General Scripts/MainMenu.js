//*******************************************************************************
//*																							*
//*							Written by Grady Featherstone								*
//										© Copyright 2011										*
//*******************************************************************************
var mainMenuFont : Font;
public var atMainMenu : boolean;

function Start(){
	var go = GameObject.Find("Player");
    var gameObject = GameObject.Find("Main Camera");
	
	Screen.showCursor = true;
	atMainMenu = true;
	AudioListener.volume = 0;
	Time.timeScale = 0;
	Screen.showCursor = true;
	go.GetComponent("MouseLook").enabled = false;
	gameObject.GetComponent("MouseLook").enabled = false;
}

function Update(){
	
}

function OnGUI(){

GUI.skin.box.font = mainMenuFont;
GUI.skin.button.font = mainMenuFont;

if (atMainMenu) {	
	var go = GameObject.Find("Player");
    var gameObject = GameObject.Find("Main Camera");
	
	var fuckStyles:GUIStyle = new GUIStyle(GUI.skin.textArea);
	fuckStyles.fontSize = 72;
	
	
	
	GUI.Box(Rect(0,0,Screen.width,Screen.height), "\n      coded_reality", fuckStyles);

	
	if(GUI.Button(Rect(Screen.width /2 - 100,Screen.height /2 - 100, 250, 50), "New Game")){
		atMainMenu = false;
		Time.timeScale = 1;
		AudioListener.volume = 1;
		Screen.showCursor = false;	
		go.GetComponent("MouseLook").enabled = true;
		gameObject.GetComponent("MouseLook").enabled = true;
		Application.LoadLevel("mainstage");
	}		
	
	//Make Main Menu button
	if(GUI.Button(Rect(Screen.width /2 - 100,Screen.height /2,250,50), "Level Select")){
		
	}
	
	//Make quit game button
	if (GUI.Button (Rect (Screen.width /2 - 100,Screen.height /2 + 50,250,50), "Quit Game")){

		Application.Quit();
	}
}
}