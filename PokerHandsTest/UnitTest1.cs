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
            Card card = new Card("S", "8");
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

            Card card1 = new Card("H", "2");
            Card card2 = new Card("H", "5");
            Card card3 = new Card("D", "3");
            Card card4 = new Card("S", "5");
            Card card5 = new Card("C", "9");
            player.TakeCard(card1);
            player.TakeCard(card2);
            player.TakeCard(card3);
            player.TakeCard(card4);
            player.TakeCard(card5);

            var expectedHighCard = 9;

            //Act
            int highCard = player.FindTheHighestCard();

            //Assert
            Assert.That(highCard, Is.EqualTo(expectedHighCard));
        }

        [Test]
        public void Given_A_Hand_With_Numbers_And_Figures_Return_The_Highes_card()
        {
            //Arrange
            Player player = new Player();

            Card card1 = new Card("H", "2");
            Card card2 = new Card("H", "5");
            Card card3 = new Card("D", "3");
            Card card4 = new Card("S", "K");
            Card card5 = new Card("C", "9");
            player.TakeCard(card1);
            player.TakeCard(card2);
            player.TakeCard(card3);
            player.TakeCard(card4);
            player.TakeCard(card5);

            var expectedHighCard = 12;

            //Act
            int highCard = player.FindTheHighestCard();

            //Assert
            Assert.That(highCard, Is.EqualTo(expectedHighCard));
        }

//----------------------------------------------------------- CHECK IF ONE PAIR ----------------------------------------------

        [Test]
        public void Given_A_Hand_With_A_Pair_On_It_Return_If_There_Are_Any_Pairs()
        {
            //Arrange
            Player player = new Player();

            Card card1 = new Card("H", "2");
            Card card2 = new Card("H", "5");
            Card card3 = new Card("D", "3");
            Card card4 = new Card("S", "K");
            Card card5 = new Card("C", "3");
            player.TakeCard(card1);
            player.TakeCard(card2);
            player.TakeCard(card3);
            player.TakeCard(card4);
            player.TakeCard(card5);

            //Act
            bool haveAnyPairs = player.IsThereAnyPairs();

            //Assert
            Assert.IsTrue(haveAnyPairs);
        }

        [Test]
        public void Given_A_Hand_With_No_Pairs_On_It_Return_If_There_Are_Any_Pairs()
        {
            //Arrange
            Player player = new Player();

            Card card1 = new Card("H", "2");
            Card card2 = new Card("H", "5");
            Card card3 = new Card("D", "3");
            Card card4 = new Card("S", "K");
            Card card5 = new Card("C", "9");
            player.TakeCard(card1);
            player.TakeCard(card2);
            player.TakeCard(card3);
            player.TakeCard(card4);
            player.TakeCard(card5);

            //Act
            bool haveAnyPairs = player.IsThereAnyPairs();

            //Assert
            Assert.IsFalse(haveAnyPairs);
        }


