using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Security;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

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
        /*
         *  The following attributes are made for the message protocol.
         */
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
            this.directoryPath = System.Environment.CurrentDirectory + "\\chatlogs.txt";
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
            this.listener.BeginAcceptTcpClient(new AsyncCallback(AcceptClients), null);
            waitForServerInput();
        }
        #endregion       

        #region accepting clients
        public void AcceptClients(IAsyncResult ar)
        {       
                TcpClient client = listener.EndAcceptTcpClient(ar);
                ServerClient serverClient = new ServerClient(client, generateID(), this);
                this.clientsInQueue.Add(serverClient);
                this.clients.Add(serverClient);

                Thread thread = new Thread(handleServerClient);
                thread.Start(serverClient);

                this.listener.BeginAcceptTcpClient(new AsyncCallback(AcceptClients), null);
        }

        /*
        *  The following generates an ID for each client.
        */
        public string generateID()
        {
            while (true)
            {
                string id = random.Next(1000, 9999)+"";
                if (!checkID(id));
                {
                    return id;
                }
            }
        }

        /*
        *  The following method checks the generated ID to see if it's not being used already.
        */
        public bool checkID(string id)
        {
            foreach (ServerClient client in this.clients)
            {
                if (client.getID() == id)
                {
                    return true;
                }
            }
            return false;
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

            Console.WriteLine(username + " - "+id+ " - connected");

            inQueue();

        }

        public void addChatlog(string message)
        {
            this.chatlogs.Add(message);
            saveChatlogs();
        }

        public void waitForServerInput()
        {
            Console.WriteLine("Type 'clear' to clear chatlogs");
            while (serverOn)
            {
                string input = Console.ReadLine();
                if(input == "clear")
                {
                    clearChatlogs();
                    Console.WriteLine("Chatlogs cleared");
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
        /*
         *  The following method sends a message to all clients but also makes sure
         *  the message is not sent to the serverclient it came from.       
         */
        public void SendToAllClients(string message, ServerClient serverClient)
        {
            string key = serverClient.getID();
            string username = IDandUsername[key];

            string messageToSend = "["+username + "]: " + message;

            addChatlog(messageToSend);

            Console.WriteLine(messageToSend);

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
                Thread.Sleep(50);
                client.Send(Server.chatmessageCode, message);
            }
        }
        #endregion        

        #region fileIO
        public void readChatlogs()
        {
            try
            {
                String[] chatlogArray = File.ReadAllLines(directoryPath);
                foreach (string log in chatlogArray)
                {
                    this.chatlogs.Add(log);
                }
            }
            catch
            {
                Console.WriteLine("Chatlogs folder not created yet");
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

        public void removeClientFromGame(ServerClient client)
        {
            client.Send(Server.inGameCode, "false");
            this.addClientToQueue(client);
        }

        /*
         *  The following method checks the amount of people in queue and calls
         *  the createGame() method when there are enough people in queue to create a game.        
         */
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

        /*
        *  The following method creates a game and sends the corresponding messages 
        *  the serverclients. 
        */
        public void createGame(ServerClient client1, ServerClient client2)
        {                     
                Game game = new Game(client1,client2);

                client1.Send(Server.inGameCode, "X" + this.IDandUsername[client2.getID()]);
                client2.Send(Server.inGameCode, "O" + this.IDandUsername[client1.getID()]);

                client1.setGame(game);
                client2.setGame(game);

                Thread.Sleep(500);  

                client1.Send(Server.turnCode, "true");
                client2.Send(Server.turnCode, "false");           
        }
        #endregion

        #region removingClients
        public void removeClientFromQueue(ServerClient client)
        {
            if (this.clientsInQueue.Contains(client))
            {
                this.clientsInQueue.Remove(client);
            }
        }

        public void removeClientFromClients(ServerClient client)
        {
            if (this.clients.Contains(client))
            {
                this.clients.Remove(client);
            }
        }
        #endregion

    }
}
