using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PostDreidelScene : MonoBehaviour
{
    TextControl textC;
    public Compendium comp;
    public Scene one = new Scene(), two = new Scene(), one2 = new Scene(), one02 = new Scene(),
        three = new Scene(), four = new Scene(), five = new Scene(), six = new Scene(),
        seven = new Scene(), eight = new Scene(), nine = new Scene(), ten = new Scene(),
        eleven = new Scene(), twelve = new Scene(), thirteen = new Scene(), fourteen = new Scene(),
        fifteen = new Scene(), sixteen = new Scene(), seventeen = new Scene(), eighteen = new Scene(), eighteen2 = new Scene(),
        nineteen = new Scene();

    Scene current = new Scene();
    int count = 0;
    public Sprite bg, dog1, dog2, dog3,
        furfur, furfurH, furfurEww, furfurDis, furfurWow, azazel, azazelF, azazelFlex, abyzou, abyzouTsu, abyzouSquint;

    public AudioClip spitTake, furFuck, azOkay, azBelieve, furDoing, abyGoWithYou, modDontGet, azMissDays, furOkay, modNotMyProblem, 
        modSuck, modFine, abyWhatsGoingOnHere, furFire, furAyy, modKnowEverything, azFire, abyOh, abyEarth;

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
            "yeah I know...:Modayaal"
        },
        bg, one02);
        one.left = abyzou;
        one.right = furfur;
        one.sound = furFuck;

        one02.Set(new string[] {
            "Just go beg Yaweh to let us back:Abyzou",
            "like do everything you can to revert this situation",
            "I have begged and pleaded:Modayaal",
            "I think the earth doesn't want us",
            "or maybe isn't prepared for us",
            "I think people have long forgot about the good we can do",
            "Also so many of us really do love it here:Furfur",
            "we couldn't get to Gehinomm before and it's kinda a utopia",
            "infinite space and resources and it's filled with fire!",
            "I mean, "
        },
        bg, one2);
        one02.left = abyzouSquint;
        one02.right = furfurDis;
        one02.sound = abyEarth;

        one2.Set(new string[]
        {
            "The dybbuk won't stop going on about ::A",
            "how happy they are never hearing about a Rabbi's daughter again",
            "here is just so much better for so many people",
            "yeah but I love that dang humanity so much:Abyzou",
            "If I could just open up a clinic and help those who need me",
            "I feel like it's my purpose",
            "here anyone can just have kids or not at will",
            "so I feel like I'm worthless"
        },
        bg, two);
        one2.left = abyzouTsu;
        one2.right = furfurH;
        one2.compendiumEntry = "Dybbuk";

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
            "it's probably better without the pugnent sin that used to emanate from me ::A",
            "just look for the bright side",
            "that's not so easy:Abyzou",
            "you can say that again:Modayaal",
            "Things will only get better for you both:Azazel",
            "Now that you're starting to come out of your shell Modayaal",
            "I'm sure you'll start to see how much people actually like it here",
            "and Abyzou",
            "There's tons of great women out there",
            "you can still fall in love here",
            "it doesn't have to be on earth ::A",
            "yeah but:Abyzou",
            "yeah",
            "yeah:Modayaal",
            "being around eachother is call of celebration :Azazel",
            "not moping::A"
        },
        bg, three);
        two.left = abyzouTsu;
        two.right = azazel;
        two.sound = azOkay;

        three.Set(new string[] 
        {
            "I believe in all of you!:Azazel"
        },
        bg, four);
        three.left = abyzou;
        three.right = azazelFlex;
        three.sound = azBelieve;

        four.Set(new string[]
        {
            "You know Modey:Furfur",
            "we just gotta figure out what you wanna do",
            "brainstorm sesh",
            "What about Abyzou?:Azazel",
            "I mean she and I can hit up the clubs later:Furfur"
        },
        bg, five);
        four.left = azazelF;
        four.right = furfur;
        four.sound = furDoing;

        five.Set(new string[]
        {
            "and you think I'd want to go with you:Abyzou",
            "owch!:Furfur"
        },
        bg, six);
        five.left = abyzou;
        five.right = furfurWow;
        five.sound = abyGoWithYou;

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
            "you also don't know the outcome of socializing with people!:Furfur",
            "There's tons of stuff around that people put on:Azazel"
        },
        bg, seven);
        six.left = azazelF;
        six.right = furfur;
        six.sound = modDontGet;

        seven.Set(new string[]
        {
            "The annual Purim reanactment is coming up:Azazel",
            "I don't know if that's quiet for me:Modayaal"
        },
        bg, eight);
        seven.left = azazelFlex;
        seven.right = furfur;
        seven.compendiumEntry = "Purim";
        seven.sound = azMissDays;

        eight.Set(new string[]
        {
            "What about like running a library:Furfur",
            "You can make every single book ever",
            "I mean that would only take an instance:Modayaal",
            "Librarians do a lot more than just know books Modey:Furfur",
            "Have you ever tried making, like, a pet?:Abyzou",
            "Aby you know we can't make life:Furfur",
            "don't call me Aby:Abyzou"
        },
        bg, nine);
        eight.left = abyzou;
        eight.right = furfurH;
        eight.sound = furOkay;

        nine.Set(new string[]
        {
            "but yeah the life we makes aren't even close to the worst golem attempts:Modayaal",
            "Modayaal your house is alive:Abyzou",
            "and?:Modayaal",
            "I don't think anyone else's is:Abyzou",
        },
        bg, ten);
        nine.center = abyzou;
        nine.compendiumEntry = "Golem";
        nine.sound = modNotMyProblem;

        ten.Set(new string[]
        {
            "I think I saw Asmodai's house run away once:Furfur",
            "what?:Abyzou",
            "fuck iunno:Furfur",
            "well I don't want my house to be alive:Modayaal",
            "it just is",
            "Well still why don't you try making a dog:Abyzou",
            "couldn't hurt",
            "fine:Modayaal"
        },
        bg, eleven);
        ten.left = abyzou;
        ten.right = furfurDis;
        ten.compendiumEntry = "Asmodai";
        ten.sound = modSuck;

        eleven.Set(new string[]
        {
            "there ya go:Modayaal",
            "well it's certainly animate:Furfur",
            "what is it doing though:Azazel",
            "well :Modayaal",
            "I think it's just playing through what happened ::A",
            "from the moment I referenced to summon it",
            "Wait this is a specific dog?:Furfur",
            "Yeah the objectively cutest dog ever:Modyaaal",
            "Marbles who Granny Lake cared for in 2201",
            "well now what do we do with it it's just trying to eat the air:Furfur"
        },
        bg, twelve);
        eleven.left = azazel;
        eleven.right = furfur;
        eleven.mini = dog1;
        eleven.sound = modFine;

        twelve.Set(new string[]
        {
            "yeah it's kinda creeping me out:Abyzou",
            "I really don't want to think about it anymore:Modayaal",
            "like is it real is it fake?",
            "aaa"
        },
        bg, thirteen);
        twelve.left = abyzou;
        twelve.right = furfur;
        twelve.mini = dog2;
        twelve.compendiumEntry = "Marbles";
        twelve.sound = abyWhatsGoingOnHere;

        thirteen.Set(new string[]
        {
            "*pumf*:The Dog::I",
            "what???:Furfur",
            "aaa:Modayaal",
            "why did it turn into confetti:Azazel",
            "I just wanted it gone:Modayaal"

        },
        bg, fourteen);
        thirteen.left = azazel;
        thirteen.right = furfur;
        thirteen.mini = dog3;

        fourteen.Set(new string[]
        {
            "so like your brain powered it?:Furfur",
            "bruh you're a computer",
            "I mean no:Modayaal",
            "this is great though:Furfur",
            "you can just run the whole Purim reenactment yourself",
            "I think that takes the fun out of it:Azazel",
        },
        bg, fifteen);
        fourteen.left = azazel;
        fourteen.right = furfur;
        fourteen.sound = furFire;

        fifteen.Set(new string[]
        {
             "I dunno bro I wanna groger confetti Haman:Furfur",
             "well I'm sure if Modayaal wants we can do both:Azazel",
             "but Purim's the one time I get to shitfaced:Modayaal",
             "I didn't know today was Purim:Furfur",
             "and yesterday",
             "and the day before that",
             "we get it your funny:Modayaal",
             "although honestly that gives me an idea",
             "cause I was thinking a lot of theater has been lost since I can't really recreate it",
             "maybe that's an avenue I can explore"
        },
        bg, sixteen);
        fifteen.left = azazel;
        fifteen.right = furfur;
        fifteen.compendiumEntry = "Groger";
        fifteen.sound = furAyy;

        sixteen.Set(new string[]
        {
            "Finally I get to see Medically Brunette as it was intended:Furfur",
            "so as a movie?:Modayaal",
            "it has the soul of theater even in the film:Furfur",
            "You can show us future theater then too right?:Abyzou",
            "yeah actually one of my favorite times in theater is the 2500s postprepostpostism movement"
        },
        bg, seventeen);
        sixteen.left = abyzou;
        sixteen.right = furfur;
        sixteen.compendiumEntry = "Medically Brunette";
        sixteen.sound = furFire;

        seventeen.Set(new string[]
        {
            "I could set up a replica of the New Nyce Grand Community Theater:Modayaal",
            "and then just run plays",
            "if this really works how we think it does",
            "I mean there's literal no harm in trying",
            "we can just cast away anything you don't need:Furfur",
            "or better yet"
        },
        bg, eighteen);
        seventeen.center = furfur;
        seventeen.compendiumEntry = "New Nyce";
        seventeen.sound = modKnowEverything;

        eighteen.Set(new string[]
        {
            "we can set it on fire!:Furfur",
        },
        bg, eighteen2);
        eighteen.left = azazelF;
        eighteen.right = furfurH;
        eighteen.sound = furFire;

        eighteen2.Set(new string[]
        {
            "I do like fire:Azazel",
            "Should we head out right now?:Furfur",
            "I think I've done a lot today:Modayaal",
            "baby steps right?",
            "but I think I'd be ready to give it a try tomorrow?",
            "Sounds like a plan to me:Furfur",
            "There's no harm in going at your own pace:Azazel",
            "So what did y'all want to do with the rest of today?:Furfur",
            "play Dreidel again?"
        },
        bg, nineteen);
        eighteen2.left = azazelF;
        eighteen2.right = furfurH;
        eighteen2.sound = azFire;

        nineteen.Set(new string[]
        {
            "I think I'm gelted out:Abyzou",
            "but I think I'm the only one",
            "who didn't get to play Koi-Koi",
            "eyy?:Furfur",
            "Abyzou's got a soft spot now?",
            "willing to play games?",
            "shut up:Abyzou",
            "that's what I'm sayinnnn:Modayaal",
            "but hey",
            "ummm",
            "let's play"
        });
        nineteen.left = abyzou;
        nineteen.sound = abyOh;

        

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
