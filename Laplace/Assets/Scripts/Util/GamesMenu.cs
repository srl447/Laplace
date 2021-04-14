using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GamesMenu : MonoBehaviour
{
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            gameObject.SetActive(false);
        }
    }
    public void KoiKoiButton()
    {
        GameManager.Instance.opponent = "Onoskelis";
        SceneManager.LoadScene(2);
    }
        
    public void DreidelButton()
    {
        GameManager.Instance.opponent = "Onoskelis";
        SceneManager.LoadScene(5);
    }

    public void FishingButton()
    {
        SceneManager.LoadScene(9);
    }

}
