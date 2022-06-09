namespace PokerHandsTest
{
    public class Card
    {
        public string club
        { get; set; }
        public string value
        { get; set; }

        public Card(string club, string value)
        {
            this.club = club;
            this.value = value;
        }

        public object FindTheCardClub()
        {
            return club;
        }
        public object FindTheCardFigure()
        {
            return value;
        }

        public int FindTheCardValue()
        {
            if (value == "A")
                return 13;
            else if (value == "K")
                return 12;
            else if (value == "Q")
                return 11;
            else if (value == "J")
                return 10;
            else
                return Int32.Parse(value);
        }
    }
}