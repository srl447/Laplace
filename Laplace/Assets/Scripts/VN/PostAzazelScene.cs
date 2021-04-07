using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PostAzazelScene : MonoBehaviour
{
    TextControl textC;
    public Compendium comp;
    public Scene one = new Scene(), two = new Scene(), one2 = new Scene(),
        three = new Scene(), four = new Scene(), five = new Scene(), six = new Scene(),
        seven = new Scene(), eight = new Scene(), nine = new Scene(), ten = new Scene(),
        eleven = new Scene(), twelve = new Scene(), thirteen = new Scene(), fourteen = new Scene(),
        fifteen = new Scene(), sixteen = new Scene(), seventeen = new Scene(), eighteen = new Scene(),
        nineteen = new Scene(), twenty = new Scene(), twentyOne = new Scene(), twentyTwo = new Scene(),
        twentyThree = new Scene(), twentyFour = new Scene(), twentyFive = new Scene(), twentySix = new Scene(),
        twentySeven = new Scene(), twentyEight = new Scene(), twentyNine = new Scene(), thirty = new Scene(),
        thirtyOne = new Scene(), thirtyTwo = new Scene(), thirtyThree = new Scene(), thirtyFour = new Scene(),
        thirtyFive = new Scene(), thirtySix = new Scene(), thirtySeven = new Scene();

    Scene current = new Scene();
    int count = 0;
    public Sprite bg, bgBlank, bgFrontDoor, bgHallway1, bgHallway2, bgHallway3,
        furfur, furfurH, furfurEww, furfurDis, furfurWow, azazel, azazelF, abyzou, abyzouTsu, abyzouScared,
        counter, oldFashion, carrotJuice1, carrotJuice2, scaryDoor, modayaalZoom, azazelFlex;

    public AudioClip spitTake, pour;

    void Start()
    {
        //setup next opponent
        GameManager.Instance.opponent = "Abyzou";

        //Note: Put speaker name at the beginning of each scene so there's a speaker name when loading
        one.Set(new string[]
        {
            "Well that was quiet enjoyable!:Azazel",
            "Yeah we play it every day:Furfur",
            "Hey SOMETIMES we play other things:Modayaal",
        },
        bg, one2);
        one.left = azazelF;
        one.right = furfur;

        one2.Set(new string[]
        {
            "652 days ago we played Fireball Valley",
            "Yeah but you only wanted to do it once for the spectacle:Furfur"
        },
        bg, two);
        one2.left = azazelF;
        one2.right = furfurDis;
        one2.compendiumEntry = "Fireball Valley";

        two.Set(new string[]
        {
            "hmp I still wanna play dreidel:Abyzou",
            "well you got that right Modey?:Furfur",
            "you don't remember the Chanukah party?:Modayaal",
        },
        bg, three);
        two.left = abyzou;
        two.right = furfur;

        three.Set(new string[]
        {
            "I may have had a few too many:Furfur",
            "All you did was come over with a giant box of dreidels :Modayaal",
            "and then pass out ::A",
            "Fuck yeah!:Furfur"
        },
        bg, four);
        three.center = furfurH;

        four.Set(new string[]
        {
            "So where are the dreidels?:Abyzou",
            "I assume there's a box in the closet in the back:Modayaal",
            "Just like umm",
            " walk a bit::A",
            " take a right::A",
            " and then hope?::A",
        },
        bg, five);
        four.center = abyzouTsu;
        four.compendiumEntry = "Dreidel";

        five.Set(new string[]
        {
            "that's not helpful:Abyou",
            "This house kinda creeps and morphs on its own:Modayaal",
            "so sometimes rooms aren't always in the same place",
            "that's where the hope comes in",
            "Do you want me to come and help you find them?",
            "I don't want to be alone with anyone, but I know I should help:Modayaal::I",
            "No I can make good on my own:Abyzou::N"
        },
        bg, six);
        five.center = abyzou;

        six.Set(new string[]
        {
            "Next time I'm sure you can help bud:Furfur",
            "You got all eternity",
            "but eternity goes by so quick:Modayaal::I",
        },
        bg, seven);
        six.center = furfur;

        seven.Set(new string[]
        {
            "You know I think I'll take you up on that drink now:Azazel",
            "yeah hit me with another too!:Furfur",
            "You actually want the carrot juice?:Modayaal",
            "ehhhh I don't want it but I also don't wanna skip it:Furfur",
            "What do you want Azazel?:Modayaal",
            "Oh an old fashioned would be great:Azazel"
        },
        bg, eight);
        seven.left = azazelF;
        seven.right = furfurH;

        eight.Set(new string[]
        {
            "so:Modayaal",
        },
        bg, nine);
        eight.mini = counter;

        nine.Set(new string[]
        {
            "there we go:Modayaal"
        },
        bg, ten);
        nine.sound = pour;
        nine.mini = oldFashion;
        nine.compendiumEntry = "Old Fashioned";

        ten.Set(new string[]
        {
            "and for Furfur:Modayaal"
        },
        bg, eleven);
        ten.mini = carrotJuice1;

        eleven.Set(new string[]
        {
            "What?:Modayaal",
            "Even when I try I still get confetti:::I",
            "And now there's a bubble wand in his carrot juice",
            "Well it's his fault anyways"
        },
        bg, twelve);
        eleven.mini = carrotJuice2;

        twelve.Set(new string[]
        {
            "Here you are:Modayaal::N",
            "thank you very much:Azazel",
            "don't mind if I do:Furfur"
        },
        bg, thirteen);
        twelve.left = azazelF;
        twelve.right = furfur;

        thirteen.Set(new string[]
        {
            "BLECHHHH:Furfur",
            "Carrot Juice and a bubble wand?",
            "what a bad combo",
            "that's on you bud:Modayaal",
            "did this guy ever take a good shot?:Furfur"
        },
        bg, fourteen);
        thirteen.center = furfurEww;
        thirteen.sound = spitTake;

        fourteen.Set(new string[]
        {
            "What are you even drinking?:Azazel",
            "Every shot Blom Blamilton ever took:Furfur",
            "it made sense a few years ago",
            "but this guy is the only one who can make it",
            "yeah if you need anything I gotchu:Modayaal",
            "I can get you some scapegoat meat from after I fucked up",
            "I don't know if it'd be the same:Azazel",
            "I didn't partake in the scapegoat rite because I love the taste of sinful goat",
            "I did it because I wanted to help out humanity as best I could",
            "mrmrmrmrmrmrrm:Modayaal",
            "Ahh don't worry:Azazel",
            "I'm not blaming you",
            "I know you didn't know this would happen",
            "yeah but it's still my fault:Modayaal",
            "That's a healthy outlook :Azazel",
            "Well if there's anything I can get you:Modayaal",
            "I'm here to help"
        },
        bg, fifteen);
        fourteen.left = azazelF;
        fourteen.right = furfurDis;

        fifteen.Set(new string[]
        {
            "Well actually...:Azazel",
            "I've always been curious",
            "how do you get around that whole irreversability of entropy thing",
            "Well you see:Modayaal"
        },
        bg, sixteen);
        fifteen.center = azazel;

        sixteen.Set(new string[]
        {
            "Hey y'all Tess here:Tess",
            "I've decided to redact Modayaal's answer here, ",
            "as to not spoil the answer for all the physicist aspiring to solve entropy here.",
            "Thank you for your understanding!"
        },
        bgBlank, seventeen);
        sixteen.compendiumEntry = "Entropy";

        seventeen.Set(new string[]
        {
            "Wow absolutely fascinating:Azazel",
            "It's wild how long it took humanity to figure out such a simple concept:Modayaal"
        },
        bg, eighteen);
        seventeen.center = azazelFlex;

        eighteen.Set(new string[]
        {
            "Modey, do you think you should check up on Abyzou?:Furfur",
            "Yeah I'm getting kind of worried:Azazel",
            "How hard could it be to find a closet?",
            "umm I do sleep in the foyer for a reason:Modayaal",
            "but she really didn't want me to help her",
            "I think it's time to make the call:Furfur",
            "well:Modayaal",
            "*GULP*:Modayaal::I",
            "wish me luck:Modayaal::N",
            "Which way do you think they mean?:Azazel",
            "honestly not sure:Furfur"
        },
        bg, nineteen);
        eighteen.left = azazelF;
        eighteen.right = furfur;

        nineteen.Set(new string[]
        {
            "Okay let's see:Modayaal"
        },
        bgFrontDoor, twenty);

        twenty.Set(new string[]
        {
            "Hopefully she didn't go this way:Modayaal"
        },
        bgFrontDoor, twentyOne);
        twenty.mini = scaryDoor;

        twentyOne.Set(new string[]
        {
            "*CREAK*:The House::I"
        },
        bgHallway1, twentyTwo);

        twentyTwo.Set(new string[]
        {
            "*URKK*:The House::I"
        },
        bgHallway2, twentyThree);

        twentyThree.Set(new string[]
        {
            "oh no....:Modayaal::N"
        },
        bgHallway3, twentyFour);
        twentyThree.mini = modayaalZoom;

        twentyFour.Set(new string[]
        {
            "what are you doinng here..?.:Modayaal",
            "what is this place:Abyzou",
            "I like to pretend it doesn't exist:Modayaal",
            "This house is leprous:Abyzou",
            "I just hope the tzaraath will go away if I abandoned it:Modayaal",
            "There's no dreidels here",
            "; we should go::A",
            "I feel like :Abyzou",
            "it begs me to stay:Abyzou:A",
            "I can assure you I'm not:Modayaal",
            "I'm so sorry:Abyzou",
            "It's only my fault:Modayaal",
            "we need to go before the exits ebbs "
        },
        bgHallway3, twentyFive);
        twentyFour.center = abyzouScared;
        twentyFour.compendiumEntry = "Tzaraath";

        twentyFive.Set(new string[]
        {
            "Okay I made a dreidel:Modayaal",
            "we can go back to the others",
            "Are you sure you don't wanna talk about that:Abyzou",
            "I do, but maybe not today:Modayaal"
        },
        bgFrontDoor);
        twentyFive.center = abyzouTsu;

        twentySix.Set(new string[]
        {
            "Welcome back you two:Furfur",
            "I see you brought the dreidel:Azazel",
            "Feels like I've been waiting for Forneus:Furfur",
        },
        bg, twentySeven);
        twentySix.left = azazelF;
        twentySix.right = furfurH;
        twentySix.compendiumEntry = "Forneus";

        twentySeven.Set(new string[]
        {
            "Yeah I just got a little lost:Abyzou",
            "not a big deal",
            "well then let's get going:Furfur",
            "you know I can't wait to eat some gelt"
        },
        bg);
        twentySeven.left = abyzou;
        twentySeven.right = furfur;


        textC = TextControl.instance;
        current = one;
        //loads progress
        for (int i = 0; i < GameManager.Instance.progress; i++)
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
            if(autoCount > 240)
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

    public void AutoButton()
    {
        if(auto)
        {
            auto = false;
        }
        else
        {
            auto = true;
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
                SceneManager.LoadScene(5); // Dreidel scene
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
        textC.Say(text, a, speaker, style);
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