//----------------------------------------------------------- CHECK IF TWO PAIRS ----------------------------------------------

        [Test]
        public void Given_A_Hand_With_No_Pairs_On_It_Return_If_There_Are_Two_Pairs()
        {
            //Arrange
            Player player = new Player();

            Card card1 = new Card("H", "2");
            Card card2 = new Card("H", "5");
            Card card3 = new Card("D", "3");
            Card card4 = new Card("S", "K");
            Card card5 = new Card("C", "9");
            player.TakeCard(card1);
            player.TakeCard(card2);
            player.TakeCard(card3);
            player.TakeCard(card4);
            player.TakeCard(card5);

            //Act
            bool haveTwoPairs = player.IsThereTwoPairs();

            //Assert
            Assert.IsFalse(haveTwoPairs);
        }

        [Test]
        public void Given_A_Hand_With_One_Pair_On_It_Return_If_There_Are_Two_Pairs()
        {
            //Arrange
            Player player = new Player();

            Card card1 = new Card("H", "2");
            Card card2 = new Card("H", "5");
            Card card3 = new Card("D", "3");
            Card card4 = new Card("S", "K");
            Card card5 = new Card("C", "3");
            player.TakeCard(card1);
            player.TakeCard(card2);
            player.TakeCard(card3);
            player.TakeCard(card4);
            player.TakeCard(card5);

            //Act
            bool haveTwoPairs = player.IsThereTwoPairs();

            //Assert
            Assert.IsFalse(haveTwoPairs);
        }

        [Test]
        public void Given_A_Hand_With_Two_Pairs_On_It_Return_If_There_Are_Two_Pairs()
        {
            //Arrange
            Player player = new Player();

            Card card1 = new Card("H", "2");
            Card card2 = new Card("H", "K");
            Card card3 = new Card("D", "3");
            Card card4 = new Card("S", "K");
            Card card5 = new Card("C", "3");
            player.TakeCard(card1);
            player.TakeCard(card2);
            player.TakeCard(card3);
            player.TakeCard(card4);
            player.TakeCard(card5);

            //Act
            bool haveTwoPairs = player.IsThereTwoPairs();

            //Assert
            Assert.IsTrue(haveTwoPairs);
        }

//----------------------------------------------------------- CHECK IF TRIO ----------------------------------------------

        [Test]
        public void Given_A_Hand_With_No_Trio_On_It_Return_If_There_Is_A_Trio()
        {
            //Arrange
            Player player = new Player();

            Card card1 = new Card("H", "2");
            Card card2 = new Card("H", "5");
            Card card3 = new Card("D", "3");
            Card card4 = new Card("S", "K");
            Card card5 = new Card("C", "9");
            player.TakeCard(card1);
            player.TakeCard(card2);
            player.TakeCard(card3);
            player.TakeCard(card4);
            player.TakeCard(card5);

            //Act
            bool haveTrio = player.IsThereAnyTrio();

            //Assert
            Assert.IsFalse(haveTrio);
        }

        [Test]
        public void Given_A_Hand_With_A_Pair_On_It_Return_If_There_Is_A_Trio()
        {
            //Arrange
            Player player = new Player();

            Card card1 = new Card("H", "2");
            Card card2 = new Card("H", "5");
            Card card3 = new Card("D", "K");
            Card card4 = new Card("S", "K");
            Card card5 = new Card("C", "9");
            player.TakeCard(card1);
            player.TakeCard(card2);
            player.TakeCard(card3);
            player.TakeCard(card4);
            player.TakeCard(card5);

            //Act
            bool haveTrio = player.IsThereAnyTrio();

            //Assert
            Assert.IsFalse(haveTrio);
        }

        [Test]
        public void Given_A_Hand_With_A_Trio_On_It_Return_If_There_Is_A_Trio()
        {
            //Arrange
            Player player = new Player();

            Card card1 = new Card("H", "J");
            Card card2 = new Card("H", "5");
            Card card3 = new Card("D", "J");
            Card card4 = new Card("S", "J");
            Card card5 = new Card("C", "9");
            player.TakeCard(card1);
            player.TakeCard(card2);
            player.TakeCard(card3);
            player.TakeCard(card4);
            player.TakeCard(card5);

            //Act
            bool haveTrio = player.IsThereAnyTrio();

            //Assert
            Assert.IsTrue(haveTrio);
        }

