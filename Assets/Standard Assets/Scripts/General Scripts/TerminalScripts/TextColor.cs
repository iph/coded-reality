using UnityEngine;
using System.Collections;

public class TextColor : MonoBehaviour {
	public float red, green, blue;
	GameObject cube;
    public Font font;
    bool open;
	// Use this for initialization
    Vector3 target;
	void Start () {
		cube = GameObject.FindGameObjectWithTag("blockpath");
        open = false;
        target = new Vector3(cube.transform.localPosition.x, cube.transform.localPosition.y, cube.transform.localPosition.z-20);
        
	}
   public string stringToEdit = "cube.x = 10;\nHOLYHELL";


    void OnGUI() 

    {
        /*
        //backup color 
        Color backupColor = GUI.color;
        Color backupContentColor = GUI.contentColor;
        Color backupBackgroundColor = GUI.backgroundColor;
        
        //add textarea with transparent text
        GUI.contentColor = new Color(1f, 1f, 1f, 0f);
        GUIStyle style = new GUIStyle(GUI.skin.textArea);
        style.fontSize = 29;
        style.font = font;
        //style.padding = new RectOffset(10, 10, 40, 40);
        Rect bounds = new Rect(30, Screen.height / 2 + 100, Screen.width - 60, 100);
        GUI.backgroundColor = new Color(1.0f, 1.0f, 1.0f, 1.0f);
        stringToEdit = GUI.TextArea(bounds, stringToEdit, style);

        //get the texteditor of the textarea to control selection
        int controlID = GUIUtility.GetControlID(bounds.GetHashCode(), FocusType.Keyboard);  
        TextEditor editor = (TextEditor)GUIUtility.GetStateObject(typeof(TextEditor), controlID -1);

        
        //set background of all textfield transparent
        GUI.backgroundColor = new Color(1f, 1f, 1f, 0f);    

        //backup selection to remake it after process
        int backupPos = editor.pos;
        int backupSelPos = editor.selectPos;

        //get last position in text
        editor.MoveTextEnd();
        int endpos = editor.pos;

        Random.seed = 123;

        //draw textfield with color on top of text area
        editor.MoveTextStart();     
        while (editor.pos != endpos)
        {
            editor.SelectToStartOfNextWord();
            string wordtext = editor.SelectedText;  
    
            //set word color
            GUI.contentColor = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));

            

            //draw each word with a random color

            Vector2 pixelselpos = style.GetCursorPixelPosition(editor.position, editor.content, editor.selectPos);

            Vector2 pixelpos = style.GetCursorPixelPosition(editor.position, editor.content, editor.pos);

            GUI.TextField(new Rect(pixelselpos.x - style.border.left, pixelselpos.y - style.border.top, pixelpos.x, pixelpos.y + 100), wordtext, style);

        

            editor.MoveToStartOfNextWord();

        }

        

        //Reposition selection

        Vector2 bkpixelselpos = style.GetCursorPixelPosition(editor.position, editor.content, backupSelPos);    

        editor.MoveCursorToPosition(bkpixelselpos); 

            

        //Remake selection

        Vector2 bkpixelpos = style.GetCursorPixelPosition(editor.position, editor.content, backupPos);  

        editor.SelectToPosition(bkpixelpos);    

 

        //Reset color

        GUI.color = backupColor;

        GUI.contentColor = backupContentColor;

        GUI.backgroundColor = backupBackgroundColor;
    
         */ }

	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown("9")){
            print("Yel");
            open = true;
        
			//cube.transform.Translate(0, 0, -10);
		}

        if (open)
        {
            int smooth = 2;

            cube.transform.localPosition = Vector3.Slerp(cube.transform.localPosition, target, Time.deltaTime * smooth);

        }
	}
}
