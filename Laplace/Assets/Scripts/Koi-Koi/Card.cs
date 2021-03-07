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

    public GameObject shade; //the semi-opaque black background when hovering over won cards
    GameObject highlight = null;
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
        //shows the face
        if (faceUp)
        {
            this.GetComponent<SpriteRenderer>().sprite = front;
        }
        else
        {
            this.GetComponent<SpriteRenderer>().sprite = back;
        }

        //create border
        if(selected && highlight == null)
        {
            highlight = Instantiate(gameObject) as GameObject;
            //don't want any weird interactions
            Destroy(highlight.GetComponent<Card>());
            Destroy(highlight.GetComponent<BoxCollider2D>());

            //Essentially a black shadow or border
            highlight.GetComponent<SpriteRenderer>().color = Color.black;
            highlight.transform.position = new Vector3(highlight.transform.position.x, highlight.transform.position.y, highlight.transform.position.z + .01f);
            highlight.transform.localScale = highlight.transform.localScale * 1.2f;

        }

        if(highlight != null && (selected == false || zone != 2))
        {
            Destroy(highlight);
        }


        if (deal.turn == 1 && GameManager.Instance.canClick && hover && (Input.GetKeyDown(GameManager.Instance.main) || Input.GetKeyDown(GameManager.Instance.alt)))
        {
            bool canSelect = true;
            for(int i = 0; i < 8; i++)
            {
                if(deal.handP[i] != null && deal.handP[i].GetComponent<Card>().selected)
                {
                    canSelect = false;
                    break;
                }
            }
            switch (zone)
            {
                case 2:
                    if (!selected && canSelect)
                    {
                        selected = true;
                    }
                    else
                    {
                        selected = false;
                    }
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
            else if (!GameManager.Instance.tempCardsShow)
            {
                if (zone == 5 && tempCards.Count == 0 && deal.turn < 3)
                {
                    int count = 0;
                    int count2 = 0;
                    shade.GetComponent<SpriteRenderer>().enabled = true;
                    GameManager.Instance.tempCardsShow = true;
                    foreach (ArrayList pile in deal.pileP)
                    {
                        foreach (GameObject card in pile)
                        {
                            GameObject newCard = Instantiate(card) as GameObject;
                            Destroy(newCard.GetComponent<Card>());
                            newCard.transform.position = new Vector3(-7.2f + (count * (2f - (count / 13))), 3.2f - count2 * 2.2f, -1.1f);
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
                    GameManager.Instance.tempCardsShow = true;
                    foreach (ArrayList pile in deal.pileC)
                    {
                        foreach (GameObject card in pile)
                        {
                            GameObject newCard = Instantiate(card) as GameObject;
                            Destroy(newCard.GetComponent<Card>());
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
            else if(tempCards.Count > 0 && (zone == 5 || zone == 6))
            {
                shade.GetComponent<SpriteRenderer>().enabled = false;
                GameManager.Instance.tempCardsShow = false;
                foreach (GameObject card in tempCards)
                {
                    Destroy(card);
                }
                tempCards.Clear();
            }
        }
    }
}
