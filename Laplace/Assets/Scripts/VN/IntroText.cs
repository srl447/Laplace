using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroText : MonoBehaviour
{
    TextControl textC;
    int count = 0;
    private string[] t = new string[]
    {
        "Ugh why is it early:Modayaal",
        "Time to grab a drink",
        "Where did I put it",
        "Oh Yeah!   ",
        "I can make it::A"

    };

    public string[] T { get => t; set => t = value; }
    public Sprite[] background;
    Sprite bg;
    int bgCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        textC = TextControl.instance;
    }


    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if(!textC.isSpeaking || textC.waitForInput)
            {
                if(count >= T.Length)
                {
                    return;
                }

                Say(T[count]);
                count++;
            }
        }
        
    }
    void Say(string s)
    {
        string[] part = s.Split(':');
        string text = part[0];
        string speaker = (part.Length >= 2) ? part[1] : "";
        bool a = (part.Length >= 3) ? true : false;
        if(part.Length >= 4 && part[3] != "")
        {
            bg = background[bgCount];
            bgCount++;
        }
        textC.Say(bg, text,a,speaker);
    }
}
