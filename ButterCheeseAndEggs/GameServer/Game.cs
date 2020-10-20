using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace GameServer
{
    class Game
    {
        private int turn;
        private Boolean player1Turn;
        private Boolean player2Turn;
        private Boolean gameWon;
        private int[][] player1Coordinates;
        private int[][] player2Coordinates;
        private ServerClient player1;
        private ServerClient player2;



        public Game(ServerClient player1, ServerClient player2)
        {
            this.player1 = player1;
            this.player2 = player2;
            turn = 0;
            player1Turn = true;
            player2Turn = false;
            gameWon = false;
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

        public void sendCoord(ServerClient client, string message) 
        {
            if(player1 != client)
            {
                player1.Send(ServerClient.coordinateCode, message);
                player1.Send(ServerClient.turnCode, "true");
                player2.Send(ServerClient.turnCode, "false");

            }
            else
            {
                player2.Send(ServerClient.coordinateCode, message);
                player1.Send(ServerClient.turnCode, "false");
                player2.Send(ServerClient.turnCode, "true");

            }
        }

        public Boolean[] receive(int[] newCoords)
        {
            Boolean isUnique = true;
            if (player1Turn)
            {
                if(player1Coordinates.Length != 0)
                {
                    foreach (int[] oldCoords in player1Coordinates)
                    {
                        if (newCoords.Equals(oldCoords))
                        {
                            isUnique = false;
                            break;
                        }
                    }
                }
                
                if (isUnique)
                {
                    player1Coordinates[turn] = newCoords;
                    turn++;
                    if (turn > 4)
                        checkFullRow();
                    player1Turn = false;
                    player2Turn = true;                 
                }
            }
            else if (player2Turn)
            {
                if(player2Coordinates.Length != 0)
                {
                    foreach (int[] oldCoords in player2Coordinates)
                    {
                        if (newCoords.Equals(oldCoords))
                        {
                            isUnique = false;
                            break;
                        }
                    }
                }
                
                if (isUnique)
                {
                    player1Coordinates[turn - 1] = newCoords;
                    turn++;
                    if (turn > 4)
                        checkFullRow();
                    player1Turn = true;
                    player2Turn = false;                    
                }
            }
            return new Boolean[] {player1Turn, player2Turn, gameWon};
        }

        public void checkFullRow()
        {
            Boolean[] checkingArray = new Boolean[9];

            if(player1Turn)
            {
                foreach (int[] coordinates in player1Coordinates)
                {
                    //puts all the coordinates in a 2d array
                    checkingArray[(coordinates[0] - 1) + ((coordinates[1] - 1) * 3)] = true;
                }               
            }

            if (player2Turn)
            {
                foreach (int[] coordinates in player2Coordinates)
                {
                    //puts all the coordinates in a 2d array
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
    }
}
