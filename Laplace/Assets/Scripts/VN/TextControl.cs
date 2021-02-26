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
        logText.text = "";
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    public void Say(string speech, bool additive = false, string speaker = "", string style = "")
    {
        StopSpeaking();
        logText.text += speakerName.text ="\n" + mainText.text +"\n \n";
        mainText.text = targetText;
        Debug.Log("Saying");
        //set elements to appear/dissappear when they change
        if (rightImage.sprite == null)
        {
            rightImage.color = Color.clear;
        }
        else
        {
            rightImage.color = Color.white;
        }
        if (leftImage.sprite == null)
        {
            leftImage.color = Color.clear;
        }
        else
        {
            leftImage.color = Color.white;
        }
        if (miniImage.sprite == null)
        {
            miniImage.color = Color.clear;
        }
        else
        {
            miniImage.color = Color.white;
        }
        if (centerImage.sprite == null)
        {
            centerImage.color = Color.clear;
        }
        else
        {
            centerImage.color = Color.white;
        }
        //sets the style of the text
        if (style != "")
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

    //allows you to skip to the end of the text instead of having it print char by char
    bool hurry = false;
    public void HurrySpeaking()
    {
        hurry = true;
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
        {
            mainText.text = "";
        }
        else
        {
            targetText = mainText.text + targetText;
        }
        speakerName.text = DetermineSpeaker(speaker);
        waitForInput = false;

        while(mainText.text != targetText)
        {
            mainText.text += targetText[mainText.text.Length];
            if (hurry) //recieving input from HurrySpeaking()
            {
                mainText.text = targetText;
                hurry = false;
            }
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

    //log button function
    public void LogClick()
    {
        if(logBox.activeSelf)
        {
            logBox.SetActive(false);
        }
        else
        {
            logBox.SetActive(true);
        }
    }

    [System.Serializable] //allows for recreation of class when needed
    public class Elements
    {
        /*
         * Contains all the elements of the visual novel
         */

        public GameObject textBox, logBox;
        public Text speakerName;
        public Text mainText;
        public Image backgroundImage, leftImage, rightImage, centerImage, miniImage;

        public Button logButton;
        public Text logText;
    }

    //So there's no need to reference elements every time
    public GameObject textBox { get { return elements.textBox; } }
    public GameObject logBox { get { return elements.logBox; } }
    public Text speakerName { get { return elements.speakerName; } }
    public Text mainText { get { return elements.mainText; } }
    public Image backgroundImage { get { return elements.backgroundImage; } }
    public Image leftImage { get { return elements.leftImage; } }
    public Image rightImage { get { return elements.rightImage; } }
    public Image centerImage { get { return elements.centerImage; } }
    public Image miniImage { get { return elements.miniImage; } }

    public Text logText { get { return elements.logText; } }
    public Button logButton { get { return elements.logButton; } }

}

