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
    ArrayList winCons = new ArrayList(); //List of conditions won
    public ArrayList[] pileP = { new ArrayList(), new ArrayList(), new ArrayList(), new ArrayList() }; //cards collected by the player
    public ArrayList[] pileC = { new ArrayList(), new ArrayList(), new ArrayList(), new ArrayList() }; //cards collected by the computer
    Queue deck = new Queue(); // deck of cards
    public int turn = 0;
    bool group = false; //only turns true when there's a group of 3 of a suit on the table
    void Start()
    {
        Shuffle(); //shuffle the deck
        StartCoroutine(Deal()); //deal the cards
        
    }
    // Update is called once per frame
    void Update()
    {
        CheckEnd(); //makes sure the table, deck, hands, etc aren't empty
        //should this be a switch case? is that more efficient?
        if (turn == 1)
        {
            PlayerTurn();
        }
        else if (turn == 2)
        {
            ComputerTurn();
        }
        else if (turn == 3)
        {
            //TODO: Player Koi-Koi options and winnig and such
        }
        else if (turn == 4)
        {
            if(ComputerKoiKoi())
            {
                turn = 1;
            }
            //TODO:Computer winning 
        }
        else if (turn == 5)
        {
            //TODO:What happens when the deck. hands, table runs out of cards and such
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
            newCard.transform.position = new Vector3(-8f + (.005f * i), 0f, 0);
            newCard.GetComponent<Card>().zone = 1;
            deck.Enqueue(newCard);
        }
    }

    IEnumerator Deal()
    {
        /*
         *   Deal out cards two at a time to each players hand and the table
         *      That's how Koi-Koi works
         *   TODO: Animate This
         *   TODO: Decide a "dealer" and deal out cards accordingly
         *      Maybe I can just cheat and always have the player deal
         */
        group = false;
        for (int i = 0; i < 8; i += 2)
        {
            handP[i] = (GameObject)deck.Dequeue();
            handP[i].GetComponent<Card>().zone = 2;
            handP[i + 1] = (GameObject)deck.Dequeue();
            handP[i + 1].GetComponent<Card>().zone = 2;
            handC[i] = (GameObject)deck.Dequeue();
            handC[i].GetComponent<Card>().zone = 3;
            handC[i + 1] = (GameObject)deck.Dequeue();
            handC[i + 1].GetComponent<Card>().zone = 3;
            table.Add(deck.Dequeue());
            table.Add(deck.Dequeue());
        }
        foreach (GameObject setCard in table)
        {
            setCard.GetComponent<Card>().zone = 4;
        }
        for (int i = 0; i < 8; i++)
        {
            handP[i].transform.position = new Vector3(-6f + i * 1.5f, -3.3f, handP[i].transform.position.z);
            handP[i].GetComponent<Card>().faceUp = true;
            yield return new WaitForEndOfFrame();
            handC[i].transform.position = new Vector3(-6f + i * 1.5f, 3.3f, handC[i].transform.position.z);
            yield return new WaitForEndOfFrame();

        }
        turn = 1;
        //Checking to see if someone won based on collecting a full suit in hand
        int[] suitCount = new int[12];
        foreach (GameObject card in handC) //Computer
        {
            suitCount[card.GetComponent<Card>().suit - 1]++;
        }
        for (int i = 0; i < 12; i++)
        {
            if (suitCount[i] == 4)
            {
                winCons.Add("Full Suit:6");
                turn = 4;
            }
        }
        suitCount = new int[12];
        foreach (GameObject card in handP) //Player
        {
            suitCount[card.GetComponent<Card>().suit - 1]++;
        }
        for (int i = 0; i < 12; i++)
        {
            if (suitCount[i] == 4)
            {
                winCons.Add("Full Suit:6");
                turn = 3;
            }
        }
        //Group same suit on table
        suitCount = new int[12];
        foreach (GameObject card in table)
        {
            suitCount[card.GetComponent<Card>().suit - 1]++;
        }
        for (int i = 0; i < 12; i++)
        {
            if (suitCount[i] == 4)
            {
                //TODO: Reshuffling for full suit on table
            }
            else if (suitCount[i] == 3)
            {
                group = true;
                foreach (GameObject card in table)
                {
                    ArrayList suitGroup = new ArrayList();
                    if (card.GetComponent<Card>().suit == i)
                    {
                        suitGroup.Add(card);
                        table.Remove(card);
                    }
                    table.Add(suitGroup);
                }
            }
        }
        TableLayout(); //finally lay the table out
    }

    /*
     * TODO:Choosing between multiple cards
     *    this should be urgent
     * TODO: If three of a suit is on the table, you should get all 4 by playing the final card
     *    it doesn't work rn I got lucky somehow 
     *    this needs to happen for player, computer, and nextdeck
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
                        lookCard.GetComponent<Card>().zone = 6;
                        pileN = CardSort(handC[i]);
                        pileC[pileN].Add(handC[i]);
                        handC[i].GetComponent<Card>().zone = 6;
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
                lookCard.GetComponent<Card>().zone = 4 + turn;
                pileN = CardSort(nextCard);
                correctPile[pileN].Add(nextCard);
                nextCard.GetComponent<Card>().zone = 4 + turn;
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
        //Something is broken here for when there's 3 cards of a suit?
        //TODO: Actually figure out how to fix this shit lol 
        foreach (GameObject nextCard in table)
        {
            nextCard.GetComponent<Card>().faceUp = true;
            if (i % 2 == 0)
            {
                nextCard.transform.position = new Vector3(-3f + .7f * i, 1.2f, nextCard.transform.position.z);
            }
            else
            {
                nextCard.transform.position = new Vector3(-3.75f + .7f * i, -1.2f, nextCard.transform.position.z);
            }
            i++;
        }
        if (group)
        {
            foreach (ArrayList group in table)
            {
                int j = 0;
                foreach (GameObject nextCard in table)
                {
                    nextCard.GetComponent<Card>().faceUp = true;
                    if (i % 2 == 0)
                    {
                        nextCard.transform.position = new Vector3(-3f + (.7f * i) + (.25f * j), 1.2f, nextCard.transform.position.z);
                    }
                    else
                    {
                        nextCard.transform.position = new Vector3(-3.75f + (.7f * i) + (.25f * j), -1.2f, nextCard.transform.position.z);
                    }
                }
                i++;
            }
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
     * TODO: All of 1 Month
     * TODO: Winning does something
     */
    void CheckEnd() //checks to see if one of the end game conditions has happened
    {
        ArrayList[] checkPile = null;
        ArrayList newWin = new ArrayList();
        switch(turn)
        {
            case 1:
                /* checks if the player's hand is empty 
                 * TODO: Check if the computers hand is empty if I ever get to making
                 *  the computer able to deal
                 */
                int countH = 0;
                foreach (GameObject c in handP)
                {
                    if (c == null)
                    {
                        countH++;
                    }
                }
                if (countH == 8)
                {
                    turn = 5;
                }
                checkPile = pileP;
                break;
            case 2:
                checkPile = pileC;
                break;
        }
        if (deck.Count == 0 || table.Count == 0) //checks if table or deck is empty
        {
            turn = 5;
        }
        if (checkPile != null)
        {
            bool sake = false, boar = false, deer = false, butterfly = false,
            moon = false, crane = false, blossom = false, rainman = false, phoenix = false;
            if (checkPile[2].Count >= 1)
            {
                if (checkPile[2].Count >= 5)
                {
                    newWin.Add("Seeds:" + (checkPile[2].Count - 4));
                }
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
                    newWin.Add("Boar, Deer, Butterfly:5");
                }
            }
            if (checkPile[0].Count >= 10 || (sake && checkPile[0].Count >= 9))
            {
                /*Trash is counted as 1 points plus 1 point for every additional card 
                 *The sake cup can also act as trash
                 *TODO: Make the sake card not count if it's used for another win condition
                 *  I'm pretty sure this is a rule, but I'm not 100% certain
                 *  I think technically I'm supposed to ask players if they want to count the sake
                 *  cup for the win
                 *  I could also do none of this and it wouldn't have a major impact, so this
                 *  should be saved for later
                 */
                int sak = sake ? 1 : 0; //wth C# why isn't bools 0/1
                newWin.Add("Trash:" + (checkPile[0].Count - (9 + sak)));
            }
            if (checkPile[1].Count >= 3)
            {
                if (checkPile[1].Count >= 5)
                {
                    newWin.Add("Tanzaku:" + (checkPile[0].Count - 4));
                }
                //poetry tanzaku counting
                int poetryTanzaku = 0, blueTanzaku = 0;
                foreach (GameObject card in checkPile[1])
                {
                    switch (card.GetComponent<Card>().suit)
                    {
                        case 1:
                            poetryTanzaku++;
                            break;
                        case 2:
                            poetryTanzaku++;
                            break;
                        case 3:
                            poetryTanzaku++;
                            break;
                        case 6:
                            blueTanzaku++;
                            break;
                        case 9:
                            blueTanzaku++;
                            break;
                        case 10:
                            blueTanzaku++;
                            break;
                    }
                }
                if(poetryTanzaku == 3)
                {
                    newWin.Add("Red Poetry Tanzaku:5");
                }
                if(blueTanzaku == 3)
                {
                    newWin.Add("Blue Poetry Tanzaku:5");
                }
            }
            if (checkPile[3].Count == 5)
            {
                newWin.Add("Five Lights:20");
            }
            if(checkPile[3].Count >= 1)
            {
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
                        newWin.Add("Four Lights:10");
                    }
                    else
                    {
                        newWin.Add("Three Lights:6");
                    }
                }
                else if(rainman && crane && blossom && phoenix)
                {
                    newWin.Add("Rainy Four Lights:8");
                }
                if (sake && moon)
                {
                    newWin.Add("Moon Viewing:5");
                }
                if (sake && blossom)
                {
                    newWin.Add("Flower Viewing:5");
                }
            }
            if (WinTotal(newWin) > WinTotal(winCons))
            {
                turn = (checkPile == pileP) ? 3 : 4;
                winCons = newWin;
                Debug.Log(winCons[0]);
            }
        }
    }
    /*
     * Separates winCons into a list of winning names and a list of point values (matching order)
     * For Clarification
     * WinSort()[0] is an array of strings containing the win conditions achieved by name
     * WinSort()[1] is a corresponding array of strings containing the values of the win conditions met
     */
    string[][] WinSort(ArrayList winToSort) 
    {
        string[] names = new string[winToSort.Count], values = new string[winToSort.Count];
        for (int i = 0; i < winToSort.Count; i++)
        {
            string winConCurrent = (string)winToSort[i]; //need to make sure I can use the Split function
            string[] namePoints = winConCurrent.Split(':');
            names[i] = namePoints[0]; //the name is always the 1st part
            values[i] = namePoints[1]; //the value is always the 2nd part
        }
        return new string[2][] {names, values};
    }
    int WinTotal(ArrayList winToTotal) //gives a total point value for the current winCons using WinSort()
    {
        int totalPoints = 0;
        string[] values = WinSort(winToTotal)[1];
        foreach(string v in values)
        {
            totalPoints += int.Parse(v);
        }
        return totalPoints;
    }
    /*computer choses to koi-koi based on their score
     * with a score of 1 they have a slightly higher than 50% to koi-koi
     * with a score of 11 they still CAN koi-koi, but it's not very likely
     * with a score of 15 they'll never koi-koi
     * I could make a better AI, but I don't think it's necessary for now
     */
    bool ComputerKoiKoi()
    {
        bool koi = (Random.Range(0, 20) + WinTotal(winCons) < 14) ? true : false;
        if (koi) //don't want computer koi-koing if they don't have any cards
        {
            int countH = 0;
            foreach (GameObject c in handP)
            {
                if (c == null)
                {
                    countH++;
                }
            }
            if (countH == 8)
            {
                koi = false;
            }
        }
        return koi;
    }
}
