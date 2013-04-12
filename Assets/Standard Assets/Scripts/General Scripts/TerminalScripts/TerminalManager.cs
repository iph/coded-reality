using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TerminalManager 
{
    private List<Terminal> terminals;

    public TerminalManager()
    {
        terminals = new List<Terminal>();
    }
    
    public static Terminal CreateTerminalTransaction()
    {
        return new Terminal();
    }

    public void AddTerminal(Terminal term)
    {
        terminals.Add(term);
    }

    public void Draw()
    {
        for (int i = 0; i < terminals.Count; i++)
        {
            terminals[i].Draw();
        }
    }

}
