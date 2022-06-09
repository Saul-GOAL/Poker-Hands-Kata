namespace PokerHandsTest
{
    public class Player
    {
        public List<Card> cards
        { get; set; }
        public int winningCard
        { get; set; }
        public string name
            { get; set; }


        public Player()
        {
            this.cards = new List<Card>();
            this.winningCard = 0;
            this.name = "";
        }

        public void TakeCard(Card card)
        {
            this.cards.Add(card);
        }

        public int FindTheHighestCard(List<int> handValues)
        {
            return handValues.Last();
        }

        public bool IsThereAnyPairs()
        {
            int aux = 0;
            int count = 0;

            List<int> handValues = SortCards();

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
                winningCard = FindTheHighestCard(handValues);
                return false;
            }
              

        }

        public bool IsThereTwoPairs()
        {
            List<int> handValues = SortCards();
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
                winningCard = FindTheHighestCard(handValues);
                return false;
            }
        }

        public bool IsThereAnyTrio()
        {
            List<int> handValues = SortCards();

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
                winningCard = FindTheHighestCard(handValues);
                return false;
            }
        }

        public bool IsStraight()
        {
            List<int> handValues = SortCards();

            for (int i = 0; i < this.cards.Count - 1; i++)
            {
                int card = handValues[i];
                int nextCard = handValues[i + 1];

                if (card + 1 != nextCard)
                {
                        winningCard = FindTheHighestCard(handValues);
                        return false;
                }
            }
            winningCard = FindTheHighestCard(handValues);
            return true;
        }

        public bool IsFlush()
        {
            List<string> handClubs = new List<string>();
            List<int> handValues = SortCards();

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
                winningCard = FindTheHighestCard(handValues);
                return true;
            }
            else
            {
                winningCard = FindTheHighestCard(handValues);
                return false;
            }
        }

        public bool IsFullHouse()
        {
            List<int> handValues = SortCards();
            if (IsThereAnyPairs() && IsThereAnyTrio())
            {
                return true;
            }
            else
            {
                winningCard = FindTheHighestCard(handValues);
                return false;
            }
        }

        public bool IsFourOfAKind()
        {
            List<int> handValues = SortCards();

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
                winningCard = FindTheHighestCard(handValues);
                return false;
            }
        }

        public bool IsStraightFlush()
        {
            return (IsStraight() && IsFlush());
        }

        public List<int> SortCards()
        {
            List<int> handValues = new List<int>();

            foreach (Card card in cards)
            {
                handValues.Add(card.FindTheCardValue());
            }
            handValues.Sort();

            return handValues;
        }
    }
}