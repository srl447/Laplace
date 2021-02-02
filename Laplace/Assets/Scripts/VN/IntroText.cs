using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroText : MonoBehaviour
{
    TextControl textC;
    public Scene Intro = new Scene(), Intro2 = new Scene(), Second = new Scene();
    Scene current = new Scene();
    int count = 0;
    public Sprite bg, bg2, handSmall, handSmall2;

    // Start is called before the first frame update
    void Start()
    {
        Intro.textBody = new string[]
        {
            "YARGHHRHRRHH:Modayaal",
        "Suddenly infinity entered my mind.:::I",
        "The same as it did every morning.::A",

        };
        Intro2.textBody = new string[]
        {
            "I need my morning ethanol:::N",
            "I can make it:::I"
        };
        Second.textBody = new string[]
        {
            "Why does it always make confetti?",
            "whatever...",
            "*GLUG*:Modayaal:::I",
            "*GLUG*::A",
            "*GLUG*::A"
        };
        Intro.nextScene = Intro2;
        Intro2.nextScene = Second;
        Intro.background = bg;
        Intro2.background = bg2;
        Second.background = bg2;
        Intro2.mini = handSmall;
        Second.mini = handSmall2;
        textC = TextControl.instance;
        current = Intro;
        Sync();
    }


    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if(!textC.isSpeaking || textC.waitForInput)
            {
                if(count >= current.textBody.Length)
                {
                    if(current.nextScene != null)
                    {
                        current = current.nextScene;
                        Sync();
                    }
                    return;
                }

                Say(current.textBody[count]);
                count++;
            }
        }
        
    }
    void Say(string s)
    {
        string[] part = s.Split(':');
        string text = part[0];
        string speaker = (part.Length >= 2) ? part[1] : "";
        bool a = (part.Length >= 3 && part[2] == "A") ? true : false;
        string style = (part.Length >= 4) ? part[3] : "";
        textC.Say(text,a,speaker, style);
    }

    void Sync()
    {
        textC.backgroundImage.sprite = current.background;
        textC.leftImage.sprite = current.left;
        textC.rightImage.sprite = current.right;
        textC.miniImage.sprite = current.mini;
        textC.centerImage.sprite = current.center;
        count = 0;
    }
}
