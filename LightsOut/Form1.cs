using LightsOutBL.Helpers;
using LightsOutBL.Helpers.IHelpers;
using LightsOutBL.Models;
using LightsOutConstants;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LightsOut
{
    public partial class Form1 : Form
    {
        GameEngine gameEngine = new GameEngine();

        //Public array initialization
        bool[,] tileArray = new bool[5, 5];
        private TableLayoutPanel tableLayoutPanel = null;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            InitializeBoard();
        }

        private void InitializeBoard()
        {
            tableLayoutPanel = new TableLayoutPanel();
            this.Controls.Add(tableLayoutPanel);

            //Setting the size of The form and the layout panel
            this.AutoSize = true;
            tableLayoutPanel.AutoSize = true;

            var board = gameEngine.GenerateBoard(tileArray.GetLength(0), tileArray.GetLength(1));

            //Counter will be used for naming the form buttons.
            int counter = 1;

            for (int x = 0; x < tileArray.GetLength(0); x++) //GetLength(0) => Will get the length of the first dimension of the array
            {
                for (int y = 0; y < tileArray.GetLength(1); y++) //GetLength(1) => Will get the length of the second dimension of the array
                {
                    var tileState = board[x, y];
                    Button tile = CreateTile(x, y, tileState, counter);
                    tableLayoutPanel.Controls.Add(tile, x, y);

                    counter++;
                }
            }
        }

        /// <summary>
        /// Creates a new Tile.
        /// </summary>
        /// <param name="positionX">X position of the tile</param>
        /// <param name="positionY">Y position of the tile</param>
        /// <param name="counter">Counter that will be used for tile naming</param>
        /// <returns>A tile</returns>
        private Button CreateTile(int positionX, int positionY, bool tileState, int counter)
        {
            TileModel tileModel = new TileModel
            {
                TilePositionX = positionX,
                TilePositionY = positionY,
                TileState = tileState
            };

            Button tile = new Button();
            tile.Width = Constants.tileWidth;
            tile.Height = Constants.tileHeight;
            tile.Name = Constants.buttonsNamePrefix + counter;
            tile.Location = new Point(Constants.distanceBetweenTilesX * tileModel.TilePositionX, Constants.distanceBetweenTilesY * tileModel.TilePositionY);
            tile.BackColor = tileModel.TileState == true ? Color.Yellow : Color.Gray;
            tile.Tag = tileModel;
            tile.Click += Btn_Click;

            return tile;
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            Button tile = (Button)sender;
            TileModel tileModel = (TileModel)tile.Tag;
            gameEngine.ToggleAdjucentTiles(tileModel, tableLayoutPanel);
            ValidateBoard();
        }

        private void ValidateBoard()
        {
            bool boardIsValid = gameEngine.ValidateBoard();

            if (boardIsValid)
            {
                MessageBox.Show("Congratulations, you won. ");
                InitializeBoard();
            }
        }
    }
}
