using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Text;

namespace GameServer
{
    public class ServerClient
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
                if (this.connected != false)
                {
                    streamWriter.WriteLine(type + this.ID + message);
                    streamWriter.Flush();
                }
            }
            catch {
                Console.WriteLine("Failed to send");
            }
        }

       /*
        *  The following method receives the messages, divides them and takes the right
        *  action depending on the type of the message.
        */
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
                        case "CRDN": //set coordinates
                            setCoords(message);
                            break;
                        case "GORC": //set gameover
                            setGameOver();
                            break;
                    }
                
           
                }
                catch(Exception e)
                {
                    disconnect();

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

        #region disconnecting
        public void disconnect()
        {
            disconnectFromGame();
            this.server.removeClientFromClients(this);
            this.server.removeClientFromQueue(this);
            this.streamReader.Close();
            this.streamWriter.Close();
            this.client.Close();
            this.connected = false;
            Console.WriteLine(this.username + " - " + this.ID + " - disconnected");
        }

        public void disconnectFromGame()
        {
            if(this.game != null)
            {
                if(game.player1 != this)               
                    this.server.removeClientFromGame(game.player1);
                else
                    this.server.removeClientFromGame(game.player2);

            }
        }
        #endregion
    }

}
