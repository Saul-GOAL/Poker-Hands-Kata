namespace PokerHandsTest
{
    public class UniTests
    {
        //Normal Input Black: 2H 3D 5S 9C KD  White: 2C 3H 4S 8C AH
        //              0     1  2  3  4  5     6    7  8  9  10  11

//----------------------------------------------------- RETURN  VALUES ----------------------------------------------

        [Test]
        public void Given_A_Card_S8_As_Strings_Return_Its_Int_Values_And_String_Clubs_Separated()
        {
            //Arrange
            Card card = new Card("S","8");
            var testClub = "S";
            var testValue = 8;

            //Act
            var cardValue = card.FindTheCardValue(card);
            var cardClub = card.FindTheCardClub(card);


            //Assert
            Assert.That(cardClub, Is.EqualTo(testClub));
            Assert.That(cardValue, Is.EqualTo(testValue));
        }

        [Test]
        public void Given_A_Card_DK_As_Strings_Return_Its_Int_Values_And_String_Clubs_Separated()
        {
            //Arrange
            Card card = new Card("D", "K");
            var testValue = 12;
            var testClub = "D";


            //Act
            var cardValue = card.FindTheCardValue(card);
            var cardClub = card.FindTheCardClub(card);


            //Assert
            Assert.That(cardClub, Is.EqualTo(testClub));
            Assert.That(cardValue, Is.EqualTo(testValue));
        }

        //-------------------------------------------------------- HIGHEST  CARD ----------------------------------------------

        [Test]
        public void Given_A_Hand_With_Only_Numbers_Return_The_Highes_card()
        {
            //Arrange
            Player player = new Player();

            List<Card> hand = new List<Card>();
            hand.Add(new Card("H","2"));
            hand.Add(new Card("H","5"));
            hand.Add(new Card("D","3"));
            hand.Add(new Card("S","5"));
            hand.Add(new Card("C","9"));
            hand.Add(new Card("D","4"));

            var expectedHighCard = 9;

            //Act
            int highCard = player.FindTheHighestCard(hand);

            //Assert
            Assert.That(highCard, Is.EqualTo(expectedHighCard));

        }

        [Test]
        public void Given_A_Hand_With_Numbers_And_Figures_Return_The_Highes_card()
        {
            //Arrange
            Player player = new Player();

            List<Card> hand = new List<Card>();
            hand.Add(new Card("H", "2"));
            hand.Add(new Card("H", "5"));
            hand.Add(new Card("D", "K"));
            hand.Add(new Card("S", "5"));
            hand.Add(new Card("C", "9"));
            hand.Add(new Card("D", "4"));

            var expectedHighCard = 12;


            //Act
            int highCard = player.FindTheHighestCard(hand);

            //Assert
            Assert.That(highCard, Is.EqualTo(expectedHighCard));
        }


  //----------------------------------------------------------- CHECK IF ONE PAIR ----------------------------------------------

    }
}