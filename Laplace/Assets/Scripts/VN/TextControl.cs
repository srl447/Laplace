using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextControl : MonoBehaviour
{
    public static TextControl instance;
    public Elements elements;

    void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    public void Say(string speech, bool additive = false, string speaker = "", string style = "")
    {
        StopSpeaking();
        mainText.text = targetText;
        if(style != "")
        {
            if(style == "I")
            {
                mainText.fontStyle = FontStyle.Italic;
            }
            else if (style == "B")
            {
                mainText.fontStyle = FontStyle.Bold;
            }
            else if (style == "BI")
            {
                mainText.fontStyle = FontStyle.BoldAndItalic;
            }
            else
            {
                mainText.fontStyle = FontStyle.Normal;
            }
        }
        speaking = StartCoroutine(Speaking(speech, additive, speaker));

    }

    void StopSpeaking()
    {
        if (isSpeaking)
        {
            StopCoroutine(speaking);
        }
        speaking = null;
    }

    public bool isSpeaking {get{return speaking != null;}}
    public bool waitForInput = false;

    string targetText = "";
    Coroutine speaking = null;
    IEnumerator Speaking(string inText, bool additive, string speaker = "")
    {
        textBox.SetActive(true);
        targetText = inText;
        if (!additive)
            mainText.text = "";
        else
            targetText = mainText.text + targetText;
        speakerName.text = DetermineSpeaker(speaker);
        waitForInput = false;

        while(mainText.text != targetText)
        {
            mainText.text += targetText[mainText.text.Length];
            yield return new WaitForEndOfFrame();
        }

        waitForInput = true;
        while(waitForInput)
        {
            yield return new WaitForEndOfFrame();
        }

        StopSpeaking();
    }

    string DetermineSpeaker(string s)
    {
        string speaker = speakerName.text;
        if(s!= "" && s != speakerName.text)
        {
            speaker = (s.ToLower().Contains("narrator")) ? "" : s;
        }
        return speaker;
    }
    [System.Serializable] //allows for recreation of class when needed
    public class Elements
    {
        /*
         * Contains all the elements of the visual novel
         */

        public GameObject textBox;
        public Text speakerName;
        public Text mainText;
        public Image backgroundImage, leftImage, rightImage, centerImage;
    }

    //So there's no need to reference elements every time
    public GameObject textBox { get { return elements.textBox; } }
    public Text speakerName { get { return elements.speakerName; } }
    public Text mainText { get { return elements.mainText; } }
    public Image backgroundImage { get { return elements.backgroundImage; } }
    public Image leftImage { get { return elements.leftImage; } }
    public Image rightImage { get { return elements.rightImage; } }
    public Image centerImage { get { return elements.centerImage; } }

}

