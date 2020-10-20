using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace GameServer
{
    class Server
    {
        private List<ServerClient> clients;
        private List<ServerClient> clientsInQueue;
        private IPAddress localhost;
        private TcpListener listener;
        private List<Thread> clientThreads;
        private Random random;
        private Dictionary<string, string> IDandUsername;

        private string disconnectCode = "DCNT";
        private string chatmessageCode = "CHMS";

        public static void Main(string[] args)
        {
            Server server = new Server();
            server.start();
        }

        public Server()
        {
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
            AcceptClients();
        }

        public void AcceptClients()
        {
            Console.WriteLine("Waiting for people to join...");

            while (true)
            {

                TcpClient client = listener.AcceptTcpClient();
                ServerClient serverClient = new ServerClient(client,generateID(),this);
                this.clients.Add(serverClient);
                this.clientsInQueue.Add(serverClient);

                Console.WriteLine(serverClient.getID()+" connected");

                Thread thread = new Thread(handleServerClient);
                thread.Start(serverClient);

            }
        }



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

            createGames();

        }
        #endregion

        #region sending 
        public void SendToAllClients(string message, ServerClient serverClient)
        {
            string key = serverClient.getID();
            string username = IDandUsername[key];

            string messageToSend = "["+username + "]: " + message;

            Console.WriteLine("Sending to all clients: "+messageToSend);

            foreach (ServerClient client in this.clients)
            {
                if (serverClient != client)
                    client.Send(ServerClient.chatmessageCode, messageToSend);
            }
        }
        #endregion

        #region generating
        public string generateID()
        {
            while (true)
            {
                bool taken = false;
                int id = random.Next(1000, 9999);
                foreach (ServerClient client in this.clients)
                {
                    if (client.getID() == id+"")
                    {
                        taken = true;
                    }
                }
                if (!taken)
                    return id+"";
            }
        }

        public void createGames()
        {          
            if(this.clientsInQueue.Count == 2)
            {
                ServerClient client1 =  this.clientsInQueue[0];
                ServerClient client2 =  this.clientsInQueue[1];

                client1.Send(ServerClient.inGameCode, "O" + this.IDandUsername[client2.getID()]);
                client2.Send(ServerClient.inGameCode, "X" + this.IDandUsername[client1.getID()]);

                this.clientsInQueue.Clear();
            }
        }
        #endregion



    }
}
