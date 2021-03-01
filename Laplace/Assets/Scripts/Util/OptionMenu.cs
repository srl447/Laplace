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

    private void Awake()
    {
        PullSettings();
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
        if (chosenTypeface == 2)
        {
            foreach (Text t in allText)
            {
                int fontSize = (int)Mathf.Floor( t.fontSize * .8f);
                t.fontSize = fontSize;
            }
        }
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
    }
}
