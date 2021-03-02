using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroText : MonoBehaviour
{
    TextControl textC;
    public Scene Intro = new Scene(), Intro2 = new Scene(), Second = new Scene(),
        third = new Scene(), fourth = new Scene(), fifth = new Scene(), sixth = new Scene(),
        fourth2 = new Scene(), fourth3 = new Scene(), fourth4 = new Scene(), seven = new Scene(), eight = new Scene();

    Scene[] sceneProgess;
    Scene current = new Scene();
    int count = 0;
    public Sprite bg, bg2, handSmall, handSmall2, furfur,
        fufurH, doorSmall1, doorSmall2, doorSmall3, doorSmall4;

    // Start is called before the first frame update
    void Start()
    {
        //Progress used for saving to skip to most recent chunk of text
        sceneProgess = new Scene[] { Intro, Intro2, Second, third, fourth, fourth2, fourth3, fourth4, fifth, sixth, seven, eight};

        //Note: Put speaker name at the beginning of each scene so there's a speaker name when loading 
        Intro.textBody = new string[]
        {
            "YARGHHRHRRHH:Modayaal",
        "Suddenly infinity entered my mind. :::I",
        "The same as it does every morning.::A",

        };
        Intro2.textBody = new string[]
        {
            "I need my morning ethanol:Modayaal::N",
            "I can make it:::I"
        };
        Second.textBody = new string[]
        {
            "Why does it always make confetti?:Modayaal::N",
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
            "Okay yep this stuff is still gross.:Modayaal::N",
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
        bg2, fourth);

        fourth.Set(new string[]
        {
            "*KNOCK* :The Door::I"
        },
        bg2, fourth2);
        fourth.mini = doorSmall1;

        fourth2.Set(new string[]
        {
            "*KNOCK* :The Door:A"
        },
        bg2, fourth3);
        fourth2.mini = doorSmall2;

        fourth3.Set(new string[]
        {
            "*KNOCK* :The Door:A",
        },
        bg2, fourth4);
        fourth3.mini = doorSmall3;

        fourth4.Set(new string[]
        {
            "What? :Modayaal::N",
            "Why? ::A",
            "Who?::A",
            "Whatever.",
            "COME INNN",
        },
        bg2, fifth);
        fourth4.mini = doorSmall4;

        fifth.Set(new string[]
        {
            "Don't tell me you forgot your best pal was coming over.:Furfur",
            "How could I? You come over almost every day:Modayaal",

        },
        bg2, sixth);
        fifth.center = furfur;

        //TODO: Need Happy Furfur
        sixth.Set(new string[]
        {
            "And that's cause I love you so much:Furfur",
            "yeah loves bugging me:Modayaal::I",
        },
        bg2, seven);
        sixth.center = fufurH;

        seven.Set(new string[]
        {
            "What was that?:Furfur::N",
            "I didn't even say anything!!!:Modayaal",
            "Anyways, you good bud?: Furfur",
            "????:Modayal",
            "fair:Furfur",
            " fair::A",
            "You want a drink?:Modayaal",
            "You know I'm on the Blom Blamilton routine:Furfur",
            "Gimme the next shot",
            "One day you're gonna ask me for something that isn't conjured,:Modayaal",
            "and it's gonna blow your mind",
            "Yeah but I'm so close like we're already on the Cat's Life tour:Furfur",
            "Fine:Modayaal"
        },
        bg2, eight);
        seven.center = furfur;

        eight.Set(new string[]
        {
            "ugh:Modayaal::I"
        },
        bg2);

        textC = TextControl.instance;
        current = sceneProgess[GameManager.Instance.progress];
        Sync();
    }


    // Update is called once per frame
    void Update()
    {
        if(GameManager.Instance.canClick && (Input.GetKeyDown(GameManager.Instance.main) || Input.GetKeyDown(GameManager.Instance.alt)))
        {
            if(!textC.isSpeaking || textC.waitForInput)
            {
                if(count >= current.textBody.Length)
                {
                    if(current.nextScene != null)
                    {
                        current = current.nextScene;
                        GameManager.Instance.progress++;
                        Sync();
                    }
                    else
                    {
                        GameManager.Instance.progress = 0;
                        SceneManager.LoadScene(2); //First Koi-Koi scene
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
