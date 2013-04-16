using UnityEngine;
using System.Collections;

public class TerminalSwap : MonoBehaviour, OnTerminalClickListener {
	GameObject player;
    public Font font;
	GameObject cube;
	DoorSlider door;
    public GameObject otherCamera;
    TextEditor editor;
    ChoiceTerminal terms;
	// Use this for initialization
    private string str = "Cube.x = 20";
    bool open;
	bool openCube;
	void Start () {
        open = false;
        terms = new ChoiceTerminal(font);
		openCube = false;
		cube = GameObject.FindGameObjectWithTag("blockpath");
		door = (DoorSlider)GameObject.FindGameObjectWithTag("door").GetComponent("DoorSlider");
		player = GameObject.FindGameObjectWithTag("MainCamera"); 
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
        terms.addOnTerminalClickListener("name", this);
	}
	public void onClick(string newtext, string old){
        if (newtext.Equals("20"))
        {
            Vector3 originalPos = new Vector3(80.85552f, 6.947796f, 76.70168f);
            cube.transform.position = originalPos;
        }
        else
        {
            cube.transform.position = new Vector3(0, 0, 0);
        }
    }
	// Update is called once per frame
	void Update () {
        if (open)
        {
            terms.MouseHandler();
        }
	}

    void OnGUI()
    {
        if (open)
        {
            terms.Draw();

			if(Event.current.Equals (Event.KeyboardEvent("9"))){
	            openCube = true;
			}
	
	        if (openCube)
	        {
	            int smooth = 2;
				door.SetActive();	
	        }
             if (Event.current.Equals(Event.KeyboardEvent("tab")) && editor.pos < 10)
            {
                Event.current.Use();
            } 
            
           
        }
    }
    void OnTriggerStay(Collider obj){
 		      
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
