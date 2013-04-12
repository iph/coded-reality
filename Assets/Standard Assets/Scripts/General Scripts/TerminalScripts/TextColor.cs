using UnityEngine;
using System.Collections;

public class TextColor : MonoBehaviour {
	public float red, green, blue;
    public static Texture2D white;
    public static GUIContent style;

    TerminalManager terms;
	GameObject cube;
    public Font font;
    bool open;
	// Use this for initialization
    Vector3 target;
	void Start () {
        terms = new TerminalManager();
		cube = GameObject.FindGameObjectWithTag("blockpath");
        white = new Texture2D(200, 200);
        for (int i = 0; i < 200; i++)
        {
            for (int j = 0; j < 200; j++)
            {
                white.SetPixel(i, j, Color.white);
            }
        }
        white.Apply();
        open = false;
        target = new Vector3(cube.transform.localPosition.x, cube.transform.localPosition.y, cube.transform.localPosition.z-20);
        Terminal t = TerminalManager.CreateTerminalTransaction();
        Terminal t2 = TerminalManager.CreateTerminalTransaction();
        t.font = font;
        t2.font = font;
            t.AddText("Hello world\n");
            t.ChangeColor(Color.green);
            t.AddText("SUP BITCHES");
            t.ChangeColor(Color.red);
            t.AddText("SUUUUUUP");


            t2.MoveX(400);
            t2.AddText("Hi");
        // Done with terminal transaction, add it.
        terms.AddTerminal(t);
        terms.AddTerminal(t2);

	}
   public string stringToEdit = "cube.x = 10;\nHOLYHELL";


    void OnGUI() 
    {
        terms.Draw();
        /*
        GUIStyle generic_style = new GUIStyle();
        GUI.skin.box = generic_style;
        GUI.Box(new Rect(0, 0, 200, 200), white);
        FancyTextArea.FancyLabel(new Rect(0, 0, 200, 200), "#FF00FFFFHello World#!", font, font, font, TextAlignment.Left);
        */


    }

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
