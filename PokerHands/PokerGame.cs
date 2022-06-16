using System;
using System.Collections.Generic;


namespace PokerHands
{
    public class Game
    {
        //With this list we avoid repeated cards on the game

        List<string> FullDeckList = new List<string> { "2H", "3H", "4H", "5H", "6H", "7H", "8H", "9H", "JH","QH","KH","AH",
                "2S", "3S", "4S", "5S", "6S", "7S", "8S", "9S", "JS","QS","KS","AS",
                "2D", "3D", "4D", "5D", "6D", "7D", "8D", "9D", "JD","QD","KD","AD",
                "2C", "3C", "4C", "5C", "6C", "7C", "8C", "9C", "JC","QC","KC","AC",
            };

        public static void Main()
        {
            int winnerHandRankPlayer1;
            int winnerHandRankPlayer2;

            Player player1 = new Player();
            Player player2 = new Player();
            
            Console.WriteLine("Please enter the name of the first player:");
            string player1Name = Console.ReadLine();
            
            Console.WriteLine("Please enter the name of the second player:");
            string player2Name = Console.ReadLine();
           
            Game poker = new Game();
            
            poker.AddPlayer(player1, player1Name);
            poker.AddPlayer(player2, player2Name);
           
            poker.DealCards(player1);
            poker.DealCards(player2);
            
            winnerHandRankPlayer1 = poker.WinnerHand(player1);
            winnerHandRankPlayer2 = poker.WinnerHand(player2);

            Console.WriteLine(" ");
            Console.WriteLine(player1.playerName + " Hand");
            poker.printCards(player1);
            Console.WriteLine(" ");
            Console.WriteLine(player2.playerName + " Hand");
            poker.printCards(player2);
            Console.WriteLine(" ");
            Console.WriteLine("++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++ ");
            Console.WriteLine(" ");

            if (winnerHandRankPlayer1 > winnerHandRankPlayer2)
                Console.WriteLine(player2.playerName + " is the winner with a " + poker.stringWinnerHand(winnerHandRankPlayer2, player2));
            else if (winnerHandRankPlayer1 < winnerHandRankPlayer2)
                Console.WriteLine(player1.playerName + " is the winner with a " + poker.stringWinnerHand(winnerHandRankPlayer1, player1));
            else
            {
                Console.WriteLine("Both players hace the same Winner Hand: " + poker.stringWinnerHand(winnerHandRankPlayer1));
               string winnerResult = poker.TieBreaker(player1,player2);
                Console.WriteLine(winnerResult);
            }

            Console.WriteLine(" ");
            Console.WriteLine("++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++ ");
            Console.WriteLine(" ");
        }

        

        public void AddPlayer(Player player, string playerName)
        {
            player.playerName=playerName;
        }

        public void DealCards(Player player)
        {
            int index=0;
            Random random = new Random();

            for (int i = 0; i < 5; i++)
            {
                index = random.Next(FullDeckList.Count);
                Card card = new Card(FullDeckList[index]);
                player.TakeCard(card);
                FullDeckList.RemoveAt(index);
            } 
            
        }

        public int WinnerHand(Player player)
        {
            List<int> handValues = new List<int>();

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
            else if (player.FindTheHighestCard()!=0)
                return 9;
            return 0;
        }

        private string stringWinnerHand(int winnerHandRank)
        {
            if (winnerHandRank == 1)
                return ("Straight Flush");
            else if (winnerHandRank == 2)
                return ("Poker");
            else if (winnerHandRank == 3)
                return ("Full House");
            else if (winnerHandRank == 4)
                return ("Flush");
            else if (winnerHandRank == 5)
                return ("Straight");
            else if (winnerHandRank == 6)
                return ("Three of a Kind");
            else if (winnerHandRank == 7)
                return ("Two Pairs of Cards");
            else if (winnerHandRank == 8)
                return ("a Pair of Cards");
            else
                return ("A Higher card ");
        }
    
        public string stringWinnerHand(int winnerHandRank, Player player)
        {
            if (winnerHandRank == 1)
                return ("Straight Flush of " + player.winningClub + " and Topper as " + this.ConversorValueFigure(player.winningCard));
            else if (winnerHandRank == 2)
                return ("Poker of " + this.ConversorValueFigure(player.winningCard));
            else if (winnerHandRank == 3)
                return ("Full House, three of " + this.ConversorValueFigure(player.winningCard));
            else if (winnerHandRank == 4)
                return ("a Flush of " + player.winningClub);
            else if (winnerHandRank == 5)
                return ("a Straight, whith the Topper as " + this.ConversorValueFigure(player.winningCard));
            else if (winnerHandRank == 6)
                return ("Three of " + player.winningCard);
            else if (winnerHandRank == 7)
                return ("Two Pairs, whith the Topper as " + this.ConversorValueFigure(player.winningCard));
            else if (winnerHandRank == 8)
                return ("a Pair of " + this.ConversorValueFigure(player.winningCard));
            else
                return ("the higher card " + this.ConversorValueFigure(player.winningCard));
        }

        public string TieBreaker(Player player1, Player player2)
        {
            if (player1.winningCard > player2.winningCard)
                return (" but " + player1.playerName + " is the winner with the higher card: " + this.ConversorValueFigure(player1.winningCard));
            else if (player2.winningCard > player1.winningCard)
                        return (" but " + player2.playerName + " is the winner with the higher card: " + this.ConversorValueFigure(player2.winningCard));
                    else
                return (player1.playerName + " and "+ player2.playerName + " have a tie with the card: " + this.ConversorValueFigure(player2.winningCard));
        }

        public void printCards(Player player)
        {
            foreach (Card card in player.cardValue)
            {
                Console.WriteLine(this.ConversorValueFigure(card.value) + " " + card.FindTheCardClub() );
            }
        }

        public string ConversorValueFigure(int value)
        {
            string valueString;

            if (value == 13)
                return "A";
            else if (value == 12)
                return "K";
            else if (value == 11)
                return "Q";
            else if (value == 10)
                return "J";
            else
                return valueString = value.ToString();
        }
    }

   
}