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
            "days, neat.");

        compendiumImage.Add("Furfur's Joke", allSprites[6]);
        compendiumText.Add("Furfur's Joke",
            "The joke is that F is a labial fricative");

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
