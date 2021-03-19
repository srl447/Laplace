using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DreidelController : MonoBehaviour
{
    int modayaalScore, furfurScore, abyzouScore, azazelScore, pot, startingAmount, turn;

    /*
     * Turn Table
     * 
     * 0 - Modayaal
     * 1 - Abyzou
     * 2 - Furfur
     * 3 - Azazel
     */

    public GameObject spinImage, spinButtonObject, eatButtonObject;
    public Image dreidel;
    public Sprite gimmel, hay, nun, shin;
    public Text modayaalText, furfurText, abyzouText, azazelText, potText;
    public AudioClip[] spinNoises;
    public AudioClip dropNoise;

    bool turnHappening = false;

    // Start is called before the first frame update
    void Start()
    {
        startingAmount = 5;
        modayaalScore = startingAmount;
        furfurScore = startingAmount;
        abyzouScore = startingAmount;
        azazelScore = startingAmount;
        pot = startingAmount;

        SetScores();


    }

    // Update is called once per frame
    void Update()
    {
        //others eating
        if(Random.Range(0, 5000) > 4998 && abyzouScore > 0)
        {
            abyzouScore--;
            SetScores();
        }
        else if (Random.Range(0, 4500) > 4498 && furfurScore > 0)
        {
            furfurScore--;
            SetScores();
        }
        else if (Random.Range(0, 10000) > 9998 && azazelScore > 0)
        {
            azazelScore--;
            SetScores();
        }


        //refill the pot
        if (pot == 0)
        {
            if(abyzouScore > 0)
            {
                abyzouScore--;
                pot++;
            }
            if (modayaalScore > 0)
            {
                modayaalScore--;
                pot++;
            }
            if (furfurScore > 0)
            {
                furfurScore--;
                pot++;
            }
            if (azazelScore > 0)
            {
                azazelScore--;
                pot++;
            }
            SetScores();
        }

        //checking for the end and skipping out players
        int outCount = 0;
        switch(turn)
        {
            case 0:
                if(modayaalScore == 0)
                {
                    turn++;
                    outCount++;
                }
                break;
            case 1:
                if (abyzouScore == 0)
                {
                    turn++;
                    outCount++;
                }
                break;
            case 2:
                if (furfurScore == 0)
                {
                    turn++;
                    outCount++;
                }
                break;
            case 3:
                if (azazelScore == 0)
                {
                    turn++;
                    outCount++;
                }
                break;
        }
        if(outCount == 3)
        {
            //TODO: Ending
        }

        //starting next turn
        if(!turnHappening && turn != 0)
        {
            switch(turn)
            {
                case 1:
                    abyzouScore--;
                    break;
                case 2:
                    furfurScore--;
                    break;
                case 3:
                    azazelScore--;
                    break;
            }
            pot++;
            StartCoroutine(Spin());
        }
        else if(!turnHappening && turn == 0)
        {
            spinButtonObject.SetActive(true);
        }


        //Eatting Button
        eatButtonObject.SetActive(modayaalScore >= 1);
    }

    void SetScores()
    {
        modayaalText.text = "Modayaal: " + modayaalScore;
        furfurText.text = "Furfur: " + furfurScore;
        abyzouText.text = "Abyzou: " + abyzouScore;
        azazelText.text = "Azazel: " + azazelScore;
        potText.text = pot + " Gelt";
    }

    //what happens when the player presses the spin button
    public void SpinButton()
    {
        modayaalScore--;
        pot++;
        StartCoroutine(Spin());
        spinButtonObject.SetActive(false);
    }

    public void EatButton()
    {
        modayaalScore--;
        SetScores();
    }

    //generic spin function
    public IEnumerator Spin()
    {
        turnHappening = true;
        SetScores();
        spinImage.SetActive(true);
        RectTransform spinImageRT = spinImage.GetComponent<RectTransform>();
        Vector2 oSize = spinImageRT.sizeDelta;
        float lerpSpeed = .1f;
        spinImageRT.sizeDelta = new Vector2(32, 28);
        AudioManager.Instance.PlayOneShot(spinNoises[Mathf.FloorToInt(Random.Range(0, spinNoises.Length - .0001f))]);
        for (int i = 0; i < 9; i++)
        {
            spinImageRT.sizeDelta = new Vector2(Mathf.Lerp(spinImageRT.sizeDelta.x, oSize.x*1.2f, lerpSpeed), Mathf.Lerp(spinImageRT.sizeDelta.y, oSize.y*1.2f, lerpSpeed));
            yield return new WaitForEndOfFrame();
        }
        for (int i = 0; i < 3; i++)
        {
            spinImageRT.sizeDelta = new Vector2(Mathf.Lerp(spinImageRT.sizeDelta.x, oSize.x, lerpSpeed*2), Mathf.Lerp(spinImageRT.sizeDelta.y, oSize.y, lerpSpeed*2));
            yield return new WaitForEndOfFrame();
        }
        spinImageRT.sizeDelta = oSize;
        yield return new WaitForSecondsRealtime(2.1f);
        int result = Mathf.FloorToInt(Random.Range(0, 3.999999f));
        int modifier = 0; //this changes the scores
        /*
         * Result Table
         *  0 - shin
         *  1 - nun
         *  2 - hay
         *  3 - gimmel
         */
        switch(result)
        {
            case 0:
                dreidel.sprite = shin;
                modifier = -1;
                SetScores();
                break;
            case 1:
                dreidel.sprite = nun;
                break;
            case 2:
                dreidel.sprite = hay;
                modifier = Mathf.CeilToInt(pot / 2);
                break;
            case 3:
                dreidel.sprite = gimmel;
                modifier = pot;
                break;

        }
        spinImage.SetActive(false);
        AudioManager.Instance.PlayOneShot(dropNoise);
        switch (turn)
        {
            case 0:
                modayaalScore += modifier;
                if(modayaalScore < 0) //this is just incase they get shin on their last turn
                {
                    modayaalScore = 0;
                    pot--;
                }
                turn++;
                break;
            case 1:
                abyzouScore += modifier;
                if (abyzouScore < 0)
                {
                    abyzouScore = 0;
                    pot--;
                }
                turn++;
                break;
            case 2:
                furfurScore += modifier;
                if (furfurScore < 0)
                {
                    furfurScore = 0;
                    pot--;
                }
                turn++;
                break;
            case 3:
                azazelScore += modifier;
                if (azazelScore < 0)
                {
                    azazelScore = 0;
                    pot--;
                }
                turn = 0;
                break;
        }
        pot -= modifier;
        SetScores();
        yield return new WaitForSecondsRealtime(1.8f);
        turnHappening = false;


    }


}
