using System;
using System.Linq;
using System.Threading;

namespace sus
{
    internal class Program
    {
        private string[] gestures = new[]{
            "Kámen",
            "Nůžky",
            "Papír"
        };

        private int playerScore;
        private int aiScore;

        private Random rnd = new Random();

        private void Start()
        {
            Console.WriteLine("Vítej ve hře Kámen - Nůžky - Papír");
            Console.WriteLine("Hra začne za...");
            Console.WriteLine("3");
            Thread.Sleep(1000);
            Console.WriteLine("2");
            Thread.Sleep(1000);
            Console.WriteLine("1");

            this.BuildBoard();
        }

        private void BuildBoard()
        {
            while (true)
            {
                Console.Clear();

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Hráč: {this.playerScore}");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine($"Nepřítel: {this.aiScore}");
                Console.ForegroundColor = ConsoleColor.White;

                Console.WriteLine("-------------");
                Console.WriteLine("Kolo hráče:");
                for (int index = 0; index < this.gestures.Length; index++)
                {
                    Console.WriteLine($"{index} - {this.gestures[index]}");
                }
                Console.WriteLine("-------------");

                string ans = Console.ReadLine();
                if (string.IsNullOrEmpty(ans) || !ans.All(char.IsDigit))
                {
                    continue;
                }

                int playerAns = int.Parse(ans);
                int aiAns = this.rnd.Next(0, 3);
                if (playerAns < 0 || playerAns > 2)
                {
                    continue;
                }

                if (playerAns == 0 && aiAns == 1)
                {
                    this.PlayerWon(aiAns);
                }
                else if (playerAns == 0 && aiAns == 2)
                {
                    this.AiWon(aiAns);
                }
                else if (playerAns == 1 && aiAns == 0)
                {
                    this.AiWon(aiAns);
                }
                else if (playerAns == 1 && aiAns == 2)
                {
                    this.PlayerWon(aiAns);
                }
                else if (playerAns == 2 && aiAns == 0)
                {
                    this.PlayerWon(aiAns);
                }
                else if (playerAns == 2 && aiAns == 1)
                {
                    this.AiWon(aiAns);
                }
                else if (playerAns == aiAns)
                {
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine("Remíza");
                    Console.ForegroundColor = ConsoleColor.White;
                }

                Console.WriteLine("\nStiskni enter pro pokračování");
                Console.ReadLine();
            }
        }

        private void PlayerWon(int numberAi)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Hráč vyhrál - nepřítel zvolil {this.gestures[numberAi]}");
            Console.ForegroundColor = ConsoleColor.White;
            this.playerScore++;
        }

        private void AiWon(int numberAi)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"Nepřítel vyhrál - zvolil {this.gestures[numberAi]}");
            Console.ForegroundColor = ConsoleColor.White;
            this.aiScore++;
        }

        public static void Main() => new Program().Start();
    }
}