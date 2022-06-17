namespace PokerHands

{
    public class Hand
    {
        public List<Card> Cards { get; } = new List<Card>();
        public List<int> cardValues{ get; } = new List<int>();

        //public IEnumerable<int> CardValues => Cards.Select(card => card.GetValue());

        internal void Add(Card card)
        {
           Cards.Add(card);
        }

        internal bool IsCompleted() => Size() == 5;

        internal int Size() => Cards.Count;

        internal int GetValue(int i) => Cards[i].GetValue();

        internal int CountSimilarCards(int value) => Cards.FindAll(card => card.GetValue() == value).Count;
    }
}