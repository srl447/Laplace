using System.Collections;
using System.Collections.Generic;
using Patterns;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public string opponent = "Furfur";
    public bool canClick = true;
    public int progress = 0;
    public int scoreP = 0, scoreC = 0;

    public KeyCode main, alt;

    public bool tempCardsShow = false;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);

        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        //update settings
        OptionMenu oM = FindObjectOfType<OptionMenu>();;
        oM.PullSettings();
        oM.gameObject.SetActive(false);
        Instance.canClick = true;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public int GetSceneNumber()
    {
        return SceneManager.GetActiveScene().buildIndex;
    }

    public void SaveData()
    {
        SaveSystem.SaveData(this);
    }

    public void LoadData()
    {
        Data data = SaveSystem.LoadData();
        SceneManager.LoadScene(data.sceneNumber);
        opponent = data.opponentName;
        progress = data.progressIndex;
        scoreP = data.scoreP;
        scoreC = data.scoreC;
    }
}
