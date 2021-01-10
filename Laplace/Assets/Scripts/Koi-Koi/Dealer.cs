using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dealer : MonoBehaviour
{
    /*
     * TODO: Calling Koi-koi
     * TODO: Pile checking on hover or making the cards smaller or something
     */
    // Start is called before the first frame update
    public GameObject[] cards, handP, handC; //all the cards, player and computer hands
    ArrayList table = new ArrayList(); //cards on the table
    ArrayList[] pileP = { new ArrayList(), new ArrayList(), new ArrayList(), new ArrayList() }; //cards collected by the player
    ArrayList[] pileC = { new ArrayList(), new ArrayList(), new ArrayList(), new ArrayList() }; //cards collected by the computer
    Queue deck = new Queue(); // deck of cards
    int turn = 0;
    void Start()
    {
        Shuffle(); //shuffle the deck
        /*
         *   Deal out cards two at a time to each players hand and the table
         *      That's how Koi-Koi works
         *   TODO: Move to a coroutine and animate it
         *   TODO: Decide a "dealer" and deal out cards accordingly
         *   TODO: Check for multiples of a suit and act accordingly
         *       This means either ending the game and awarding 6 points to either player for a full suit
         *       or bunching up 3 of the same suit that are on the table
         *       or reshuffling if a full suit ends up on the table 
         *           technically I could catch this and make sure it never happens which will probably be easier
         */
        for (int i = 0; i < 8;i+=2) 
        {
            handP[i] = (GameObject) deck.Dequeue();
            handP[i].GetComponent<Card>().zone = 2;
            handP[i+1] = (GameObject)deck.Dequeue();
            handP[i+1].GetComponent<Card>().zone = 2;
            handC[i] = (GameObject)deck.Dequeue();
            handC[i].GetComponent<Card>().zone = 3;
            handC[i+1] = (GameObject)deck.Dequeue();
            handC[i+1].GetComponent<Card>().zone = 3;
            table.Add(deck.Dequeue());
            table.Add(deck.Dequeue());
        }
        foreach(GameObject setCard in table)
        {
            setCard.GetComponent<Card>().zone = 4;
        }
        for (int i = 0; i < 8; i++)
        {
            handP[i].transform.position = new Vector3(-6f + i*1.5f, -3.3f, handP[i].transform.position.z);
            handP[i].GetComponent<Card>().faceUp = true;
            handC[i].transform.position = new Vector3(-6f + i * 1.5f, 3.3f, handC[i].transform.position.z);
            TableLayout();
        }
        turn = 1;
    }
    // Update is called once per frame
    void Update()
    {
        CheckEnd();
        if (turn == 1)
        {
            PlayerTurn();
        }
        else if (turn == 2)
        {
            ComputerTurn();
        }
    }

    void Shuffle() //shuffles the deck
    {
        GameObject[] shuffle = (GameObject[])cards.Clone(); //clone a list of all cards
        deck.Clear(); //clear the queue *note: probably need to destroy all previous cards as well
        for (int i = 0; i < 48; i++)  //swaps each card in the deck with a random one
        {
            int pick = Random.Range(0, 47);
            cards[i] = shuffle[pick];
            cards[pick] = shuffle[i];
            shuffle = (GameObject[])cards.Clone(); //make sure the reference deck is updated
        }
        for (int i = 0; i < 48; i++) //create each card in the deck
        {
            GameObject newCard = Instantiate(cards[i]) as GameObject;
            newCard.transform.position = new Vector3(-10f + (.005f * i), 0f, 0);
            newCard.GetComponent<Card>().zone = 1;
            deck.Enqueue(newCard);
        }
    }

    /*
     * TODO:Choosing between multiple cards
     */
    void PlayerTurn() // what occurs when it's the player's turn
    {
        for (int i = 0; i < handP.Length; i++)
        {
            if (handP[i] != null && handP[i].GetComponent<Card>().selected)
            {
                bool match = false;
                handP[i].GetComponent<Card>().selected = false;
                foreach (GameObject lookCard in table)
                {
                    if (lookCard.GetComponent<Card>().suit == handP[i].GetComponent<Card>().suit)
                    {
                        int pileN = CardSort(lookCard);
                        pileP[pileN].Add(lookCard);
                        lookCard.GetComponent<Card>().zone = 5;
                        pileN = CardSort(handP[i]);
                        pileP[pileN].Add(handP[i]);
                        handP[i].GetComponent<Card>().zone = 5;
                        table.Remove(lookCard);
                        handP[i] = null;
                        PlayerPile();
                        match = true;
                        break;
                    }
                }
                if(!match)
                {
                    table.Add(handP[i]);
                    handP[i] = null;
                }
                NextDeck();
                CheckEnd();
                if(turn == 1)
                    turn = 2;
            }
        }
    }

    /*
     * 
     */
    void ComputerTurn() //what occurs when it's the computer's turn
    {
        bool match = false;
        for(int i = 0; i < 8; i++)
        {
            if(handC[i] != null)
            {
                foreach (GameObject lookCard in table)
                {
                    if (lookCard.GetComponent<Card>().suit == handC[i].GetComponent<Card>().suit)
                    {
                        int pileN = CardSort(lookCard);
                        pileC[pileN].Add(lookCard);
                        lookCard.GetComponent<Card>().zone = 5;
                        pileN = CardSort(handC[i]);
                        pileC[pileN].Add(handC[i]);
                        handC[i].GetComponent<Card>().zone = 5;
                        table.Remove(lookCard);
                        handC[i] = null;
                        ComputerPile();
                        match = true;
                        break;
                    }
                }
                if(match)
                {
                    NextDeck();
                    CheckEnd();
                    if(turn == 2)
                        turn = 1;
                    break;
                }
            }
        }
        if(!match)
        {
            for (int i = 7; i >= 0; i--)
            {
                if (handC[i] != null)
                {
                    table.Add(handC[i]);
                    handC[i] = null;
                    NextDeck();
                    CheckEnd();
                    if (turn == 2)
                        turn = 1;
                    break;
                }
            }
        }
    }
    void NextDeck() //puts the next card from the deck on the table and adds it to the appropriate player's pile if combod
    {
        GameObject nextCard = (GameObject) deck.Dequeue();
        bool match = false;
        foreach(GameObject lookCard in table)
        {
            ArrayList[] correctPile;
            if(turn == 1)
            {
                correctPile = pileP;
            }
            else
            {
                correctPile = pileC;
            }
            if(nextCard.GetComponent<Card>().suit == lookCard.GetComponent<Card>().suit)
            {
                int pileN = CardSort(lookCard);
                correctPile[pileN].Add(lookCard);
                lookCard.GetComponent<Card>().zone = 5;
                pileN = CardSort(nextCard);
                correctPile[pileN].Add(nextCard);
                nextCard.GetComponent<Card>().zone = 5;
                if (turn == 1)
                {
                    PlayerPile();
                }
                else
                {
                    ComputerPile();
                }
                match = true;
                table.Remove(lookCard);
                break;
            }
        }
        if (match)
        {
            TableLayout();
        }
        else
        {
            table.Add(nextCard);
            TableLayout();
        }
    }

    int CardSort(GameObject lookCard) //puts the card in 1 of 4 piles based on value
    {
        int pileN = 0; //Pile Number
        switch (lookCard.GetComponent<Card>().value)
        {
            case 1:
                pileN = 0;
                break;
            case 5:
                pileN = 1;
                break;
            case 10:
                pileN = 2;
                break;
            case 20:
                pileN = 3;
                break;
        }

        return pileN;
    }

    void TableLayout() //Arranges the cards on the table
    {
        int i = 0;
        foreach (GameObject nextCard in table)
        {
            nextCard.GetComponent<Card>().faceUp = true;
            if (i % 2 == 0)
            {
                nextCard.transform.position = new Vector3(-3f + .75f * i, 1.2f, nextCard.transform.position.z);
            }
            else
            {
                nextCard.transform.position = new Vector3(-3.75f + .75f * i, -1.2f, nextCard.transform.position.z);
            }
            i++;
        }
    }
    void PlayerPile() //Arranges cards the player has based on values
    {
        for (int i = 0; i < 4; i++)
        {
            int count = 0;
            foreach (GameObject card in pileP[i])
            {
                card.transform.position = new Vector3(7f + i * 1.5f, -3f - count, 0f - count * .01f);
                card.GetComponent<Card>().faceUp = true;
                count++;
            }
        }
    }
    void ComputerPile() //Arranges cards the computer has based on value
    {
        for (int i = 0; i < 4; i++)
        {
            int count = 0;
            foreach (GameObject card in pileC[i])
            {
                card.transform.position = new Vector3(7f + i * 1.5f, 3f + count, 0f + count * .01f);
                card.GetComponent<Card>().faceUp = true; //cards won are always face up
                count++;
            }
        }
    }

    /*
     * TODO: Making Sake Trash Optional
     * TODO: Winning a suit only counts after a koi-koi if it earns more points than previously
     * TODO: 3 Red/Blue Poetry Tanzaku
     * TODO: All of 1 Month
     * TODO: Winning does something besides sends a debug log
     */
    void CheckEnd() //checks to see if one of the end game conditions has happened
    {
        ArrayList[] checkPile = null;
        switch(turn)
        {
            case 1:
                checkPile = pileP;
                break;
            case 2:
                checkPile = pileC;
                break;
        }
        if (checkPile != null)
        {
            bool sake = false;
            if (checkPile[2].Count >= 1)
            {
                if (checkPile[2].Count >= 5)
                {
                    Debug.Log("Seeds");
                    turn = 0;
                }
                bool boar = false, deer = false, butterfly = false;
                foreach (GameObject card in checkPile[2])
                {
                    switch (card.GetComponent<Card>().suit)
                    {
                        case 6:
                            butterfly = true;
                            break;
                        case 7:
                            boar = true;
                            break;
                        case 9:
                            sake = true;
                            break;
                        case 10:
                            deer = true;
                            break;
                    }
                }
                if (boar && deer && butterfly)
                {
                    Debug.Log("Boar, Deer, Butterfly");
                    turn = 0;
                }
            }
            if (checkPile[0].Count >= 10 || (sake && checkPile[0].Count >= 9))
            {
                Debug.Log("Trash");
                turn = 0;
            }
            if (checkPile[1].Count >= 5)
            {
                Debug.Log("Tanzaku");
                turn = 0;
            }
            if (checkPile[3].Count == 5)
            {
                Debug.Log("Five Lights");
                turn = 0;
            }
            if(checkPile[3].Count >= 1)
            {
                bool moon = false, crane = false,
                     blossom = false, rainman = false, phoenix = false;
                foreach(GameObject card in checkPile[3])
                {
                    switch(card.GetComponent<Card>().suit)
                    {
                        case 1:
                            crane = true;
                            break;
                        case 3:
                            blossom = true;
                            break;
                        case 8:
                            moon = true;
                            break;
                        case 11:
                            rainman = true;
                            break;
                        case 12:
                            phoenix = true;
                            break;
                    }
                }
                if(moon && crane && blossom)
                {
                    if(phoenix)
                    {
                        Debug.Log("Four Lights");
                        turn = 0;
                    }
                    else
                    {
                        Debug.Log("Three Lights");
                        turn = 0;
                    }
                }
                else if(rainman && crane && blossom && phoenix)
                {
                    Debug.Log("Rainy Four Lights");
                    turn = 0;
                }
                if (sake && moon)
                {
                    Debug.Log("Moon Viewing");
                    turn = 0;
                }
                if (sake && blossom)
                {
                    Debug.Log("Flower Viewing");
                    turn = 0;
                }
            }
        }
        if (deck.Count == 0 || table.Count == 0)
        {
            turn = 0;
        }
    }
}
