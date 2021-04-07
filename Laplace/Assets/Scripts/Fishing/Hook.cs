using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Hook : MonoBehaviour
{
    GameObject fishHooked = null;
    int score = 0;
    int health = 3;
    public Text scoreText;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0); //get the x and y value
        pos = Camera.main.ScreenToWorldPoint(pos); //convert them to unity space
        transform.position = new Vector3(transform.position.x, pos.y, -1);

        //return to the main menu
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }

        if (fishHooked != null)
        {
            fishHooked.transform.position = transform.position; //attaches fish to hook

            if(transform.position.y > 3)//removes fish
            {
                if(fishHooked.tag == "Fish")
                {
                    ScoreUpdate(1);
                }
                else if (fishHooked.tag == "Untagged")
                {
                    ScoreUpdate(5);
                }
                Destroy(fishHooked);
                
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Fish")
        {
            if(fishHooked == null)
            {
                fishHooked = collision.gameObject;
                fishHooked.transform.eulerAngles += new Vector3(0, 0, 90);
                fishHooked.GetComponent<Fish>().speed = 0;
            }
        }
        else if(collision.gameObject.tag == "BadFish")
        {
            if(fishHooked != null)
            {
                Destroy(fishHooked);
            }
            health--;
            collision.gameObject.tag = "Untagged";
        }
        else if (collision.gameObject.tag == "BigFish")
        {
            if(fishHooked != null)
            {
                Destroy(fishHooked);
                fishHooked = collision.gameObject;
                collision.gameObject.tag = "Untagged";
                fishHooked.transform.eulerAngles += new Vector3(0, 0, 90);
                fishHooked.GetComponent<Fish>().speed = 0;
            }
        }
    }

    void ScoreUpdate(int amount)
    {
        score += amount;
        scoreText.text = "Score: " + score;
    }
}
