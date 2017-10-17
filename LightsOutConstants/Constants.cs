using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LightsOutConstants
{
    public class Constants
    {
        #region BoardInitializationConstants
        public const string buttonsNamePrefix = "LightsOutButton";

        public const int tileWidth = 60;
        public const int tileHeight = 60;
        
        //distanceBetweenTilesX,distanceBetweenTilesY are going to be used to space buttons
        //Their value is currently 80 because buttons have a width and height of 60
        //So buttons will have 20points distance between them
        public const int distanceBetweenTilesX = 80;
        public const int distanceBetweenTilesY = 80;
        #endregion

    }
}
