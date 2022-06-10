using PokerHands;

namespace PokerHandsTest
{
    public class UniTests
    {

//----------------------------------------------------------- RETURN  VALUES ------------------------------------------------------

        [Test]
        public void Given_A_Card_S8_As_Strings_Return_Its_Int_Values_And_String_Clubs_Separated()
        {
            //Arrange
            Card card = new Card("8S");
            var testClub = "S";
            var testValue = 8;
            card.FindTheCardValue();


            //Act
            var cardValue = card.value;
            var cardClub = card.FindTheCardClub();

            //Assert
            Assert.That(cardClub, Is.EqualTo(testClub));
            Assert.That(cardValue, Is.EqualTo(testValue));
        }

        [Test]
        public void Given_A_Card_DK_As_Strings_Return_Its_Int_Values_And_String_Clubs_Separated()
        {
            //Arrange
            Card card = new Card("KD");
            var testValue = 12;
            var testClub = "D";
            card.FindTheCardValue();

            //Act
            var cardValue = card.value;
            var cardClub = card.FindTheCardClub();

            //Assert
            Assert.That(cardClub, Is.EqualTo(testClub));
            Assert.That(cardValue, Is.EqualTo(testValue));
        }

//------------------------------------------------------------- HIGHEST  CARD -----------------------------------------------------

        [Test]
        public void Given_A_Hand_With_Only_Numbers_Return_The_Highes_card()
        {
            //Arrange
            Player player = new Player();

            Card card1 = new Card("2H");
            Card card2 = new Card("5H");
            Card card3 = new Card("3D");
            Card card4 = new Card("5S");
            Card card5 = new Card("9C");
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

            Card card1 = new Card("2H");
            Card card2 = new Card("5H");
            Card card3 = new Card("3D");
            Card card4 = new Card("KS");
            Card card5 = new Card("9C");
            player.TakeCard(card1);
            player.TakeCard(card2);
            player.TakeCard(card3);
            player.TakeCard(card4);
            player.TakeCard(card5);
            List<int> handValues = player.SortCards();

            var expectedHighCard = 12;

            //Act
            int highCard = player.FindTheHighestCard();

            //Assert
            Assert.That(highCard, Is.EqualTo(expectedHighCard));
        }

//------------------------------------------------------------- CHECK IF ONE PAIR -------------------------------------------------

        [Test]
        public void Given_A_Hand_With_A_Pair_On_It_Return_If_There_Are_Any_Pairs()
        {
            //Arrange
            Player player = new Player();

            Card card1 = new Card("2H");
            Card card2 = new Card("5H");
            Card card3 = new Card("3D");
            Card card4 = new Card("KS");
            Card card5 = new Card("3C");
            player.TakeCard(card1);
            player.TakeCard(card2);
            player.TakeCard(card3);
            player.TakeCard(card4);
            player.TakeCard(card5);

            int expectedHighCard = 3;

            //Act
            bool haveAnyPairs = player.IsAPair();

            //Assert
            Assert.IsTrue(haveAnyPairs);
            Assert.That(player.winningCard, Is.EqualTo(expectedHighCard));
        }

        [Test]
        public void Given_A_Hand_With_No_Pairs_On_It_Return_If_There_Are_Any_Pairs()
        {
            //Arrange
            Player player = new Player();

            Card card1 = new Card("2H");
            Card card2 = new Card("5H");
            Card card3 = new Card("3D");
            Card card4 = new Card("KS");
            Card card5 = new Card("9C");
            player.TakeCard(card1);
            player.TakeCard(card2);
            player.TakeCard(card3);
            player.TakeCard(card4);
            player.TakeCard(card5);

            int expectedHighCard = 12;

            //Act
            bool haveAnyPairs = player.IsAPair();

            //Assert
            Assert.IsFalse(haveAnyPairs);
            Assert.That(player.winningCard, Is.EqualTo(expectedHighCard));
        }


//----------------------------------------------------------- CHECK IF TWO PAIRS --------------------------------------------------

