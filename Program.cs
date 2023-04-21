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
            string[,] exit_data = Rooms.LoadExits();        //loads exitsConditions.txt into a 11 row by 100 col array
            Console.ForegroundColor = ConsoleColor.White;
            MyGlobals.Debug = GetYesNo("Would you like to enable Debug mode? ");  //Check if this is on using ifs, debug messages are surrounded by brackets
            //EX:
            if (MyGlobals.Debug){Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("[Debug Mode Enabled]"); Console.ForegroundColor = ConsoleColor.White;}
                

            //welcome and get name
            
            Console.Write("Please enter your name: ");
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            string playerName = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Hi, " + playerName);
            Console.WriteLine("Welcome to Cyber Conspiracy!");
            Console.WriteLine("Try moving around or picking up items to progress. At the start of any room, type HELP to list your commands.\n");
            
            //setup stuff
            int currentRoom = 1;
            int chosen_exit_id;
            int playerAction = 0; //0 = start, 1 = move, 2 = look around

            while (true)   //game loop
            {
                Console.WriteLine(room_data[currentRoom, 2]);
                //nextRoom = Rooms.Navigate(nextRoom);

                playerAction = 0;       //reset action to trigger loop
                while(!(playerAction == 1))
                {
                    //constantly prompt player to make a choice, once they want to move, 
                    playerAction = GetPlayerAction("What would you like to do? ");
                    switch(playerAction)
                    {
                        //move
                        case 1:     
                            Console.WriteLine("Here are your options:");
                            //prompt room.cs to give the player their current exits, and then move the player to a new room
                            chosen_exit_id = Rooms.ListExits(currentRoom, room_data[currentRoom, 1], exit_data);
                            currentRoom = chosen_exit_id;


                            //once the player moves, rinse and repeat
                            if (MyGlobals.Debug){ Console.ForegroundColor = ConsoleColor.Cyan; 
                                Console.WriteLine("[Current Room is: {0}, RoomID:{1}]", currentRoom, room_data[currentRoom, 1]); Console.ForegroundColor = ConsoleColor.White; }
                            break;
                        //display long desc
                        case 2:     
                            Console.WriteLine(room_data[currentRoom, 3]);   
                            break;
                        case 3:
                            Console.WriteLine("Here are your commands:");
                            Console.WriteLine("HELP - Replay this command.");
                            Console.WriteLine("MOVE/M/GO - Choose an exit from your current location with a cardinal direction.");
                            Console.WriteLine("LOOK/EXAMINE/EXPLORE/E - Get a better description of the area, sometimes enhanced by items.");
                            Console.WriteLine("TAKE/PICKUP [ITEM] - Take an [ITEM] from the room and stow it.");
                            Console.WriteLine("DROP/LEAVE [ITEM] - Drop an [ITEM] in the room from your inventory.");
                            Console.WriteLine("EXIT/QUIT - Quit the game.");
                            break;
                    }
                        

               




                }
                
            }



            //Console.WriteLine("you're journey begins here, in the: {0}",Roomdata);
            //Console.WriteLine("you have the ability to move in 4 directions: North(N),South(S),East(E),West(W)");


            
            //use method choices for movement from player prompt.cs



        }









        


        

        static int GetPlayerAction(string prompt)
        {
            int player_action = 0;
            string[] valid = { "MOVE", "M", "GO", "LOOK", "L", "E", "LOOK AROUND", "EXPLORE","HELP" };
            string[] move = {"MOVE", "M","GO"};
            string[] look_around = { "LOOK", "L", "LOOK AROUND", "EXPLORE", "E","EXAMINE" };
            string[] help = { "HELP" };

            string userInput = GetString(prompt, valid, "?Invalid response, please reenter");

            if (move.Contains(userInput))
                player_action = 1;
            else if (look_around.Contains(userInput))
                player_action = 2;
            else if (help.Contains(userInput))
                player_action = 3;

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
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                response = Console.ReadLine().ToUpper();
                Console.ForegroundColor = ConsoleColor.White;
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
