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
                    Button btn = new Button();
                    btn.Width = Constants.tileWidth;
                    btn.Height = Constants.tileHeight;
                    btn.Name = Constants.buttonsNamePrefix + counter;
                    btn.Location = new Point(Constants.distanceBetweenTilesX * i, Constants.distanceBetweenTilesY * j);
                    btn.Tag = i.ToString() + "," + j.ToString();
                    btn.Click += Btn_Click;
                    this.Controls.Add(btn);

                    counter++;
                }
            }
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
        }
    }
}
