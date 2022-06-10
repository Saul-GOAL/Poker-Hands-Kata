namespace PokerHands
{
    public class Player
    {
        public List<Card> cards
        { get; set; }
        public List<int> handValues
        { get; set; }

        public int winningCard
        { get; set; }
        public string winningClub
        { get; set; }

        public string name
            { get; set; }

        public Player()
        {
            this.cards = new List<Card>();
            this.handValues = new List<int>();
            this.winningCard = 0;
            this.winningClub = "None";
            this.name = "None";
        }

//------------------------------------------------------------- CARD  MANAGEMENT ---------------------------------------------------
       
        public void TakeCard(Card card)
        {
            this.cards.Add(card);
            if(cards.Count==5)
                SortCards();
        }

        public int FindTheHighestCard()
        {
            return handValues.Last();
        }

        public List<int> SortCards()
        {

            foreach (Card card in cards)
            {
                card.FindTheCardValue();
                handValues.Add(card.value);
            }
            handValues.Sort();

            return handValues;
        }

//------------------------------------------------------------ WINNING  HAND  CHECKER ----------------------------------------------

        public bool IsAPair()
        {
            int aux = 0;
            int count = 0;

            List<int> pairs = new List<int>();

            foreach (int card in handValues)
            {
                if (card == aux)
                {
                    count++; 
                }
                else
                {
                    if (count == 1)
                    {
                        pairs.Add(aux);
                        winningCard = aux;
                    }    
                    aux = card;
                    count = 0;
                }
            }
            

            if (pairs.Count >= 1)
                return true;
            else
            {
                winningCard = FindTheHighestCard();
                return false;
            }
              

        }

        public bool IsTwoPairs()
        {
            int aux = 0;
            int numPairs = 0;

            foreach (int card in handValues)
                {
                    if (card == aux)
                    {
                    aux = 0;
                    numPairs++;
                    winningCard = card;
                } 
                    else
                        aux = card;
                }
            
            if (numPairs > 1)
                return true;
            else
            {
                winningCard = FindTheHighestCard();
                return false;
            }
        }

        public bool IsThreeOfAKind()
        {
            int aux = 0;
            int count = 0;
            int trio = 0;

            foreach (int card in handValues)
            {
                if (card == aux)
                {
                    count++;
                    if (count == 2)
                    {
                        trio++;
                        winningCard = card;
                    }
                }
                        
                else
                {
                    aux = card;
                    count = 0;
                }
            }

            if (trio!=0)
                return true;
            else
            {
                winningCard = FindTheHighestCard();
                return false;
            }
        }

        public bool IsStraight()
        {
            for (int i = 0; i < this.cards.Count - 1; i++)
            {
                int card = handValues[i];
                int nextCard = handValues[i + 1];

                if (card + 1 != nextCard)
                {
                        winningCard = FindTheHighestCard();
                        return false;
                }
            }
            winningCard = FindTheHighestCard();
            return true;
        }

        public bool IsFlush()
        {
            List<string> handClubs = new List<string>();

            foreach (Card card in this.cards)
            {
                handClubs.Add(card.club);
            }
            handClubs.Sort();

            string aux = handClubs[0];
            int count = 0;

            foreach (string club in handClubs)
            {
                if (club == aux)
                {
                    count++;
                }
            }

            if (count == 5)
            {
                winningCard = FindTheHighestCard();
                winningClub = handClubs[0];
                return true;
            }
            else
            {
                winningCard = FindTheHighestCard();
                return false;
            }
        }

        public bool IsFullHouse()
        {
            if (IsAPair() && IsThreeOfAKind())
            {
                return true;
            }
            else
            {
                winningCard = FindTheHighestCard();
                return false;
            }
        }

        public bool IsFourOfAKind()
        {
            int aux = 0;
            int count = 0;
            int poker = 0;

            foreach (int card in handValues)
            {
                if (card == aux)
                {
                    count++;
                    if (count == 3)
                    {
                        poker++;
                        winningCard = card;
                    }
                }
                else
                {
                    aux = card;
                    count = 0;
                } 
            }
            if (poker > 0)
                return true;
            else
            {
                winningCard = FindTheHighestCard();
                return false;
            }
        }

        public bool IsStraightFlush()
        {
            return (IsStraight() && IsFlush());
        }

//---------------------------------------------------------- WINNING  HAND  MANAGEMENT ---------------------------------------------
       
        public int WinnerHandRanking()
        {
            handValues = SortCards();

            if (IsStraightFlush())
                return 1;
            else if (IsFourOfAKind())
                return 2;
            else if (IsFullHouse())
                return 3;
            else if (IsFlush())
                return 4;
            else if (IsStraight())
                return 5;
            else if (IsThreeOfAKind())
                return 6;
            else if (IsTwoPairs())
                return 7;
            else if (IsAPair())
                return 8;
            else if (FindTheHighestCard() != 0)
                return 9;
            return 0;
        }
    }
}