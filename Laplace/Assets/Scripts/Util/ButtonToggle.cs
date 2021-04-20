using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonToggle : MonoBehaviour
{
    public GameObject gO;
    public void Button()
    {
        if(gO.activeSelf != true)
        {
            gO.SetActive(true);
        }
        else
        {
            gO.SetActive(false);
        }
    }
}
