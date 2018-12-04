using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dvimvienas
{
    public static class Game
    {
        public static void Games()
        {
           
            
                Console.WriteLine("******************");
                Console.WriteLine("**Choose a game**");
                Console.WriteLine("21 - A; Blackjack - B");
                string GameChooseInput = Console.ReadLine();
                

                while (GameChooseInput.ToLower() != "a" && GameChooseInput.ToLower() != "b")
                {
                    Console.WriteLine("You entered a bad entry.");
                    GameChooseInput = Console.ReadLine();
                }

           
                if (GameChooseInput.ToLower() == "a" || GameChooseInput == "21")
                {
                    TwentyOne.TwentyOneGame();
                    
                }

                else if (GameChooseInput.ToLower() == "b")
                {
                    Console.WriteLine("Game is not ready yet");
                    Console.ReadKey();

                }
               
            
            



            Console.WriteLine("...the program has ended, press any key to exit...");
            Console.ReadKey();
        }

       
    }
}
