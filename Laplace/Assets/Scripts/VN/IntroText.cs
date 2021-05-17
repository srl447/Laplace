using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class IntroText : MonoBehaviour
{
    TextControl textC;
    public Compendium comp;

    //I'm sorry for this
    public Scene Intro = new Scene(), Intro2 = new Scene(), Second = new Scene(), nine2 = new Scene(), nine3 = new Scene(), third2 = new Scene(),
        third = new Scene(), fourth = new Scene(), fifth = new Scene(), sixth = new Scene(), seven2 = new Scene(), third3 = new Scene(),
        fourth2 = new Scene(), fourth3 = new Scene(), fourth4 = new Scene(), seven = new Scene(), eight = new Scene(),
        nine = new Scene(), ten = new Scene(), eleven = new Scene(), twelve = new Scene(), thirteen = new Scene(),
        nine4 = new Scene(), fourteen = new Scene(), ten2 = new Scene(), ten3 = new Scene();

    Scene current = new Scene();
    int count = 0;
    public Sprite bg, bg2, bg3, handSmall, handSmall2, furfur, furfurEww, furfurWow,
        furfurH, doorSmall1, doorSmall2, doorSmall3, doorSmall4,
        shotGlass1, shotGlass2, corpseRaiser1, corpseRaiser2;

    public AudioClip knock, pour, spitTake, modayaalNeedDrink, modayaalBored;

    // Start is called before the first frame update
    void Start()
    { 
        //setup next opponent
        GameManager.Instance.opponent = "Furfur";

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
        Intro2.sound = modayaalNeedDrink;
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
            "; I always hate the taste of newly conjured stuff anyways.:Modayaal:A",
            "It's been five seconds, and today is already just as horrible as the last.:Modayaal::N",
            "I know I didn't do anything different, but why should I?",
            "Nothing will change",
            
        }, 
        bg2, third2);

        third2.Set(new string[]
        {
            ". It'll still be fucking boring:Modayaal:A",
            "Why did I ask to know everything?",
            "Why did I put this on myself?",
            "I'd think knowing everything that ever have and will happen down to the exact quark",
            "would provide some sort of universal enlightenment and give purpose to my life.",
            "How could I not see how wrong that was? ",
            "How could I be so ignorant?::A",

        },
        bg2, third3);
        third2.sound = modayaalBored;

        third3.Set(new string[]
        {
            "How could I think trapping everyone in Gehinnom was worth anything?:Modayaal",
            "STOP! :::I",
            "Stop. ::A",
            "stop stop stop::A",
            "That's enough brain.",
            "We do this every morning, and I need to stop it."
        },
        bg2, fourth);
        third3.compendiumEntry = "Gehinomm";

        fourth.Set(new string[]
        {
            "*KNOCK* :The Door::I"
        },
        bg2, fourth2);
        fourth.mini = doorSmall1;
        fourth.sound = knock;

        fourth2.Set(new string[]
        {
            "*KNOCK* :The Door:A"
        },
        bg2, fourth3);
        fourth2.mini = doorSmall2;
        fourth2.sound = knock;

        fourth3.Set(new string[]
        {
            "*KNOCK* :The Door:A",
        },
        bg2, fourth4);
        fourth3.mini = doorSmall3;
        fourth3.sound = knock;

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
        fifth.compendiumEntry = "Furfur";

        sixth.Set(new string[]
        {
            "And that's cause I love you so much:Furfur",
            "yeah loves bugging me:Modayaal::I",
        },
        bg2, seven);
        sixth.center = furfurH;

        seven.Set(new string[]
        {
            "What was that?:Furfur::N",
            "I didn't even say anything!!!:Modayaal",
            "Anyways, you good bud?: Furfur",
            "????:Modayal",
            "fair:Furfur",
            " fair::A",
            "You want a drink?:Modayaal"
        },
        bg2, seven2);
        seven.center = furfur;

        seven2.Set(new string[]
        {
            "You know I'm on the Blom Blamilton routine:Furfur",
            "Gimme the next shot",
            "One day you're gonna ask me for something that isn't conjured,:Modayaal",
            "and it's gonna blow your mind",
            "Yeah but I'm so close like we're already on the Temporary Staycation tour:Furfur"
        },
        bg2, eight);
        seven2.center = furfurH;
        seven2.compendiumEntry = "Blom Blamilton";
        
        //TODO: Split this up and create art assests as needed
        eight.Set(new string[]
        {
            "Fine:Modayaal",
            "ugh:Modayaal::I"
        },
        bg2, nine);
        eight.mini = shotGlass1;

        nine.Set(new string[]
        {
            "Here ya go.:::N",
            "You're the best bud:Furfur",
            "You know ",
            "you don't have to make confetti everytime right?::A",
            "ever since you told me to do it with confetti:Modayaal",
            "I can't make it without it",
        },
        bg2, nine2);
        nine.mini = shotGlass2;
        nine.center = furfur;

        nine2.Set(new string[]
        {
            "Well...:Furfur",
            "Bottom's up!::A"
        },
        bg2, nine3);
        nine2.center = furfur;

        nine3.Set(new string[]
        {
            "BLeCH:Furfur",
            "really what was this dude drinking",
            "Hey next up is the tour where they just drank carrot juice:Modayaal",
            "I can't wait?:Furfur"
        },
        bg2, nine4);
        nine3.center = furfurEww;
        nine3.sound = spitTake;

        nine4.Set(new string[]
        {
            "Sooooooo:Furfur",
            "I may have invited some others over...",
            "I already told Bael:Modayaal"
        },
        bg2, ten);
        nine4.center = furfurH;
        nine4.compendiumEntry = "Bael";

        ten.Set(new string[]
        {
            "I can't make a non-existent Quick and the Curious movie better than they can",
            "No no no :Furfur",
            "It's Azazel and Abyzou::A",
            "fuck Furfur:Modayaal",
            "they hate being trapped here... ",
            "WHY would you bring them here::A",
            "That's EXACTLY why!:Furfur",
            "it's something shared to bond over",
            "UGHHGHGHG:Modayaal",
            "You need something to spice up your life,:Furfur",
            "and you won't even let me zap you with my straight baby ray",
            "I'm not a baby AND I'm agender how would that even work:Modayaal",
            "We won't know unless we try!:Furfur",
            "I'm going to go make a Corpse Reviver:Modayaal",
        },
        bg2, ten2);
        ten.center = furfur;
        ten.compendiumEntry = "The Quick and the Curious";

        ten2.Set(new string[]
        {
            "You owe me a game of Koi-Koi, ",
            "go set it up."
        },
        bg2, ten3);
        ten2.compendiumEntry = "Koi-Koi";
        ten2.center = furfurWow;

        ten3.Set(new string[]
        {
            "Corpse Reviver No. 2?:Furfur",
            "Of course number 2 who are you:Modayaal"
        }, 
        bg2, eleven);
        ten3.compendiumEntry = "Corpse Reviver No. 2";
        ten3.center = furfurH;

        eleven.Set(new string[]
        {
            "*Pouring Noise*:Liquids::I",
            "And... :Modayaal::N"
        }, 
        bg2, twelve);
        eleven.mini = corpseRaiser1;
        eleven.sound = pour;

        twelve.Set(new string[]
        {
            "done!:Modayaal:A:N",
            "this way it won't have any of that rank conjured taste"
        },
        bg2, thirteen);
        twelve.mini = corpseRaiser2;

        thirteen.Set(new string[]
        {
            "*Sipping Noises*:Modayaal::I",
            "aaaahhhh:Modayaal::N",
        },
        bg2, fourteen);
        thirteen.mini = shotGlass1;

        fourteen.Set(new string[]
        {
            "time to go kick his ass:Modayaal::I"
        },
        bg3);
        fourteen.center = furfur;


        textC = TextControl.instance;
        current = Intro;
        //loads progress
        for(int i = 0; i < GameManager.Instance.progress; i++)
        {
            current = current.nextScene;
        }
        Sync();
    }


    int autoCount = 0;
    public bool auto = false;
    void Update()
    {
        if (auto && textC.waitForInput)
        {
            if (autoCount > 240)
            {
                Advance();
                autoCount = 0;
            }
            autoCount++;
        }

        if (GameManager.Instance.canClick && (Input.GetKeyDown(GameManager.Instance.main) || Input.GetKeyDown(GameManager.Instance.alt)))
        {
            if (!textC.isSpeaking || textC.waitForInput)
            {
                Advance();
            }
            else if (textC.isSpeaking)
            {
                textC.HurrySpeaking();
            }
        }
    }

    public GameObject autoArrow;
    public void AutoButton()
    {
        if (auto)
        {
            auto = false;
            autoArrow.SetActive(false);
        }
        else
        {
            auto = true;
            autoArrow.SetActive(true);
        }
    }
    void Advance()
    {
        if (count >= current.textBody.Length)
        {
            if (current.nextScene != null)
            {
                current = current.nextScene;
                GameManager.Instance.progress++;
                Sync();
            }
            else
            {
                GameManager.Instance.progress = 0;
                SceneManager.LoadScene(2); // KoiKoi Scene
            }
            return;
        }

        Say(current.textBody[count]);
        count++;
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
        if (current.sound != null)
        {
            AudioManager.Instance.PlayOneShot(current.sound);
        }
        if (current.compendiumEntry != null)
        {
            StopCoroutine(AddCompendiumEntry(""));
            StartCoroutine(AddCompendiumEntry(current.compendiumEntry));
        }
        count = 1;
    }

    public GameObject compAdd;
    IEnumerator AddCompendiumEntry(string entry)
    {
        if (!comp.buttonValues.Contains(entry))
        {
            comp.Add(entry);
            Vector3 originalP = compAdd.transform.position;
            Text fade = compAdd.GetComponent<Text>();
            fade.color = Color.white;
            fade.text = entry + " added to Compendium";
            yield return new WaitForSecondsRealtime(3);
            for (int i = 0; i < 6; i++)
            {
                fade.color = new Color(fade.color.r, fade.color.g, fade.color.b, Mathf.Lerp(fade.color.a, 0, .18f));
                compAdd.transform.position += Vector3.up / 6;
                yield return new WaitForEndOfFrame();
            }
            fade.color = new Color(fade.color.r, fade.color.g, fade.color.b, 0);
            compAdd.transform.position = originalP;
        }
    }
}
