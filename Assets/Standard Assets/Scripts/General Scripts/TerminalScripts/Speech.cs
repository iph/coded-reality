using UnityEngine;
using System.Collections;

public class Speech : MonoBehaviour {

    public string[] talkBubbles;
    string currentTalk;
    bool inTalkRange;
    int quotePosition;
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

        if(inTalkRange)
        {

            GUI.Label(new Rect(40, 40, currentTalk.Length * 12, 30), currentTalk, style);
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
        InvokeRepeating("ChooseNewQuote", 0, 3);
    }

    void ChooseNewQuote()
    {
        if (quotePosition < talkBubbles.Length)
        {
            currentTalk = talkBubbles[quotePosition];
        }
        quotePosition = ++quotePosition % talkBubbles.Length;
    }

    void OnTriggerExit(Collider c)
    {
        inTalkRange = false;
        CancelInvoke("ChooseNewQuote");
    }
}
