using BattleshipLiteClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipLiteClassLibrary
{
    public class GameLogic
    {
        public static int GetShotCount(PlayerInfoModel winner)
        {
            throw new NotImplementedException();
        }

        public static bool IdentifyShotResult(PlayerInfoModel opponent, char row, int column)
        {
            throw new NotImplementedException();
        }

        public static void  InitializeGrid(PlayerInfoModel model)
        {
            List<char> letters = new List<char>
            {
                'A', 'B', 'C', 'D', 'E'
            };
            List<int> numbers = new List<int>
            {
                1, 2, 3, 4, 5
            };
            foreach (char letter in letters)
            {
                foreach (int number in numbers)
                {
                    AddGridSpot(model, letter, number);
                }
            }
        }

        public static void MarkShotRelult(PlayerInfoModel activePlayer, char row, int column)
        {
            throw new NotImplementedException();
        }

        public static bool Placeship(PlayerInfoModel model, string location)
        {
            throw new NotImplementedException();
        }

        public static bool PlayerStillActive(PlayerInfoModel opponent)
        {
            throw new NotImplementedException();
        }

        public static (char row, int column) SplitShotIntoRowAndColumn(string shot)
        {
            throw new NotImplementedException();
        }

        public static bool ValidateShot(PlayerInfoModel activePlayer, char row, int column)
        {
            throw new NotImplementedException();
        }

        private static void AddGridSpot (PlayerInfoModel model, char letter, int number)
        {
            GridSpotModel spot = new GridSpotModel
            {
                SpotLetter = letter,
                SpotNumber = number,
                Status = GridSpotStatus.Empty
            };
            model.ShotGrid.Add(spot);
        }
    }
}
