using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroText : MonoBehaviour
{
    TextControl textC;
    public Scene Intro = new Scene(), Intro2 = new Scene(), Second = new Scene();
    public Scene third = new Scene();
    Scene current = new Scene();
    int count = 0;
    public Sprite bg, bg2, handSmall, handSmall2;

    // Start is called before the first frame update
    void Start()
    {
        Intro.textBody = new string[]
        {
            "YARGHHRHRRHH:Modayaal",
        "Suddenly infinity entered my mind. :::I",
        "The same as it does every morning.::A",

        };
        Intro2.textBody = new string[]
        {
            "I need my morning ethanol:::N",
            "I can make it:::I"
        };
        Second.textBody = new string[]
        {
            "Why does it always make confetti?:::N",
            "whatever...",
            "*GLUG*:Modayaal::I",
            "*GLUG*::A",
            "*GLUG*::A"
        };
        Intro.nextScene = Intro2;
        Intro2.nextScene = Second;
        Second.nextScene = third;
        Intro.background = bg;
        Intro2.background = bg2;
        Second.background = bg2;
        Intro2.mini = handSmall;
        Second.mini = handSmall2;

        //trying a new style of formatting, hopefully it'll be more legible moving forward
        third.Set(new string[]
        { 
            "Okay yep this stuff is still gross.:::N",
            "I'll make something better later:::I",
            "; I always hate the taste of newly conjured stuff anyways.::A",
            "It's been five seconds, and today is already just as horrible as the last.:::N",
            "I know I didn't do anything different, but why should I?",
            "Nothing will change",
            ". It'll still be fucking boring::A",
            "Why did I ask to know everything?",
            "Why did I put this on myself?",
            "I'd think knowing everything that ever have and will happen down to the exact quark",
            "would provide some sort of universal enlightenment and give purpose to my life.",
            "How could I not see how wrong that was? ",
            "How could I be so ignorant?::A",
            "How could I think trapping everyone in Gehinnom was worth anything?",
            "STOP! :::I",
            "Stop. ::A",
            "stop stop stop::A",
            "That's enough brain.",
            "We do this every morning, and I need to stop it."
        }, 
        bg2);

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
                    else
                    {
                        SceneManager.LoadScene(1);
                    }
                    return;
                }

                Say(current.textBody[count]);
                count++;
            }
            else if(textC.isSpeaking)
            {
                textC.HurrySpeaking();
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
        Say(current.textBody[0]);
        count = 1;
    }
}
