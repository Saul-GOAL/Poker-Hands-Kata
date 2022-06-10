using System;
using System.Collections.Generic;


namespace PokerHands
{
    public class Game
    {
        List<string> FullDeck = new List<string> { "2H", "3H", "4H", "5H", "6H", "7H", "8H", "9H", "JH","QH","KH","AH",
                "2S", "3S", "4S", "5S", "6S", "7S", "8S", "9S", "JS","QS","KS","AS",
                "2D", "3D", "4D", "5D", "6D", "7D", "8D", "9D", "JD","QD","KD","AD",
                "2C", "3C", "4C", "5C", "6C", "7C", "8C", "9C", "JC","QC","KC","AC",
            };
        public static void Main()
        {
            int rankPlayer1;
            int rankPlayer2;

            Console.WriteLine("Please enter the name of the first player:");
            string player1Name = Console.ReadLine();
            Player player1 = new Player();
            Console.WriteLine("Please enter the name of the second player:");
            string player2Name = Console.ReadLine();
            Player player2 = new Player();
            
            Game poker = new Game();
            poker.AddPlayer(player1, player1Name);
            poker.AddPlayer(player2, player2Name);

            poker.DealCards(player1);
            poker.DealCards(player2);

            rankPlayer1 = poker.WinnerHand(player1);
            rankPlayer2 = poker.WinnerHand(player2);

            if(rankPlayer1<rankPlayer2)
                Console.WriteLine(player2.name + " is the winner ");
            else if (rankPlayer1>rankPlayer2)
                Console.WriteLine(player1.name + " is the winner ");
            else
            {
                poker.tieBreaker(player1,player2);
                Console.WriteLine("It is a draw");
            }
                
        }

        private void tieBreaker(Player player1, Player player2)
        {
            throw new NotImplementedException();
        }

        private int WinnerHand(Player player)
        {
            List<int> handValues = new List<int>();
            handValues = player.SortCards();

            if (player.IsStraightFlush())
                return 1;
            else if (player.IsFourOfAKind())
                return 2;
            else if (player.IsFullHouse())
                return 3;
            else if (player.IsFlush())
                return 4;
            else if (player.IsStraight())
                return 5;
            else if (player.IsThreeOfAKind())
                return 6;
            else if (player.IsTwoPairs())
                return 7;
            else if (player.IsAPair())
                return 8;
            else if (player.FindTheHighestCard(handValues)!=0)
                return 9;
            return 0;
        }

        public void DealCards(Player player1)
        {
            int index=0;
            Random random = new Random();

            for (int i = 0; i < 5; i++)
            {
                index = random.Next(FullDeck.Count);
                Card card = new Card(FullDeck[index]);
                player1.TakeCard(card);
                FullDeck.RemoveAt(index);
            }      
            
        }

        public void AddPlayer(Player player, string playerName)
        {
            player.name=playerName;
        }
    }
}