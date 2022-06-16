namespace PokerHands
{
    public class Card
    {
        private string club
        { get; set; }
        private string figure
        { get; set; }

        public int value = 0;

        public Card(string card)
        {
            this.figure = card.Substring(0,1);
            this.club = card.Substring(1);

        }

        public string FindTheCardClub()
        {
            return club;
        }

        public string FindTheCardFigure()
        {
            return figure;
        }

        public void FindTheCardValue()
        {
            value = ConversorFigureValue();
        }

        public int ConversorFigureValue()
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