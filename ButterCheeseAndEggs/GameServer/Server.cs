using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Security;
using System.Text;
using System.Threading;

namespace GameServer
{
    public class Server
    {
        #region attributes
        private List<ServerClient> clients;
        private List<ServerClient> clientsInQueue;
        private IPAddress localhost;
        private TcpListener listener;
        private List<Thread> clientThreads;
        private Random random;
        private Dictionary<string, string> IDandUsername;
        private List<String> chatlogs;
        private string directoryPath;
        private bool serverOn;
        #endregion

        #region protocol codes
        public static string disconnectCode = "DCNT";
        public static string chatmessageCode = "CHMS";
        public static string idCode = "IDEN";
        public static string inGameCode = "STIG";
        public static string turnCode = "STTN";
        public static string coordinateCode = "CRDN";
        public static string outcomeCode = "OUTC";
        #endregion

        public static void Main(string[] args)
        {
            Server server = new Server();
            server.start();
        }

        #region startup
        public Server()
        {
            this.serverOn = true;
            this.directoryPath = System.Environment.CurrentDirectory + "\\chatlogs\\chatlogs.txt";
            this.chatlogs = new List<string>();
            this.readChatlogs();
            this.clients = new List<ServerClient>();
            this.clientsInQueue = new List<ServerClient>();
            this.IDandUsername = new Dictionary<string, string>();
            this.localhost = IPAddress.Parse("127.0.0.1");
            this.listener = new TcpListener(localhost, 1337);
            this.clientThreads = new List<Thread>();
            this.random = new Random();           
        }

        public void start()
        {
            this.listener.Start();
            Thread thread = new Thread(AcceptClients);
            thread.Start();

            waitForServerInput();
        }
        #endregion       

        #region accepting clients
        public void AcceptClients()
        {
            Console.WriteLine("Waiting for people to join...");

            while (serverOn)
            {

                TcpClient client = listener.AcceptTcpClient();
                ServerClient serverClient = new ServerClient(client,generateID(),this);
                this.clientsInQueue.Add(serverClient);
                Console.WriteLine("PPL IN Q: "+clientsInQueue.Count);
                this.clients.Add(serverClient);

                Console.WriteLine(serverClient.getID()+" connected");

                Thread thread = new Thread(handleServerClient);
                thread.Start(serverClient);

            }
        }

        public string generateID()
        {
            while (true)
            {
                bool taken = false;
                int id = random.Next(1000, 9999);
                foreach (ServerClient client in this.clients)
                {
                    if (client.getID() == id + "")
                    {
                        taken = true;
                    }
                }
                if (!taken)
                    return id + "";
            }
        }
        #endregion

        #region handling input
        public void handleServerClient(object obj)
        {
            ServerClient serverClient = obj as ServerClient;
            serverClient.Receive();
        }

        public void addUsername(string id, string username)
        {
            this.IDandUsername.Add(id, username);

            Console.WriteLine("Username set!");

            inQueue();

        }

        public void addChatlog(string message)
        {
            this.chatlogs.Add(message);
            saveChatlogs();
        }

        public void waitForServerInput()
        {
            Console.WriteLine("Type 'clear' to clear chatlogs\nType 'quit' to shutdown server");
            while (serverOn)
            {
                string input = Console.ReadLine();
                switch (input)
                {
                    case "quit":
                        stopServer();
                        Console.WriteLine("Goodbye");
                        break;
                    case "clear":
                        clearChatlogs();
                        Console.WriteLine("Chaglogs cleared");
                        break;
                }
            }
        }
        public void stopServer()
        {
            this.serverOn = false;
            foreach (ServerClient client in this.clients)
            {
                client.connected = false;
            }
        }
        #endregion

        #region sending 
        public void SendToAllClients(string message, ServerClient serverClient)
        {
            string key = serverClient.getID();
            string username = IDandUsername[key];

            string messageToSend = "["+username + "]: " + message;

            addChatlog(messageToSend);

            Console.WriteLine("Sending to all clients: "+messageToSend);

            foreach (ServerClient client in this.clients)
            {
                if (serverClient != client)
                    client.Send(Server.chatmessageCode, messageToSend);
            }
        }

        public void getChatMessages(ServerClient client)
        {
            foreach(string message in this.chatlogs)
            {
                client.Send(Server.chatmessageCode, message);
            }
        }
        #endregion        

        #region fileIO
        public void readChatlogs()
        {
            String[] chatlogArray = File.ReadAllLines(directoryPath);
            foreach (string log in chatlogArray)
            {
                this.chatlogs.Add(log);
            }
        }

        public void saveChatlogs()
        {
            File.WriteAllLines(directoryPath, this.chatlogs);
        }

        public void clearChatlogs()
        {
            this.chatlogs.Clear();
            saveChatlogs();
        }
        #endregion

        #region game and queue handling
        public void addClientToQueue(ServerClient client)
        {
            this.clientsInQueue.Add(client);
            inQueue();
        }

        public void inQueue()
        {
            if (this.clientsInQueue.Count >= 2)
            {
                ServerClient client1 = this.clientsInQueue[0];
                ServerClient client2 = this.clientsInQueue[1];
                createGame(client1, client2);
                this.clientsInQueue.Clear();
            }

        }

        public void createGame(ServerClient client1, ServerClient client2)
        {                     
                Game game = new Game(client1,client2);

                client1.Send(Server.inGameCode, "X" + this.IDandUsername[client2.getID()]);
                client2.Send(Server.inGameCode, "O" + this.IDandUsername[client1.getID()]);

                client1.setGame(game);
                client2.setGame(game);

                client1.Send(Server.turnCode, "true");
                client2.Send(Server.turnCode, "false");           
        }
        #endregion
        
    }
}
