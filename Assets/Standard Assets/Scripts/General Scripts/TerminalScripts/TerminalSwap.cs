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
    ChoiceTerminal doorTerminal;
    bool isTabbed;
	// Use this for initialization
    private string str = "Cube.x = 20";
    bool open;
    bool doorUnlock;
	bool openCube;
	void Start () {
        isTabbed = false;
        open = false;
        doorUnlock = false;
        terms = new ChoiceTerminal(font);
        doorTerminal = new ChoiceTerminal(font);
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

        doorTerminal.AddText("lock_up_dude()\nunlock_door(");
        doorTerminal.AddTextChoice("door_val", "false");
        doorTerminal.AddChoice("door_val", "true");
        doorTerminal.AddChoice("door_val", "maybe");
        doorTerminal.AddChoice("door_val", "explode");
 
        // A special way to add your own colored text without tagging it as a choice.
        doorTerminal.AddText(")\nlaugh_maniacally_at_test_subject("+Terminal.ColorToHex(TerminalManager.fromHSV(6, 43, 90)) +"true" + "#!" + ")");
        doorTerminal.x = 200;
        doorTerminal.y = 500;
       doorTerminal.recalculateLayout();

	}
	public void onClick(string newtext, string old){
        if (newtext.Equals("20"))
        {
            doorUnlock = false;
            Vector3 originalPos = new Vector3(80.85552f, 6.947796f, 76.70168f);
            cube.transform.position = originalPos;
        }
        else
        {
            doorUnlock = true;
            cube.transform.position = new Vector3(0, 0, 0);
        }
    }
	// Update is called once per frame
	void Update () {
        if (open)
        {
            terms.MouseHandler();
            if (doorUnlock)
            {
                doorTerminal.MouseHandler();
            }
        }
	}

    void OnGUI()
    {
        if (open)
        {
            terms.Draw();
            GameObject go = GameObject.Find("Player");
            GameObject gameObject = GameObject.Find("Main Camera");
                
			if(Event.current.Equals (Event.KeyboardEvent("9"))){
	            openCube = true;
			}
	
	        if (openCube)
	        {
	            int smooth = 2;
				door.SetActive();	
	        }
            if (doorUnlock)
            {
                doorTerminal.Draw();
            }
             if (Event.current.Equals(Event.KeyboardEvent("tab")) )
            {
                if (isTabbed)
                {
                    Screen.showCursor = false;
                    ((MouseLook)(go.GetComponent("MouseLook"))).enabled = true;
                    ((MouseLook)gameObject.GetComponent("MouseLook")).enabled = true;

                }
                else
                {

                    AudioListener.volume = 0;
                    Screen.showCursor = true;
                    ((MouseLook)(go.GetComponent("MouseLook"))).enabled = false;
                    ((MouseLook)gameObject.GetComponent("MouseLook")).enabled = false;
                }
                isTabbed = !isTabbed;
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
