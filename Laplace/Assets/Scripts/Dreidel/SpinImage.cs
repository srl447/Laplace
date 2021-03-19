using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpinImage : MonoBehaviour
{
    public Sprite spin1, spin2;
    int count = 0;
    void Update()
    {
        if(count == 30)
        {
            GetComponent<Image>().sprite = spin2;
        }
        else if(count == 60)
        {
            GetComponent<Image>().sprite = spin1;
            count = 0;
        }
        count++;
    }
}
