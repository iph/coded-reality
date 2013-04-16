var wUnpressed : Texture2D;
var wPressed : Texture2D;
var dUnpressed : Texture2D;
var dPressed : Texture2D;
var aUnpressed : Texture2D;
var aPressed : Texture2D;
var sUnpressed : Texture2D;
var sPressed : Texture2D;
var wKeyTexture : Texture2D;
var aKeyTexture : Texture2D;
var dKeyTexture : Texture2D;
var sKeyTexture : Texture2D;

function OnGUI() {
	GUI.DrawTexture(ScaleGUI(Rect(150,650,200,150)), wKeyTexture);
	GUI.DrawTexture(ScaleGUI(Rect(5,705,200,150)), aKeyTexture);
	GUI.DrawTexture(ScaleGUI(Rect(290,700,200,150)), dKeyTexture);
	GUI.DrawTexture(ScaleGUI(Rect(145,730,200,150)), sKeyTexture);
}

function Start () {
	wKeyTexture = wUnpressed;
	aKeyTexture = aUnpressed;
	dKeyTexture = dUnpressed;
	sKeyTexture = sUnpressed;
}

function Update () {
	if(Input.GetKeyDown(KeyCode.W)) {
		wKeyTexture = wPressed;
	}
	if(Input.GetKeyDown(KeyCode.A)) {
		aKeyTexture = aPressed;
	}
	if(Input.GetKeyDown(KeyCode.D)) {
		dKeyTexture = dPressed;
	}
	if(Input.GetKeyDown(KeyCode.S)) {
		sKeyTexture = sPressed;
	}
	if(Input.GetKeyUp(KeyCode.W)) {
		wKeyTexture = wUnpressed;
	}
	if(Input.GetKeyUp(KeyCode.A)) {
		aKeyTexture = aUnpressed;
	}
	if(Input.GetKeyUp(KeyCode.D)) {
		dKeyTexture = dUnpressed;
	}
	if(Input.GetKeyUp(KeyCode.S)) {
		sKeyTexture = sUnpressed;
	}
}

function ScaleGUI(_rect : Rect) : Rect
{
	var rectWidth = (_rect.width / 1600) * Screen.width;
	var rectHeight = (_rect.height / 900) * Screen.height;
	var rectX = (_rect.x / 1600) * Screen.width;
	var rectY = (_rect.y / 900) * Screen.height;
 
	return Rect(rectX,rectY,rectWidth,rectHeight);
}