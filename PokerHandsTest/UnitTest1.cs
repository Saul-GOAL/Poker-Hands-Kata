namespace PokerHandsTest
{
    public class UniTests
    {

//----------------------------------------------------- RETURN  VALUES ----------------------------------------------

        [Test]
        public void Given_A_Card_S8_As_Strings_Return_Its_Int_Values_And_String_Clubs_Separated()
        {
            //Arrange
            Card card = new Card("S", "8");
            var testClub = "S";
            var testValue = 8;

            //Act
            var cardValue = card.FindTheCardValue();
            var cardClub = card.FindTheCardClub();

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
            var cardValue = card.FindTheCardValue();
            var cardClub = card.FindTheCardClub();

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
            List<int> handValues = player.SortCards();


            var expectedHighCard = 9;

            //Act
            int highCard = player.FindTheHighestCard(handValues);

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
            List<int> handValues = player.SortCards();

            var expectedHighCard = 12;

            //Act
            int highCard = player.FindTheHighestCard(handValues);

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

            int expectedHighCard = 3;

            //Act
            bool haveAnyPairs = player.IsThereAnyPairs();

            //Assert
            Assert.IsTrue(haveAnyPairs);
            Assert.That(player.winningCard, Is.EqualTo(expectedHighCard));
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

            int expectedHighCard = 12;

            //Act
            bool haveAnyPairs = player.IsThereAnyPairs();

            //Assert
            Assert.IsFalse(haveAnyPairs);
            Assert.That(player.winningCard, Is.EqualTo(expectedHighCard));
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

            int expectedHighCard = 12;

            //Act
            bool haveTwoPairs = player.IsThereTwoPairs();

            //Assert
            Assert.IsFalse(haveTwoPairs);
            Assert.That(player.winningCard, Is.EqualTo(expectedHighCard));
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

            int expectedHighCard = 12;

            //Act
            bool haveTwoPairs = player.IsThereTwoPairs();

            //Assert
            Assert.IsFalse(haveTwoPairs);
            Assert.That(player.winningCard, Is.EqualTo(expectedHighCard));
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

            int expectedHighCard = 12;

            //Act
            bool haveTwoPairs = player.IsThereTwoPairs();

            //Assert
            Assert.IsTrue(haveTwoPairs);
            Assert.That(player.winningCard, Is.EqualTo(expectedHighCard));
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

            int expectedHighCard = 12;

            //Act
            bool haveTrio = player.IsThereAnyTrio();

            //Assert
            Assert.IsFalse(haveTrio);
            Assert.That(player.winningCard, Is.EqualTo(expectedHighCard));
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

            int expectedHighCard = 12;

            //Act
            bool haveTrio = player.IsThereAnyTrio();

            //Assert
            Assert.IsFalse(haveTrio);
            Assert.That(player.winningCard, Is.EqualTo(expectedHighCard));
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

            int expectedHighCard = 10;

            //Act
            bool haveTrio = player.IsThereAnyTrio();

            //Assert
            Assert.IsTrue(haveTrio);
            Assert.That(player.winningCard, Is.EqualTo(expectedHighCard));
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

            int expectedHighCard = 12;

            //Act
            bool haveStraight = player.IsStraight();

            //Assert
            Assert.IsFalse(haveStraight);
            Assert.That(player.winningCard, Is.EqualTo(expectedHighCard));
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

            int expectedHighCard = 13;

            //Act
            bool haveStraight = player.IsStraight();

            //Assert
            Assert.IsTrue(haveStraight);
            Assert.That(player.winningCard, Is.EqualTo(expectedHighCard));
        }

//----------------------------------------------------------- CHECK IF FLUSH ----------------------------------------------

        [Test]
        public void Given_A_Hand_With_No_Flush_On_It_Return_If_There_Is_A_Flush()
        {
            //Arrange
            Player player = new Player();

            Card card1 = new Card("H", "J");
            Card card2 = new Card("H", "7");
            Card card3 = new Card("D", "Q");
            Card card4 = new Card("S", "K");
            Card card5 = new Card("C", "9");
            player.TakeCard(card1);
            player.TakeCard(card2);
            player.TakeCard(card3);
            player.TakeCard(card4);
            player.TakeCard(card5);

            int expectedHighCard = 12;

            //Act
            bool haveFlush = player.IsFlush();

            //Assert
            Assert.IsFalse(haveFlush);
            Assert.That(player.winningCard, Is.EqualTo(expectedHighCard));
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

            int expectedHighCard = 13;

            //Act
            bool haveFlush = player.IsFlush();

            //Assert
            Assert.IsTrue(haveFlush);
            Assert.That(player.winningCard, Is.EqualTo(expectedHighCard));
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

            int expectedHighCard = 13;

            //Act
            bool haveFullHouse = player.IsFullHouse();

            //Assert
            Assert.IsFalse(haveFullHouse);
            Assert.That(player.winningCard, Is.EqualTo(expectedHighCard));
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

            int expectedHighCard = 12;

            //Act
            bool haveFullHouse = player.IsFullHouse();

            //Assert
            Assert.IsFalse(haveFullHouse);
            Assert.That(player.winningCard, Is.EqualTo(expectedHighCard));
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

            int expectedHighCard = 12;

            //Act
            bool haveFullHouse = player.IsFullHouse();

            //Assert
            Assert.IsFalse(haveFullHouse);
            Assert.That(player.winningCard, Is.EqualTo(expectedHighCard));

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

            int expectedHighCard = 10;

            //Act
            bool haveFullHouse = player.IsFullHouse();

            //Assert
            Assert.IsTrue(haveFullHouse);
            Assert.That(player.winningCard, Is.EqualTo(expectedHighCard));

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

            int expectedHighCard = 13;

            //Act
            bool haveFourOfAKind = player.IsFourOfAKind();

            //Assert
            Assert.IsFalse(haveFourOfAKind);
            Assert.That(player.winningCard, Is.EqualTo(expectedHighCard));
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

            int expectedHighCard = 13;

            //Act
            bool haveFourOfAKind = player.IsFourOfAKind();

            //Assert
            Assert.IsTrue(haveFourOfAKind);
            Assert.That(player.winningCard, Is.EqualTo(expectedHighCard));
        }

        //------------------------------------------------- CHECK IF THERE IS A STRAIGHT FLUSH ----------------------------------------------

        [Test]
        public void Given_A_Hand_With_No_Straight_Flush_On_It_Return_If_There_Is_A_Straight_Flush()
        {
            //Arrange
            Player player = new Player();

            Card card1 = new Card("H", "J");
            Card card2 = new Card("H", "K");
            Card card3 = new Card("D", "K");
            Card card4 = new Card("S", "K");
            Card card5 = new Card("C", "K");
            player.TakeCard(card1);
            player.TakeCard(card2);
            player.TakeCard(card3);
            player.TakeCard(card4);
            player.TakeCard(card5);

            int expectedHighCard = 12;

            //Act
            bool haveStraightFlush = player.IsStraightFlush();

            //Assert
            Assert.IsFalse(haveStraightFlush);
            Assert.That(player.winningCard, Is.EqualTo(expectedHighCard));
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
            Card card4 = new Card("H", "8");
            Card card5 = new Card("H", "K");
            player.TakeCard(card1);
            player.TakeCard(card2);
            player.TakeCard(card3);
            player.TakeCard(card4);
            player.TakeCard(card5);

            int expectedHighCard = 12;

            //Act
            bool haveStraightFlush = player.IsStraightFlush();

            //Assert
            Assert.IsTrue(haveStraightFlush);
            Assert.That(player.winningCard, Is.EqualTo(expectedHighCard));
        }
    }



}