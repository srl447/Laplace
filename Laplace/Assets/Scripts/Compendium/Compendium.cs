using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Compendium : MonoBehaviour
{
    public Text textBox, titleBox;
    public Image image;
    public GameObject menuButton, refButton;
    Dropdown sortDrop;
    float distance;

    Dictionary<string, string> compendiumText = new Dictionary<string, string>();
    Dictionary<string, Sprite> compendiumImage = new Dictionary<string, Sprite>();

    public List<string> buttonValues = new List<string>();
    int buttonCount = 1;

    public Sprite[] allSprites;

    public GameObject buttonContent;

    private void Start()
    {
        sortDrop = GetComponentInChildren<Dropdown>();

        //finds the distance the buttons need to be spaced based on screen size
        distance = refButton.transform.position.y - menuButton.transform.position.y;

        //Loads previous data and creates buttons
        string[] values = PlayerPrefs.GetString("Compendium").Split(':');
        foreach(string s in values)
        {
            if (s != "" && !buttonValues.Contains(s))
            {
                buttonValues.Add(s);
                GameObject newButton = Instantiate(menuButton) as GameObject;
                newButton.transform.SetParent(buttonContent.transform);
                newButton.GetComponentInChildren<Text>().text = s;
                newButton.transform.localScale = new Vector3(1, 1, 1);
                newButton.transform.position = new Vector3(menuButton.transform.position.x, menuButton.transform.position.y - distance * buttonCount,0);
                buttonCount++;
            }
        }
        buttonValues.Add("Laplace's Demon");
        buttonValues.Add("Modayaal");

        //All the entries
        compendiumImage.Add("Laplace's Demon", allSprites[0]);
        compendiumText.Add("Laplace's Demon", 
            "\"We may regard the present state of the universe as the effect of its past and the " +
            "cause of its future. An intellect which at a certain moment would know all forces that " +
            "set nature in motion, and all positions of all items of which nature is composed, if this " +
            "intellect were also vast enough to submit these data to analysis, it would embrace in a " +
            "single formula the movements of the greatest bodies of the universe and those of the " +
            "tiniest atom; for such an intellect nothing would be uncertain and the future just like " +
            "the past would be present before its eyes.\" \n— Pierre Simon Laplace, A Philosophical Essay on Probabilities " +
            "\n \nLaplace's Demon is a articulation of Determinism theory, which basically says you can figure out the entire " +
            "history and future of the universe if you know the location of every atom and all the forces enacting on it. " +
            "Casual determinism was proven incorrect because of the second law of thermodynamics; because some thermodynamic " +
            "properties are irrevesible, Laplace's Demon could not possibly predict the past. \n \nLaplace originally described " +
            "this as an intelligence. I don't know who first called it a demon, but they were a bit of a dick. Demon's have " +
            "sentience, so it kinda sucks to have infinite procesing power and knowledge of the universe." +
            "\n\nPortrait by Johann Ernst Heinsius");

        Select("Laplace's Demon");//loads up something to show to start

        compendiumImage.Add("Modayaal", allSprites[1]);
        compendiumText.Add("Modayaal",
            "They made a deal that gave them infinite brain power and knowledge of all possible realities. " +
            "The trade off was all demons would be trapped in Gehinomm forever and would not be allowed to " +
            "interact with humans and earth ever again. This deal kinda sucks but hey 20/20 hindsight. " +
            "Now, they just drink to stop their brain from functioning at 100% efficiency, so they can try to forget " +
            "all the knowledge in the universe and just enjoy a little randomness in life.");

        compendiumImage.Add("Gehinomm", allSprites[2]);
        compendiumText.Add("Gehinomm",
            "Gehinomm is a waiting room for souls to go after they die. Souls there will be judged based on their sins. " +
            "People are not in Gehinomm forever. Jews don't spend longer than 11 months, and, with exception, " +
            "even the most wicked people won't stay here for more than a year. Souls atone for their sins here, but " +
            "they still get the Sabbath off. \nGehinomm is described as on fire. \nPictured: Valley of Hinomm c. 1900");

        compendiumImage.Add("Blom Blamilton", allSprites[3]);
        compendiumText.Add("Blom Blamilton",
            "Bassist for the band Bombersmith. Furfur is currently taking every single shot Blom has ever had in chronological order. " +
            "He's already up to Bombersmith's tour of their 1987 album Temporary Staycation. The band's next " +
            "tour, Drain, was drug free, so they only drank carrot juice.");

        compendiumImage.Add("Corpse Reviver No. 2", allSprites[4]);
        compendiumText.Add("Corpse Reviver No. 2",
            "Created with gin, freshly squeezed lemon juice, curaçao, some brand name wine, and a bit of absinthe. " +
            "Usually garnished with a lemon or orange slice. Corpse Revivers are a family of cocktail originating in the " +
            "1800s and dranken to cure hangovers." +
            "Apparently four of these quickly will unrevive the corpse, so make 5 just in case.");

        compendiumImage.Add("Furfur", allSprites[5]);
        compendiumText.Add("Furfur",
            "The Earl of Hell, Furfur, he rules 26 legions of spirits according to Arc Goetia in the " +
            "Lesser Keys of Solomon. He's a liar that will only answer truthfully if you enter a pact with him. " +
            "His element is fire despite the fact that he controls thunder, lightning, storms, and hurricanes. He'll " +
            "reveal the secrets of the planet to you if you're loyal. He can cause love between a man and a woman, which, " +
            "not gonna lie, kinda straight. He just kills people he doesn't like, so you don't have to worry about forcibly becoming " +
            "straight at least. He used to zap babies with the straight ray occasionally, which isn't cool. You can summon him on leap " +
            "days, neat. Nowadays, Furfur is much chiller thanks to the realizations removal from Earth brought. ");

        compendiumImage.Add("Furfur's Joke", allSprites[6]);
        compendiumText.Add("Furfur's Joke",
            "\"Amon can't send his condolensces\"" +
            "The joke is that F is a labial fricative.");

        compendiumImage.Add("Amon", allSprites[7]);
        compendiumText.Add("Amon",
            "Amon is the Grand Marquis of Hell according to The Lesser Keys of Solomon. He has a serpent's tail, a wolf's body, and " +
            "a raven's head. He's the strongest of the 72 demons, and genuinely a good guy. He can help stop conflicts of all kinds: " +
            "from friendship spats to fullblown wars. Kinda makes you wish Modayaal made their deal after the 20th century because " +
            "this poor guy can no longer help humans. He can breathe fire, but I'm not sure how this helped solve any conflicts. " +
            "\n\nThis depiction is from the 1863 edition of Dictionnaire Infernal");

        compendiumImage.Add("Bael", allSprites[8]);
        compendiumText.Add("Bael",
            "Bael (Ba'al) means \"Ruler\" in many semetic languages. Many demons have Ba'al prefixes such as Ba'al Berith or Beelzebub. " +
            "Because of this, there's definitely some confusion (at least to me) around exactly who Bael is. They sometimes get lumped " +
            "into another demon, and sometimes they stand alone.\nWell here they're definitely their own person. They might be the only " +
            "demon who likes The Quick and the Curious movies, and they've taken up local politics. They have the power of popularity, " +
            "but they don't even need it. Who wouldn't agree with a spider that has a human, cat, and toad head all at once. They even get " +
            "three votes! They also have the power of invisibility, which seems like the exact opposite of the power of popularity. I'm " +
            "not sure if that's a really good or a really bad combo.\n\nThis depiction is from the 1818 edition of Dictionnaire Infernal");

        compendiumImage.Add("The Quick and the Curious", allSprites[9]);
        compendiumText.Add("The Quick and the Curious",
            "Despite the infinite multiverse that exists, there's only 19 meaninfully distinct Quick and the Curious movies. The fact " +
            "that this contradicts Schrödinger's equation fascinates many of our shedim physicists: much more so than the actual plots of " +
            "any of the films.");

        compendiumImage.Add("Hanafuda", allSprites[10]);
        compendiumText.Add("Hanafuda",
            "Hanafuda (Flower Cards) originated in Japan durinng the Edo period as a result of a ban on gambling and the western playing cards brought " +
            "to Japan by the Portuguese. People could gamble using Hanafuda because the art disguised the true purpose of the cards. " +
            "Whenever authorities caught onto a deck being used for gambling, a new design would take its place cyclically. " +
            "Hana in Hanafuda being a homonym  (or hana-nym eh? eh?) for both Nose and Flower helped keep the gambling a secret, since gamblers could simply " +
            "tap their nose if they wanted to play a game using hanafuda. Hanafuda was legalized after western playing cards became leagilized in 1885 " +
            "and Maeda Kihei realized that Hanafuda wasn't technically illegal anymore. He went on to start the first Hanafuda " +
            "shop after proving his theory that Hanafuda was not illegal. " +
            "\n\nThe inspiration for Hanafuda and many games played with these decks come from picture matching games " +
            "of the Heian period. Kai-ōi was a large inspirtation, which involved matching two half-shells. " +
            "Hana-awase is an early mixture of Portuguese playing cards's suits and Kai-awase, shell matching competitions. " +
            "These decks contained significantly more cards than the later hanafuda ones. " +
            "\n\nMany different regional variants of decks and rules exist, but the most common deck to see is the Hachihachi-bana variant. " +
            "This deck contains 12 suits of 4 cards each. The suits each represent a month of the year and flora found during it. " +
            "\n\nDepicted: 19th Century Designer shells used to play Kai-ōi from the Portland Art Museum ");

        compendiumImage.Add("Koi-Koi", allSprites[11]);
        compendiumText.Add("Koi-Koi",
            "An image matching game played with hanafuda. Koi-Koi means Come On in Japanese, which is a main mechanic of the game. After collecting " +
            "card sets called yaku, players can scream Koi-Koi if they wish to risk their luck and get another. \n\nKoi-koi has just the " +
            "combination of luck and skill that hits Modayaal's sweetspot for enjoying a game, so they tend to play it a lot ");

        compendiumImage.Add("Azazel", allSprites[12]);
        compendiumText.Add("Azazel",
            "Father of all shedim, participant in the scapegoat rite, husband to Namaah, it's Azazel! Every Yom Kippur, two goats " +
            "are prepared. One, a sin offering to Yaweh. The other, sent to the forest for Azazel. There in the forest we meet our " +
            "Azazel. He's a good demon who consumes the sins of all of humanity every Yom Kippur. He fell in love with Namaah, who birthed his children, " +
            "the first shedim. Namaah was human, and thus died millenia ago. Azazel continues living his life in Gehinomm, only wishing " +
            "he could continue participating in the scapegoat rite for humanity. Festering sin is never a good thing.");

        compendiumImage.Add("Abyzou", allSprites[13]);
        compendiumText.Add("Abyzou",
            "Abyzou has the power to make a person unpregnant. She cannot have kids of her own and her emotions bioled for decades like a raging tempest. " +
            "One day she accidentally let her frustration out and vanished a pregnant person's child. In horror and guilt, she ran as long as she could. " +
            "Eventually, King Solomon found her and punished for her crime. He tied her serpant hair to a statue for her to hang in pain. After long enough, " +
            "her hair gave out and she managed to escape. She now has come to terms with not being able to bear children, but still wishes to form a family. She fell in love " +
            "many women on earth, but has never raised children there. Stuck in Gehinomm, she wishes to return to earth to help people who no longer wish to be pregnant, " +
            " similar to performing abortions, and hopes to finally form a family of her own. Unfortunately, it doesn't seem like an escape from Gehinomm will ever come to be. ");

        compendiumImage.Add("Mah-Jongg", allSprites[14]);
        compendiumText.Add("Mah-Jongg",
            "Mah-Jongg is an 19th-Century Chinese game that Jews have long been associated with. The game became popular with Jewish, American Immigrants " +
            "during the early 1900s. Jewish-American women formed the National Mah-Jongg League (NMJL) in 1937 in order to standarize one ruleset to use. " +
            "The game also has another connection because of the many Jewish refugees that sought sanctum in Shanghai during WWII, thanks to " +
            "the sacrifices of Ho Feng-Shan." +
            "\n\nPhoto and Mah-Jongg set from certified Jewish woman and my grandma, Judy Goldwasser ");

        compendiumImage.Add("Fireball Valley", allSprites[15]);
        compendiumText.Add("Fireball Valley",
            "\"Gather all your adventuring friends as you embark to ... Fireball Valley. Every turn each player advances closer to a cave that probably contains treasure " +
            "I don't know no one's ever made it stop asking. What I do know is you're between many active volcanoes. Dodge falling rocks, molten lava, and, of course, fireballs on your " +
            "great trek. Play to see if anyone will make it out alive..\" \n-The Box from Fireball Valley \n\n Fireball Valley is a board game that involves an elaborate board where players have fun " +
            "with plastic and gravity.");

        compendiumImage.Add("Tzaraath", allSprites[16]);
        compendiumText.Add("Tzaraath",
            "Tzaraath are the visual affliction of leprousy. According to the Torah, both houses and clothing can be struck with leprousy. To cure a house of " +
            "leprousy, first you take out the infected parts. If tzaraath remain, the house must be abandoned since a person is better off without a dwelling than live in " +
            "one infected. Many intepret this to potentially be metaphorical, but others assume tzaraath is mold.");

        compendiumImage.Add("Entropy", allSprites[17]);
        compendiumText.Add("Entropy",
            "Entropy in an isolated system can only increase, not decrease. This is because some physics properties are irreversible. Modayaal does know exactly how to reverse every " +
            "physical process, but humans only discover the solution to entropy, on average, in the year 2160.");

        compendiumImage.Add("Dreidel", allSprites[18]);
        compendiumText.Add("Dreidel",
            "During the Seleucid Empire's rule of Judea, Jewish children would use dreidels as a guise for studying Torah. Dreidels looked like simple teetotums to any unsuspecting " +
            "Seleucid guards. Owning a Torah was a capitol offense, so hiding their study was required.");

        compendiumImage.Add("Old Fashioned", allSprites[19]);
        compendiumText.Add("Old Fashioned",
            "An 19th Century cocktail composed of a sugar cube, a dash or two of bitters, and Bourbon or rye whisky and garnished with a cherry, orange slice, or both.");

        compendiumImage.Add("Forneus", allSprites[20]);
        compendiumText.Add("Forneus",
            "In an inverted Tokyo, Decarabia perilessly waited for his friend Forneus. Little did he know, a high schooler had murdered Forneus shortly after his arrival. " +
            "No one in Gehinomm knows what happens to Forneus and little is understood about how the events of that day transpired. Decarabia has since gained acclaim for his play " +
            "Waiting Forneus.");

        compendiumImage.Add("Asmodai", allSprites[21]);
        compendiumText.Add("Asmodai",
            "Asmodai and King Solomon had many misadventures. Asmodai once traded places with King Solomon when they threw Solomon 400 leagues away from Jerusalem. " +
            "When Solomon finally walked back, Asmodai interacted with the locals, played with some bricks, was questioned, and then fled. " +
            "\n\nThis depiction is from the 1863 edition of Dictionnaire Infernal ");

        compendiumImage.Add("Golem", allSprites[22]);
        compendiumText.Add("Golem",
            "A clay man created brought to life through writing emet, meaning truth, into it's forehead. " +
            "It can subsequently be killed by removing the aleph in emet, turning the word into met, meaning dead. " +
            "\nMy last name, Leiman, is the spanish version of Leymman, which translates from Yiddish into clay man. Don't go around erasing my forehead now. " +
            "\n\nDepicted: Hebrew transcription of emet");

        compendiumImage.Add("Dybbuk", allSprites[23]);
        compendiumText.Add("Dybbuk",
            "Possesion spirits that make the men they posses fall in love with women and sometimes men. The cure for one is to talk to a Rabbi, which, I dunno, kinda feels " +
            "like it's the one Jewish joke we always tell. Like the Rabbi will talk so much that the Dybbuk will not want to stay. Don't get me wrong, I love the joke and think it's kinda perfect ");

        compendiumImage.Add("Purim", allSprites[24]);
        compendiumText.Add("Purim",
            "Often known as the Jewish holiday where you put on plays and get drunk, Purim celebrates the victory of the Jews over Haman. Haman, a viceroy to King Ahasuerus of the " +
            "Achaemenid Empire, plotted to kill all the Jews because Mordecai, a Jewish townsman, refused to bow to him. " +
            "Mordecai had earlier bested a reigcide attempt, and the king throws him a banquet. Esther, a candidate for future queen and " +
            "Mordecai's niece, reveals she's Jewish and Haman wants to kill her people, so the king calls off the genicide Haman scheduled and kills Haman. " +
            "After that, they threw a huge feast and party which is why this holiday is known for its festive drinking. Apparently they also then killed 75,000 enemies of the Jews, " +
            "which I guess they left out of my Hebrew school play. " +
            "\n\nDepicted: Esther Megillah from the Minneapolis Institute of Arts");

        compendiumImage.Add("Medically Brunette", allSprites[25]);
        compendiumText.Add("Medically Brunette",
            "One girl, burdened by the lack of stereotypes about her hair color, defies the odds and gets into medical school. She's then forced by circumstance to replace " +
            "the doctor she was shadowing in her residency and perform brain surgery on the spot. Thanks to her deep understanding of hair care, she successfully completes the surgery, " +
            "saving the day.");

        compendiumImage.Add("Groger", allSprites[26]);
        compendiumText.Add("Groger",
            "A jewish toy that makes a grating sound. Children would arm these during Purim reanactment plays and blast noise whenever Haman's name was said " +
            "\n\nDepicted: 20th Century Groger from the Minneapolis Institute of Arts");

        compendiumImage.Add("New Nyce", allSprites[27]);
        compendiumText.Add("New Nyce",
            "Hundreds of years after the fall of New York City, a new New York City rises from its ashes as New NYC. The problem was, no one remembered what NYC stood for. " +
            "After several decades of colloquially reffering to NYC as Nyce, not knowing it was an abbreviation, the city officially changed it's name to New Nyce. New Nyce coincidentally " +
            "also had a plentiful theater scene spanning from productions staring hundreds of actors on stage at once to a one person production " +
            "which lasted 20 years.");

        compendiumImage.Add("Marbles", allSprites[28]);
        compendiumText.Add("Marbles",
            "I just want to apologize. Modayaal claimed Marbles was the cutest dog ever, but I can assure you that your dog is indeed the cutest of all time, not Marbles. ");

        //hides itself to start
        gameObject.SetActive(false);

    }

    public void Update()
    {
        GameManager.Instance.canClick = false;
        if(Input.GetKeyUp(KeyCode.Escape))
        {
            OnClose();
        }
    }
    //lets you add values to this
    public void Add(string newEntry)
    {
        if (!buttonValues.Contains(newEntry))
        {
            buttonValues.Add(newEntry);
            PlayerPrefs.SetString("Compendium", PlayerPrefs.GetString("Compendium") + ":" + newEntry);
            GameObject newButton = Instantiate(menuButton) as GameObject;
            newButton.transform.SetParent(buttonContent.transform);
            newButton.GetComponentInChildren<Text>().text = newEntry;
            newButton.transform.localScale = new Vector3(1, 1, 1);
            newButton.transform.position = new Vector3(menuButton.transform.position.x, menuButton.transform.position.y - distance * buttonCount, 0);
            buttonCount++;
            ChooseSort();
        }
    }

    //to show the correct text
    public void Select(string key)
    {
        textBox.text = compendiumText[key];
        titleBox.text = key;
        image.sprite = compendiumImage[key];
    }

    public void OnClose()
    {
        gameObject.SetActive(false);
        GameManager.Instance.canClick = true;
    }

    //Sorting functions
    public void ChooseSort()
    {
        switch(sortDrop.value)
        {
            case 0:
                OldestSort();
                break;
            case 1:
                NewestSort();
                break;
            case 2:
                AlphabeticalSort();
                break;
        }
    }

    public void AlphabeticalSort()
    {
        Button[] allButtons = GetComponentsInChildren<Button>();
        buttonValues.Sort();
        for(int i = 0; i < allButtons.Length; i++)
        {
            if (allButtons[i].GetComponentInChildren<Text>().text != "Close")
            {
                allButtons[i].GetComponentInChildren<Text>().text = buttonValues[i];
            }
        }

    }

    public void NewestSort()
    {
        Button[] allButtons = GetComponentsInChildren<Button>();
        string[] values = PlayerPrefs.GetString("Compendium").Split(':');
        List<string> tempValues = new List<string>();
        foreach (string s in values)
        {
            if (s != "" && !tempValues.Contains(s))
            {
                tempValues.Add(s);
            }
        }
        for (int i = tempValues.Count - 1, j = 0; i > -1; i--, j++)
        {
            if (allButtons[i].GetComponentInChildren<Text>().text != "Close")
            {
                allButtons[j].GetComponentInChildren<Text>().text = tempValues[i];
            }
            else
            {
                i++;
            }
            
        }
        allButtons[allButtons.Length - 3].GetComponentInChildren<Text>().text = "Modayaal";
        allButtons[allButtons.Length - 2].GetComponentInChildren<Text>().text = "Laplace's Demon";
    }

    public void OldestSort()
    {
        Button[] allButtons = GetComponentsInChildren<Button>();
        string[] values = PlayerPrefs.GetString("Compendium").Split(':');
        List<string> tempValues = new List<string>();
        foreach (string s in values)
        {
            if (s != "" && !tempValues.Contains(s))
            {
                tempValues.Add(s);
            }
        }
        allButtons[0].GetComponentInChildren<Text>().text = "Laplace's Demon";
        allButtons[1].GetComponentInChildren<Text>().text = "Modayaal";
        for (int i = 2, j = 0; j < tempValues.Count; i++, j++)
        {
            if (allButtons[i].GetComponentInChildren<Text>().text != "Close")
            {
                allButtons[i].GetComponentInChildren<Text>().text = tempValues[j];
            }
            else
            {
                j--;
            }
        }
        
        
    }
}
