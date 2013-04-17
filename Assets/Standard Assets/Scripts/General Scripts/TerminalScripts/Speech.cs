using UnityEngine;
using System.Collections;

public class Speech : MonoBehaviour {

    public string[] talkBubbles;
    public string name;
    string currentTalk;
	public static int onScreenAtOnce = 4;
    string [] currentText = new string[onScreenAtOnce];
    bool inTalkRange;
    int quotePosition;
    int currentTextPosition;
    public Font font;
    GUIStyle style;
	public AudioSource audio;
	public bool active = true;
	public float waitTime = .05f;
	public float waitBetweenTime = .05f;
	
	public bool hasCrucialText = false;
	public int crucialTextPos;
	public AudioSource comeBack;
	float audioTime = 0f;
	
	
    void Start()
    {
        inTalkRange = false;
        quotePosition = 0;
        currentTalk = talkBubbles[0];
		for (int i = 0; i < onScreenAtOnce; i++) {
			currentText[i] = "";
		}
    }

    void OnGUI()
    {
        GUIStyle style = new GUIStyle(GUI.skin.textArea);
        style.font = font;
        style.fontSize = 15;
        style.padding = new RectOffset(10, 10, 5, 5);
		
        if(inTalkRange)
        {
			for (int i = 0; i < onScreenAtOnce; i++) {
				if (!currentText[i].Equals("")) {
					GUI.Label(new Rect(500, 5 * Screen.height/6 - 32*i, Mathf.FloorToInt((name.Length + currentText[i].Length) * 10.0f + 30), 30), name + ": " + currentText[i], style);
				}
			}
		}
    }

    IEnumerator updateText()
    {
        while (true)
        {
            for (int i = 1; i < onScreenAtOnce; i++) {
				if (quotePosition - 1 >= i && quotePosition - i - 1 < talkBubbles.Length) {
					currentText[i] = talkBubbles[quotePosition-1-i];
				}
				else {
					currentText[i] = "";	
				}
			}
			currentText[0] = currentTalk.Substring(0, currentTextPosition);
            if (currentTextPosition < currentTalk.Length)
            {
                currentTextPosition++;
            }
            yield return new WaitForSeconds(waitTime);
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
		if (audio != null && audioTime != -1) {
			audio.time = audioTime; 
			audio.mute = false;
			audio.Play();
		}
    }

    IEnumerator ChooseNewQuote()
    {
        while (inTalkRange)
        {
            if (quotePosition < talkBubbles.Length)
            {
                currentTalk = talkBubbles[quotePosition];
            }
			else {
				currentTalk = "";	
			}
            currentTextPosition = 0;
            quotePosition = ++quotePosition;
            StartCoroutine(updateText());
            yield return new WaitForSeconds(currentTalk.Length * waitBetweenTime + 2);
        }
    }

    void OnTriggerExit(Collider c)
    {
        inTalkRange = false;
        StopCoroutine("ChooseNewQuote");
		if (hasCrucialText && quotePosition - 1 < crucialTextPos) {	
			comeBack.Play();	
		}
		if (audio != null && audio.isPlaying) {
			audioTime = audio.time;
			audio.Pause();
			audio.mute = true;
		}
		else {
			audioTime = -1;	
		}
    }
}
