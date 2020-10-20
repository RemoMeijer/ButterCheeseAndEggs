using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Text;

namespace GameServer
{
    class ServerClient
    {
        private TcpClient client;
        private String username;
        private string ID;
        private StreamWriter streamWriter;
        private StreamReader streamReader;
        private bool connected;
        private Server server;
        private Game game;

        public static string disconnectCode = "DCNT";
        public static string chatmessageCode = "CHMS";
        public static string idCode = "IDEN";
        public static string inGameCode = "STIG";
        public static string turnCode = "STTN";

        public ServerClient(TcpClient client, string ID, Server server)
        {
            this.server = server;
            this.connected = true;
            this.client = client;
            this.ID = ID;
            this.streamWriter = new StreamWriter(client.GetStream(), Encoding.ASCII, -1, true);
            this.streamReader = new StreamReader(client.GetStream(), Encoding.ASCII);
            Send(ServerClient.idCode, ID);

        }

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
                            break;

                        case "CHMS": //chatmessage
                            this.server.SendToAllClients(message,this);
                            break;

                        case "DCNT": //disconnect
                            disconnect();
                            break;
                        case "CRDN":

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

        public string getID()
        {
            return this.ID;
        }

        public void setGame(Game game)
        {
            this.game = game;
        }

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
