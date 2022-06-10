namespace PokerHands
{
    public class Card
    {
        public string club
        { get; set; }
        public string figure
        { get; set; }

        public int value = 0;

        public Card(string card)
        {
            this.figure = card.Substring(0,1);
            this.club = card.Substring(1);

        }

        public object FindTheCardClub()
        {
            return club;
        }
        public object FindTheCardFigure()
        {
            return figure;
        }

        public void FindTheCardValue()
        {
            value = ConversorFigureValue();
        }

        private int ConversorFigureValue()
        {
            if (figure == "A")
                return 13;
            else if (figure == "K")
                return 12;
            else if (figure == "Q")
                return 11;
            else if (figure == "J")
                return 10;
            else
                return Int32.Parse(figure);
        }
    }
}