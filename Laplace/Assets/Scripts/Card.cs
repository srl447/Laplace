using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    // Start is called before the first frame update
    public int suit;
    public int value;
    public int zone = 0;
    /*
     * 0:Void
     * 1:Deck
     * 2:Player's Hand
     * 3:Computer's Hand
     * 4:Table
     * 5:Player's Pile
     * 6:Computer's Pile
     */
    public bool faceUp, selected, hover;
    public Sprite front, back;
    void Start()
    {
        //this.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        //this.GetComponent<Rigidbody2D>().simulated = true;
        Destroy(this.GetComponent<Rigidbody2D>());
    }

    // Update is called once per frame
    void Update()
    {
        if (faceUp)
        {
            this.GetComponent<SpriteRenderer>().sprite = front;
        }
        else
        {
            this.GetComponent<SpriteRenderer>().sprite = back;
        }
        if (hover && Input.GetMouseButtonDown(0))
        {
            selected = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Cursor" && zone == 2)
        {
            hover = true;
        }
        else
        {
            hover = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Cursor" && zone == 2)
        {
            hover = false;
        }
    }
}
