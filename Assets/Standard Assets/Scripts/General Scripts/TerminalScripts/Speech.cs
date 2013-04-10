using UnityEngine;
using System.Collections;

public class Speech : MonoBehaviour {

    public string[] talkBubbles;
    public string name;
    string currentTalk;
    string currentText;
    bool inTalkRange;
    int quotePosition;
    int currentTextPosition;
    public Font font;
    GUIStyle style;

    void Start()
    {
        inTalkRange = false;
        quotePosition = 0;
        currentTalk = talkBubbles[0];
    }

    void OnGUI()
    {
        GUIStyle style = new GUIStyle(GUI.skin.textArea);
        style.font = font;
        style.fontSize = 15;
        style.padding = new RectOffset(10, 10, 5, 5);

        if(inTalkRange)
        {
            GUI.Label(new Rect(40, 40, Mathf.FloorToInt((name.Length + currentTalk.Length) * 10.0f + 30), 30), name + ": " + currentText, style);
        }
    }

    IEnumerator updateText()
    {
        while (true)
        {
            currentText = currentTalk.Substring(0, currentTextPosition);
            if (currentTextPosition < currentTalk.Length)
            {
                currentTextPosition++;
            }
            yield return new WaitForSeconds(.3f);
        }
    }

	// Update is called once per frame
    void OnTriggerEnter(Collider c)
    {
        inTalkRange = true;
        
        if (talkBubbles.Length > 0)
        {
            currentTalk = talkBubbles[0];
        }
        StartCoroutine(ChooseNewQuote());
    }

    IEnumerator ChooseNewQuote()
    {
        while (inTalkRange)
        {
            if (quotePosition < talkBubbles.Length)
            {
                currentTalk = talkBubbles[quotePosition];
            }
            currentTextPosition = 0;
            quotePosition = ++quotePosition % talkBubbles.Length;
            StartCoroutine(updateText());
            yield return new WaitForSeconds(currentTalk.Length * .3f + 2);
        }
    }

    void OnTriggerExit(Collider c)
    {
        inTalkRange = false;
        StopCoroutine("ChooseNewQuote");
    }
}
