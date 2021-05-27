using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PostAbyzouScene : MonoBehaviour
{

    TextControl textC;
    public Compendium comp;
    public Scene one = new Scene(), two = new Scene(), choice = new Scene(), final1 = new Scene(), final2 = new Scene(),
        three = new Scene(), four = new Scene(), four2 = new Scene(), five = new Scene(), six = new Scene(),
        seven = new Scene(), eight = new Scene(), nine = new Scene(), ten = new Scene(),
        eleven = new Scene(), twelve = new Scene(), thirteen = new Scene(), fourteen = new Scene();

    Scene current = new Scene();
    int count = 0;
    public Sprite bg, bg2,
        furfur, furfurH, furfurEww, furfurDis, furfurWow, azazel, azazelF, azazelFlex, abyzou, abyzouTsu, abyzouC;

    public Button choice1, choice2;

    public AudioClip abyForIt, azOkay, azMissDays, abyCouldntHurt, furAlright, modWhatever, modBye;

    void Start()
    {
        //hook up buttons
        choice1.onClick.AddListener(Choice1);
        choice2.onClick.AddListener(Choice2);

        //Note: Put speaker name at the beginning of each scene so there's a speaker name when loading

        one.Set(new string[] 
        {
            "Hey that was actually pretty fun:Abyzou",
            "I'm telling you best gambling game EZ:Modayaal",
            "We should definitely play again sometime:Abyzou",
        },
        bg, two);
        one.center = abyzouC;
        one.sound = abyForIt;

        two.Set(new string[]
        {
            "They make me play every day:Furfur",
            "that's cause you come over for no reason every day:Modayaal",
            "but... ",
            "okay::A"
        },
        bg, three);
        two.left = abyzou;
        two.right = furfurH;

        three.Set(new string[]
        {
            "So where does our adventure take us next:Azazel",
            "I think :Modayaal",
            "I'm done for today::A",
            "this has been like :Furfur",
            "ten times more shit than usual",
            "Ahh :Azazel",
            "I understand::A",
            "I do have an idea tho:Modayaal"
        },
        bg, four);
        three.left = azazelF;
        three.right = furfur;
        three.sound = azOkay;

        four.Set(new string[]
        {
            "which is?:Abyzou",
            "I think I need to take some time alone:Modayaal",
            "to think on things",
            "so to also test out this puppet thing",
            "I think I'm gonna go make a lake filled with fish",
            "and just try fishing",
            "see what happens",
            "I'd be happy to see that work, :Azazel",
            "so maybe another night I could join you."
        },
        bg, four2);
        four.left = abyzou;
        four.right = azazel;
        four.sound = abyCouldntHurt;

        four2.Set(new string[]
        {
            "Fishing was a favorite passtime of mine back in the forest.:Azazel"
        },
        bg, five);
        four2.center = azazelFlex;
        four2.sound = azMissDays;

        five.Set(new string[]
        {
            "So is this goodbye?:Furfur",
            "I think it is:Modayaal"
        },
        bg2, choice);
        five.center = furfurDis;
        five.sound = furAlright;

        choice.Set(new string[]
        {
            "What do I say?:Modayaal::I"
        },
        bg2, choice);

        final1.Set(new string[]
        {
            "bye I guess:Modayaal::N",
            "ugh",
            "hmph",
            "hmmm",
            "guess I'm alone now::I"
        },
        bg2);
        final1.sound = modWhatever;

        final2.Set(new string[]
        {
            "Can't wait to see you all again:Modayaal::N",
            "okay",
            "tomorrow things start anew",
            "hey huh",
            "I guess that closet is gone now",
            "well off I go"
        },
        bg2);
        final2.sound = modBye;

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
        if (auto && textC.waitForInput && current != choice)
        {
            if (autoCount > 240)
            {
                Advance();
                autoCount = 0;
            }
            autoCount++;
        }

        if(current == choice)
        {
            choice1.gameObject.SetActive(true);
            choice2.gameObject.SetActive(true);
        }
        else if (GameManager.Instance.canClick && (Input.GetKeyDown(GameManager.Instance.main) || Input.GetKeyDown(GameManager.Instance.alt)))
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
                SceneManager.LoadScene(8); //Credits Scene
            }
            return;
        }

        Say(current.textBody[count]);
        count++;
    }

    void Choice1()
    {
        current = final1;
        choice1.gameObject.SetActive(false);
        choice2.gameObject.SetActive(false);
        Sync();
    }

    void Choice2()
    {
        current = final2;
        choice1.gameObject.SetActive(false);
        choice2.gameObject.SetActive(false);
        Sync();
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
