namespace PokerHandsTest
{
    public class UniTests
    {
        //Normal Input Black: 2H 3D 5S 9C KD  White: 2C 3H 4S 8C AH
        //              0     1  2  3  4  5     6    7  8  9  10  11

        [Test]
        public void Given_A_Card_8S_Return_Its_Values_Separated()
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
        public void Given_A_Card_KD_Return_Its_Values_Separated()
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
    }
}