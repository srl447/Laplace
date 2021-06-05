using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Credits : MonoBehaviour
{
    public Text title, body;
    public AudioClip shma, missYou, paul;
    string[] credits = new string[]
    {
        "A Game By:Tess Leiman",
        "Art:Tess Leiman",
        "Moldy Wall Stock Photo: Inga Seliverstova",
        "Art Tracing and Reference:Louie Mantia's Lotus Hanafuda\n   That asset and falls under CC BY-SA 4.0\n   creativecommons.org/licenses/by-sa/4.0/\n Nintendo's Napolean Deck ",
        "Programming:Tess Leiman",
        "Fonts:Times Newer Roman - MSCHF \n    timesnewerroman.com \nOpen Dyslexic - Abbie Gonzalez \n    opendyslexic.org",
        "Playtesters:Paul Merritt\nLeon Hou\nRonan Le\nSekai Murashige\nAndy Bow\nBecca Leiman\nAnnie Leiman\nSam Green",
        "Playtesters:Matt Soree\nAdam Behar",
        "Alcohol Consultant:Lawrence Xu",
        "Voice Actors:Ronan Le - Modayaal\nPaul Merritt - Furfur\nAnnie Leiman - Abyzou\nRandy Seidler - Azazel\nTess Leiman - Tess",
        "Music:Fishing on a Cliff\n   Randy Seidler\nSh'ma\nperformed by Tess Leiman\nAndante spianato and \n   Grande Polonaise Brillante Op. 22\n   Olga Gurevich performing Chopin",
        "Music:Nocturne in B flat minor, Op. 9 no. 1\n   Olga Gurevich performing Chopin\nNocturne in E flat minor, Op. 9 no. 2\n   Aya Higuchi performing Chopin",
        "Music:Fantaisie - Impromptu, Op. 66\n   Frank Levy performing Chopin\nPeer Gynt Suite no. 1, \n   Op. 46 - I. Morning Mood\n   Musopen Symphony \n   performing Edvard Grieg",
        "Music:Oh How I Miss You Tonight\n   John McCormack performing Benny Davis\nWaltz Op. 8, no. 4\n   Christian Silva Gonçalves performing \n   Agustin Barrios Mangore",
        "Music:Albinoni Adagio de Albinoni\n   The Modena Chamber Orchestra\n   performing Tomaso Albinoni\nTitanic Blues\n   Virginia Liston\nApril Kisses\n   Eddie Lang",
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
        PlayerPrefs.SetInt("Credits Rolled", 1);
        string[] parts  = credits[0].Split(':');
        title.text = parts[0];
        body.text = parts[1];
    }

    // Update is called once per frame
    void Update()
    {
        if(AudioManager.Instance.bgm == shma)
        {
            AudioManager.Instance.audioSource.loop = false;
        }
        if(!AudioManager.Instance.audioSource.isPlaying)
        {
            AudioManager.Instance.ChangeBGM(missYou);
            AudioManager.Instance.audioSource.Play();
            AudioManager.Instance.audioSource.loop = true;
        }
        if(Input.GetKeyDown(KeyCode.P) && Input.GetKeyDown(KeyCode.A) && Input.GetKeyDown(KeyCode.U) && Input.GetKeyDown(KeyCode.L))
        {
            AudioManager.Instance.PlayOneShot(paul);
        }
        count++;
        if(count == 480)
        {
            if (index >= credits.Length - 1)
            {
                Destroy(AudioManager.Instance.gameObject);
                SceneManager.LoadScene(0);
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