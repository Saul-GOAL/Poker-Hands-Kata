namespace PokerHands
{
    public class Card
    {
        private string club;
        
        private string figure;

        public Card(string card)
        {
            this.figure = card.Substring(0,1);
            this.club = card.Substring(1);

        }

        public string GetClub()
        {
            return club;
        }

        public string GetFigure()
        {
            return figure;
        }

        public int GetValue()
        {
            return ConversorFigureValue();
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