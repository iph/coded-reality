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

    public static Color fromHSV(int hue, int saturation, int value_i)
    {
        float hue_f = hue / 360f;
        float sat_f = saturation / 100f;
        float value = value_i / 100f; 
         
        int h = (int)(hue_f * 6);
        float f = hue_f * 6 - h;
        float p = value * (1 - sat_f);
        float q = value * (1 - f * sat_f);
        float t = value * (1 - (1 - f) * sat_f);

        switch (h) {
          case 0: return new Color(value, t, p);
          case 1: return new Color(q, value, p);
          case 2: return new Color(p, value, t);
          case 3: return new Color(p, q, value);
          case 4: return new Color(t, p, value);
          case 5: return new Color(value, p, q);
          default: return new Color(0f, 0f, 0f);
        }
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
