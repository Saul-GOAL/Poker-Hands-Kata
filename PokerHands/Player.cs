namespace PokerHands
{
    public class Player
    {
        public List<Card> cardValue
        { get; set; }
        public List<int> cardValues
        { get; set; }

        public int winningCard
        { get; set; }
        public string winningClub
        { get; set; }

        public string playerName
            { get; set; }

        public Player()
        {
            this.cardValue = new List<Card>();
            this.cardValues = new List<int>();
            this.winningCard = 0;
            this.winningClub = "None";
            this.playerName = "None";
        }
 
        public void TakeCard(Card card)
        {
            this.cardValue.Add(card);
            if(cardValue.Count==5)
                SortCards();
        }

        public List<int> SortCards()
        {
            foreach (Card card in cardValue)
            {
                card.FindTheCardValue();
                cardValues.Add(card.value);
            }
            cardValues.Sort();

            return cardValues;
        }

        public int FindTheHighestCard()
        {
            return cardValues.Last();
        }

        public bool IsAPair()
        {
            return PairsOfCardsCounter(2);
        }

        public bool IsTwoPairs()
        {
           return PairsOfCardsCounter(4);
        }

        public bool IsThreeOfAKind()
        {
            return RepeatCardCounter(3);
        }

        public bool IsStraight()
        {
            for (int i = 0; i < this.cardValue.Count - 1; i++)
            {
                int cardValue = cardValues[i];
                int nextCard = cardValues[i + 1];

                if (cardValue + 1 != nextCard)
                {
                        return false;
                }
            }
            winningCard = FindTheHighestCard();
            return true;
        }

        public bool IsFlush()
        {
            List<string> handClubs = new List<string>();

            foreach (Card card in this.cardValue)
            {
                handClubs.Add(card.FindTheCardClub());
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
                return false;
            }
        }

        public bool IsFullHouse()
        {
            if (IsAPair() && IsThreeOfAKind())
            {
                winningCard = FindTheHighestCard();
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsFourOfAKind()
        {
            return RepeatCardCounter(4);
        }

        public bool IsStraightFlush()
        {
            return (IsStraight() && IsFlush());
        }

        public bool RepeatCardCounter(int counter)
        {
            for (int i = 0; i < cardValue.Count; i++)
            {
                int value = cardValue[i].value;
                if (this.cardValue.FindAll(card => card.value.Equals(value)).Count == counter)
                {
                    winningCard = cardValue[i].value;
                    return true;
                }
            }
            return false;
        }

        public bool PairsOfCardsCounter(int counter)
        {
            List<int> pairs = new List<int>();

            for (int i = 0; i < cardValue.Count; i++)
            {
                int value = cardValue[i].value;
                if (this.cardValue.FindAll(card => card.value.Equals(value)).Count == 2) pairs.Add(this.cardValue[i].value);
            }
            if (pairs.Count == counter)
            {
                winningCard = pairs[0];
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}