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
    class Game    //Game.cs equivalent
    {
        static void Main(string[] args)
        {
            string[,] room_data = Rooms.LoadRooms();





            MyGlobals.Debug = GetYesNo("Would you like to enable Debug mode?");  //Check if this is on using ifs, debug messages are surrounded by brackets
            //EX:
            if (MyGlobals.Debug) Console.WriteLine("[Debug Mode Enabled]");


            Console.WriteLine("Welcome to Cyber Conspiracy!");

            string playerName = WelcomePlayer();
            Console.WriteLine("Hi, " + playerName);


            //int currentRoomID = 1;
            int nextRoom = 1;
            int playerAction = 0; //0 = start, 1 = move, 2 = look around

            while (true)   //game loop
            {
                Console.WriteLine(room_data[nextRoom,2]);
                //nextRoom = Rooms.Navigate(nextRoom);
                

                while(!(playerAction == 1))
                {
                    playerAction = GetPlayerAction("What would you like to do?");
                    if(playerAction == 2)
                        Console.WriteLine(room_data[nextRoom, 3]);
                }

                Console.WriteLine("Where would you like to go? (Enter RoomID): ");
                nextRoom = int.Parse(Console.ReadLine());












            }










        }









        static string WelcomePlayer()
        {
            ///Insert other introductory stuff here
            Console.WriteLine("Welcome to Cyber Conspiracy!");
            Console.WriteLine("Please enter your name: ");            
            string userInput = Console.ReadLine();
            return userInput;

        }
        static bool GetYesNo(string prompt)
        {
            string[] valid = { "YES", "Y", "NO", "N" };
            string ans;
            ans = GetString(prompt, valid, "?Invalid response, please reenter");
            return (ans == "YES" || ans == "Y");

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
