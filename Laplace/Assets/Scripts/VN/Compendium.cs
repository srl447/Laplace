using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Compendium : MonoBehaviour
{
    public Text textBox;
    public Image image;
    public GameObject menuButton;

    public Dictionary<string, string> compendiumText = new Dictionary<string, string>();
    public Dictionary<string, Sprite> compendiumImage = new Dictionary<string, Sprite>();

    List<string> buttonValues = new List<string>();

    //creates all the buttons for entries already collected
    private void Start()
    {
        string[] values = PlayerPrefs.GetString("Compendium").Split(':');
        foreach(string s in values)
        {
            buttonValues.Add(s);
            GameObject newButton = Instantiate(menuButton) as GameObject;
            newButton.GetComponentInChildren<Text>().text = s;
            newButton.transform.position -= Vector3.up * 40;
        }
    }

    //lets you add values to this
    public void Add(string newEntry)
    {
        buttonValues.Add(newEntry);
        PlayerPrefs.SetString("Compendium", PlayerPrefs.GetString("Compendium") + ":" + newEntry);
    }

    //to show the correct text
    public void Select(string key)
    {
        textBox.text = compendiumText[key];
        image.sprite = compendiumImage[key];
    }
}
