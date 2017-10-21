using LightsOutBL.Helpers;
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
        //Public array initialization
        int[,] tileArray = new int[5, 5];

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
            //Setting the size of The form
            this.AutoSize = true;

            //Counter will be used for naming the form buttons.
            int counter = 1;

            for (int i = 0; i < tileArray.GetLength(0); i++) //GetLength(0) => Will get the length of the first dimension of the array
            {
                for (int j = 0; j < tileArray.GetLength(1); j++) //GetLength(1) => Will get the length of the second dimension of the array
                {
                    Button tile = CreateTile(i, j, counter);
                    this.Controls.Add(tile);

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
        private Button CreateTile(int positionX, int positionY, int counter)
        {
            Button tile = new Button();
            tile.Width = Constants.tileWidth;
            tile.Height = Constants.tileHeight;
            tile.Name = Constants.buttonsNamePrefix + counter;
            tile.Location = new Point(Constants.distanceBetweenTilesX * positionX, Constants.distanceBetweenTilesY * positionY);
            tile.Tag = positionX.ToString() + "," + positionY.ToString();
            tile.Click += Btn_Click;

            return tile;
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            Button tile = (Button)sender;
        }
    }
}
