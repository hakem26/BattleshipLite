using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleshipLiteClassLibrary;
using BattleshipLiteClassLibrary.Models;

namespace BattleshipLite
{
    internal class Program
    {
        static void Main(string[] args)
        {
            WelcomeMessage();
            PlayerInfoModel activePlayer = CreatePlayer("Player 1");
            PlayerInfoModel opponent = CreatePlayer("Player 2");
            PlayerInfoModel winner = null;
            do
            {
                //display grid from active player on where they fired
                //ask active player for a shot
                //determine if it is a valid player
                //determine shot result
                //determine if game is over
                //if over set active player as  winner, else swpap positions: activePlayer  <=> opponent 
            } while (winner == null);
            Console.ReadLine();
        }

        private static void WelcomeMessage()
        {
            Console.WriteLine("Welcome to Battheship  lite :)");
        }

        private static PlayerInfoModel CreatePlayer(string playerTitle)
        {
            PlayerInfoModel output = new PlayerInfoModel();
            Console.WriteLine($"Player information for {playerTitle}");

            //Ask user for name
            output.UsersName = AskForUserName();

            //Load up shot grid
            GameLogic.InitializeGrid(output);

            //Ask the user for their 5 ship placements
            PlaceShips(output);
            //Clear
            Console.Clear();
            return output;
        }

        private static string AskForUserName() 
        {
            Console.Write("What\'s your name? ");
            string output = Console.ReadLine();
            return output;
        }

        private static void PlaceShips(PlayerInfoModel model)
        {
            do
            {
                Console.WriteLine($"Where do  you want to place ship number { model.ShipLocations.Count + 1 }");
                string location = Console.ReadLine();
                bool isValidLocation = GameLogic.Placeship(model, location);
                if (isValidLocation == false)
                {
                    Console.WriteLine("That was\'nt valid location. try again!");
                }
            } while (model.ShipLocations.Count < 5);
        }
    }
}
