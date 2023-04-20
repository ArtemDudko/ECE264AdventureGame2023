//Artem Dudko, Nikolas Tapanainen, Thomas J Ryan, Sai Abhishek Bhattiprolu - started 3/29/23
//ECE264 - Advneture Game Final Project
//Referneces:
/*
 *      <<GITHUB>>
 * FOR WORKING ON YOUR BRANCH:
 * 
 * 
 * 
 * 
 * 
 */


using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;




namespace ECE264AdventureGame2023
{
    class Program    //Game.cs equivalent
    {
        static void Main(string[] args)
        {
            string[,] room_data = Rooms.LoadRooms();        //load rooms.txt into 2d array, dimesnisons 4 rows by 100 coloumns
                                                            //order is same as in rooms.txt: roomid, room name, short desc, long desc
            string[,] exit_data = Rooms.LoadExits();



            MyGlobals.Debug = GetYesNo("Would you like to enable Debug mode?");  //Check if this is on using ifs, debug messages are surrounded by brackets
            //EX:
            if (MyGlobals.Debug) Console.WriteLine("[Debug Mode Enabled]");            



            string playerName = WelcomePlayer("Please enter your name: "); //welcome and get name
            


            //int currentRoomID = 1;
            int currentRoom = 1;
            int chosen_exit_id;
            int playerAction = 0; //0 = start, 1 = move, 2 = look around

            while (true)   //game loop
            {
                Console.WriteLine(room_data[currentRoom, 2]);
                //nextRoom = Rooms.Navigate(nextRoom);
                

                while(!(playerAction == 1))
                {
                    playerAction = GetPlayerAction("What would you like to do?");
                    if(playerAction == 2)
                        Console.WriteLine(room_data[currentRoom, 3]);



                }

                //Console.WriteLine("Where would you like to go?: ");
                chosen_exit_id = Rooms.ListExits(currentRoom, exit_data);
                currentRoom = chosen_exit_id;
















            }



            //Console.WriteLine("you're journey begins here, in the: {0}",Roomdata);
            //Console.WriteLine("you have the ability to move in 4 directions: North(N),South(S),East(E),West(W)");


            
            //use method choices for movement from player prompt.cs



        }









        static string WelcomePlayer(string prompt)
        {
            ///Insert other introductory stuff here
            Console.WriteLine("Welcome to Cyber Conspiracy!");
            Console.WriteLine(prompt);
           string userInput =  Console.ReadLine();            
            Console.WriteLine("Hi, " + userInput);
            return userInput;
        }


        

        static int GetPlayerAction(string prompt)
        {
            int player_action = 0;
            string[] valid = { "MOVE", "M", "LOOK", "L", "LOOK AROUND", "EXPLORE" };
            string[] move = {"MOVE", "M"};
            string[] look_around = { "LOOK", "L", "LOOK AROUND", "EXPLORE" };
            string ans = GetString(prompt, valid, "?Invalid response, please reenter");
            if (move.Contains(ans))
                player_action = 1;
            else if (look_around.Contains(ans))
                player_action = 2;
            

            return player_action;

        }

        static bool GetYesNo(string prompt)
        {
            string[] valid = { "YES", "Y", "NO", "N" };
            string ans;
            ans = GetString(prompt, valid, "?Invalid response, please reenter");
            return (ans == "YES" || ans == "Y");

        }
        //Universal get string with prompt, valid values, and error message
        static string GetString(string prompt, string[] valid, string error)
        {
            //prompt = user prompt, valid = array of valid responses
            //error = msg to display on invalid entry
            //all strings returned upper case. all valid[] entries must be in upper case
            string response;
            bool OK = false;
            do
            {
                Console.Write(prompt);
                response = Console.ReadLine().ToUpper();
                foreach (string s in valid) if (response == s.ToUpper()) OK = true;
                if (!OK) Console.WriteLine(error);

            } while (!OK);
            return response;
        }

        static void GameOver(int gameOverNumber)
        {
            switch (gameOverNumber)
            {
                case 1:
                    Console.WriteLine("Your connections were not strong enough to get you out of this bind, \nCyclone will make sure nobody hears of you.");
                    break;
                case 2:
                    Console.WriteLine("'Sorry, but the house always wins, and you can no longer pay your debt.'");
                    break;
            }
            Console.WriteLine("GAME OVER, YOU REACHED BAD ENDING #" + gameOverNumber + ", THANKS FOR PLAYING");

        }
        //global variables
        public static class MyGlobals
        {
            //public const string Prefix = "ID_"; // cannot change
            public static bool Debug = false; // can change because not const
        }



    }
}
