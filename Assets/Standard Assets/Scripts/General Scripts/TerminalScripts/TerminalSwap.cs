using UnityEngine;
using System.Collections;

public class TerminalSwap : MonoBehaviour {
	GameObject player;
    public Font font;
    public GameObject otherCamera;
    TextEditor editor;
	// Use this for initialization
    private string str = "Cube.x = 20";
    bool open;
	void Start () {
        open = false;

		player = GameObject.FindGameObjectWithTag("MainCamera"); 
	}
	
	// Update is called once per frame
	void Update () {

	}

    void OnGUI()
    {
        if (open)
        {
            int width = Screen.width / 2;
            int height = Screen.height / 2;


            GUI.SetNextControlName("Terminal");
            GUIStyle style = new GUIStyle(GUI.skin.textArea);
            style.fontSize = 20;
            style.padding = new RectOffset(10, 10, 10, 10);
            if (font != null)
            {
                style.font = font;
            }

             if (Event.current.Equals(Event.KeyboardEvent("tab")) && editor.pos < 10)
            {
                GUI.FocusControl("Terminal");
                Event.current.Use();
            } 
             if (Event.current.Equals(Event.KeyboardEvent("backspace")) && editor.pos < 10)
            {
                Event.current.Use();
            } 
            if (Event.current.Equals(Event.KeyboardEvent("delete")) && editor.pos < 10)
            {
                Event.current.Use();
            }

            GUI.Label(new Rect(30, height+60, 200, 100), "Press Tab to switch...");
            str = GUI.TextArea(new Rect(30, height + 100, Screen.width - 60, 100), str, 25, style);

             if (Event.current.Equals(Event.KeyboardEvent("escape")))
            {
                print("OKEY");
                GUI.UnfocusWindow();
                Event.current.Use();
            } 
            editor = (TextEditor)GUIUtility.GetStateObject(typeof(TextEditor), GUIUtility.keyboardControl);

            if (editor.pos < 6)
            {
                for (int i = editor.pos; i < 6; i++)
                {
                    editor.MoveRight();

                }
            }
           
        }
    }
    void OnTriggerStay(Collider obj){
 		if(Input.GetKeyDown("1")){
			player.camera.enabled = false;
			otherCamera.camera.enabled = true;
		}
		else if(Input.GetKeyDown("2")){
			player.camera.enabled = true;
			otherCamera.camera.enabled = false;			
		}       
    }

    void OnTriggerEnter(Collider obj)
    {
        open = true;

    }

    void OnTriggerExit(Collider obj)
    {
        open = false;
    }
		
}
