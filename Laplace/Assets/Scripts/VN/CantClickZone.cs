using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CantClickZone : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Cursor")
        {
            Debug.Log("collided");
            GameManager.Instance.canClick = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Cursor")
        {
            GameManager.Instance.canClick = true;
        }
    }
}
