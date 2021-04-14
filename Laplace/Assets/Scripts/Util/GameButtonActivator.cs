using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameButtonActivator : MonoBehaviour
{
    public GameObject gameButton;
    void Awake()
    {
        if(PlayerPrefs.GetInt("Credits Rolled") == 1)
        {
            gameButton.SetActive(true);
        }
    }


}
