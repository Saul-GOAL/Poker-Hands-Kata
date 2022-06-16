using PokerHands;

namespace PokerHandsTest
{
    public class UniTestsCard
    {
        [TestCase("8S", "S", 8)]
        [TestCase("KD", "D", 12)]
            public void Given_A_Card_As_Strings_It_Returns_Its_Separate_Int_Value(string cardName, string testClub, int expectedValue)
            {
            //Arrange
            Card card = new Card(cardName);

            //Act
            card.FindTheCardValue();
            var cardValue = card.value;

            //Assert
            Assert.That(cardValue, Is.EqualTo(expectedValue));
            }

        [TestCase("8S", "S")]
        [TestCase("KD", "D")]
        public void Given_A_Card_As_Strings_It_Returns_Its_Separate_String_Club(string cardName, string expectedClub)
        {
            //Arrange
            Card card = new Card(cardName);

            //Act
            var cardClub = card.FindTheCardClub();

            //Assert
            Assert.That(cardClub, Is.EqualTo(expectedClub));
        }

    }
}