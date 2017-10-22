using LightsOutBL.Helpers.IHelpers;
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
        /// Generates a random bool with 50% chance
        /// </summary>
        /// <returns>Bool</returns>
        private bool RandomBool()
        {
            Random random = new Random();
            int randomNumber = random.Next(0, 100);
            if (randomNumber > 50)
                return false;
            else
                return true;
        }
    }
}
