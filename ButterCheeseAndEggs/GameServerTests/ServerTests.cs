﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using GameServer;
using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Sockets;

namespace GameServer.Tests
{
    [TestClass()]
    public class ServerTests
    {
        private Server server;

        public ServerTests()
        {
            this.server = new Server();

        }
        [TestMethod()]
        public void generateIDTest()
        {
            Assert.AreEqual(4, server.generateID().Length);
        }

        [TestMethod()]
        public void addChatlogTest()
        {
            server.addChatlog("Test"); 
        }
    }
}