//----------------------------------------------------------- CHECK IF SRAIGHT ----------------------------------------------

        [Test]
        public void Given_A_Hand_With_No_Straight_On_It_Return_If_There_Is_A_Straight()
        {
            //Arrange
            Player player = new Player();

            Card card1 = new Card("H", "2");
            Card card2 = new Card("H", "5");
            Card card3 = new Card("D", "K");
            Card card4 = new Card("S", "K");
            Card card5 = new Card("C", "9");
            player.TakeCard(card1);
            player.TakeCard(card2);
            player.TakeCard(card3);
            player.TakeCard(card4);
            player.TakeCard(card5);

            //Act
            bool haveStraight = player.IsStraight();

            //Assert
            Assert.IsFalse(haveStraight);
        }

        [Test]
        public void Given_A_Hand_With_A_Straight_On_It_Return_If_There_Is_A_Straight()
        {
            //Arrange
            Player player = new Player();

            Card card1 = new Card("H", "J");
            Card card2 = new Card("H", "A");
            Card card3 = new Card("D", "Q");
            Card card4 = new Card("S", "K");
            Card card5 = new Card("C", "9");
            player.TakeCard(card1);
            player.TakeCard(card2);
            player.TakeCard(card3);
            player.TakeCard(card4);
            player.TakeCard(card5);

            //Act
            bool haveStraight = player.IsStraight();

            //Assert
            Assert.IsTrue(haveStraight);
        }

//----------------------------------------------------------- CHECK IF FLUSH ----------------------------------------------

        [Test]
        public void Given_A_Hand_With_No_Flush_On_It_Return_If_There_Is_A_Flush()
        {
            //Arrange
            Player player = new Player();

            Card card1 = new Card("H", "J");
            Card card2 = new Card("H", "A");
            Card card3 = new Card("D", "Q");
            Card card4 = new Card("S", "K");
            Card card5 = new Card("C", "9");
            player.TakeCard(card1);
            player.TakeCard(card2);
            player.TakeCard(card3);
            player.TakeCard(card4);
            player.TakeCard(card5);

            //Act
            bool haveFlush = player.IsFlush();

            //Assert
            Assert.IsFalse(haveFlush);
        }

        [Test]
        public void Given_A_Hand_With_Flush_On_It_Return_If_There_Is_A_Flush()
        {
            //Arrange
            Player player = new Player();

            Card card1 = new Card("H", "J");
            Card card2 = new Card("H", "A");
            Card card3 = new Card("H", "Q");
            Card card4 = new Card("H", "K");
            Card card5 = new Card("H", "9");
            player.TakeCard(card1);
            player.TakeCard(card2);
            player.TakeCard(card3);
            player.TakeCard(card4);
            player.TakeCard(card5);

            //Act
            bool haveFlush = player.IsFlush();

            //Assert
            Assert.IsTrue(haveFlush);
        }
    
