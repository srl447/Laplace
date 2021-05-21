using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PostFurfurScene : MonoBehaviour
{
    TextControl textC;
    public Compendium comp;
    public Scene one = new Scene(), two = new Scene(), three2 = new Scene(),
        three = new Scene(), four = new Scene(), five = new Scene(), six = new Scene(), sixteen2 = new Scene(),
        seven = new Scene(), eight = new Scene(), nine = new Scene(), ten = new Scene(), ten2 = new Scene(),
        eleven = new Scene(), twelve = new Scene(), thirteen = new Scene(), fourteen = new Scene(),
        fifteen = new Scene(), sixteen = new Scene(), seventeen = new Scene(), eighteen = new Scene(),
        nineteen = new Scene(), twenty = new Scene(), twentyone = new Scene(), twentytwo = new Scene(),
        twentyThree = new Scene(), twentyFour = new Scene(), twentyFive = new Scene(), twentySix = new Scene(),
        twentySeven = new Scene(), twentyEight = new Scene(), twentyNine = new Scene(), thirty = new Scene(),
        thirtyOne = new Scene(), thirtyTwo = new Scene(), thirtyThree = new Scene(), thirtyFour = new Scene(),
        thirtyFive = new Scene(), thirtyFive2 = new Scene(), thirtySix = new Scene(), thirtySeven = new Scene(), thirtyEight = new Scene();

    Scene current = new Scene();
    int count = 0;
    public Sprite bg, bg2, furfur, furfurH, furfurEww, furfurDis, furfurWow, azazel, azazelF, abyzou, abyzouTsu,
        counter, iceCream1, iceCream2, iceCream3, door;

    public AudioClip knock, pour, abyHmph, azGreetings, abyDreidel, azSuppose, furJoke, furHey, furNice, 
        modEverything, modDrink, furFire, modBored, furfurBest, furBelieve;

    // Start is called before the first frame update
    void Start()
    {
        //setup next opponent
        GameManager.Instance.opponent = "Azazel";

        //Note: Put speaker name at the beginning of each scene so there's a speaker name when loading 
        one.Set(new string[]
        {
            "Hey ya know?:Furfur",
            "Why do you always get to go first?",
            "Why do you come over every day?:Modayaal"
        },
        bg, two);
        one.center = furfurH;
        one.sound = furHey;

        two.Set(new string[]
        {
            "You know the reasonn:Furfur",
            ";)",
            "Hey! :Furfur",
            "Hey!::A",
            "hi???...:Modayaal",
            "Wanna hear a joke?:Furfur",
            "probably not but you're gonna say it anyways:Modayaal"
        },
        bg, three);
        two.center = furfur;
        two.sound = furNice;


        three.Set(new string[]
        {
            "Amon can't send his condolences:Furfur",
            "I have access to infinite knowledge of the universe, :Modayaal",
        },
        bg, three2);
        three.center = furfurH;
        three.compendiumEntry = "Amon";
        three.sound = furJoke;

        three2.Set(new string[]
        {
            "and even I can't comprehend how that's a joke:Modayaal:A",
            "Maybe you should drink less:Furfur"
        },
        bg, four);
        three2.center = furfurWow;
        three2.compendiumEntry = "Furfur's Joke";
        three2.sound = modEverything;

        four.Set(new string[]
        {
            "Maybe I should drink more:Modayaal",
            "Where do you fall on the vote tomorrow?:Furfur",
            "shaddupp:Modayaal",
            "I'm wrenching conversation out of you kicking and screaming bruh:Furfur",
            "It's good for you!",
            "fineee:Modayaal",
            "what are they even voting on?",
            "Whether to put more or less fire around Namaah Theater Square:Furfur",
            "why would I care I don't leave my house:Modayaal"
        },
        bg, five);
        four.center = furfur;
        four.sound = modDrink;

        five.Set(new string[]
        {
            "Who doesn't love more fire?:Furfur",
            "Less fire more fire :Modayaal",
            "it's all the same::A"
        },
        bg, six);
        five.center = furfurH;
        five.sound = furFire;

        six.Set(new string[]
        {
            "It gives us a reason to go out and talk.:Furfur",
            "It's all in good fun!"
        },
        bg, seven);
        six.center = furfur;

        seven.Set(new string[]
        {
            "I don't even remember what fun is:Modayaal",
            "It's been over 200 years after all:::I",
            "So you're telling me we keep playing Koi-Koi for nothinggg:Furfur::N",
            "no we play it cause it's better than nothing:Modayaal",
            "I know, I know, :Furfur",
            "I'm just being ::A"
        },
        bg, eight);
        seven.center = furfurDis;
        seven.sound = modBored;

        eight.Set(new string[]
        {
            "coy:Furfur:A",
            "shaddUPPP:Modayaal"
        },
        bg, nine);
        eight.center = furfurH;

        nine.Set(new string[]
        {
            "If you wanna talk we can talk:Furfur",
            "I can stop joking",
            "for a bit at least ::A",
            "ugh Idunno :Modayaal",
            "it's just:Modayaal",
            "How did you stop feeling horrible ",
            "about the bad things you've done?::A",
            "Well all the people I've killed would've died ten times over by now:Furfur"
        },
        bg, ten);
        nine.center = furfur;

        ten.Set(new string[]
        {
            "that helps:Furfur",
            "I still did those terrible things, but ",
            "I don't do them anymore::A",
            "that doesn't make it okay",
            ", but it's all I can do really::A",
            "I can't just change the past to not have murder people or zapped some babies"
        },
        bg, ten2);
        ten.center = furfurDis;

        ten2.Set(new string[]
        {
            "I just do my best to do good as I can now",
            "Just hanging out and helping around Gehinomm",
            "I think makes me",
            ", at least::A"
        },
        bg, eleven);
        ten2.center = furfurDis;
        ten2.sound = furfurBest;

        eleven.Set(new string[]
        {
            ", feel like I'm doing better:Furfur:A",
            "I can't do that everyone hates me here:Modayaal",
            "Oh nobody hates you here Modey:Furfur",
            "you trucked up big, but tons of us have",
            "it's not all bad, and we all make the most of it",
            "iunno:Modayaal"
        },
        bg, twelve);
        eleven.center = furfur;

        twelve.Set(new string[]
        {
            "There's no rush:Furfur",
            "no one's dying anytime soon"
        },
        bg, thirteen);
        twelve.center = furfurH;

        thirteen.Set(new string[]
        {
            ", probably.:Furfur:A",
            "!!:Modayaal",
            "okay okay:Furfur"
        },
        bg, fourteen);
        thirteen.center = furfurDis;

        fourteen.Set(new string[]
        {
            "You want ice cream buddy?:Furfur",
            "I can make Bourban flavored"
        },
        bg, fifteen);
        fourteen.center = furfurH;

        fifteen.Set(new string[]
        {
            "I'll make you a deal:Modayaal",
            "Just make vanilla but mix it with the Bourban I got",
            "and you gotta have some to",
        },
        bg, sixteen);
        fifteen.center = furfur;

        sixteen.Set(new string[]
        {
            "oh I am inSULTED:Furfur"
        },
        bg, sixteen2);
        sixteen.center = furfurWow;

        sixteen2.Set(new string[]
        {
            "That you'd think I'd ever pass up a chance to eat ice cream:Furfur",
            "and I'd never pass up more booze:Modayaal",
            "my heads pounding like big:::I",
        },
        bg, seventeen);
        sixteen2.center = furfurH;

        seventeen.Set(new string[]
        {
            "okay so :Furfur::N"
        },
        bg, eighteen);
        seventeen.mini = counter;

        eighteen.Set(new string[]
        {
            "this:Furfur:A"
        },
        bg, nineteen);
        eighteen.mini = iceCream1;

        nineteen.Set(new string[]
        {
            "and I add this:Furfur",
            "aaaaaaand ",
        },
        bg, twenty);
        nineteen.mini = iceCream2;
        nineteen.sound = pour;

        twenty.Set(new string[]
        {
            "done:Furfur:A",
            "Bourban ice cream for you and some for me",
            "So you make bubbles when conjuring now?:Modayaal",
            "I like to mix it up:Furfur",
            "maybe now you'll make bubbles instead too!"
        },
        bg, twentyone);
        twenty.mini = iceCream3;

        twentyone.Set(new string[]
        {
            "well hopefully this'll make knowing everything at once bearable:Modayaal",
            "or else I'll need to get more ethanol",
            "okay",
            "what should I do?",
            "about what?:Furfur",
            "like helping people?:Modayaal",
            "well there's lots of ways:Furfur",
            "maybe you can start by making that movie for Bael "
        },
        bg, twentytwo);
        twentyone.center = furfur;

        twentytwo.Set(new string[]
        {
            "even if it doesn't exist :Furfur:A",
            "but I don't like themmmm:Modayaal",
            "you could just make one you like!:Furfur",
            "find the way to help without making you live in even more pain",
        },
        bg, twentyThree);
        twentytwo.center = furfurH;

        twentyThree.Set(new string[]
        {
            "Also just take today seriously:Furfur",
            "I mean it that I think it's good that you actually talk to Azazel and Abyzou",
            "what do I do?:Modayaal",
            "just be your usual self:Furfur"
        },
        bg, twentyFour);
        twentyThree.center = furfur;

        twentyFour.Set(new string[]
        {
            "the one you try and hide under that tough exterior:Furfur",
            "the one who says yes to ice cream"
        },
        bg, twentyFive);
        twentyFour.center = furfurH;

        twentyFive.Set(new string[]
        {
            "be welcoming and actually listen to their troubles:Furfur",
            "play games with them because it's fun to play games",
            ", not just because you're bored::A",
            "if you can actually help them",
            ", then help them::A",
            "you're the only person who can create litterally anything",
            "I think you can do more than you think"
        },
        bg, twentySix);
        twentyFive.center = furfur;

        twentySix.Set(new string[]
        {
            "I can't imagine the massive crisis knowing everything brought you:Furfur",
            "or just how much that hurts"
        },
        bg, twentySeven);
        twentySix.center = furfurDis;

        twentySeven.Set(new string[]
        {
            "but I do know that I believe in you:Furfur",
            "I'm here everyday because I know you're worth it",
            "and can make Gehinomm better for everyone"
        },
        bg, twentyEight);
        twentySeven.center = furfurH;
        twentySeven.sound = furBelieve;

        twentyEight.Set(new string[]
        {
            "You're cute you know that:Modayaal"
        },
        bg, twentyNine);
        twentyEight.center = furfurWow;

        twentyNine.Set(new string[]
        {
            "Fuck yeah buddy:Furfur",
            "When are Azazel and Abyzou getting here?:Modayaal",
            "Oh I'd say:Furfur"
        },
        bg, thirty);
        twentyNine.center = furfurH;

        thirty.Set(new string[]
        {
            "*KNOCK*:The Door::I"
        },
        bg2, thirtyOne);
        thirty.mini = door;
        thirty.sound = knock;

        thirtyOne.Set(new string[]
        {
            "now:Furfur::N",
        },
        bg, thirtyTwo);
        thirtyOne.center = furfurH;

        thirtyTwo.Set(new string[]
        {
            "Greetings!:Azazel"
        },
        bg2, thirtyThree);
        thirtyTwo.center = azazelF;
        thirtyTwo.compendiumEntry = "Azazel";
        thirtyTwo.sound = azGreetings;

        thirtyThree.Set(new string[]
        {
            "hmph:Abyzou"
        },
        bg2, thirtyFour);
        thirtyThree.left = abyzou;
        thirtyThree.right = azazel;
        thirtyThree.compendiumEntry = "Abyzou";
        thirtyThree.sound = abyHmph;

        thirtyFour.Set(new string[]
        {
            "Hello hello hello!:Furfur",
            "      hi:Modayaal",
            "I'm glad y'all found your way here fine:Furfur",
            "does anyone want a drink?:Modayaal"
        },
        bg2, thirtyFive);
        thirtyFour.left = abyzou;
        thirtyFour.right = furfurH;

        thirtyFive.Set(new string[]
        {
            "Oh I can just conjur anything myself:Azazel",
            "I pregamed before I got here:Abyzou",
            "Well I hate newly conjured alcohol:Modayaal",
            "so I got a lot of aged stuff if you ever want",
            "Maybe I'll take you up on that in a bit:Azazel",
            "well do you want to play Koi-Koi?:Modayaal",
            "Why would I ever want to do that?:Abyzou",
        },
        bg2, thirtyFive2);
        thirtyFive.left = abyzou;
        thirtyFive.right = azazel;

        thirtyFive2.Set(new string[]
        {
            "We can play dreidel:Abyzou"
        },
        bg2, thirtySix);
        thirtyFive2.center = abyzouTsu;
        thirtyFive2.sound = abyDreidel;

        thirtySix.Set(new string[]
        {
            "Well Koi-Koi is basically the only thing we ever do:Furfur",
            "and the Hanafuda's already out:Modayaal",
            "but you'd be happy to set up anything right...:Furfur",
            "oh:Modayaal",
            " ... of course::A"
        },
        bg, thirtySeven);
        thirtySix.left = abyzou;
        thirtySix.right = furfur;
        thirtySix.compendiumEntry = "Hanafuda";

        thirtySeven.Set(new string[]
        {
            "Actually :Azazel",
            "I'd like to try Koi-Koi::A",
            "I've never played before",
            "How do you play?"       
        },
        bg, thirtyEight);
        thirtySeven.left = azazelF;
        thirtySeven.right = furfur;
        thirtySeven.sound = azSuppose;

        thirtyEight.Set(new string[]
        {
            "It's kinda like a mix of Mah-Jongg and Go Fish:Modayaal",
            "if that makes sense",
            "well I suppose there's no better way to learn than by playing:Azazel",
            "and no better way to start than by starting"
        },
        bg);
        thirtyEight.compendiumEntry = "Mah-Jongg";
        thirtyEight.left = azazelF;
        thirtyEight.right = furfur;

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

