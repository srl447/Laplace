using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PostFurfurScene : MonoBehaviour
{
    TextControl textC;
    public Compendium comp;
    public Scene one = new Scene(), two = new Scene(),
        three = new Scene(), four = new Scene(), five = new Scene(), six = new Scene(),
        seven = new Scene(), eight = new Scene(), nine = new Scene(), ten = new Scene(), 
        eleven = new Scene(), twelve = new Scene(), thirteen = new Scene();

    Scene[] sceneProgess;
    Scene current = new Scene();
    int count = 0;
    public Sprite bg, furfur, furfurH, azazel, abyzou;

    // Start is called before the first frame update
    void Start()
    {
        //setup next opponent
        GameManager.Instance.opponent = "Azazel";

        //Note: Put speaker name at the beginning of each scene so there's a speaker name when loading 
        one.Set(new string[]
        {
            "Hey ya know?:Furfur",
            "Why do you always get to go first?"
        },
        bg, two);
        one.center = furfurH;

        two.Set(new string[]
        {
            "Why do you come over every day?:Modayaal",
            "Hey:Furfur",
            "hi???...:Modayaal",
            "Wanna hear a joke?:Furfur",
            "probably not but you're gonna say it anyways"
        }, 
        bg, three);
        two.center = furfur;

        three.Set(new string[]
        {
            "Amon can't send his condolences:Furfur",
            "I have access to infinite knowledge of the universe,:Modayaal",
            "and even I can't comprehend how that's a joke::A",
            "Maybe you should drink less:Furfur",
            "Maybe I should drink more: Modayaal"

        },
        bg, four);
        three.center = furfurH;
        three.compendiumEntry = "Amon";

        four.Set(new string[]
        {
            "Where do you fall on the vote tomorrow?:Furfur",
            "shaddupp:Modayaal",
            "I'm wrenching conversation out of you kicking and screaming bruh:Fufur",
            "It's good for you!",
            "fineee:Modayaal",
            "what are they even voting on?",
            "Whether to put more or less fire around Namaah Theater Square:Furfur",
            "why would I care I don't leave my house:Modayaal"
        },
        bg);
        four.center = furfur;
        four.compendiumEntry = "Furfur's Joke";


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
            yield return new WaitForSecondsRealtime(1);
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

