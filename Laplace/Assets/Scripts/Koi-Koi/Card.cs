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

    public GameObject shade;
    public Dealer deal;
    ArrayList tempCards = new ArrayList();
    public bool faceUp, selected, hover, selectedDouble;
    public Sprite front, back;
    void Start()
    {
        //this.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        //this.GetComponent<Rigidbody2D>().simulated = true;
        GameObject dealer = GameObject.Find("Dealer");
        deal = dealer.GetComponent<Dealer>();
        shade = GameObject.Find("Shade");
        Destroy(this.GetComponent<Rigidbody2D>()); //I'm to lazy to change 48 prefabs I should've used a generic card prefab 
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
        if (GameManager.Instance.canClick && hover && (Input.GetKeyDown(GameManager.Instance.main) || Input.GetKeyDown(GameManager.Instance.alt)))
        {
            switch (zone)
            {
                case 2:
                    selected = true;
                    break;
                case 4:
                    selectedDouble = true;
                    break;
            }
        }
        else if (!hover)
        {
            selectedDouble = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Cursor")
        {
            if (zone == 2 || zone == 4)
            {
                hover = true;
            }
            else if (zone == 5 && tempCards.Count == 0 && deal.turn < 3)
            {
                int count = 0;
                int count2 = 0;
                shade.GetComponent<SpriteRenderer>().enabled = true;
                foreach (ArrayList pile in deal.pileP)
                {
                    foreach (GameObject card in pile)
                    {
                        GameObject newCard = Instantiate(card) as GameObject;
                        newCard.transform.position = new Vector3(-7.2f + (count*(2f-(count/13))), 3.2f - count2*2.2f, -1.1f);
                        tempCards.Add(newCard);
                        count++;
                    }
                    count = 0;
                    count2++;
                }
            }
            else if (zone == 6 && tempCards.Count == 0 && deal.turn < 3)
            {
                int count = 0;
                int count2 = 0;
                shade.GetComponent<SpriteRenderer>().enabled = true;
                foreach (ArrayList pile in deal.pileC)
                {
                    foreach (GameObject card in pile)
                    {
                        GameObject newCard = Instantiate(card) as GameObject;
                        newCard.transform.position = new Vector3(-7.2f + (count * (2f - (count / 13))), 3.2f - count2 * 2.2f, -1.1f);
                        tempCards.Add(newCard);
                        count++;
                        if (count > 10)
                        {
                            count2++;
                            count = 0;
                        }
                    }
                    count = 0;
                    count2++;
                }
            }
        }
        else
        {
            hover = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Cursor")
        {
            if (zone == 2)
            {
                hover = false;
            }
            else if(zone == 5 || zone == 6)
            {
                shade.GetComponent<SpriteRenderer>().enabled = false;
                foreach (GameObject card in tempCards)
                {
                    Destroy(card);
                }
                tempCards.Clear();
            }
        }
    }
}
