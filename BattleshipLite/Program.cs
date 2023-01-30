﻿using System;
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
            Console.ReadLine();
        }

        private static void WelcomeMessage()
        {
            Console.WriteLine("Welcome to Battheship  lite :)");
        }

        private static PlayerInfoModel CreatePlayer()
        {
            PlayerInfoModel output = new PlayerInfoModel();

            //Ask user for name
            output.UsersName = AskForUserName();

            //Load up shot grid
            GameLogic.InitializeGrid(output);
            
            //Ask the user for their 5 ship placements

            //Clear

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
                //bool isValidLocation = GameLogic.StoreShot(model, location);
            } while (model.ShipLocations.Count < 5);
        }
    }
}