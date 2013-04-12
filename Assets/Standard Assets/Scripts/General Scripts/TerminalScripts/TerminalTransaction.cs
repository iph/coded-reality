using UnityEngine;
using System.Collections;
using System.Text;
public class Terminal{
    Rect rect;
    GUIStyle style;
    StringBuilder builder;
    Color currentColor;

    public Terminal()
    {
        style = new GUIStyle();
        builder = new StringBuilder("#000000FF"); // Start with the default color of black.
        rect = new Rect();
        //font = (Font)Resources.Load("Assets/SourceCode");
    }

    /*
     * ChangeColor(Color c);
     *      All text from this point on will be the color input.
     */
    public void ChangeColor(Color c)
    {
        builder.Append("#!");
        builder.Append(ColorToHex(c));
    }

    /*
     * AddText(string text)
     *      adds the text you enter into the current terminal. Will not add newlines for you.
     */
    public void AddText(string s)
    {
        MonoBehaviour.print("Here...");
        builder.Append(s);
        Vector2 size = style.CalcSize(new GUIContent(builder.ToString()));
        rect.width = size.x;
        rect.height = size.y;

    }

    /* 
     * MoveX(int x)
     *      Move the x position of the rectangle to this position.
     */
    public void MoveX(int x)
    {
        rect.x = x;
    }

    /* 
     * MoveY(int y)
     *      Move the x position of the rectangle to this position.
     */
    public void MoveY(int y)
    {
        rect.y = y;
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

    public void Draw()
    {
        FancyTextArea.FancyLabel(Area, ToString(), font, font, font, TextAlignment.Left);  
    }

    public string ToString()
    {
        return builder.ToString();
    }

    public Rect Area
    {
        get
        {
            return rect;
        }
    }

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
