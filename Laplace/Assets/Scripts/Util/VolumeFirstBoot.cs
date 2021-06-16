using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeFirstBoot : MonoBehaviour
{
    public AudioClip bgm;
    public OptionMenu oM;
    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.GetString("Volume Fix") != "Fixed")
        {
            PlayerPrefs.SetFloat("Music Volume", 1);
            PlayerPrefs.SetFloat("Sound Volume", 1);
            PlayerPrefs.SetString("Volume Fix", "Fixed");
            oM.PullSettings();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (AudioManager.Instance.bgm != bgm)
        {
            AudioManager.Instance.ChangeBGM(bgm);
        }
    }
}
