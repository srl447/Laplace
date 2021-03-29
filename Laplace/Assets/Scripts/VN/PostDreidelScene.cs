using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PostDreidelScene : MonoBehaviour
{
    TextControl textC;
    public Compendium comp;
    public Scene one = new Scene(), two = new Scene(),
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
    public Sprite bg,
        furfur, furfurH, furfurEww, furfurDis, furfurWow, azazel, azazelF, azazelFlex, abyzou, abyzouTsu;

    public AudioClip spitTake, pour;

    // Start is called before the first frame update
    void Start()
    {
        //setup next opponent
        GameManager.Instance.opponent = "Abyzou";

        //Note: Put speaker name at the beginning of each scene so there's a speaker name when loading
        one.Set(new string[]
        {
            "Damn gelt taste good:Furfur",
            "really why do people only play Dreidel at Chanukah?",
            "That's why I always advocate for it:Abyzou",
            "it's basically an excuse to play with tops and eat chocolate.",
            "Thank you all for playing with me.",
            "If you want anything else just mention it:Modayaal",
            "well not that you can give me:Abyzou",
            "yeah I know...:Modayaal",
            "Just go beg Yaweh to let us back:Abyzou",
            "like do everything you can to revert this situation",
            "I have begged and pleaded:Modayaal",
            "I think the earth doesn't want us",
            "or maybe isn't prepared for us",
            "I think people have long forgot about the good we can do",
            "Also so many of us really do love it here:Furfur",
            "we couldn't get to Gehinomm before and it's kinda a utopia",
            "infinite space and resources and it's filled with fire!",
            "yeah but I love that dang humanity so much:Abyzou",
            "If I could just open up a clinic and help those who need me",
            "I feel like it's my purpose",
            "here anyone can just have kids or not at will",
            "so I feel like I'm worthless"
        },
        bg, two);
        one.left = abyzou;
        one.right = furfur;

        two.Set(new string[]
        {
            "Abyzou:Azazel",
            "you're anything but worthless",
            "you're my treasured friend and that is priceless",
            "look I can tell every infinite future that both exists and doesn't:Modayaal",
            "and I can't even help steer people to the good ones",
            "we're in this together",
            "we can just be us",
            "and maybe that's okay",
            "That's more than okay:Azazel",
            "I've gotten by just fine even though I can no longer perform the scapegoat rite",
            "and you know ",
            "it's probably better without the pugnent sin that used to emanate from me::A",
            "just look for the bright side",
            "that's not so easy:Abyzou",
            "you can say that again:Modayaal",
            "Things will only get better for you both:Azazel",
            "Now that you're starting to come out of your shell Modayaal",
            "I'm sure you'll start to see how much people actually like it here",
            "and Abyzou",
            "There's tons of great women out there",
            "you can still fall in love here",
            "it doesn't have to be on earth::A",
            "yeah but:Abyzou",
            "yeah",
            "yeah:Modayaal",
            "being around eachother is call of celebration :Azazel",
            "not moping::A"
        },
        bg, three);
        two.left = abyzouTsu;
        two.right = azazel;

        three.Set(new string[] 
        {
            "I believe in all of you!:Azazel"
        },
        bg, four);
        three.left = abyzou;
        three.right = azazelFlex;

        four.Set(new string[]
        {
            "You know Modey:Furfur",
            "we just gotta figure out what you wanna do",
            "brainstorm sesh",
            "What about Abyzou?:Azazel",
            "I mean she and I can hit up the clubs later"
        },
        bg, five);
        four.left = azazelF;
        four.right = furfur;

        five.Set(new string[]
        {
            "and you think I'd want to with you:Abyzou",
            "owch!:Furfur"
        },
        bg, six);
        five.left = abyzou;
        five.right = furfurWow;

        six.Set(new string[]
        {
            "but if I knew what I wanted to do:Modayaal",
            "I'd do it",
            "all I do know is I want my head to stop splitting",
            "but nothing really fixes that",
            "that's why you gotta find the things that make it a bit more bareable:Furfur",
            "like gambling?:Modayaal",
            "don't know the outcome of randomness",
            "I mean yeah, but...:Furfur",
            "you also don't know the outcome of socializing with people!:Furfur"
        });

        textC = TextControl.instance;
        current = one;
        //loads progress
        for (int i = 0; i < GameManager.Instance.progress; i++)
        {
            current = current.nextScene;
        }
        Sync();

    }
    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.canClick && (Input.GetKeyDown(GameManager.Instance.main) || Input.GetKeyDown(GameManager.Instance.alt)))
        {
            if (!textC.isSpeaking || textC.waitForInput)
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
                        SceneManager.LoadScene(0); //TODO: Make Scene 7
                    }
                    return;
                }

                Say(current.textBody[count]);
                count++;
            }
            else if (textC.isSpeaking)
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
