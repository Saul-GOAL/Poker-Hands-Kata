namespace PokerHandsTest
{
    public class Player
    {
        public List<Card> cards
        {
            get; set;
        }
        public Card winningCard
        {
            get; set;
        }

        public Player()
        {
            this.cards = new List<Card>();
            this.winningCard = null;
        }

        public void TakeCard(Card card)
        {
            this.cards.Add(card);
        }

        public int FindTheHighestCard()
        {
            int highestCard = 0;
            int aux = 0;

            foreach (Card card in this.cards)
            {
                aux = card.FindTheCardValue(card);
                if (aux >= highestCard)
                    highestCard = aux;
            }

            return highestCard;
        }

        internal bool IsThereAnyPairs()
        {
            List<int> handValues = new List<int>();

            int aux = 0;

            foreach (Card card in this.cards)
            {
                handValues.Add(card.FindTheCardValue(card));
            }

            handValues.Sort();

            foreach (int card in handValues)
            {
                if (card == aux)
                    return true;
                else
                    aux = card;
            }
            return false;

        }

        internal bool IsThereTwoPairs()
        {
                List<int> handValues = new List<int>();

                int aux = 0;
                int numPairs = 0;

                foreach (Card card in this.cards)
                {
                    handValues.Add(card.FindTheCardValue(card));
                }

                handValues.Sort();

                foreach (int card in handValues)
                {
                    if (card == aux)
                    {
                    aux = 0;
                    numPairs++;
                }
                       
                    else
                        aux = card;
                }
            
            if (numPairs > 1)
                return true;
            else
                return false;
        }

        internal bool IsThereAnyTrio()
        {
            List<int> handValues = new List<int>();

            int aux = 0;
            int same = 0;

            foreach (Card card in this.cards)
            {
                handValues.Add(card.FindTheCardValue(card));
            }

            handValues.Sort();

            foreach (int card in handValues)
            {
                if (card == aux)
                {
                    same += 1;
                }
                else
                    aux = card;

                if (same == 2)
                    return true;
            }
            return false;
        }

        internal bool IsStraight()
        {
            List<int> handValues = new List<int>();


            foreach (Card card in this.cards)
            {
                handValues.Add(card.FindTheCardValue(card));
            }

            handValues.Sort();

            for (int i = 0; i < this.cards.Count - 1; i++)
            {
                int card = handValues[i];
                int nextCard = handValues[i + 1];

                if (card + 1 != nextCard)
                {
                    return false;
                }
            }
            return true;
        }

        internal bool IsFlush()
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
                return true;
            else
                return false;
        }
    }
}