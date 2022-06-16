using PokerHands;

namespace PokerHandsTest
{
    public class UniTestsPlayer
    {

        [TestCase("2H", "5H", "3D", "5S", "9C", 9)]
        [TestCase("2H", "5H", "3D", "KS", "9C", 12)]
        public void Given_A_Full_Hand_Of_Cards_It_Returns_The_Highest_Value_Card(string ex_card1, string ex_card2,
            string ex_card3, string ex_card4, string ex_card5, int expectedHighCard)
        {
            //Arrange
            Player player = new Player();

            Card card1 = new Card(ex_card1);
            Card card2 = new Card(ex_card2);
            Card card3 = new Card(ex_card3);
            Card card4 = new Card(ex_card4);
            Card card5 = new Card(ex_card5);

            player.TakeCard(card1);
            player.TakeCard(card2);
            player.TakeCard(card3);
            player.TakeCard(card4);
            player.TakeCard(card5);

            //Act
            int highCard = player.FindTheHighestCard();

            //Assert
            Assert.That(highCard, Is.EqualTo(expectedHighCard));

        }


        [TestCase("2H", "5H", "3D", "KS", "3C",true)]
        [TestCase("2H", "5H", "3D", "KS", "9C",false)]
        public void Given_A_Full_Hand_Of_Cards_It_Returns_If_There_Are_A_Pair_On_It(string ex_card1, string ex_card2,
            string ex_card3, string ex_card4, string ex_card5, bool expectedResult)
        {
            //Arrange
            Player player = new Player();

            Card card1 = new Card(ex_card1);
            Card card2 = new Card(ex_card2);
            Card card3 = new Card(ex_card3);
            Card card4 = new Card(ex_card4);
            Card card5 = new Card(ex_card5);

            player.TakeCard(card1);
            player.TakeCard(card2);
            player.TakeCard(card3);
            player.TakeCard(card4);
            player.TakeCard(card5);

            //Act
            bool haveAnyPairs = player.IsAPair();

            //Assert
            Assert.That(haveAnyPairs, Is.EqualTo(expectedResult));
        }


        [TestCase("KH", "5H", "3D", "KS", "3C", true)]
        [TestCase("2H", "5H", "3D", "KS", "9C", false)]
        [TestCase("2H", "5H", "3D", "QS", "3C", false)]
        public void Given_A_Full_Hand_Of_Cards_It_Returns_If_There_Are_Two_Pairs_On_It(string ex_card1, string ex_card2,
            string ex_card3, string ex_card4, string ex_card5, bool expectedResult)
        {
            //Arrange
            Player player = new Player();

            Card card1 = new Card(ex_card1);
            Card card2 = new Card(ex_card2);
            Card card3 = new Card(ex_card3);
            Card card4 = new Card(ex_card4);
            Card card5 = new Card(ex_card5);

            player.TakeCard(card1);
            player.TakeCard(card2);
            player.TakeCard(card3);
            player.TakeCard(card4);
            player.TakeCard(card5);

            //Act
            bool haveTwoPairs = player.IsTwoPairs();

            //Assert
            Assert.That(haveTwoPairs, Is.EqualTo(expectedResult));
        }


        [TestCase("JH", "5H", "JD", "JS", "9C", true)]
        [TestCase("2H", "5H", "KD", "KS", "9C", false)]
        [TestCase("3H", "5H", "4D", "JS", "9C", false)]
        public void Given_A_Full_Hand_Of_Cards_It_Return_If_There_Are_Three_Of_A_Kind_On_It(string ex_card1, string ex_card2,
            string ex_card3, string ex_card4, string ex_card5, bool expectedResult)
        {
            //Arrange
            Player player = new Player();

            Card card1 = new Card(ex_card1);
            Card card2 = new Card(ex_card2);
            Card card3 = new Card(ex_card3);
            Card card4 = new Card(ex_card4);
            Card card5 = new Card(ex_card5);

            player.TakeCard(card1);
            player.TakeCard(card2);
            player.TakeCard(card3);
            player.TakeCard(card4);
            player.TakeCard(card5);

            //Act
            bool haveThreeOfAKind = player.IsThreeOfAKind();

            //Assert
            Assert.That(haveThreeOfAKind, Is.EqualTo(expectedResult));
        }


        [TestCase("JH", "AH", "QD", "KS", "9C", true)]
        [TestCase("2H", "5H", "KD", "KS", "9C", false)]
        public void Given_A_Full_Hand_Of_Cards_It_Return_If_There_Is_A_Straight_On_It(string ex_card1, string ex_card2,
            string ex_card3, string ex_card4, string ex_card5, bool expectedResult)
        {
            //Arrange
            Player player = new Player();

            Card card1 = new Card(ex_card1);
            Card card2 = new Card(ex_card2);
            Card card3 = new Card(ex_card3);
            Card card4 = new Card(ex_card4);
            Card card5 = new Card(ex_card5);

            player.TakeCard(card1);
            player.TakeCard(card2);
            player.TakeCard(card3);
            player.TakeCard(card4);
            player.TakeCard(card5);

            //Act
            bool haveStraight = player.IsStraight();

            //Assert
            Assert.That(haveStraight, Is.EqualTo(expectedResult));
        }


