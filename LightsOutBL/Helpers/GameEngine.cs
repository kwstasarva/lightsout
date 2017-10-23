using LightsOutBL.Helpers.IHelpers;
using LightsOutBL.Models;
using LightsOutConstants;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LightsOutBL.Helpers
{
    public class GameEngine : IGameEngine
    {
        private bool[,] tileArray = new bool[5, 5];

        public bool[,] GenerateBoard(int dimensionX, int dimensionY)
        {
            var result = false;
            do
            {
                for (int x = 0; x < tileArray.GetLength(0); x++) //GetLength(0) => Will get the length of the first dimension of the array
                {
                    for (int y = 0; y < tileArray.GetLength(1); y++) //GetLength(1) => Will get the length of the second dimension of the array
                    {
                        var tileState = RandomTileStateGenerator();
                        tileArray[x, y] = tileState;

                        if (tileState)
                            result = tileState;
                    }
                }
            } while (result == false);

            return tileArray;
        }

        /// <summary>
        /// Checks if Board is validated
        /// </summary>
        /// <returns></returns>
        public bool ValidateBoard()
        {
            for (int x = 0; x < tileArray.GetLength(0); x++) //GetLength(0) => Will get the length of the first dimension of the array
            {
                for (int y = 0; y < tileArray.GetLength(1); y++) //GetLength(1) => Will get the length of the second dimension of the array
                {
                    var tileState = tileArray[x, y];
                    if (!tileState)
                        return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Random Tile State Generator
        /// </summary>
        /// <returns>The state of the tile.</returns>
        public bool RandomTileStateGenerator()
        {
            bool state = RandomBool();
            return state;
        }

        /// <summary>
        /// Toggles the state of the adjucent cells of the clicked tile
        /// </summary>
        /// <param name="tileModel"></param>
        /// <param name="tableLayoutPanel"></param>
        public void ToggleAdjucentTiles(TileModel tileModel, TableLayoutPanel tableLayoutPanel)
        {
            List<Button> tileList = new List<Button>();
            List<TileModel> positions = new List<TileModel>();

            //clicked cell
            positions.Add(new TileModel
            {
                TilePositionX = tileModel.TilePositionX,
                TilePositionY = tileModel.TilePositionY
            });

            //Right
            positions.Add(new TileModel
            {
                TilePositionX = tileModel.TilePositionX + 1,
                TilePositionY = tileModel.TilePositionY
            });

            //Left
            positions.Add(new TileModel
            {
                TilePositionX = tileModel.TilePositionX - 1,
                TilePositionY = tileModel.TilePositionY
            });

            //Up
            positions.Add(new TileModel
            {
                TilePositionX = tileModel.TilePositionX,
                TilePositionY = tileModel.TilePositionY + 1
            });

            //Down
            positions.Add(new TileModel
            {
                TilePositionX = tileModel.TilePositionX,
                TilePositionY = tileModel.TilePositionY - 1
            });

            foreach (var position in positions)
            {
                if (CheckIfTileOutOfBounds(position.TilePositionX, position.TilePositionY))
                {
                    Button tile = tableLayoutPanel.GetControlFromPosition(position.TilePositionX, position.TilePositionY) as Button;
                    tileList.Add(tile);
                }
            }

            foreach (var tile in tileList)
            {
                ToggleTile(tile);
            }
        }

        /// <summary>
        /// Toggles the tile
        /// </summary>
        /// <param name="tile"></param>
        private void ToggleTile(Button tile)
        {
            if (tile != null)
            {
                TileModel tileModel = (TileModel)tile.Tag;
                if (tileModel.TileState)
                {
                    tileModel.TileState = false;
                }
                else
                {
                    tileModel.TileState = true;
                }
                tile.BackColor = tileModel.TileState == true ? Color.Yellow : Color.Gray;
            }
        }

        /// <summary>
        /// Checking for out of bounds exceptions
        /// </summary>
        /// <param name="positionX"></param>
        /// <param name="positionY"></param>
        /// <returns></returns>
        private bool CheckIfTileOutOfBounds(int positionX, int positionY)
        {
            if (positionX >= 0
                && positionX <= 4
                && positionY >= 0
                && positionY <= 4)
                return true;

            return false;
        }

        /// <summary>
        /// Generates a random bool with 30% chance
        /// </summary>
        /// <returns>Bool</returns>
        private bool RandomBool()
        {
            Random random = new Random();
            int randomNumber = random.Next(0, 100);
            if (randomNumber > 30)
                return false;
            else
                return true;
        }

        /// <summary>
        /// Sets all lights to True
        /// </summary>
        public void SetBoardToTrue()
        {
            for (int x = 0; x < tileArray.GetLength(0); x++) //GetLength(0) => Will get the length of the first dimension of the array
            {
                for (int y = 0; y < tileArray.GetLength(1); y++) //GetLength(1) => Will get the length of the second dimension of the array
                {
                    tileArray[x, y] = true;
                }
            }
        }
    }
}
