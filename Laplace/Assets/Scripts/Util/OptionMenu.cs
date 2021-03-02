using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionMenu : MonoBehaviour
{
    public Text[] textToUpdate;
    public Slider fontSlider;

    public Font[] typefaces;
    public Dropdown typefaceDropdown;

    public Toggle colorToggle;

    private void Awake()
    {
        PullSettings();
    }

    private void Update()
    {
        GameManager.Instance.canClick = false;
    }
    public void UpdateFonts()
    {
        int fontSize = (int) fontSlider.value;
        PlayerPrefs.SetInt("Font Size", fontSize);
        foreach(Text t in textToUpdate)
        {
            t.fontSize = fontSize;
        }
        
    }

    public void UpdateTypeface()
    {
        Text[] allText = FindObjectsOfType<Text>();
        int chosenTypeface = typefaceDropdown.value;
        //Open Dyslexic is much bigger, so I need to shrink it
        if (chosenTypeface == 2)
        {
            foreach (Text t in allText)
            {
                int fontSize = (int)Mathf.Floor( t.fontSize * .8f);
                t.fontSize = fontSize;
            }
        }
        //this checks if it used to be Open Dyslexic, so I readjust the size if needed
        else if (PlayerPrefs.GetInt("Typeface") == 2)
        {
            foreach (Text t in allText)
            {
                int fontSize = (int)Mathf.Floor(t.fontSize * 1.25f);
                t.fontSize = fontSize;
            }
        }
        foreach (Text t in allText)
        {
            t.font = typefaces[chosenTypeface];
        }
        PlayerPrefs.SetInt("Typeface", chosenTypeface);
    }

    public void PullSettings()
    {
        fontSlider.value = PlayerPrefs.GetInt("Font Size");
        typefaceDropdown.value = PlayerPrefs.GetInt("Typeface");
        colorToggle.isOn = PlayerPrefs.GetInt("Text Color") == 1;
    }

    public void SetCanClick()
    {
        GameManager.Instance.canClick = true;
    }

    public void TextColorBool()
    {
        if(colorToggle.isOn)
        {
            PlayerPrefs.SetInt("Text Color", 1);
        }
        else
        {
            PlayerPrefs.SetInt("Text Color", 0);
        }
    }
}
