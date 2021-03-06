﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;

namespace GameClient
{
    public class Client
    {
        #region attributes
        private GUI GUI;
        private EnterUsername enterUsername;
        private String username;
        private TcpClient server;
        private StreamWriter streamWriter;
        private StreamReader streamReader;
        private bool connected;
        private int wins;
        private int losses;
        private int ties;
        private static byte[] buffer = new byte[1024];
        private static string totalBuffer;
        private string ID;
        private NetworkStream networkStream;

        public string teamString { get; set; }
        public bool turn { get; set; }
        public bool inGame { get; set; }
        public Dictionary<string,bool> coordinates { get; set; }
        #endregion

        #region protocol codes
        /*
        *  The following attributes are made for the message protocol.
        */
        public static string chatmessageCode = "CHMS";
        public static string usernameCode = "USRN";
        public static string disconnectCode = "DCNT";
        public static string coordinateCode = "CRDN";
        public static string gameOverCode = "GORC";
        #endregion

        public static void Main(string[] args)
        {
            Client client = new Client();
            client.login();
        }

        #region startup
        public Client()
        {
            this.server = new TcpClient("127.0.0.1", 1337);
            this.streamWriter = new StreamWriter(server.GetStream(), Encoding.ASCII, -1, true);
            this.streamReader = new StreamReader(server.GetStream(), Encoding.ASCII);
            this.networkStream = server.GetStream();
            this.connected = true;
            this.inGame = false;
            this.turn = false;
            this.coordinates = new Dictionary<string, bool>();
            this.wins = 0;
            this.losses = 0;
            this.ties = 0;
            fillCoordinates();
          
        }

        public void login()
        {
            this.GUI = new GUI(this);
            startEnterUsername();
            //Thread enterUsernameThread = new Thread(startEnterUsername);
            //enterUsernameThread.Start();
        }

        public void start(string username)
        {
            this.username = username;
            this.GUI.setUsername(username);

            Thread GUIThread = new Thread(startGUI);
            GUIThread.Start();


            networkStream.BeginRead(buffer, 0, buffer.Length, new AsyncCallback(OnRead), null);
            //Receive();           
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
        #endregion

        #region receiving and sending
        public void Send(string type, string message)
        {
            try
            {
                if (this.connected != false)
                {
                    streamWriter.WriteLine(type + this.ID + message);
                    streamWriter.Flush();
                }
            }
            catch
            {
                Console.WriteLine("Failed to send");
            }
        }

        private void OnRead(IAsyncResult ar)
        {
            try
            {
                int receivedBytes = networkStream.EndRead(ar);
                string receivedText = System.Text.Encoding.ASCII.GetString(buffer, 0, receivedBytes);
                receivedText = receivedText.Trim();

                Receive(receivedText);

                networkStream.BeginRead(buffer, 0, buffer.Length, new AsyncCallback(OnRead), null);
            } catch
            {
                Console.WriteLine("Disconnected!");
                disconnect();
            }
        }


        public void Receive(string received)
        {        
                try
                {
                    //string received = this.streamReader.ReadLine();
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

                        case "STIG": //set game
                            setInGame(message);
                            break;

                        case "STTN": //set turn
                            setTurn(message);
                            break;

                        case "CRDN": //set coordinate
                            setCoord(message);
                            break;

                        case "OUTC": //set outcome
                            setOutcome(message);
                            break;
                        
                    }

                }
                catch(Exception e)
                {

                    Console.WriteLine("Disconnected!");
                    disconnect();
                }

            
        }
        #endregion

        #region setters
        public void setID(string ID)
        {
            this.ID = ID;           
            this.Send(Client.usernameCode, username);

        }

        public void setOutcome(string message)
        {
            if(message == "winner")
            {
                this.wins++;
                this.GUI.setStats(message, this.wins);
            }
            else if(message == "loser")
            {
                this.losses++;
                this.GUI.setStats(message, this.losses);
            }
            else if(message == "tie")
            {
                this.ties++;
                this.GUI.setStats(message, this.ties);
            }

            this.inGame = false;
            clearAllCoordinates();

            Send(Client.gameOverCode, "");

        }

        public void setCoord(string message)
        {
            string coords = message.Substring(0, 2);          
            string team = message.Substring(2, 1);             
            this.GUI.setCoordinate(coords, team);
        }

        public void setTurn(string turnString)
        {
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
                clearAllCoordinates();
                this.GUI.setOpponent("Waiting for opponent...");
                this.GUI.setTurnLabel("");
            }
            else
            {
                this.inGame = false;
                clearAllCoordinates();
                this.inGame = true;
                setTeam(message);
            }
        }

        public void setTeam(string message)
        {
            this.teamString = message.Substring(0, 1);
            string opponentUsername = message.Substring(1);
            this.GUI.setOpponent(teamString, opponentUsername);

        }
        #endregion

        #region coordinateHandling
        /*
        *  The following method fills in all the possible coordinates in a list.
        */
        public void fillCoordinates()
        {
            int i = 11;
            for (int b = 0; b < 3; b++)
            {
                for (int c = 0; c < 3; c++)
                {

                    this.coordinates.Add(i + "", false);
                    i++;
                }
                i += 7;
            }
        }

        public void clearAllCoordinates()
        {
            this.inGame = false;
            foreach(string key in this.coordinates.Keys)
            {                
                this.GUI.inputSet(key, "");
            }
            this.coordinates = new Dictionary<string, bool>();
            fillCoordinates();
        }

        public bool checkCoordinates()
        {
            bool allFilled = true;
            foreach (KeyValuePair<string, bool> entry in this.coordinates)
            {
                if (this.coordinates[entry.Key] == false)
                {
                    allFilled = false;
                    break;
                }
            }
            return allFilled;
        }
        #endregion

        public void disconnect()
        {
            this.Send(Client.disconnectCode, "");
            this.networkStream.Close();
            this.streamReader.Close();
            this.streamWriter.Close();
            this.server.Close();
            this.connected = false;
        }
    }
}
