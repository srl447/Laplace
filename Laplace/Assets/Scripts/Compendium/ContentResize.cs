using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ContentResize : MonoBehaviour
{
    public RectTransform rt;
    public Text t;
    
    void Update()
    {
        //TODO: Adjust for font size
        rt.sizeDelta = new Vector2(rt.sizeDelta.x, 400 + (100 * (t.text.Length/35)));


    }
}
