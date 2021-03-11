using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Dealer : MonoBehaviour
{
    /*
     * TODO: Fix starting win condition
     *   You win with 4 sets of pairs 
     *   You can also claim 4 of a kind at any point in the game
     *   You can also caim 4 of a kind if you have 3 of a kind and the match is on the table
     * TODO: Fix Scoring
     *   Koi-koi might only double score if your opponent called koikoi and not if you did
     *   Score doubled if above 7
     *   Do these stack? Why is it so hard to find out rules
     *      It's hard because there's no set rules and people play with house rules and such
     * TODO: TODOs listed below
     */ 
    public GameObject[] cards, handP, handC; //all the cards, player and computer hands
    ArrayList table = new ArrayList(); //cards on the table
    List<string> winConsP = new List<string>(), winConsC = new List<string>(); //List of conditions won
    public ArrayList[] pileP = { new ArrayList(), new ArrayList(), new ArrayList(), new ArrayList() }; //cards collected by the player
    public ArrayList[] pileC = { new ArrayList(), new ArrayList(), new ArrayList(), new ArrayList() }; //cards collected by the computer
    Queue deck = new Queue(); // deck of cards
    public int turn = 0;
    bool group = false; //only turns true when there's a group of 3 of a suit on the table
    bool winOn = false; //checks if the win UI is turned on
    bool koiCallP = false, koiCallC = false;
    public Button koiB, stopB; //buttons for the win screen
    GameObject[] suitGroup1 = new GameObject[3], suitGroup2 = new GameObject[3]; //suit groups
    public int scoreP, scoreC; //scores for player, computer

    public Text playerScore, computerScore;
    public Image koiType, stopType;
    public AudioClip typeNoise;

    public AudioClip[] cardNoise;
    // Start is called before the first frame update
    void Start()
    {
        scoreP = GameManager.Instance.scoreP;
        scoreC = GameManager.Instance.scoreC;
        koiB.onClick.AddListener(KoiClick);
        stopB.onClick.AddListener(StopClick);
        Shuffle(); //shuffle the deck
        StartCoroutine(Deal()); //deal the cards
        computerScore.text = GameManager.Instance.opponent + ": " + scoreC;
        playerScore.text = "Modayaal: " + scoreP;
        
    }
    // Update is called once per frame
    void Update()
    {
        CheckEnd(); //makes sure the table, deck, hands, etc aren't empty
        switch(turn) //runs different stuff depending on whose turn
        {
            case 1:
                PlayerTurn();
                break;
            case 2:
                if (!compTurnOn)
                {
                    StartCoroutine(ComputerTurn());
                }
                break;
            case 3:
                if (!winOn)
                {
                    StartCoroutine(WinUI(winConsP, koiCallP));
                    winOn = true;
                }
                if (!winUI.activeSelf)
                {
                    winOn = false;
                }
                break;
            case 4:
                if (!winOn)
                {
                    StartCoroutine(WinUI(winConsC, koiCallC));
                    winOn = true;
                }
                if(!winUI.activeSelf)
                {
                    winOn = false;
                }
                break;
            case 5:
                turn = 0;
                RoundAdvance();
                break;
        }
    }

    void Shuffle() //shuffles the deck
    {
        koiCallC = false;
        koiCallP = false; //no one's called koi koi yet
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

    //Restarts a coroutine
    //Needed to redeal when 4 of a suit are on the table
    IEnumerator RestartCoroutine(IEnumerator coroutineToRestart)
    {
        StopCoroutine(coroutineToRestart);
        yield return new WaitForEndOfFrame();
        StartCoroutine(coroutineToRestart);
    }

    IEnumerator Deal()
    {
        /*
         *   Deal out cards two at a time to each players hand and the table
         *      That's how Koi-Koi works
         *   TODO: Animate This better
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

        //wait for fade in
        for (int i = 0; i < 5; i++)
        {
            yield
                return new WaitForEndOfFrame();
        }

        //dealing cards animation
        for (int i = 0; i < 8; i+=2)
        {
            handP[i].GetComponent<Card>().faceUp = true;
            handP[i+1].GetComponent<Card>().faceUp = true;
            for(int j = 0; j < 5; j++)
            {
                handP[i].transform.position = new Vector3
                    (Mathf.Lerp(handP[i].transform.position.x, -7f + i * 1.5f, .25f),
                    Mathf.Lerp(handP[i].transform.position.y, -3.3f, .25f), handP[i].transform.position.z);
                handP[i+1].transform.position = new Vector3
                    (Mathf.Lerp(handP[i+1].transform.position.x, -7f + (i+1) * 1.5f, .25f),
                    Mathf.Lerp(handP[i+1].transform.position.y, -3.3f, .25f), handP[i+1].transform.position.z);
                yield return new WaitForEndOfFrame();
            }
            PlayCardNoise();
            handP[i].transform.position = new Vector3(-7f + i * 1.5f, -3.3f, handP[i].transform.position.z);
            handP[i+1].transform.position = new Vector3(-7f + (i+1) * 1.5f, -3.3f, handP[i+1].transform.position.z);

            yield return new WaitForEndOfFrame();
            for (int j = 0; j < 5; j++)
            {
                handC[i].transform.position = new Vector3
                    (Mathf.Lerp(handC[i].transform.position.x, -7f + i * 1.5f, .25f),
                    Mathf.Lerp(handC[i].transform.position.y, 3.3f, .25f), handC[i].transform.position.z);
                handC[i + 1].transform.position = new Vector3
                    (Mathf.Lerp(handC[i + 1].transform.position.x, -7f + (i + 1) * 1.5f, .25f),
                    Mathf.Lerp(handC[i + 1].transform.position.y, 3.3f, .25f), handC[i + 1].transform.position.z);
                yield return new WaitForEndOfFrame();
            }
            PlayCardNoise();
            handC[i].transform.position = new Vector3(-7f + i * 1.5f, 3.3f, handC[i].transform.position.z);
            handC[i+1].transform.position = new Vector3(-7f + (i+1) * 1.5f, 3.3f, handC[i].transform.position.z);
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
            int doubleCount = 0;
            if (suitCount[i] == 2)
            {
                doubleCount++;
            }
            else if (suitCount[i] == 4)
            {
                winConsC.Add("Full Suit:6");
                turn = 4;
                break;
            }

            if (doubleCount == 4)
            {
                winConsC.Add("Joined Hand: 6");
                turn = 4;
                break;
            }
        }
        suitCount = new int[12];
        foreach (GameObject card in handP) //Player
        {
            suitCount[card.GetComponent<Card>().suit - 1]++;
        }
        for (int i = 0; i < 12; i++)
        {
            int doubleCount = 0;
            if(suitCount[i] == 2)
            {
                doubleCount++;
            }
            else if (suitCount[i] == 4)
            {
                winConsP.Add("Full Suit:6");
                turn = 3;
                break;
            }
            
            if(doubleCount == 4)
            {
                winConsP.Add("Sticky: 6");
                turn = 3;
                break;
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
                Card[] allCards = FindObjectsOfType<Card>();
                foreach (Card oneCard in allCards)
                {
                    Destroy(oneCard.gameObject);
                }
                Shuffle();
                RestartCoroutine(Deal());
                break;
            }
            else if (suitCount[i] == 3)
            {
                group = true;
                GameObject[] suitGroup = new GameObject[3];
                int j = 0;
                foreach (GameObject card in table)
                {
                    if (card.GetComponent<Card>().suit == i+1)
                    {
                        suitGroup[j] = card;
                        j++;
                    }
                }
                foreach(GameObject card in suitGroup) 
                {
                    table.Remove(card);
                }
                if(suitGroup1[0] == null)
                {
                    suitGroup1 = suitGroup;
                }
                else
                {
                    suitGroup2 = suitGroup;
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
    GameObject[] matchingCards = new GameObject[2];
    int selIndex;
    void PlayerTurn() // what occurs when it's the player's turn
    {
        if (matchingCards[1] == null)
        {
            for (int i = 0; i < handP.Length; i++)
            {
                if (handP[i] != null && handP[i].GetComponent<Card>().selected) //looking for matches
                {
                    handP[i].GetComponent<Card>().selected = false;
                    selIndex = i;
                    int count = 0;
                    if (group)
                    {
                        if (suitGroup1[0].GetComponent<Card>().suit == handP[i].GetComponent<Card>().suit)
                        {
                            int pileN = CardSort(handP[i]);
                            pileP[pileN].Add(handP[i]);
                            handP[i].GetComponent<Card>().zone = 5;
                            handP[i] = null;
                            foreach (GameObject lookCard in suitGroup1)
                            {
                                pileN = CardSort(lookCard);
                                pileP[pileN].Add(lookCard);
                                lookCard.GetComponent<Card>().zone = 5;
                            }
                            PlayerPile();
                            NextDeck();
                            CheckEnd();
                            if (turn == 1)
                            {
                                turn = 2;
                            }
                            break;
                        }
                        else if(suitGroup2[0] != null && suitGroup2[0].GetComponent<Card>().suit == handP[i].GetComponent<Card>().suit)
                        {
                            int pileN = CardSort(handP[i]);
                            pileP[pileN].Add(handP[i]);
                            handP[i].GetComponent<Card>().zone = 5;
                            handP[i] = null;
                            foreach (GameObject lookCard in suitGroup2)
                            {
                                pileN = CardSort(lookCard);
                                pileP[pileN].Add(lookCard);
                                lookCard.GetComponent<Card>().zone = 5;
                            }
                            PlayerPile();
                            NextDeck();
                            CheckEnd();
                            if (turn == 1)
                            {
                                turn = 2;
                            }
                            break;
                        }
                    }
                    foreach (GameObject lookCard in table) //figuring out which cards match
                    {
                        if (count == 2) //there can only be 2 possible matches maximum
                        {
                            break;
                        }
                        if (lookCard.GetComponent<Card>().suit == handP[i].GetComponent<Card>().suit)
                        {
                            matchingCards[count] = lookCard;
                            count++;
                        }
                    }
                    if (count == 1) //if there's only one match, just do the match
                    {
                        GameObject lookCard = matchingCards[0];
                        int pileN = CardSort(lookCard);
                        pileP[pileN].Add(lookCard);
                        lookCard.GetComponent<Card>().zone = 5;
                        pileN = CardSort(handP[i]);
                        pileP[pileN].Add(handP[i]);
                        handP[i].GetComponent<Card>().zone = 5;
                        table.Remove(lookCard);
                        handP[i] = null;
                        PlayerPile();
                        NextDeck();
                        CheckEnd();
                        if (turn == 1)
                        {
                            turn = 2;
                        }
                    }
                    else if (count == 0) //if there's no match, add the card to the table
                    {
                        table.Add(handP[i]);
                        handP[i] = null;
                        NextDeck();
                        CheckEnd();
                        if (turn == 1)
                        {
                            turn = 2;
                        }
                    }
                    break;
                }
            }
        }
        else //selecting a card between 2
        {
            for(int i = 0; i < 2; i++)
            {
                if(matchingCards[i].GetComponent<Card>().selectedDouble)
                {
                    GameObject lookCard = matchingCards[i];
                    lookCard.GetComponent<Card>().selectedDouble = false;
                    int pileN = CardSort(lookCard);
                    pileP[pileN].Add(lookCard);
                    lookCard.GetComponent<Card>().zone = 5;
                    pileN = CardSort(handP[selIndex]);
                    pileP[pileN].Add(handP[selIndex]);
                    handP[selIndex].GetComponent<Card>().zone = 5;
                    table.Remove(lookCard);
                    handP[selIndex] = null;
                    matchingCards = new GameObject[2];
                    PlayerPile();
                    NextDeck();
                    CheckEnd();
                    if (turn == 1)
                    {
                        turn = 2;
                    }
                    break;
                }
            }
        }
    }

    bool compTurnOn = false; //so the coroutine only runs one at a time
    IEnumerator ComputerTurn() //what occurs when it's the computer's turn
    {
        compTurnOn = true;
        yield return new WaitForSecondsRealtime(Random.Range(1, 4));
        bool match = false;
        for(int i = 0; i < 8; i++)
        {
            if(handC[i] != null)
            {
                if (group)
                {
                    if (suitGroup1[0].GetComponent<Card>().suit == handC[i].GetComponent<Card>().suit)
                    {
                        int pileN = CardSort(handC[i]);
                        pileC[pileN].Add(handC[i]);
                        handC[i].GetComponent<Card>().zone = 6;
                        handC[i] = null;
                        foreach (GameObject lookCard in suitGroup1)
                        {
                            pileN = CardSort(lookCard);
                            pileC[pileN].Add(lookCard);
                            lookCard.GetComponent<Card>().zone = 6;
                        }
                        ComputerPile();
                        NextDeck();
                        CheckEnd();
                        if (turn == 2)
                        {
                            turn = 1;
                        }
                        compTurnOn = false;
                        break;
                    }
                    else if (suitGroup2[0] != null && suitGroup2[0].GetComponent<Card>().suit == handC[i].GetComponent<Card>().suit)
                    {
                        int pileN = CardSort(handC[i]);
                        pileC[pileN].Add(handC[i]);
                        handC[i].GetComponent<Card>().zone = 6;
                        handC[i] = null;
                        foreach (GameObject lookCard in suitGroup2)
                        {
                            pileN = CardSort(lookCard);
                            pileC[pileN].Add(lookCard);
                            lookCard.GetComponent<Card>().zone = 6;
                        }
                        ComputerPile();
                        NextDeck();
                        CheckEnd();
                        if (turn == 2)
                        {
                            turn = 1;
                        }
                        compTurnOn = false;
                        break;
                    }
                }
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
                    if (turn == 2)
                    {
                        turn = 1;
                    }
                    compTurnOn = false;
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
                    {
                        turn = 1;
                    }
                    compTurnOn = false;
                    break;
                }
            }
        }
    }
    /*
     * TODO: Selecting between 2 cards for player if there's 2 possible matches
     *    low priority because it's not common, hard to notice when it happens, and would be hassal
     */
    void NextDeck() //puts the next card from the deck on the table and adds it to the appropriate player's pile if combod
    {
        GameObject nextCard = (GameObject) deck.Dequeue();
        bool match = false;
        ArrayList[] correctPile;
        if (turn == 1)
        {
            correctPile = pileP;
        }
        else
        {
            correctPile = pileC;
        }
        if (group)
        {
            if (suitGroup1[0].GetComponent<Card>().suit == nextCard.GetComponent<Card>().suit)
            {
                int pileN = CardSort(nextCard);
                correctPile[pileN].Add(nextCard);
                nextCard.GetComponent<Card>().zone = 4 + turn;
                foreach (GameObject card in suitGroup1)
                {
                    pileN = CardSort(card);
                    correctPile[pileN].Add(card);
                    card.GetComponent<Card>().zone = 4 + turn;
                }
                if (turn == 1)
                {
                    PlayerPile();
                }
                else
                {
                    ComputerPile();
                }
                match = true;
            }
            else if (suitGroup2[0] != null && suitGroup2[0].GetComponent<Card>().suit == nextCard.GetComponent<Card>().suit)
            {
                int pileN = CardSort(nextCard);
                correctPile[pileN].Add(nextCard);
                nextCard.GetComponent<Card>().zone = 4 + turn;
                foreach (GameObject card in suitGroup2)
                {
                    pileN = CardSort(card);
                    correctPile[pileN].Add(card);
                    card.GetComponent<Card>().zone = 4 + turn;
                }
                if (turn == 1)
                {
                    PlayerPile();
                }
                else
                {
                    ComputerPile();
                }
                match = true;
            }
        }
        foreach (GameObject lookCard in table)
        {
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
        if (!match)
        {
            table.Add(nextCard);
        }
        TableLayout();
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
                StartCoroutine(MoveCard(nextCard, new Vector3(-4f + .7f * i, 1.2f, nextCard.transform.position.z)));
            }
            else
            {
                StartCoroutine(MoveCard(nextCard, new Vector3(-4.75f + .7f * i, -1.2f, nextCard.transform.position.z)));
            }
            i++;
        }
        if (group)
        {
            int j = 0;
            if (suitGroup1[0].GetComponent<Card>().zone == 4)
            {
                foreach (GameObject nextCard in suitGroup1)
                {
                    nextCard.GetComponent<Card>().faceUp = true;
                    if (i % 2 == 0)
                    {
                        StartCoroutine(MoveCard(nextCard, new Vector3(-4f + (.7f * i) + (.25f * j), 1.2f, nextCard.transform.position.z + j * .001f)));
                    }
                    else
                    {
                        StartCoroutine(MoveCard(nextCard, new Vector3(-4.75f + (.7f * i) + (.25f * j), -1.2f, nextCard.transform.position.z + j * .001f)));
                    }
                    j++;
                }
                i++;
            }
            if (suitGroup2[0] != null && suitGroup2[0].GetComponent<Card>().zone == 4)
            {
                j = 0;
                foreach (GameObject nextCard in suitGroup2)
                {
                    nextCard.GetComponent<Card>().faceUp = true;
                    if (i % 2 == 0)
                    {
                        StartCoroutine(MoveCard(nextCard, new Vector3(-4f + (.7f * i) + (.25f * j), 1.2f, nextCard.transform.position.z)));
                    }
                    else
                    {
                        StartCoroutine(MoveCard(nextCard, new Vector3(-4.75f + (.7f * i) + (.25f * j), -1.2f, nextCard.transform.position.z)));
                    }
                    j++;
                }
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
                if (card.transform.position != new Vector3(5.6f + i * 0.85f, -3f - count * .1f, 0f - count * .01f))
                {
                    StartCoroutine(MoveCard(card, new Vector3(5.6f + i * 0.85f, -3f - count * .1f, 0f - count * .01f)));
                }
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
                if (card.transform.position != new Vector3(5.6f + i * 0.85f, 3f - count * .1f, 0f - count * .01f))
                {
                    StartCoroutine(MoveCard(card, new Vector3(5.6f + i * 0.85f, 3f - count * .1f, 0f - count * .01f)));
                }
                card.GetComponent<Card>().faceUp = true; //cards won are always face up
                count++;
            }
        }
    }

    /*
     * TODO: Making Sake Trash Optional
     * TODO: Winning does something
     */
    void CheckEnd() //checks to see if one of the end game conditions has happened
    {
        ArrayList[] checkPile = null;
        bool checkKoi = false;
        List<string> newWin = new List<string>();
        switch(turn)
        {
            case 1:
                /* checks if the player's hand is empty 
                 * TODO: Check if the computers hand is empty if I ever get to making
                 *  the computer able to deal
                 */
                int countH = 0;
                //makes sure the computer hand is empty cause that means the computer took it's final turn
                //this is weird but it ends up working I think?
                foreach (GameObject c in handC)
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
                checkKoi = koiCallP;
                break;
            case 2:
                checkPile = pileC;
                checkKoi = koiCallC;
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
                int sak = sake ? 1 : 0; //wtf C# why isn't bools 0/1
                newWin.Add("Trash:" + (checkPile[0].Count + sak - 9));
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
                if (checkPile[3].Count == 5)
                {
                    newWin.Add("Five Lights:20");
                }
                else if (moon && crane && blossom)
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
            if(turn == 1)
            {
                if (WinTotal(newWin, checkKoi) > WinTotal(winConsP, koiCallP))
                {
                    turn = 3;
                    winConsP = newWin;
                }
            }
            else if(turn == 2)
            {
                if (WinTotal(newWin, checkKoi) > WinTotal(winConsC, koiCallC))
                {
                    turn = 4;
                    winConsC = newWin;
                }
            }
        }
    }
    /*
     * Separates winCons into a list of winning names and a list of point values (matching order)
     * For Clarification
     * WinSort()[0] is an array of strings containing the win conditions achieved by name
     * WinSort()[1] is a corresponding array of strings containing the values of the win conditions met
     */
    string[][] WinSort(List<string> winToSort) 
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
    int WinTotal(List<string> winToTotal, bool koikoi) //gives a total point value for the current winCons using WinSort()
    {
        int totalPoints = 0;
        string[] values = WinSort(winToTotal)[1];
        foreach(string v in values)
        {
            totalPoints += int.Parse(v);
        }
        if(totalPoints > 7 || koikoi) //double the points if needed
        {
            totalPoints = totalPoints * 2;
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
        bool koi = (Random.Range(0, 20) + WinTotal(winConsC, koiCallC) < 14) ? true : false;
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

    //winning UI coroutine
    public GameObject winUI, koiButton, stopButton;
    public Text winText, totalText;
    public AudioClip winTextSound, totalSound;
    IEnumerator WinUI(List<string> winCons, bool koikoi)
    {
        winUI.SetActive(true);
        winText.text = "";
        totalText.text = "";
        yield return new WaitForEndOfFrame();
        //displays win conditions
        string[][] wins = WinSort(winCons);
        for(int i = 0; i < wins[0].Length; i++)
        {
            AudioManager.Instance.PlayOneShot(winTextSound);
            winText.text += wins[0][i] + "                     " + wins[1][i] + "\n";
            yield return new WaitForSecondsRealtime(.3f);
        }
        //display total points
        AudioManager.Instance.PlayOneShot(totalSound);
        totalText.text = WinTotal(winCons, koikoi).ToString();
        yield return new WaitForSecondsRealtime(.3f);
        //different win things based on who won
        if (turn == 3) //player
        {
            int countH = 0;
            foreach (GameObject c in handP)
            {
                if (c == null)
                {
                    countH++;
                }
            }
            if (countH < 8)
            {
                koiButton.SetActive(true);
                stopButton.SetActive(true);
            }
            else
            {
                scoreP += WinTotal(winConsP, koiCallC);
                playerScore.text = "Modayaal: " + scoreP;
                GameManager.Instance.scoreP = scoreP;
                StartCoroutine(TextZoom(turn, false));
            }
        }
        if (turn == 4) //computer
        {
            yield return new WaitForSecondsRealtime(.3f);
            if(ComputerKoiKoi())
            {
                StartCoroutine(TextZoom(turn, true));
            }
            else
            {
                scoreC += WinTotal(winConsC, koiCallP);
                computerScore.text = GameManager.Instance.opponent + ": " + scoreC;
                GameManager.Instance.scoreC = scoreC;
                StartCoroutine(TextZoom(turn, false));
            }
        }
    }
    //koi-koi button function
    public void KoiClick()
    {
        StartCoroutine(TextZoom(turn, true));
    }
    //What happens when someone koikois
    IEnumerator TextZoom(int pTurn, bool toKoi)
    {
        Image textZoom;
        if (toKoi)
        {
            textZoom = koiType;
        }
        else 
        {
            textZoom = stopType;
        }
        Transform kT = textZoom.transform;
        Vector3 oPos = kT.position;
        Vector3 oSize = kT.localScale;
        kT.position += Vector3.up;
        kT.localScale += (Vector3.up + Vector3.right) * 10;
        AudioManager.Instance.PlayOneShot(typeNoise);
        float lerpSpeed = .12f;
        for (int i = 0; i < 8; i++)
        {
            kT.position = new Vector3(Mathf.Lerp(kT.position.x, oPos.x, lerpSpeed), Mathf.Lerp(kT.position.y, oPos.y, lerpSpeed), oPos.z);
            kT.localScale = new Vector3(Mathf.Lerp(kT.localScale.x, oSize.x, lerpSpeed), Mathf.Lerp(kT.localScale.y, oSize.y, lerpSpeed), oSize.z);
            textZoom.color = new Color(1, 1, 1, Mathf.Lerp(koiType.color.a, 1, lerpSpeed));
            yield return new WaitForEndOfFrame();
        }
        kT.position = oPos;
        kT.localScale = oSize;
        textZoom.color = Color.white;
        yield return new WaitForSecondsRealtime(1.2f);
        //turn off winning UI
        textZoom.color = Color.clear;
        koiButton.SetActive(false);
        stopButton.SetActive(false);
        winUI.SetActive(false);
        winOn = false;
        if (toKoi)
        {
            if (pTurn == 3)
            {
                turn = 2;
                koiCallP = true;
            }
            else if (pTurn == 4)
            {
                turn = 1;
                koiCallC = true;
            }
        }
        else
        {
            RoundAdvance();
        }
    }
    //stop button function
    public void StopClick()
    {
        scoreP += WinTotal(winConsP, koiCallC);
        playerScore.text = "Modayaal: " + scoreP;
        GameManager.Instance.scoreP = scoreP;
        StartCoroutine(TextZoom(turn, false));
    }

    //Advances to rounds 2+
    void RoundAdvance()
    {
        //Delete all cards
        Card[] allCards = FindObjectsOfType<Card>();
        foreach (Card oneCard in allCards)
        {
            Destroy(oneCard.gameObject);
        }
        //Reset variables
        winConsC = new List<string>();
        winConsP = new List<string>();
        table = new ArrayList();
        pileP = new ArrayList[] { new ArrayList(), new ArrayList(), new ArrayList(), new ArrayList() };
        pileC = new ArrayList[] { new ArrayList(), new ArrayList(), new ArrayList(), new ArrayList() };

        //Deal a new game if there hasn't been 3 rounds
        if (GameManager.Instance.progress < 2)
        {
            turn = 0;
            Shuffle();
            StartCoroutine(Deal());
            GameManager.Instance.progress++;
        }
        else if (GameManager.Instance.opponent == "Furfur")
        {
            StartCoroutine(NextScene());
        }
        //TODO: load scenes for different opponents when I write them
    }

    public Image fade;
    IEnumerator NextScene()
    {
        //Reset Variables
        GameManager.Instance.progress = 0;
        GameManager.Instance.scoreC = 0;
        GameManager.Instance.scoreP = 0;

        //Fade Out
        fade.gameObject.SetActive(true);
        yield return new WaitForEndOfFrame();
        for (int i = 0; i < 5; i++)
        {
            fade.color = new Color(fade.color.r, fade.color.g, fade.color.b, Mathf.Lerp(fade.color.a, 1, .25f));
            yield return new WaitForEndOfFrame();
        }
        fade.color = new Color(fade.color.r, fade.color.g, fade.color.b, 1);
        yield return new WaitForEndOfFrame();

        //Select which scene to go to
        if (GameManager.Instance.opponent == "Furfur")
        {
            GameManager.Instance.progress = 0; //for some reason the progress goes up so reset it again just to be safe
            SceneManager.LoadScene(3);
        }
        else if (GameManager.Instance.opponent == "Azazel")
        {

        }
        else if (GameManager.Instance.opponent == "Abyzou")
        {

        }

    }

    //Lerps Card from one point to another
    IEnumerator MoveCard(GameObject card, Vector3 location)
    {
        yield return new WaitForEndOfFrame();
        Transform cardT =  null;
        if (card != null)
        {
            cardT = card.transform;
        }
        for (int i = 0; i < 5; i++)
        {
            try
            {
                card.transform.position = new Vector3(
                    Mathf.Lerp(cardT.position.x, location.x, .2f), Mathf.Lerp(cardT.position.y, location.y, .2f), cardT.position.z);
            }
            catch
            {
                i = 5;
            }
            yield return new WaitForEndOfFrame();
        }
        PlayCardNoise();
        if (cardT != null)
        {
            cardT.position = location;
        }
    }

    void PlayCardNoise()
    {
        AudioManager.Instance.PlayOneShot(cardNoise[(int)Mathf.Floor(Random.Range(0, cardNoise.Length - .01f))]);
    }
}
