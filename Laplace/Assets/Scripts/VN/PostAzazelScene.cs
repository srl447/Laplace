using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PostAzazelScene : MonoBehaviour
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
    public Sprite bg, furfur, furfurH, furfurEww, furfurDis, furfurWow, azazel, azazelF, abyzou, abyzouTsu;

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
            "652 days ago we played Fireball Valley",
            "Yeah but you only wanted to do it once for the spectacle:Furfur"
        },
        bg, two);
        one.left = azazelF;
        one.right = furfur;
        one.compendiumEntry = "Fireball Valley";

        two.Set(new string[]
        {
            "hmp I still wanna play dreidel:Abyzou",
            "well you got that right Modey?:Furfur",
            "you don't remember the Chanukah party?:Modayaal",
        },
        bg,three);
        two.left = abyzou;
        two.right = furfur;

        three.Set(new string[]
        {
            "I may have had a few too many:Furfur",
            "All you did was come over with a giant box of dreidels :Modayaal",
            "and then pass out::A",
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
        bg);
        five.center = abyzou;

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
                        SceneManager.LoadScene(2); // Koi-Koi scene
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
