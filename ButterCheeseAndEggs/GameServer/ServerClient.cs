using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Text;

namespace GameServer
{
    class ServerClient
    {
        #region attributes
        private TcpClient client;
        private String username;
        private string ID;
        private StreamWriter streamWriter;
        private StreamReader streamReader;
        public bool connected { get; set; }
        private Server server;
        private Game game;
        #endregion

        public ServerClient(TcpClient client, string ID, Server server)
        {
            this.server = server;
            this.connected = true;
            this.client = client;
            this.ID = ID;
            this.streamWriter = new StreamWriter(client.GetStream(), Encoding.ASCII, -1, true);
            this.streamReader = new StreamReader(client.GetStream(), Encoding.ASCII);
            Send(Server.idCode, ID);

        }

        #region sending and receiving
        public void Send(string type,string message)
        {
            try
            {
                streamWriter.WriteLine(type+this.ID+message);
                streamWriter.Flush();
            }
            catch {
                Console.WriteLine("Failed to send");
            }
        }

        public void Receive()
        {
            while (connected)
            {
                try
                {
                    string received = this.streamReader.ReadLine();
                    string type = received.Substring(0, 4);
                    string ID = received.Substring(4, 4);
                    string message = received.Substring(8);


                    switch (type)
                    {
                        case "USRN": //username set
                            this.server.addUsername(ID,message);
                            this.username = message;
                            this.server.getChatMessages(this);
                            break;

                        case "CHMS": //chatmessage
                            this.server.SendToAllClients(message,this);
                            break;

                        case "DCNT": //disconnect
                            disconnect();
                            break;
                        case "CRDN":
                            setCoords(message);
                            break;
                        case "GORC":
                            setGameOver();
                            break;
                    }
                
           
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine("Couldnt connect!");

                }
            }
    
        }
        #endregion

        #region getters and setters
        public string getID()
        {
            return this.ID;
        }

        public void setCoords(string message)
        {
            string coords = message.Substring(0, 2);
            int x = Int32.Parse(message.Substring(0, 1));
            int y = Int32.Parse(message.Substring(1, 1));
            string team = message.Substring(2, 1);
            
            this.game.sendCoord(this,message);
        }

        public void setGameOver()
        {
            this.server.addClientToQueue(this);
        }

        public void setGame(Game game)
        {
            this.game = game;
        }
        #endregion

        public void disconnect()
        {
            this.streamReader.Close();
            this.streamWriter.Close();
            this.client.Close();
            this.connected = false;
            Console.WriteLine(this.ID + " has disonnected");
        }

    }

}
