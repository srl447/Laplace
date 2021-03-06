using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CompendiumButton : MonoBehaviour
{
    public Compendium compendium;
    public void SelectPress()
    {
        compendium.Select(gameObject.GetComponentInChildren<Text>().text);
    }
}
