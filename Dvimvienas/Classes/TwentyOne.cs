using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dvimvienas
{
    public static class TwentyOne
    {
        public static void TwentyOneGame()
        {
            
            Console.WriteLine("*********");
            Console.WriteLine("You picked 21!");
            Console.WriteLine("*********");
            int StartingBank = 100;
            while (true)
            {
                
                Console.WriteLine($"You have: {StartingBank}, what do you want to do?");
                Console.Write("Type a number: 1 - PLAY // 2 - EXIT ");
                string GameOrExit = Console.ReadLine();
                int choice = ReadInt(GameOrExit);

                //Patikrina ar geras pasirinkimas
                while (choice != 1 && choice != 2)
                {
                    Console.WriteLine("***WRONG OPTION!***");
                    Console.Write("Type a number: 1 - PLAY // 2 - EXIT ");
                    GameOrExit = Console.ReadLine();
                    choice = ReadInt(GameOrExit);
                }
                //Patikrina ar dar turi pinigu zaisti
                if (StartingBank <= 0)
                {
                    Console.WriteLine("You have no money left to play with!");
                    break;
                }
                else if (choice == 1 && StartingBank != 0)
                {
                    Console.WriteLine("You picked PLAY!");                 
                }
                else
                {
                    Console.WriteLine($"You have chosen EXIT. You left the game with {StartingBank} money.");
                    Console.WriteLine("Have a good day!");
                    break;
                }

                Console.Write("Enter a sum which you want to bid: ");
                string EnteredSum = Console.ReadLine();
                int BidSum = ReadInt(EnteredSum);
                if (StartingBank < BidSum)
                {
                    Console.WriteLine($"You can't bid more than your bank is ({StartingBank}).");
                    Console.Write("Enter a sum which you want to bid: ");
                    EnteredSum = Console.ReadLine();
                    BidSum = ReadInt(EnteredSum);
                }
                StartingBank = StartingBank - BidSum;

                Console.WriteLine($"You have placed a bet of {BidSum}. You have {StartingBank} money left.");
                Console.Write("Pick dice number [1-6]: ");                
                string EnterDiceGuess = Console.ReadLine();
                int DiceGuess = ReadInt(EnterDiceGuess);
                //patikrina ar itilpe i kauliuko skaiciu 1-6
                while (DiceGuess > 6 && DiceGuess < 1)
                {
                    Console.WriteLine("Bad option. Pick a dice number [1-6]: ");
                    EnterDiceGuess = Console.ReadLine();
                    DiceGuess = ReadInt(EnterDiceGuess);
                }

                Console.WriteLine("...The dice is rolling, please wait...");
                System.Threading.Thread.Sleep(3000);
                Console.WriteLine("..3..");
                System.Threading.Thread.Sleep(300);
                Console.WriteLine("..2..");
                System.Threading.Thread.Sleep(300);
                Console.WriteLine("..1..");
                System.Threading.Thread.Sleep(300);
                Console.WriteLine("");

                int DealerRoll = GetRandomNumber(1, 7);
                Console.WriteLine("The dealer rolled:");
                //Rezultato atvaizdavimas
                switch (DealerRoll)
                {
                    case 1:
                        Console.WriteLine(" _______ ");
                        Console.WriteLine("|       |");
                        Console.WriteLine("|   X   |");
                        Console.WriteLine("|       |");
                        Console.WriteLine("|_______|");
                        break;
                    case 2:
                        Console.WriteLine(" _______ ");
                        Console.WriteLine("|       |");
                        Console.WriteLine("| X   X |");
                        Console.WriteLine("|       |");
                        Console.WriteLine("|_______|");
                        break;
                    case 3:
                        Console.WriteLine(" _______ ");
                        Console.WriteLine("|       |");
                        Console.WriteLine("| X X X |");
                        Console.WriteLine("|       |");
                        Console.WriteLine("|_______|");
                        break;
                    case 4:
                        Console.WriteLine(" _______ ");
                        Console.WriteLine("| X   X |");
                        Console.WriteLine("|       |");
                        Console.WriteLine("| X   X |");
                        Console.WriteLine("|_______|");
                        break;
                    case 5:
                        Console.WriteLine(" _______ ");
                        Console.WriteLine("| X   X |");
                        Console.WriteLine("|   X   |");
                        Console.WriteLine("| X   X |");
                        Console.WriteLine("|_______|");
                        break;
                    case 6:
                        Console.WriteLine(" _______ ");
                        Console.WriteLine("| X   X |");
                        Console.WriteLine("| X   X |");
                        Console.WriteLine("| X   X |");
                        Console.WriteLine("|_______|");
                        break;
                }

                if (DealerRoll == DiceGuess)
                {
                    BidSum = BidSum * 6;
                    Console.WriteLine($"CONGRATULATIONS! You won an ammount of {BidSum}");
                    StartingBank = StartingBank + BidSum;
                    Console.WriteLine($"You now have: {StartingBank}");
                }
                else
                {
                    Console.WriteLine("Your guess was not correct!");                   
                }          
            }            
        }

        private static readonly Random getrandom = new Random();

        public static int GetRandomNumber(int min, int max)
        {
            lock (getrandom) // synchronize
            {
                return getrandom.Next(min, max);
            }
        }

        private static int ReadInt(string input)
        {
            int number;
            while (!int.TryParse(input, out number))
            {
                Console.WriteLine("Bad entry. Write a number.");
                input = Console.ReadLine();
            }
            return number;
        }
    }
}
