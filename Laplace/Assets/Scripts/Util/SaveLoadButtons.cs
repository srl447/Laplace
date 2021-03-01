using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveLoadButtons : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Save()
    {
        GameManager.Instance.SaveData();
    }

    public void Load()
    {
        GameManager.Instance.LoadData();
    }
}
