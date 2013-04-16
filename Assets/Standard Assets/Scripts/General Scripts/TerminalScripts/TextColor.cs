using UnityEngine;
using System.Collections;

public class TextColor : MonoBehaviour {
	public float red, green, blue;
    public static Texture2D white;
    public static GUIContent style;
    ChoiceTerminal terms;

	GameObject cube;
    public Font font;
    bool open;
	// Use this for initialization
    Vector3 target;
	void Start () {
        terms = new ChoiceTerminal(font);
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

        /*
        Terminal t = TerminalManager.CreateTerminalTransaction();
        Terminal t2 = TerminalManager.CreateTerminalTransaction();
        Terminal t3 = TerminalManager.CreateTerminalTransaction();
        t.font = font;
        t2.font = font;
        t3.font = font;

            t.SetBackgroundColor(TerminalManager.fromHSV(195, 11, 28));
            t.Padding(10);
            t.MoveX(50);
            t.MoveY(50);
            t.ChangeColor(TerminalManager.fromHSV(2, 60, 93));
            t.AddText("def ");
            t.ChangeColor(new Color(223f / 255f, 229f / 255f, 237f / 255f));
            t.AddText("movement():\n  ");
            t.AddText("cube.x = ");
            t.ChangeColor(TerminalManager.fromHSV(84, 60, 93));
            t.AddText("20\n    ");
            t.ChangeColor(new Color(223f / 255f, 229f / 255f, 237f / 255f));
            t.AddText("cube.y = ");
            t.ChangeColor(TerminalManager.fromHSV(184, 60, 93));
            int pos = t.AddText("40");
            t.EnableBorder();
            t.recalculate();
            t.finish();
            t.changeText(pos, "HI");
            

            t2.SetBackgroundColor(TerminalManager.fromHSV(195, 11, 28));
            t2.Padding(10);
            t2.MoveX((int)t.Area.x + (int)t.Area.width + 10 * 2 + 5);
            t2.MoveY(50);
            t2.ChangeColor(new Color(1.0f, 203f/255f, 113.0f/255f));
            t2.AddText("200000");
            t2.EnableBorder();
            t2.finish();
            t2.recalculate();

            t3.SetBackgroundColor(TerminalManager.fromHSV(195, 11, 28));
            t3.Padding(10);
            int moveX = (int)t2.Area.x + (int)t2.Area.width + 10 * 2 + 5;
            t3.MoveX(moveX);
            t3.MoveY(50);
            t3.ChangeColor(new Color(1.0f, 203f/255f, 113.0f/255f));
            t3.AddText("50");
            t3.EnableBorder();
            t3.finish();
 
        // Done with terminal transaction, add it.
            t3.recalculate();
        terms.AddTerminal(t);
        terms.AddTerminal(t2);
        terms.AddTerminal(t3);
        */
        terms.AddText("def movement():\n    cube.x = ");
        terms.AddTextChoice("name", "20");
        terms.AddText("\n    cube.y = ");
        terms.AddTextChoice("y", "40");
        terms.AddChoice("name", "80");
        terms.AddChoice("name", "90");
        terms.AddChoice("name", "10");
        terms.AddChoice("y", "20");
        terms.AddChoice("y", "40");
        terms.recalculateLayout();
        terms.x = 200;
        terms.y = 400;
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
        terms.MouseHandler();
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
