using Microsoft.VisualStudio.TestTools.UnitTesting;
using GameServer;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameServer.Tests
{
    [TestClass()]
    public class GameTests
    {
        private Game game;

        public GameTests()
        {
            this.game = new Game();
        }
        [TestMethod()]
        public void receiveTest()
        {
            int[] coords = new int[] { 1, 1 };           
            Boolean[] actualBoolean = this.game.receive(coords);
            bool bool1 = actualBoolean[0];
            bool bool2 = actualBoolean[1];
            bool bool3 = actualBoolean[2];

            Assert.AreEqual(false, bool1);
            Assert.AreEqual(true, bool2);
            Assert.AreEqual(false, bool3);

            coords = new int[] { 2, 2 };
            actualBoolean = this.game.receive(coords);
            bool1 = actualBoolean[0];
            bool2 = actualBoolean[1];
            bool3 = actualBoolean[2];

            Assert.AreEqual(true, bool1);
            Assert.AreEqual(false, bool2);
            Assert.AreEqual(false, bool3);
        }
    }
}