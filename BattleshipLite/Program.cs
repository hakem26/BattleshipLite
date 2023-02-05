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
                DisplayShotGrid(activePlayer);

                RecordPlayerShot(activePlayer, opponent);

                bool doesGameContinue = GameLogic.PlayerStillActive(opponent);

                if (doesGameContinue == true)
                {
                    (activePlayer, opponent) = (opponent , activePlayer);
                }
                else
                {
                    winner = activePlayer;
                }
            } while (winner == null);
            IdentifyWinner(winner);
            Console.ReadLine();
        }

        private static void IdentifyWinner(PlayerInfoModel winner)
        {
            Console.WriteLine($"Congras to {winner.UsersName} for winning this game!");
            Console.WriteLine($"{winner.UsersName} took {GameLogic.GetShotCount(winner)} shots");
        }

        private static void RecordPlayerShot(PlayerInfoModel activePlayer, PlayerInfoModel opponent)
        {
            char row = '\0';
            int column = 0;
            bool isValidShot = false;
            do
            {
                string shot = AskForShot(activePlayer);
                try
                {
                    (row, column) = GameLogic.SplitShotIntoRowAndColumn(shot);
                    isValidShot = GameLogic.ValidateShot(activePlayer, row, column);
                }
                catch (Exception ex)
                {
                    isValidShot= false;
                }
                if (isValidShot == false)
                {
                    Console.WriteLine("Invalid shot location. Please try again");
                }
            } while (isValidShot == false);

            bool isAHit = GameLogic.IdentifyShotResult(opponent, row, column);
            
            GameLogic.MarkShotRelult(activePlayer, row, column, isAHit);
            DisplayShotResults(row, column, isAHit);
        }

        private static void DisplayShotResults(char row, int column, bool isAHit)
        {
            if (isAHit)
            {
                Console.WriteLine($"{row}{column} is a hit!");
            }
            else
            {
                Console.WriteLine($"{row}{column} is a miss!");
            }
            Console.WriteLine();
        }

        private static string AskForShot(PlayerInfoModel player)
        {
            Console.WriteLine($"{player.UsersName} please enter your shot selection: ");
            string output = Console.ReadLine();
            return output;
        }

        private static void DisplayShotGrid(PlayerInfoModel activePlayer)
        {
            char currentRow = activePlayer.ShotGrid[0].SpotLetter;
            foreach (var gridSpot in activePlayer.ShotGrid)
            {
                if (gridSpot.SpotLetter != currentRow)
                {
                    Console.WriteLine();
                    currentRow = gridSpot.SpotLetter;
                }
                if (gridSpot.Status == GridSpotStatus.Empty)
                {
                    Console.Write($" {gridSpot.SpotLetter}{gridSpot.SpotNumber} ");
                }
                else if (gridSpot.Status == GridSpotStatus.Hit)
                {
                    Console.Write(" X  ");
                }
                else if (gridSpot.Status == GridSpotStatus.Miss)
                {
                    Console.Write(" O  ");
                }
                else
                {
                    Console.Write(" ?  ");
                }
            }
            Console.WriteLine();
            Console.WriteLine();
        }

        private static void WelcomeMessage()
        {
            Console.WriteLine("Welcome to Battheship  lite :)");
        }

        private static PlayerInfoModel CreatePlayer(string playerTitle)
        {
            PlayerInfoModel output = new PlayerInfoModel();
            Console.WriteLine($"Player information for {playerTitle}");

            output.UsersName = AskForUserName();

            GameLogic.InitializeGrid(output);

            PlaceShips(output);

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

                bool isValidLocation = false;
                try
                {
                    isValidLocation = GameLogic.Placeship(model, location);
                }
                catch (Exception ex)
                {
                    isValidLocation= false;
                }
                if (isValidLocation == false)
                {
                    Console.WriteLine("That was\'nt valid location. try again!");
                }
            } while (model.ShipLocations.Count < 5);
        }
    }
}