        [Test]
        public void Given_A_Hand_With_No_Pairs_On_It_Return_If_There_Are_Two_Pairs()
        {
            //Arrange
            Player player = new Player();
            Card card1 = new Card("2H");
            Card card2 = new Card("5H");
            Card card3 = new Card("3D");
            Card card4 = new Card("KS");
            Card card5 = new Card("9C");
            player.TakeCard(card1);
            player.TakeCard(card2);
            player.TakeCard(card3);
            player.TakeCard(card4);
            player.TakeCard(card5);

            int expectedHighCard = 12;

            //Act
            bool haveTwoPairs = player.IsTwoPairs();

            //Assert
            Assert.IsFalse(haveTwoPairs);
            Assert.That(player.winningCard, Is.EqualTo(expectedHighCard));
        }

        [Test]
        public void Given_A_Hand_With_One_Pair_On_It_Return_If_There_Are_Two_Pairs()
        {
            //Arrange
            Player player = new Player();
            Card card1 = new Card("2H");
            Card card2 = new Card("5H");
            Card card3 = new Card("3D");
            Card card4 = new Card("KS");
            Card card5 = new Card("3C");
            player.TakeCard(card1);
            player.TakeCard(card2);
            player.TakeCard(card3);
            player.TakeCard(card4);
            player.TakeCard(card5);

            int expectedHighCard = 12;

            //Act
            bool haveTwoPairs = player.IsTwoPairs();

            //Assert
            Assert.IsFalse(haveTwoPairs);
            Assert.That(player.winningCard, Is.EqualTo(expectedHighCard));
        }

        [Test]
        public void Given_A_Hand_With_Two_Pairs_On_It_Return_If_There_Are_Two_Pairs()
        {
            //Arrange
            Player player = new Player();
            Card card1 = new Card("2H");
            Card card2 = new Card("KH");
            Card card3 = new Card("3D");
            Card card4 = new Card("KS");
            Card card5 = new Card("3C");
            player.TakeCard(card1);
            player.TakeCard(card2);
            player.TakeCard(card3);
            player.TakeCard(card4);
            player.TakeCard(card5);

            int expectedHighCard = 12;

            //Act
            bool haveTwoPairs = player.IsTwoPairs();

            //Assert
            Assert.IsTrue(haveTwoPairs);
            Assert.That(player.winningCard, Is.EqualTo(expectedHighCard));
        }

//----------------------------------------------------------- CHECK IF TRIO -------------------------------------------------------

        [Test]
        public void Given_A_Hand_With_No_Trio_On_It_Return_If_There_Is_A_Trio()
        {
            //Arrange
            Player player = new Player();
            Card card1 = new Card("2H");
            Card card2 = new Card("5H");
            Card card3 = new Card("3D");
            Card card4 = new Card("KS");
            Card card5 = new Card("9C");
            player.TakeCard(card1);
            player.TakeCard(card2);
            player.TakeCard(card3);
            player.TakeCard(card4);
            player.TakeCard(card5);

            int expectedHighCard = 12;

            //Act
            bool haveTrio = player.IsThreeOfAKind();

            //Assert
            Assert.IsFalse(haveTrio);
            Assert.That(player.winningCard, Is.EqualTo(expectedHighCard));
        }

        [Test]
        public void Given_A_Hand_With_A_Pair_On_It_Return_If_There_Is_A_Trio()
        {
            //Arrange
            Player player = new Player();

            Card card1 = new Card("2H");
            Card card2 = new Card("5H");
            Card card3 = new Card("KD");
            Card card4 = new Card("KS");
            Card card5 = new Card("9C");
            player.TakeCard(card1);
            player.TakeCard(card2);
            player.TakeCard(card3);
            player.TakeCard(card4);
            player.TakeCard(card5);

            int expectedHighCard = 12;

            //Act
            bool haveTrio = player.IsThreeOfAKind();

            //Assert
            Assert.IsFalse(haveTrio);
            Assert.That(player.winningCard, Is.EqualTo(expectedHighCard));
        }

