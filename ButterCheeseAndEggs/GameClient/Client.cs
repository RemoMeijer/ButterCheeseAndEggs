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
        private EnterUsername enterUsername;
        private String username;
        private TcpClient server;
        private StreamWriter streamWriter;
        private StreamReader streamReader;
        private bool connected;
        private string ID;
        public string teamString { get; set; }
        public bool turn { get; set; }
        public bool inGame { get; set; }
        public Dictionary<string,bool> coordinates { get; set; }

        public static string chatmessageCode = "CHMS";
        public static string usernameCode = "USRN";
        public static string disconnectCode = "DCNT";
        public static string coordinateCode = "CRDN";

        public static void Main(string[] args)
        {
            Client client = new Client();
            client.login();
        }
        public Client()
        {
            this.server = new TcpClient("127.0.0.1", 1337);
            this.streamWriter = new StreamWriter(server.GetStream(), Encoding.ASCII, -1, true);
            this.streamReader = new StreamReader(server.GetStream(), Encoding.ASCII);
            this.connected = true;
            this.inGame = false;
            this.turn = false;
            this.coordinates = new Dictionary<string, bool>();
            fillCoordinates();
          
        }

        public void fillCoordinates()
        {
            int i = 11;
            for(int b = 0; b < 3; b++)
            {
                for (int c = 0; c < 3; c++)
                {

                    this.coordinates.Add(i + "", false);
                    i++;
                }
                i += 7;
            }         
        }

        public void setAllCoordinatesFalse()
        {
            foreach (KeyValuePair<string, bool> entry in this.coordinates)
            {
                this.coordinates[entry.Key] = false;
            }
        }

        public void login()
        {
            this.GUI = new GUI(this);
            Thread enterUsernameThread = new Thread(startEnterUsername);
            enterUsernameThread.Start();
        }

        public void start(string username)
        {
            this.username = username;
            this.GUI.setUsername(username);

            Thread GUIThread = new Thread(startGUI);
            GUIThread.Start();

            Receive();           
        }

        public void startEnterUsername()
        {
            this.enterUsername = new EnterUsername(this);
            this.enterUsername.run();
        }

        public void startGUI()
        {
            this.GUI.run();
        }


        public void Send(string type, string message)
        {
            if (this.connected != false)
            {
                Console.WriteLine("ID: " + ID);
                streamWriter.WriteLine(type+this.ID+message);
                streamWriter.Flush();
            }
        }

        #region receiving
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
                            this.GUI.addChatMessage(message);
                            break;

                        case "IDEN": //ID set
                            setID(message);
                            break;
                        case "STIG":
                            setInGame(message);
                            break;
                        case "STTN":
                            setTurn(message);
                            break;
                        case "CRDN":
                            setCoord(message);
                            break;
                        
                    }

                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine(e.StackTrace);

                    Console.WriteLine("Couldnt connect!");
                    disconnect();
                }

            }
            disconnect();
        }
        #endregion  
        public void setID(string ID)
        {
            this.ID = ID;
            this.Send(Client.usernameCode, username);

        }

        public void setCoord(string message)
        {
            string coords = message.Substring(0, 2);
            string team = message.Substring(2, 1);
            this.GUI.setCoordinate(coords, team);
        }

        public void setTurn(string turnString)
        {
            Console.WriteLine(turnString);
            if(turnString == "true")
            {
                this.turn = true;
                this.GUI.setTurnLabel("Your turn!");
            }else
            {
                this.turn = false;
                this.GUI.setTurnLabel("Opponent's turn");

            }
        }

        public void setInGame(string message)
        {
            if(message == "false")
            {
                this.inGame = false;
            }
            else
            {
                this.inGame = true;
                setTeam(message);
            }
        }

        public void setTeam(string message)
        {
            this.teamString = message.Substring(0, 1);
            string opponentUsername = message.Substring(1);
            Console.WriteLine(teamString + " "+opponentUsername);
            this.GUI.setOpponent(teamString, opponentUsername);

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
