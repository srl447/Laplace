using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RulesUI : MonoBehaviour
{
    public Sprite[] winImages;
    public GameObject left, right;
    int index = 0;

    public void LeftButton()
    {
        if(index > 0)
        {
            if(index >= 3)
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
    }

    public void RightButton()
    {
        if (index < 3)
        {
            if (index <= 0)
            {
                left.SetActive(true);
            }
            index++;
            GetComponent<Image>().sprite = winImages[index];
            if (index >= 3)
            {
                right.SetActive(false);
            }
        }
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
