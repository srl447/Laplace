using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveLoadButtons : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject successText;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Save()
    {
        if (GameManager.Instance.SaveData())
        {
            GameObject newText = Instantiate(successText) as GameObject;
            newText.transform.SetParent(transform);
            newText.transform.position = transform.position;
        }
    }

    public void Load()
    {
        GameManager.Instance.LoadData();
    }
}