//---------------------------------------------------- CHECK IF THERE IS A FULL HOUSE ----------------------------------------------

         [Test]
        public void Given_A_Hand_With_No_FullHouse_On_It_Return_If_There_Is_A_FullHouse()
        {
            //Arrange
            Player player = new Player();

            Card card1 = new Card("H", "J");
            Card card2 = new Card("H", "A");
            Card card3 = new Card("D", "Q");
            Card card4 = new Card("S", "K");
            Card card5 = new Card("C", "9");
            player.TakeCard(card1);
            player.TakeCard(card2);
            player.TakeCard(card3);
            player.TakeCard(card4);
            player.TakeCard(card5);

            //Act
            bool haveFullHouse = player.IsFullHouse();

            //Assert
            Assert.IsFalse(haveFullHouse);
        }

        [Test]
        public void Given_A_Hand_With_Two_Pairs_On_It_Return_If_There_Is_A_FullHouse()
        {
            //Arrange
            Player player = new Player();

            Card card1 = new Card("H", "J");
            Card card2 = new Card("H", "9");
            Card card3 = new Card("D", "J");
            Card card4 = new Card("S", "K");
            Card card5 = new Card("C", "9");
            player.TakeCard(card1);
            player.TakeCard(card2);
            player.TakeCard(card3);
            player.TakeCard(card4);
            player.TakeCard(card5);

            //Act
            bool haveFullHouse = player.IsFullHouse();

            //Assert
            Assert.IsFalse(haveFullHouse);
        }

        [Test]
        public void Given_A_Hand_With_Three_Of_A_Kind_On_It_Return_If_There_Is_A_FullHouse()
        {
            //Arrange
            Player player = new Player();

            Card card1 = new Card("H", "J");
            Card card2 = new Card("H", "9");
            Card card3 = new Card("D", "J");
            Card card4 = new Card("S", "K");
            Card card5 = new Card("C", "J");
            player.TakeCard(card1);
            player.TakeCard(card2);
            player.TakeCard(card3);
            player.TakeCard(card4);
            player.TakeCard(card5);

            //Act
            bool haveFullHouse = player.IsFullHouse();

            //Assert
            Assert.IsFalse(haveFullHouse);

        }

        [Test]
        public void Given_A_Hand_With_A_FullHouse_On_It_Return_If_There_Is_A_FullHouse()
        {
            //Arrange
            Player player = new Player();

            Card card1 = new Card("H", "J");
            Card card2 = new Card("H", "9");
            Card card3 = new Card("D", "J");
            Card card4 = new Card("S", "9");
            Card card5 = new Card("C", "J");
            player.TakeCard(card1);
            player.TakeCard(card2);
            player.TakeCard(card3);
            player.TakeCard(card4);
            player.TakeCard(card5);

            //Act
            bool haveFullHouse = player.IsFullHouse();

            //Assert
            Assert.IsTrue(haveFullHouse);

        }

        //---------------------------------------------------- CHECK IF THERE ARE FOUR OF A KIND ----------------------------------------------

        [Test]
        public void Given_A_Hand_With_No_Four_Of_A_Kind_On_It_Return_If_There_Is_Four_Of_A_Kind()
        {
            //Arrange
            Player player = new Player();

            Card card1 = new Card("H", "J");
            Card card2 = new Card("H", "A");
            Card card3 = new Card("D", "Q");
            Card card4 = new Card("S", "K");
            Card card5 = new Card("C", "9");
            player.TakeCard(card1);
            player.TakeCard(card2);
            player.TakeCard(card3);
            player.TakeCard(card4);
            player.TakeCard(card5);

            //Act
            bool haveFourOfAKind = player.IsFourOfAKind();

            //Assert
            Assert.IsFalse(haveFourOfAKind);
        }

        [Test]
        public void Given_A_Hand_With_Two_Pairs_On_It_Return_If_There_Is_Four_Of_A_Kind()
        {
            //Arrange
            Player player = new Player();

            Card card1 = new Card("H", "J");
            Card card2 = new Card("H", "A");
            Card card3 = new Card("D", "Q");
            Card card4 = new Card("S", "A");
            Card card5 = new Card("C", "J");
            player.TakeCard(card1);
            player.TakeCard(card2);
            player.TakeCard(card3);
            player.TakeCard(card4);
            player.TakeCard(card5);

            //Act
            bool haveFourOfAKind = player.IsFourOfAKind();

            //Assert
            Assert.IsFalse(haveFourOfAKind);
        }

        [Test]
        public void Given_A_Hand_With_Three_Of_A_Kind_On_It_Return_If_There_Is_Four_Of_A_Kind()
        {
            //Arrange
            Player player = new Player();

            Card card1 = new Card("H", "J");
            Card card2 = new Card("H", "A");
            Card card3 = new Card("D", "A");
            Card card4 = new Card("S", "A");
            Card card5 = new Card("C", "9");
            player.TakeCard(card1);
            player.TakeCard(card2);
            player.TakeCard(card3);
            player.TakeCard(card4);
            player.TakeCard(card5);

            //Act
            bool haveFourOfAKind = player.IsFourOfAKind();

            //Assert
            Assert.IsFalse(haveFourOfAKind);
        }

        [Test]
        public void Given_A_Hand_With_A_FullHouse_On_It_Return_If_There_Is_Four_Of_A_Kind()
        {
            //Arrange
            Player player = new Player();

            Card card1 = new Card("H", "J");
            Card card2 = new Card("H", "A");
            Card card3 = new Card("D", "A");
            Card card4 = new Card("S", "A");
            Card card5 = new Card("C", "J");
            player.TakeCard(card1);
            player.TakeCard(card2);
            player.TakeCard(card3);
            player.TakeCard(card4);
            player.TakeCard(card5);

            //Act
            bool haveFourOfAKind = player.IsFourOfAKind();

            //Assert
            Assert.IsFalse(haveFourOfAKind);
        }

        [Test]
        public void Given_A_Hand_With_Four_Of_A_Kind_On_It_Return_If_There_Is_Four_Of_A_Kind()
        {
            //Arrange
            Player player = new Player();

            Card card1 = new Card("H", "J");
            Card card2 = new Card("H", "A");
            Card card3 = new Card("D", "A");
            Card card4 = new Card("S", "A");
            Card card5 = new Card("C", "A");
            player.TakeCard(card1);
            player.TakeCard(card2);
            player.TakeCard(card3);
            player.TakeCard(card4);
            player.TakeCard(card5);

            //Act
            bool haveFourOfAKind = player.IsFourOfAKind();

            //Assert
            Assert.IsTrue(haveFourOfAKind);
        }

        //------------------------------------------------- CHECK IF THERE IS A STRAIGHT FLUSH ----------------------------------------------

        [Test]
        public void Given_A_Hand_With_No_Straight_Flush_On_It_Return_If_There_Is_A_Straight_Flush()
        {
            //Arrange
            Player player = new Player();

            Card card1 = new Card("H", "J");
            Card card2 = new Card("H", "A");
            Card card3 = new Card("D", "A");
            Card card4 = new Card("S", "A");
            Card card5 = new Card("C", "A");
            player.TakeCard(card1);
            player.TakeCard(card2);
            player.TakeCard(card3);
            player.TakeCard(card4);
            player.TakeCard(card5);

            //Act
            bool haveStraightFlush = player.IsStraightFlush();

            //Assert
            Assert.IsFalse(haveStraightFlush);
        }

        [Test]
        public void Given_A_Hand_With_A_Straight_On_It_Return_If_There_Is_A_Straight_Flush()
        {
            //Arrange
            Player player = new Player();

            Card card1 = new Card("H", "9");
            Card card2 = new Card("H", "J");
            Card card3 = new Card("D", "Q");
            Card card4 = new Card("S", "K");
            Card card5 = new Card("C", "A");
            player.TakeCard(card1);
            player.TakeCard(card2);
            player.TakeCard(card3);
            player.TakeCard(card4);
            player.TakeCard(card5);

            //Act
            bool haveStraightFlush = player.IsStraightFlush();

            //Assert
            Assert.IsFalse(haveStraightFlush);
        }

        [Test]
        public void Given_A_Hand_With_A_Flush_On_It_Return_If_There_Is_A_Straight_Flush()
        {
            //Arrange
            Player player = new Player();

            Card card1 = new Card("H", "J");
            Card card2 = new Card("H", "3");
            Card card3 = new Card("H", "6");
            Card card4 = new Card("H", "8");
            Card card5 = new Card("H", "K");
            player.TakeCard(card1);
            player.TakeCard(card2);
            player.TakeCard(card3);
            player.TakeCard(card4);
            player.TakeCard(card5);

            //Act
            bool haveStraightFlush = player.IsStraightFlush();

            //Assert
            Assert.IsFalse(haveStraightFlush);
        }

        [Test]
        public void Given_A_Hand_With_A_Straight_Flush_On_It_Return_If_There_Is_A_Straight_Flush()
        {
            //Arrange
            Player player = new Player();

            Card card1 = new Card("H", "9");
            Card card2 = new Card("H", "J");
            Card card3 = new Card("H", "Q");
            Card card4 = new Card("H", "A");
            Card card5 = new Card("H", "K");
            player.TakeCard(card1);
            player.TakeCard(card2);
            player.TakeCard(card3);
            player.TakeCard(card4);
            player.TakeCard(card5);

            //Act
            bool haveStraightFlush = player.IsStraightFlush();

            //Assert
            Assert.IsTrue(haveStraightFlush);
        }
    }



}