        [Test]
        public void Given_A_Hand_With_A_Trio_On_It_Return_If_There_Is_A_Trio()
        {
            //Arrange
            Player player = new Player();

            Card card1 = new Card("JH");
            Card card2 = new Card("5H");
            Card card3 = new Card("JD");
            Card card4 = new Card("JS");
            Card card5 = new Card("9C");
            player.TakeCard(card1);
            player.TakeCard(card2);
            player.TakeCard(card3);
            player.TakeCard(card4);
            player.TakeCard(card5);

            int expectedHighCard = 10;

            //Act
            bool haveTrio = player.IsThreeOfAKind();

            //Assert
            Assert.IsTrue(haveTrio);
            Assert.That(player.winningCard, Is.EqualTo(expectedHighCard));
        }

//----------------------------------------------------------- CHECK IF SRAIGHT ----------------------------------------------------

        [Test]
        public void Given_A_Hand_With_No_Straight_On_It_Return_If_There_Is_A_Straight()
        {
            //Arrange
            Player player = new Player();

            Card card1 = new Card("2H");
            Card card2 = new Card("5H");
            Card card3 = new Card("KD");
            Card card4 = new Card("KS");
            Card card5 = new Card("9C");
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

            Card card1 = new Card("JH");
            Card card2 = new Card("AH");
            Card card3 = new Card("QD");
            Card card4 = new Card("KS");
            Card card5 = new Card("9C");
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

//----------------------------------------------------------- CHECK IF FLUSH ------------------------------------------------------

        [Test]
        public void Given_A_Hand_With_No_Flush_On_It_Return_If_There_Is_A_Flush()
        {
            //Arrange
            Player player = new Player();

            Card card1 = new Card("JH");
            Card card2 = new Card("7H");
            Card card3 = new Card("QD");
            Card card4 = new Card("KS");
            Card card5 = new Card("9C");
            player.TakeCard(card1);
            player.TakeCard(card2);
            player.TakeCard(card3);
            player.TakeCard(card4);
            player.TakeCard(card5);

            int expectedHighCard = 12;
            string expectedClub = "None";

            //Act
            bool haveFlush = player.IsFlush();

            //Assert
            Assert.IsFalse(haveFlush);
            Assert.That(player.winningCard, Is.EqualTo(expectedHighCard));
            Assert.That(player.winningClub, Is.EqualTo(expectedClub));
        }

        [Test]
        public void Given_A_Hand_With_Flush_On_It_Return_If_There_Is_A_Flush()
        {
            //Arrange
            Player player = new Player();

            Card card1 = new Card("2H");
            Card card2 = new Card("5H");
            Card card3 = new Card("3H");
            Card card4 = new Card("KH");
            Card card5 = new Card("9H");
            player.TakeCard(card1);
            player.TakeCard(card2);
            player.TakeCard(card3);
            player.TakeCard(card4);
            player.TakeCard(card5);

            int expectedHighCard = 12;
            string expectedClub = "H";

            //Act
            bool haveFlush = player.IsFlush();

            //Assert
            Assert.IsTrue(haveFlush);
            Assert.That(player.winningCard, Is.EqualTo(expectedHighCard));
            Assert.That(player.winningClub, Is.EqualTo(expectedClub));
        }
    
//---------------------------------------------------- CHECK IF THERE IS A FULL HOUSE ---------------------------------------------

         [Test]
        public void Given_A_Hand_With_No_FullHouse_On_It_Return_If_There_Is_A_FullHouse()
        {
            //Arrange
            Player player = new Player();

            Card card1 = new Card("JH");
            Card card2 = new Card("AH");
            Card card3 = new Card("QD");
            Card card4 = new Card("KS");
            Card card5 = new Card("9C");
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

            Card card1 = new Card("JH");
            Card card2 = new Card("9H");
            Card card3 = new Card("JD");
            Card card4 = new Card("KS");
            Card card5 = new Card("9C");
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

            Card card1 = new Card("JH");
            Card card2 = new Card("9H");
            Card card3 = new Card("JD");
            Card card4 = new Card("KS");
            Card card5 = new Card("JC");
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

            Card card1 = new Card("JH");
            Card card2 = new Card("9H");
            Card card3 = new Card("JD");
            Card card4 = new Card("9S");
            Card card5 = new Card("JC");
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

//---------------------------------------------------- CHECK IF THERE ARE FOUR OF A KIND ------------------------------------------

        [Test]
        public void Given_A_Hand_With_No_Four_Of_A_Kind_On_It_Return_If_There_Is_Four_Of_A_Kind()
        {
            //Arrange
            Player player = new Player();

            Card card1 = new Card("JH");
            Card card2 = new Card("AH");
            Card card3 = new Card("QD");
            Card card4 = new Card("KS");
            Card card5 = new Card("9C");
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

            Card card1 = new Card("JH");
            Card card2 = new Card("AH");
            Card card3 = new Card("QD");
            Card card4 = new Card("AS");
            Card card5 = new Card("JC");
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

            Card card1 = new Card("JH");
            Card card2 = new Card("AH");
            Card card3 = new Card("AD");
            Card card4 = new Card("AS");
            Card card5 = new Card("9C");
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

            Card card1 = new Card("JH");
            Card card2 = new Card("AH");
            Card card3 = new Card("AD");
            Card card4 = new Card("AS");
            Card card5 = new Card("JC");
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

            Card card1 = new Card("JH");
            Card card2 = new Card("AH");
            Card card3 = new Card("AD");
            Card card4 = new Card("AS");
            Card card5 = new Card("AC");
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

            Card card1 = new Card("JH");
            Card card2 = new Card("KH");
            Card card3 = new Card("KD");
            Card card4 = new Card("KS");
            Card card5 = new Card("KC");
            player.TakeCard(card1);
            player.TakeCard(card2);
            player.TakeCard(card3);
            player.TakeCard(card4);
            player.TakeCard(card5);

            int expectedHighCard = 12;
            string expectedClub = "None";

            //Act
            bool haveStraightFlush = player.IsStraightFlush();

            //Assert
            Assert.IsFalse(haveStraightFlush);
            Assert.That(player.winningCard, Is.EqualTo(expectedHighCard));
            Assert.That(player.winningClub, Is.EqualTo(expectedClub));
        }

        [Test]
        public void Given_A_Hand_With_A_Straight_On_It_Return_If_There_Is_A_Straight_Flush()
        {
            //Arrange
            Player player = new Player();

            Card card1 = new Card("9H");
            Card card2 = new Card("JH");
            Card card3 = new Card("QD");
            Card card4 = new Card("KS");
            Card card5 = new Card("AC");
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

            Card card1 = new Card("JH");
            Card card2 = new Card("3H");
            Card card3 = new Card("6H");
            Card card4 = new Card("8H");
            Card card5 = new Card("KH");
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

            Card card1 = new Card("9H");
            Card card2 = new Card("JH");
            Card card3 = new Card("QH");
            Card card4 = new Card("8H");
            Card card5 = new Card("KH");
            player.TakeCard(card1);
            player.TakeCard(card2);
            player.TakeCard(card3);
            player.TakeCard(card4);
            player.TakeCard(card5);

            int expectedHighCard = 12;
            string expectedClub = "H";

            //Act
            bool haveStraightFlush = player.IsStraightFlush();

            //Assert
            Assert.IsTrue(haveStraightFlush);
            Assert.That(player.winningCard, Is.EqualTo(expectedHighCard));
            Assert.That(player.winningClub, Is.EqualTo(expectedClub));
        }

//------------------------------------------------- CHECK IF IT RETURNS PLAYERS NAMES ----------------------------------------------
        
        [Test]
        public void Given_Two_New_players_Check_If_The_Names_Are_Stored()
        {
            //Arrange
            Player player1 = new Player();
            Player player2 = new Player();

            string player1Name = "MrWhite";
            String player2Name = "DrPurple";

            //Act
            Game poker = new Game();
            poker.AddPlayer(player1, player1Name);
            poker.AddPlayer(player2, player2Name);

            //Assert
            Assert.That(player1.name, Is.EqualTo(player1Name));
            Assert.That(player2.name, Is.EqualTo(player2Name));
        }
    }



}