using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinUIHide : MonoBehaviour
{
    // this fixes the lingering UI problem
    public Text t;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(t.text == "0")
        {
            gameObject.SetActive(false);
        }
    }
}
