using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace GameClient
{
    public class Client
    {

        private GUI GUI;
        private String username;
        private TcpClient server;
        private StreamWriter streamWriter;
        private StreamReader streamReader;
        private bool connected;
        private string ID;

        private string chatmessageCode = "CHMS";




        public static void Main(string[] args)
        {
            Client client = new Client();
            client.start();
        }
        public Client()
        {
            this.server = new TcpClient("127.0.0.1", 1337);
            this.streamWriter = new StreamWriter(server.GetStream(), Encoding.ASCII, -1, true);
            this.streamReader = new StreamReader(server.GetStream(), Encoding.ASCII);
            this.connected = true;

        }

        public void start()
        {
            Thread GUIThread = new Thread(startGUI);
            GUIThread.Start();

            Receive();           
        }

        public void startGUI()
        {
            this.GUI = new GUI(this);
            this.GUI.run();
        }


        public void Send(string type, string message)
        {
            if (this.connected != false)
            {
                streamWriter.WriteLine(type+this.ID+message);
                streamWriter.Flush();
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
                        case "CHMS": //chatmessage
                            this.GUI.addChatMessage(ID+": "+message);
                            break;
                        case "IDEN": //ID set
                            setID(message);
                            break;
                        
                    }

                }
                catch(Exception e)
                {
                    disconnect();
                }

            }
            disconnect();
        }

        public void setID(string ID)
        {
            this.ID = ID;
            Console.WriteLine(ID);
        }

        public void disconnect()
        {
            this.streamReader.Close();
            this.streamWriter.Close();
            this.server.Close();
            this.connected = false;
        }
    }
}
