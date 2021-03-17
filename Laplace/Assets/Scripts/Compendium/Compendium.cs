using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Compendium : MonoBehaviour
{
    public Text textBox, titleBox;
    public Image image;
    public GameObject menuButton, refButton;
    float distance;

    Dictionary<string, string> compendiumText = new Dictionary<string, string>();
    Dictionary<string, Sprite> compendiumImage = new Dictionary<string, Sprite>();

    public List<string> buttonValues = new List<string>();
    int buttonCount = 1;

    public Sprite[] allSprites;

    public GameObject buttonContent;

    private void Start()
    {

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
            "Bassist for the band Bombersmith. Furfur is currently taking every single shot he's ever had. " +
            "He's already up to Bombersmith's tour of their 1987 album Temporary Staycation. The band's next " +
            "tour, Drain, was drug free, so they only drank carrot juice.");

        compendiumImage.Add("Corpse Reviver No. 2", allSprites[4]);
        compendiumText.Add("Corpse Reviver No. 2",
            "Created with gin, freshly squeezed lemon juice, curaçao, some brand name wine, and a bit of absinthe. " +
            "Usually garnished with a lemon or orange slice. Corpse Revivers are a family of cocktail originating in the " +
            "1800s and dranken to cure hangovers." +
            "Apparently four of these quickly will unrevive the corpse, so make 5 just in case");

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
            "The joke is that F is a labial fricative.");

        compendiumImage.Add("Amon", allSprites[7]);
        compendiumText.Add("Amon",
            "Amon is the Grand Marquis of Hell according to The Lesser Keys of Solomon. He has a serpent's tail, a wolf's body, and " +
            "a raven's head. He's the strongest of the 72 demons, and genuinely a good guy. He can help stop conflicts of all kinds: " +
            "from friendship spats to fullblown wars. Kinda makes you wish Modayaal made their deal after the 20th century because " +
            "this poor guy can no longer help humans. He can breathe fire, but I'm not sure how this helped solve any conflicts." +
            "\n\nThis depiction is from the 1863 edition of Dictionnaire Infernal");

        compendiumImage.Add("Bael", allSprites[8]);
        compendiumText.Add("Bael",
            "Bael (Ba'al) means \"Ruler\" in many semetic languages. Many demons have Ba'al prefixes such as Ba'al Berith or Beelzebub. " +
            "Because of this, there's definitely some confusion (at least to me) around exactly who Bael is. They sometimes get lumped " +
            "into another demon, and sometimes they stand alone.\nWell here they're definitely they're own person. They might be the only " +
            "demon who likes the Quick and the Curious movies, and they've taken up local politics. They have the power of popularity, " +
            "but they don't even need it. Who wouldn't agree with a spider that has a human, cat, and toad head all at once. They even get " +
            "three votes! They also have the power of invisibility, which seems like the exact opposite of the power of popularity. I'm " +
            "not sure if that's a really good, or a really bad combo.\n\nThis depiction is from the 1818 edition of Dictionnaire Infernal");

        compendiumImage.Add("The Quick and the Curious", allSprites[9]);
        compendiumText.Add("The Quick and the Curious",
            "Despite the infinite multiverse that exists, there's only 19 meaninfully distinct Quick and the Curious movies. The fact " +
            "that this contradicts Schrödinger equation fascinates many of our shedim physicists: much more so than the actual plots of " +
            "any of the films.");

        compendiumImage.Add("Hanafuda", allSprites[10]);
        compendiumText.Add("Hanafuda",
            "Hanafuda (Flower Cards) originated in Japan durinng the Edo period as a result of a ban on gambling and the western playing cards brought " +
            "to Japan by the Portuguese. People could gamble using Hanafuda because the art disguised the true purpose of the cards. " +
            "Whenever authorities caught onto a deck being used for gambling, a new design would take its place cyclically. " +
            "Hana in Hanafuda being a homonym  (or hana-nym eh? eh?) for both Nose and Flower helped keep the gambling a secret, since gamblers could simply" +
            "tap their nose if they wanted to play a game using hanafuda. Hanafuda was legalized after western playing cards became leagilized in 1885 " +
            "and Maeda Kihei realized that Hanafuda wasn't technically illegal anymore. He went on to start the first Hanafuda " +
            "shop after proving his theory that Hanafuda was not illegal. " +
            "\n\nThe inspiration for Hanafuda and many games played with these decks come from picture matching games " +
            "of the Heian period. Kai-ōi was a large inspirtation, which involved matching two half-shells. " +
            "Hana-awase is an early mixture of Portuguese playing cards's suits and Kai-awase, shell matching competitions. " +
            "These decks contained significantly more cards than the later hanafuda ones. " +
            "\n\nMany different regional variants of decks and rules exist, but the most common deck to see is the Hachihachi-bana variant. " +
            "This deck contains 12 suits of 4 cards each. The suits each represent a month of the year and flora found during it." +
            "\n\nDepicted: 18th Century Designer shells used to play Kai-ōi from the Portland Art Museum");

        compendiumImage.Add("Koi-Koi", allSprites[11]);
        compendiumText.Add("Koi-Koi",
            "An image matching game played with hanafuda. Koi-Koi means Come On in Japanese, which is a main mechanic of the game. After collecting " +
            "card sets called yaku, players can scream Koi-Koi if they wish to risk their luck and get another. \n\nKoi-koi has just the " +
            "combination of luck and skill that hits Modayaal's sweetspot for enjoying a game, so they tend to play it a lot");

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
}
