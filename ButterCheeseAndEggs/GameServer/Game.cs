﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace GameServer
{
    class Game
    {
        #region attributes
        private int player1TurnNumber;
        private int player2TurnNumber;
        private Boolean player1Turn;
        private Boolean player2Turn;
        private Boolean gameWon;
        private int[][] player1Coordinates;
        private int[][] player2Coordinates;
        private ServerClient player1;
        private ServerClient player2;
        #endregion

        #region startup
        public Game(ServerClient player1, ServerClient player2)
        {
            this.player1 = player1;
            this.player2 = player2;
            this.player1TurnNumber = 0;
            this.player2TurnNumber = 0;
            this.player1Turn = true;
            this.player2Turn = false;
            this.gameWon = false;
            //makes the arrays for the coordinates for the players
            initialiseArrays();
        }

        public void initialiseArrays()
        {
            player1Coordinates = new int[5][];
            player2Coordinates = new int[5][];
            for (int i = 0; i < 5; i++)
            {
                player1Coordinates[i] = new int[2];
                player2Coordinates[i] = new int[2];
            }
        }
        #endregion

        #region server communication
        public void SendWinnerAndLoser(ServerClient loser, ServerClient winner)
        {
            Console.WriteLine("we have a winner!");
            winner.Send(Server.outcomeCode, "winner");
            loser.Send(Server.outcomeCode, "loser");
        }

        public void SendBothTies()
        {
            this.player1.Send(Server.outcomeCode, "tie");
            this.player2.Send(Server.outcomeCode, "tie");
        }

        public void sendCoord(ServerClient client, string message) 
        {
            int x = Int32.Parse(message.Substring(1, 1));
            int y = Int32.Parse(message.Substring(0, 1));

            int[] coordinate = new int[] { x, y };
            Console.WriteLine("RECEIVED COORD: x:"+coordinate[0]+" y:"+coordinate[1]);

            check(coordinate);
           
            if (player1 != client)
            {
                player1.Send(Server.coordinateCode, message);
                player1.Send(Server.turnCode, "true");
                player2.Send(Server.turnCode, "false");

            }
            else
            {
                player2.Send(Server.coordinateCode, message);
                player1.Send(Server.turnCode, "false");
                player2.Send(Server.turnCode, "true");

            }
        }

        public void check(int[] coordinate)
        {
            Boolean[] a = receive(coordinate);
            Console.WriteLine("Lenght : "+a.Length+ " 2:" + a[2]);
           
                if (a[0] && a[2])
                {
                    SendWinnerAndLoser(player1, player2);
                }
                else if (a[1] && a[2])
                {
                    SendWinnerAndLoser(player2, player1);
                }
            

        }
        #endregion

        #region game logic
        public Boolean[] receive(int[] newCoords)
        {
            Boolean isUnique = true;
            if (player1Turn)
            {
                //if(player1Coordinates.Length != 0)
                //{
                //    foreach (int[] oldCoords in player1Coordinates)
                //    {
                //        if (newCoords.Equals(oldCoords))
                //        {
                //            isUnique = false;
                //            break;
                //        }
                //    }
                //}
                
                if (isUnique)
                {
                    player1Coordinates[player1TurnNumber] = newCoords;
                    player1TurnNumber++;
                    if (player1TurnNumber > 2)
                        checkFullRow();
                    player1Turn = false;
                    player2Turn = true;                 
                }
                if(player1TurnNumber >= 5 && gameWon == false)               
                    SendBothTies();
                
                {

                }
            }
            else if (player2Turn)
            {
                //if(player2Coordinates.Length != 0)
                //{
                //    foreach (int[] oldCoords in player2Coordinates)
                //    {
                //        if (newCoords.Equals(oldCoords))
                //        {
                //            isUnique = false;
                //            break;
                //        }
                //    }
                //}
                
                if (isUnique)
                {
                    player2Coordinates[player2TurnNumber] = newCoords;
                    player2TurnNumber++;
                    if (player2TurnNumber > 2)
                        checkFullRow();
                    player1Turn = true;
                    player2Turn = false;           
                    
                }
            }
            
            return new Boolean[] {player1Turn, player2Turn, gameWon};
        }

        public void checkFullRow()
        {
            Console.WriteLine("AAAAAA");
            Boolean[] checkingArray = new Boolean[9];

            if(player1Turn)
            {
                foreach (int[] coordinates in player1Coordinates)
                {
                    Console.WriteLine((coordinates[0] + " : "+coordinates[1]));

                    Console.WriteLine((coordinates[0] - 1) + ((coordinates[1] - 1) * 3));
                    //puts all the coordinates in a 2d array
                    if((coordinates[0] - 1) + ((coordinates[1] - 1) * 3) >= 0)
                        checkingArray[(coordinates[0] - 1) + ((coordinates[1] - 1) * 3)] = true;

                }
               
            }

            if (player2Turn)
            {
                foreach (int[] coordinates in player2Coordinates)
                {
                    //puts all the coordinates in a 2d array
                    if ((coordinates[0] - 1) + ((coordinates[1] - 1) * 3) >= 0)
                        checkingArray[(coordinates[0] - 1) + ((coordinates[1] - 1) * 3)] = true;
                }
            }

            for (int i = 0; i < 3; i++)
            {
                //checks all horizontalRows for wins
                if (checkingArray[i] && checkingArray[i + 1] && checkingArray[i + 3])
                {
                    gameWon = true;
                }
                //checks all vertical rows for wins
                if (checkingArray[i] && checkingArray[i + 3] && checkingArray[i + 6])
                {
                    gameWon = true;
                }
            }
            if (checkingArray[0] && checkingArray[4] && checkingArray[8])
            {
                gameWon = true;
            }
            if (checkingArray[2] && checkingArray[4] && checkingArray[6])
            {
                gameWon = true;
            }
            
        }
        #endregion
    }
}
