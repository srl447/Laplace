using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RulesUI : MonoBehaviour
{
    public Sprite[] winImages;
    public GameObject left, right;
    public Text pageNumber;
    int index = 0, finalIndex;

    private void Start()
    {
        finalIndex = winImages.Length - 1;
        UpdatePage();
    }

    public void LeftButton()
    {
        if(index > 0)
        {
            if(index >= finalIndex)
            {
                right.SetActive(true);
            }
            index--;
            GetComponent<Image>().sprite = winImages[index];
            if(index <= 0)
            {
                left.SetActive(false);
            }
        }
        UpdatePage();
    }

    public void RightButton()
    {
        if (index < finalIndex)
        {
            if (index <= 0)
            {
                left.SetActive(true);
            }
            index++;
            GetComponent<Image>().sprite = winImages[index];
            if (index >= finalIndex)
            {
                right.SetActive(false);
            }
        }
        UpdatePage();
    }

    public void UpdatePage()
    {
        pageNumber.text = "Page " + (index + 1) + "/" + winImages.Length;
    }

    public void CanClick()
    {
        GameManager.Instance.canClick = true;
    }

    public void CantClick()
    {
        GameManager.Instance.canClick = false;
    }
}
