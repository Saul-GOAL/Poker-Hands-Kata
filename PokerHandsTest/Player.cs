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

        public int FindTheHighestCard(List<Card> hand)
        {
            int highestCard = 0;
            int aux = 0;

            foreach (Card card in hand)
            {
                aux = card.FindTheCardValue(card);
                if (aux >= highestCard)
                    highestCard = aux;
            }

            return highestCard;
        }

    }
}