using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ChoiceTerminal {

    Terminal mainTerminal;
    Color defaultColor;
    public Font font;
    List<Terminal> choices;
    Dictionary<string, int> choiceNames;
    Dictionary<string, Color> terminalColor;
    Dictionary<Terminal, string> r_terminalChoice;
    Dictionary<string, List<Terminal>> terminalChoices;
    Dictionary<string, List<OnTerminalClickListener>> listeners;
    private int randomNum;

    // Used for random number generation. BLACK MAGIC
    private int NextInt
    {
        get
        {
            randomNum = (randomNum + 229) % 360;
            return randomNum;
        }
    }

    // Used for the outside world to update the x value of where they want the terminal cluster to be located.
    public int x
    {
        set
        {
            mainTerminal.MoveX(value);
            recalculateLayout();
        }
    }

    // Used for the outside world to update the y value of where they want the terminal cluster to be located.
    public int y
    {
        set
        {
            mainTerminal.MoveY(value);
            recalculateLayout();
        }
    }

    // Sucks, but gotta include that font :(
    public ChoiceTerminal(Font f)
    {
        randomNum = 340;
        font = f;
        mainTerminal = this.initTerm();
        choices = new List<Terminal>();
        choiceNames = new Dictionary<string, int>();
        r_terminalChoice = new Dictionary<Terminal, string>();
        terminalChoices = new Dictionary<string, List<Terminal>>();
        listeners = new Dictionary<string, List<OnTerminalClickListener>>();
        terminalColor = new Dictionary<string, Color>();
        defaultColor = new Color(223f / 255f, 229f / 255f, 237f / 255f);
    }

    /*
     * AddText(text);
     *      Add non colored text to the terminal that is just "there" to display. 
     */
    public void AddText(string text)
    {
        mainTerminal.ChangeColor(defaultColor);
        mainTerminal.AddText(text);
    }

    /*
     * AddChoice(handle, choice);
     *      Adds the string as a menu option for the choices of that particular color.
     *      param handle: refers to the name that you gave the default choice. So order of ops:
     *          terminal.AddTextChoice("name", "bob"); creates a choice where the default text is bob.
     *          terminal.AddChoice("name", "sean"); creates an option in the menu to choose sean to replace bob in the original main terminal.
     *
     *      param choice: name of the choice.
     */          
    public void AddChoice(string handle, string choice)
    {
        Terminal t = initTerm();
        t.ChangeColor(terminalColor[handle]);
        // This means it is always the 4th position in the array.
        t.AddText(choice);
        t.finish();
        // Add terminal data to list and reverse index.
        r_terminalChoice[t] = handle;
        terminalChoices[handle].Add(t);
        choices.Add(t);
    }

    /*
     * AddTextChoice(handle, defaultChoice)
     *      will display text in the main terminal window with a certain color. Any choice added later can
     *      be added through the string handle. The default choice is the string that shows up initially.
     */
    public void AddTextChoice(string handle, string defaultChoice)
    {
        Color termColor = TerminalManager.fromHSV(NextInt, 40, 93); // Refer to definition of NextInt for the black magic of how it works.
        terminalColor[handle] = termColor;
        mainTerminal.ChangeColor(termColor);
        int position = mainTerminal.AddText(defaultChoice);
        choiceNames[handle] = position;
        terminalChoices[handle] = new List<Terminal>();
        listeners[handle] = new List<OnTerminalClickListener>();
    }
    /*
     * Draw();
     *      Call to draw the terminal.
     */
    public void Draw()
    {
        mainTerminal.Draw();
        for (int i = 0; i < choices.Count; i++)
        {
            choices[i].Draw();
        }
    }

    public void MouseHandler()
    {
        Vector2 mouse = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        mouse.y = Screen.height - mouse.y;
        Screen.showCursor = true;
        foreach (Terminal t in choices)
        {
            if (t.Area.Contains(mouse) && Input.GetMouseButtonUp(0))
            {
                SelectChoice(t, mainTerminal);
                foreach (OnTerminalClickListener listener in listeners[r_terminalChoice[t]])
                {
                }
            }
            else if (t.Area.Contains(mouse))
            {
               // t.SetBorder(TerminalManager.fromHSV(34, 0, 84));
                t.SetBorder(terminalColor[r_terminalChoice[t]]);
            }
            else
            {
                t.SetBorder(Terminal.defaultBorder);
            }
        }
    }

    private void SelectChoice(Terminal choice, Terminal main)
    {
        int mainPosition = choiceNames[r_terminalChoice[choice]];
        string choiceText = choice.getText(3);
        MonoBehaviour.print(choiceText);
        // Notify all listeners
        foreach (OnTerminalClickListener listener in listeners[r_terminalChoice[choice]])
        {
            listener.onClick(choiceText, mainTerminal.getText(mainPosition));
        }

        choice.changeText(3, mainTerminal.getText(mainPosition));
        mainTerminal.changeText(mainPosition, choiceText);
    }

    /*
     * initTerm();
     *      Returns a properly formatted terminal. You can go balls deep insane and make your own terminals
     *      but shit gets real too fast, so I would advise against it :)
     */
    private Terminal initTerm()
    {
        Terminal t = new Terminal();
        t.font = font;
        t.BorderEnabled = true;
        t.Padding(7);
        t.SetBackgroundColor(TerminalManager.fromHSV(195, 11, 28));
        t.MoveX(20);
        t.MoveY(20);
        return t; 
    }

    /*
     * recalculateLayout();
     *      HOLY SHIT THIS IS IMPORTANT: In order for the layout to be properly formatted, call this.
     *      The reason it is separate is obvious: It has a fuck-ton cost associated with it. So do a lot
     *      of operations then recalculate, otherwise you've fucked up and called this too many times and
     *      now our game sucks because it is too slow!
     */
    public void recalculateLayout()
    {
        mainTerminal.recalculate();
         for (int i = 0; i < choices.Count; i++)
        {
            choices[i].recalculate();
        }

         int moveY = (int)mainTerminal.Area.y; 
         foreach (KeyValuePair<string, List<Terminal>> entry in terminalChoices)
         {
             // do something with entry.Value or entry.Key
             Rect previous = mainTerminal.Area;
             int previousPadding = mainTerminal.padding;
            foreach(Terminal t in entry.Value){
                int moveX = (int)previous.x + (int)previous.width + 5;
                t.MoveX(moveX);
                t.MoveY(moveY);
                previous = t.Area;
                previousPadding = t.padding;
             }
             moveY = (int)previous.y + (int)previous.height + 5;

         }

        
    }


    public void addOnTerminalClickListener(string handler, OnTerminalClickListener listener)
    {
        listeners[handler].Add(listener);
    }
}
