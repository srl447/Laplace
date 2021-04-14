using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Credits : MonoBehaviour
{
    public Text title, body;
    string[] credits = new string[]
    {
        "A Game By:Tess Leiman",
        "Art:Tess Leiman",
        "Moldy Wall Stock Photo: Inga Seliverstova",
        "Art Tracing and Reference:Louie Mantia's Lotus Hanafuda\n    That asset and falls under CC BY-SA 4.0\n    creativecommons.org/licenses/by-sa/4.0/\n Nintendo's Napolean Deck ",
        "Programming:Tess Leiman",
        "Fonts:Times Newer Roman - MSCHF \n    timesnewerroman.com \nOpen Dyslexic - Abbie Gonzalez \n    opendyslexic.org",
        "Playtesters:Paul Merritt\nLeon Hou\nRonan Le\nSekai Murashige\nAndy Bow\nBecca Leiman\nAnnie Leiman\nSam Green",
        "Alcohol Consultant:Lawrence Xu",
        "Voice Actors:Ronan Le - Modayaal\nPaul Merritt - Furfur\nAnnie Leiman - Abyzou\nTBT - Azazel",
        "FreeSound.Org Sound Clips:Bendir - Xserra\nMarimba - Sassaby\nPour - Megashroom\n Spit Take - Jackfull16\nCard Noises - F4ngy and VKProduktion",
        "Programs:Unity - Game Engine\nKrita - Art Program\nAudacity - Sound Editing",
        "\n\n\n\nAnd You!:",
        "\n\n\n\nThank You For Playing!:"
    };

    int count = 0;
    int index = 0;
    // Start is called before the first frame update
    void Start()
    {
        string[] parts  = credits[0].Split(':');
        title.text = parts[0];
        body.text = parts[1];
    }

    // Update is called once per frame
    void Update()
    {
        count++;
        if(count == 480)
        {
            if (index >= credits.Length - 1)
            {
                SceneManager.LoadScene(0);
                PlayerPrefs.SetInt("Credits Rolled", 1);
            }
            else
            {
                StartCoroutine(TextChange());
            }
        }
        
    }

    IEnumerator TextChange()
    {
        yield return new WaitForEndOfFrame();
        for(int i = 0; i < 30; i++)
        {
            yield return new WaitForEndOfFrame();
            title.color = new Color(1, 1, 1, Mathf.Lerp(title.color.a, 0, .3f));
            body.color = new Color(1, 1, 1, Mathf.Lerp(body.color.a, 0, .3f));
        }
        yield return new WaitForEndOfFrame();
        title.color = Color.clear;
        body.color = Color.clear;
        index++;
        string[] parts = credits[index].Split(':');
        title.text = parts[0];
        body.text = parts[1];
        for (int i = 0; i < 30; i++)
        {
            yield return new WaitForEndOfFrame();
            title.color = new Color(1, 1, 1, Mathf.Lerp(title.color.a, 1, .3f));
            body.color = new Color(1, 1, 1, Mathf.Lerp(body.color.a, 1, .3f));
        }
        yield return new WaitForEndOfFrame();
        title.color = Color.white;
        body.color = Color.white;
        count = 0;

    }
}