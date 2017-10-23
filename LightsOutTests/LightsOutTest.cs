using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LightsOutBL.Helpers;

namespace LightsOutTests
{
    [TestClass]
    public class LightsOutTest
    {
        [TestMethod]
        public void SetAllLightsToTrue()
        {
            GameEngine gameEngine = new GameEngine();
            var board = gameEngine.GenerateBoard(5, 5);

            gameEngine.SetBoardToTrue();

            var isTrue = true;

            for (int x = 0; x < 5; x++)
            {
                for (int y = 0; y < 5; y++)
                {
                    if (board[x, y] == false)
                        isTrue = false;
                }
            }

            Assert.IsTrue(isTrue);
        }
    }
}
