using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text;
public class Terminal{
    Rect textRect;
    Rect borderRect;
    GUIStyle style;
    public static Color defaultBorder = TerminalManager.fromHSV(0, 0, 60);
    StringBuilder builder;
    StringBuilder actualContent;
    List<string> contents;
    Color currentColor, backgroundColor;
    Texture2D background;
    public int padding;
    private bool borderEnabled;

    // Sets the border to enabled, so it will draw a border!
    public bool BorderEnabled
    {
        get
        {
            return borderEnabled;
        }

        set
        {
            borderEnabled = value;
        }
    }

    public Terminal()
    {
        style = new GUIStyle();
        style.fontSize = 17;
        builder = new StringBuilder("#000000FF"); // Start with the default color of black.
        actualContent = new StringBuilder(); // Unformatted text
        textRect = new Rect();
        backgroundColor = Color.green;
        background = new Texture2D(1, 1);
        background.SetPixel(0, 0, backgroundColor);
        background.Apply();
        padding = 0;
        contents = new List<string>();
        contents.Add("#000000FF");
        font = (Font)Resources.Load("SourceCode");
    }

    /*
     * ChangeColor(Color c);
     *      All text from this point on will be the color input.
     */
    public void ChangeColor(Color c)
    {
        builder.Append("#!");
        builder.Append(ColorToHex(c));
        contents.Add("#!");
        contents.Add(ColorToHex(c));
    }


    /* LOL IT'S PRIVATE, NO NEED FOR A DESCRIPTION! */
    public void SetBorder(Color c)
    {
        for (int i = 0; i < background.width; i++)
        {
            background.SetPixel(i, 0, c);
            background.SetPixel(i, background.height - 1, c);
        }

        for (int i = 0; i < background.height; i++)
        {
            background.SetPixel(0, i, c);
            background.SetPixel(background.width - 1, i, c);
        }

        background.Apply();
    }
    /*
     * Padding(amount);
     *      Puts some space around the text but within the box, so that way the text isn't
     *      all scrunched up :)
     */
    public void Padding(int paddingAmt)
    {
        padding = paddingAmt;
    }

    /*
     * SetBackgroundColor(color);
     *      Sets the background color, what the hell did you think it would do?!!!!!
     */
    public void SetBackgroundColor(Color c)
    {
        backgroundColor = c;
        SetBackgroundPixels(c);
        background.Apply();
    }
    /*
     * AddText(string text)
     *      adds the text you enter into the current terminal. Will not add newlines for you.
     *      NOTE: CALL recalculate after you have added text (if you are adding more, do all that first THEN recalculate)
     *  returns the position in the array that this was added to.
     */
    public int AddText(string s)
    {
        builder.Append(s);
        actualContent.Append(s);
        contents.Add(s);
        
        return contents.Count - 1;
    }

    /*
     * getText(position);
     *      returns the text at some part of the terminal. Used mostly for swapping between choices outside the class.
     */
    public string getText(int position)
    {
        return contents[position];
    }

    /*
     * ChangeText(position, text)
     *      Will change the string at the position (in the array) of the text. This will invoke an automatic recalculate
     *      and is considered fairly expensive.
     */
    public void changeText(int position, string text)
    {
        builder = new StringBuilder();
        actualContent = new StringBuilder();
        contents[position] = text;
        for (int i = 0; i < contents.Count; i++)
        {
            builder.Append(contents[i]);
            if (!contents[i].StartsWith("#"))
            {
                actualContent.Append(contents[i]);
            }
        }

        recalculate();
    }
    /*
     * recalculate()
     *      does all the background texture recalculations.
     *      need to do this every time you add text or change background color. Use this to save
     *      time.
     */
    public void recalculate()
    {
       Vector2 size = style.CalcSize(new GUIContent(actualContent.ToString()));
        // Every time text is added, need to recalculate the background
       textRect.width = size.x;
        textRect.height = size.y;
        int paddedWidth = (int)(size.x);
        int paddedHeight = (int)(size.y);

        paddedHeight += padding * 2;
        paddedWidth += padding * 2;

        borderRect.width = paddedWidth;
        borderRect.height = paddedHeight;

        background = new Texture2D(paddedWidth, paddedHeight);
        background.wrapMode = TextureWrapMode.Repeat;
        SetBackgroundPixels(backgroundColor);
        if(borderEnabled)
            SetBorder(defaultBorder);
        background.Apply();


    }

    /* 
     * MoveX(int x)
     *      Move the x position of the rectangle to this position.
     */
    public void MoveX(int x)
    {
        textRect.x = x + padding;
        borderRect.x = x;
    }

    public void finish()
    {
        this.builder.Append("#!");
    }
    /* 
     * MoveY(int y)
     *      Move the x position of the rectangle to this position.
     */
    public void MoveY(int y)
    {
        textRect.y = y + padding;
        borderRect.y = y;
    }

    /*
     * ColorToHex(Color c)
     *      A nice little helper function that takes a Color objects and turns it into #RRGGBBAA form.
     */
    private static string ColorToHex(Color c)
    {
        string red = ((int)(c.r*255)).ToString("X2");
        string green = ((int)(c.g*255)).ToString("X2");
        string blue = ((int)(c.b*255)).ToString("X2");
        string alpha = ((int)(c.a*255)).ToString("X2");
        return "#" + red + green + blue + alpha;

    }

    /*
     * SetBackgroundPixels(Color c, width, height);
     *      utility to set all the background pixels to a certain color.
     */
    private void SetBackgroundPixels(Color c)
    {
        for (int i = 0; i < borderRect.width; i++)
        {
            for (int j = 0; j < borderRect.height; j++)
            {
                background.SetPixel(i, j, backgroundColor);
            }
        }
 
    }

    /*
     * Draw();
     *      Simple function to draw a singular terminal.
     */
    public void Draw()
    {
        GUI.Label(borderRect, background, style);
        FancyTextArea.FancyLabel(textRect, ToString(), font, font, font, TextAlignment.Left);
        GUI.skin.label.fontSize = 17;
        GUI.skin.label.font = font;
        //GUI.Label(textRect, actualContent.ToString());
    }

    /*
     * ToString();
     *      Prints out the string that is formatted for FancyLabel.
     */
    public string ToString()
    {
        return builder.ToString();
    }

    /*
     * Area -- Variable
     *      Allows to get the rectangle that holds the text info.
     */
    public Rect Area
    {
        get
        {
            return borderRect;
        }
    }

    public Rect clips
    {
        get
        {
            return textRect;
        }
    }
    /// <summary>
    /// CHANGES THE GOD DAMN FONT! ALSO WHAT IS THIS VISUAL STUDIO, DONT /// WTF
    /// </summary>
    public Font font
    {
        get
        {
            return style.font;
        }

        set
        {
            style.font = value;
        }
    }
}
