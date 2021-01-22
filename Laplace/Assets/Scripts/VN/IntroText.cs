using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroText : MonoBehaviour
{
    TextControl textC;
    public Scene Intro = new Scene(), Second = new Scene();
    Scene current = new Scene();
    int count = 0;
    public Sprite bg, bg2;

    // Start is called before the first frame update
    void Start()
    {
        Intro.textBody = new string[]
        {
            "YARGHHRHRRHH:Modayaal",
        "Suddenly infinity entered my mind.:::I",
        "The same as it did every morning.::A",
        "I need my morning ethanol:::N",
        "I can make it:::I"

        };
        Second.textBody = new string[]
        {
            "*GLUG*:Modayaal:::I"
        };
        Intro.nextScene = Second;
        Intro.background = bg;
        Second.background = bg2;
        textC = TextControl.instance;
        current = Intro;
        textC.backgroundImage.sprite = current.background;
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
                        textC.backgroundImage.sprite = current.background;
                        count = 0;
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
}
