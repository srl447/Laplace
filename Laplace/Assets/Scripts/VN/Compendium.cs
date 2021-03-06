using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Compendium : MonoBehaviour
{
    public Text textBox;
    public Image image;
    public GameObject menuButton;

    Dictionary<string, string> compendiumText = new Dictionary<string, string>();
    Dictionary<string, Sprite> compendiumImage = new Dictionary<string, Sprite>();

    List<string> buttonValues = new List<string>();
    int buttonCount = 1;

    public Sprite[] allSprites;

    private void Start()
    {
        //Loads previous data and creates buttons
        string[] values = PlayerPrefs.GetString("Compendium").Split(':');
        foreach(string s in values)
        {
            buttonValues.Add(s);
            GameObject newButton = Instantiate(menuButton) as GameObject;
            newButton.GetComponentInChildren<Text>().text = s;
            newButton.transform.position -= Vector3.up * 40 * buttonCount;
            buttonCount++;
        }

        //All the entries
        compendiumImage.Add("Laplace's Demon", allSprites[0]);
        compendiumText.Add("Laplace's Demon", 
            "We may regard the present state of the universe as the effect of its past and the " +
            "cause of its future. An intellect which at a certain moment would know all forces that " +
            "set nature in motion, and all positions of all items of which nature is composed, if this " +
            "intellect were also vast enough to submit these data to analysis, it would embrace in a " +
            "single formula the movements of the greatest bodies of the universe and those of the " +
            "tiniest atom; for such an intellect nothing would be uncertain and the future just like " +
            "the past would be present before its eyes. \n — Pierre Simon Laplace, A Philosophical Essay on Probabilities" +
            "\n \n Laplace's Demon is a articulation of Determinism theory, which basically says you can figure out the entire" +
            "history and future of the universe if you know the location of every atom and all the forces enacting on it." +
            "Casual determinism was proven incorrect because of the second law of thermodynamics; because some thermodynamic" +
            "properties are irrevesible, Laplace's Demon could not possibly predict the past. \n \n Laplace originally described" +
            "this as an intelligence. I don't know who first called it a demon, but they were a bit of a dick. Demon's have" +
            "sentience, so it kinda sucks to have infinite procesing power and knowledge of the universe.");
    }

    //lets you add values to this
    public void Add(string newEntry)
    {
        buttonValues.Add(newEntry);
        PlayerPrefs.SetString("Compendium", PlayerPrefs.GetString("Compendium") + ":" + newEntry);
        GameObject newButton = Instantiate(menuButton) as GameObject;
        newButton.GetComponentInChildren<Text>().text = newEntry;
        newButton.transform.position -= Vector3.up * 40 * buttonCount;
        buttonCount++;
    }

    //to show the correct text
    public void Select(string key)
    {
        textBox.text = compendiumText[key];
        image.sprite = compendiumImage[key];
    }
}
