using System.Linq;

namespace PokerHands
{
    public class Player
    {
        private const int NUMBER_SIMILAR_CLUBS = 5;

        public Hand Hand
        { get; }
 
        public int winningCard
        { get; set; }
        public string winningClub
        { get; set; }

        public string playerName
            { get; set; }

        public Player()
        {
            this.Hand = new Hand();
            this.winningCard = 0;
            this.winningClub = "None";
            this.playerName = "None";
        }
 
        public void AddCardAndSortHand(Card card)
        {
            this.Hand.Add(card);
            if (Hand.IsCompleted())
                SortCardsByValue();
        }

        public List<int> SortCardsByValue()
        {
            foreach (Card card in Hand.Cards)
            {
                Hand.cardValues.Add(card.GetValue());
            }
            Hand.cardValues.Sort();

            return Hand.cardValues;
        }

        public int FindTheHighestCard() => Hand.cardValues.Max();

        public bool HasAPair() => PairsOfCardsCounter(2);

        public bool HasTwoPairs() => PairsOfCardsCounter(4);

        public bool HasThreeOfAKind() => CalculateSimilarCards(3);

        public bool HasStraight()
        {
            for (int index = 0; index < Hand.Size() - 1; index++)
            {
                int cardValue = Hand.cardValues[index];
                int nextCard = Hand.cardValues[index + 1];

                if (cardValue + 1 == nextCard)
                {
                    continue;
                }
                return false;
            }
            winningCard = FindTheHighestCard();
            return true;
        }

        public bool HasFlush()
        {
            var handClubs = Hand.Cards.Select(card => card.GetClub()).OrderBy(club => club);

            if (handClubs.Where(club => club == handClubs.First()).Count() == NUMBER_SIMILAR_CLUBS)
            {
                winningCard = FindTheHighestCard();
                winningClub = handClubs.First();
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool HasFullHouse()
        {
            if (HasAPair() && HasThreeOfAKind())
            {
                winningCard = FindTheHighestCard();
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool HasFourOfAKind()
        {
            return CalculateSimilarCards(4);
        }

        public bool HasStraightFlush()
        {
            return (HasStraight() && HasFlush());
        }

        public bool CalculateSimilarCards(int counter)
        {
            for (int index = 0; index < Hand.Size(); index++)
            {
                int value = Hand.GetValue(index);
                if (Hand.CountSimilarCards(value) == counter)
                {
                    winningCard = value;
                    return true;
                }
            }
            return false;
        }

        public bool PairsOfCardsCounter(int counter)
        {
            var pairs = Hand.Cards
                .Select(card => card.GetValue())
                .Where(cardValue => Hand.CountSimilarCards(cardValue) == 2);

            if (pairs.Count() == counter)
            {
                winningCard = pairs.First();
                return true;
            }
            else
            {
                return false;
            }
        }
        //public override string ToString()
        //{
            
        //    return (playerName + " is the winner with a " + poker.GetWinnerHand(winnerHandRankPlayer2, player2));
        //}
    }
}