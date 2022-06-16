using PokerHands;

namespace PokerHandsTest
{
    public class UniTestsPokerGame
    {

        [Test]
        public void Given_Two_New_players_Check_If_The_Names_Are_Stored_In_The_System()
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
            Assert.That(player1.playerName, Is.EqualTo(player1Name));
            Assert.That(player2.playerName, Is.EqualTo(player2Name));
        }


        [TestCase("9H", "KH", "QH", "AH", "JH", 1)]
        [TestCase("JH", "AH", "QD", "KS", "9C", 5)]
        [TestCase("2H", "5H", "3D", "KS", "9C", 9)]

        public void Given_A_Player_It_Returns_His_Winner_Hand(string ex_card1, string ex_card2,
           string ex_card3, string ex_card4, string ex_card5, int expectedResult)
        {
            //Arrange
            Game poker = new Game();
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
            int handRanking = poker.WinnerHand(player);

            //Assert
            Assert.That(handRanking, Is.EqualTo(expectedResult));
        }

    }



}