        [TestCase("2H", "5H", "3H", "KH", "9H", true)]
        [TestCase("2H", "5H", "KD", "KS", "9C", false)]
        public void Given_A_Full_Hand_Of_Cards_It_Returns_If_There_Is_A_Flush_On_It(string ex_card1, string ex_card2,
            string ex_card3, string ex_card4, string ex_card5, bool expectedResult)
        {
            //Arrange
            Player player = new Player();

            Card card1 = new Card(ex_card1);
            Card card2 = new Card(ex_card2);
            Card card3 = new Card(ex_card3);
            Card card4 = new Card(ex_card4);
            Card card5 = new Card(ex_card5);

            player.TakeCard(card1);
            player.TakeCard(card2);
            player.TakeCard(card3);
            player.TakeCard(card4);
            player.TakeCard(card5);

            //Act
            bool haveFlush = player.IsFlush();

            //Assert
            Assert.That(haveFlush, Is.EqualTo(expectedResult));
        }


        [TestCase("2H", "5H", "2C", "5S", "5C", true)]
        [TestCase("2H", "5H", "KD", "KS", "9C", false)]
        [TestCase("2H", "5H", "KD", "4S", "9C", false)]
        public void Given_A_Full_Hand_Of_Cards_It_Return_If_There_Is_A_FullHouse_On_It(string ex_card1, string ex_card2,
            string ex_card3, string ex_card4, string ex_card5, bool expectedResult)
        {
            //Arrange
            Player player = new Player();

            Card card1 = new Card(ex_card1);
            Card card2 = new Card(ex_card2);
            Card card3 = new Card(ex_card3);
            Card card4 = new Card(ex_card4);
            Card card5 = new Card(ex_card5);

            player.TakeCard(card1);
            player.TakeCard(card2);
            player.TakeCard(card3);
            player.TakeCard(card4);
            player.TakeCard(card5);

            //Act
            bool haveFullHouse = player.IsFullHouse();

            //Assert
            Assert.That(haveFullHouse, Is.EqualTo(expectedResult));
        }


        [TestCase("2H", "5H", "5D", "5S", "5C", true)]
        [TestCase("2H", "5H", "KD", "KS", "9C", false)]
        public void Given_A_Full_Hand_Of_Cards_It_Returns_If_There_Is_Four_Of_A_Kind_On_It(string ex_card1, string ex_card2,
            string ex_card3, string ex_card4, string ex_card5, bool expectedResult)
        {
            //Arrange
            Player player = new Player();

            Card card1 = new Card(ex_card1);
            Card card2 = new Card(ex_card2);
            Card card3 = new Card(ex_card3);
            Card card4 = new Card(ex_card4);
            Card card5 = new Card(ex_card5);

            player.TakeCard(card1);
            player.TakeCard(card2);
            player.TakeCard(card3);
            player.TakeCard(card4);
            player.TakeCard(card5);

            //Act
            bool haveFourOfAKind = player.IsFourOfAKind();

            //Assert
            Assert.That(haveFourOfAKind, Is.EqualTo(expectedResult));
        }


        [TestCase("9H", "KH", "QH", "AH", "JH", true)]
        [TestCase("2H", "5H", "KD", "KS", "9C", false)]
        public void Given_A_Full_Hand_Of_Cards_It_Returns_If_There_Is_A_Straight_Flush_On_It(string ex_card1, string ex_card2,
            string ex_card3, string ex_card4, string ex_card5, bool expectedResult)
        {
            //Arrange
            Player player = new Player();

            Card card1 = new Card(ex_card1);
            Card card2 = new Card(ex_card2);
            Card card3 = new Card(ex_card3);
            Card card4 = new Card(ex_card4);
            Card card5 = new Card(ex_card5);

            player.TakeCard(card1);
            player.TakeCard(card2);
            player.TakeCard(card3);
            player.TakeCard(card4);
            player.TakeCard(card5);

            //Act
            bool haveStraightFlush = player.IsStraightFlush();

            //Assert
            Assert.That(haveStraightFlush, Is.EqualTo(expectedResult));
        }


        [TestCase("9H", "KH", "QH", "KS", "KC", true)]
        [TestCase("2H", "5H", "KD", "KS", "9C", false)]
        public void Given_A_Full_Hand_Of_Cards_It_Returns_If_There_Are_Repeated_Cards_On_It(string ex_card1, string ex_card2,
            string ex_card3, string ex_card4, string ex_card5, bool expectedResult)
        {
            //Arrange
            Player player = new Player();

            Card card1 = new Card(ex_card1);
            Card card2 = new Card(ex_card2);
            Card card3 = new Card(ex_card3);
            Card card4 = new Card(ex_card4);
            Card card5 = new Card(ex_card5);

            player.TakeCard(card1);
            player.TakeCard(card2);
            player.TakeCard(card3);
            player.TakeCard(card4);
            player.TakeCard(card5);

            //Act
            bool haveThreeOfAKind = player.RepeatCardCounter(3);

            //Assert
            Assert.That(haveThreeOfAKind, Is.EqualTo(expectedResult));
        }

    }
}



