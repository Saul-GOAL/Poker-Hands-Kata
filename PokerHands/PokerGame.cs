using PokerHandsTest;
using System;
using System.Collections.Generic;


namespace PokerHands
{
    public class Game
    {
        public static void Main()
        {
            List<string> FullDeck = new List<string> { "2H", "3H", "4H", "5H", "6H", "7H", "8H", "9H", "JH","QH","KH","AH",
                "2S", "3S", "4S", "5S", "6S", "7S", "8S", "9S", "JS","QS","KS","AS",
                "2D", "3D", "4D", "5D", "6D", "7D", "8D", "9D", "JD","QD","KD","AD",
                "2C", "3C", "4C", "5C", "6C", "7C", "8C", "9C", "JC","QC","KC","AC",
            };

            Console.WriteLine("Please enter the name of the first player:");
            string player1Name = Console.ReadLine();
            Player player1 = new Player();
            Console.WriteLine("Please enter the name of the second player:");
            string player2Name = Console.ReadLine();
            Player player2 = new Player();
            
            Game poker = new Game();
            poker.AddPlayer(player1, player1Name);
            poker.AddPlayer(player2, player2Name);

        }

        private void AddPlayer(Player player, string playerName)
        {
            player.name=playerName;
        }
    }
}