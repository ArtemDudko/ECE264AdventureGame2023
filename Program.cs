//Artem Dudko, Nikolas Tapanainen, Thomas J Ryan, Sai Abhishek Bhattiprolu - started 3/29/23
//ECE264 - Advneture Game Final Project
//Referneces:
/*
 *READ ME:
 *
 *PLEASE ENTER DIRECTORY WHERE FOLDER IS STORED TO RUN THE GAME AS 'root_folder' VARIABLE BEFORE LAUNCHING. 
 * 
 * 
 * 
 * dialogue and other stuff on entering room for hte firs t time
 * talk feature
 * trigger options, and something to check them
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

            string root_folder = "C:\\AdventureGame264 GitHub"; //CHANGE ME TO ROOT FOLDER



            
            string[,] room_data = Rooms.LoadRooms(root_folder);        //load rooms.txt into 2d array, dimesnisons 4 rows by 100 coloumns
                                                            
            string[,] exit_data = Rooms.LoadExits(root_folder);        //loads exitsConditions.txt into a 11 row by 100 col array

            var trigger_data = new List<bool>(); //read triggers for most interactions
            for (int i = 0; i < 500; i++)
                trigger_data.Add(false);
            trigger_data[0] = true;

            var trigger_switch = new List<int>();
            string[,] item_data = Inventory.LoadItems(root_folder);
            int ending = 0;

            Console.ForegroundColor = ConsoleColor.White;
            MyGlobals.Debug = GetYesNo("Would you like to enable Debug mode? ");  //Check if this is on using ifs, debug messages are surrounded by brackets
            //EX:
            if (MyGlobals.Debug){Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("[Debug Mode Enabled]"); Console.ForegroundColor = ConsoleColor.White;}


            //setup stuff
            int currentRoom = 1;
            int chosen_exit_id;
            int playerAction = 0; //0 = start, 1 = move, 2 = look around
            int money = 150;

            Console.ForegroundColor = ConsoleColor.Blue;
            //font: slant
            Console.WriteLine("Welcome to...");
            Console.WriteLine("     ______      __                 ______                       _                      ");
            Console.WriteLine("    / ____/_  __/ /_  ___  _____   / ____/___  ____  _________  (_)________ ________  __");
            Console.WriteLine("   / /   / / / / __ \\/ _ \\/ ___/  / /   / __ \\/ __ \\/ ___/ __ \\/ / ___/ __ `/ ___/ / / /");
            Console.WriteLine("  / /___/ /_/ / /_/ /  __/ /     / /___/ /_/ / / / (__  ) /_/ / / /  / /_/ / /__/ /_/ / ");
            Console.WriteLine("  \\____/\\__, /_.___/\\___/_/      \\____/\\____/_/ /_/____/ .___/_/_/   \\__,_/\\___/\\__, /  ");
            Console.WriteLine("       /____/                                         /_/                      /____/   \n");
            Console.ForegroundColor = ConsoleColor.White;




            //GAME START
            Console.Write("PA: Hello. Welcome to the Uprall Transport Hub. Please enter your name: ");
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            MyGlobals.playerName = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White;
                        
            trigger_switch = PlayerPrompt.FirstEntry(currentRoom, trigger_data, ref item_data, ref money);
            foreach(var flip in trigger_switch) trigger_data[flip] = true;
            



            while (true)   //main game loop
            {
                
                

                playerAction = 0;       //reset action to trigger loop
                while(!(playerAction == 1))
                {


                    //check for ending
                    if (trigger_data[150])
                    {
                        for (int i = 151; i<199; i++)
                        {
                            if (trigger_data[i])
                            {
                                ending = i - 150; break;
                            }
                        }
                        GameOver(ending);
                    }
                    Console.WriteLine(room_data[currentRoom, 2]);



                    //constantly prompt player to make a choice, once they want to move, 
                    playerAction = GetPlayerAction("\nWhat would you like to do? ");
                    switch(playerAction)
                    {
                        //move
                        case 1:     
                            Console.WriteLine("Here are your options:\n");
                            //prompt room.cs to give the player their current exits, and then move the player to a new room
                            chosen_exit_id = Rooms.ListExits(currentRoom, room_data[currentRoom, 1], exit_data, trigger_data, item_data);
                            currentRoom = chosen_exit_id;



                            //once the player moves, rinse and repeat
                            if (MyGlobals.Debug){ Console.ForegroundColor = ConsoleColor.Cyan; 
                                Console.WriteLine("[Current Room is: {0}, RoomID:{1}]", currentRoom, room_data[currentRoom, 1]); Console.ForegroundColor = ConsoleColor.White; }

                            if (!trigger_data[currentRoom + 100])    //if a player has not been to a room
                            {
                                //prompt player for first time and mess with triggers
                                trigger_switch = PlayerPrompt.FirstEntry(currentRoom, trigger_data, ref item_data, ref money);
                                foreach (var flip in trigger_switch) trigger_data[flip] = true;
                            }



                            break;
                        //display long desc
                        case 2:
                            Console.ForegroundColor = ConsoleColor.DarkBlue;
                            Console.WriteLine("\nYou: " + room_data[currentRoom, 3] +"\n");
                            Console.ForegroundColor = ConsoleColor.White;
                            //Inventory.ListFloorItems(currentRoom, item_data);

                            trigger_switch = PlayerPrompt.ExtraExamine(currentRoom, trigger_data, ref item_data, ref money); //if the player examines in a certain room with certain conditions, trigger dialogue
                            foreach (var flip in trigger_switch) trigger_data[flip] = true;


                            break;
                        case 3:
                            Console.WriteLine("Here are your commands:");
                            Console.WriteLine("HELP - Replay this command.");
                            Console.WriteLine("MOVE/M/GO - Choose an exit from your current location with a cardinal direction.");
                            Console.WriteLine("LOOK/EXAMINE/EXPLORE/E - Get a better description of the area, sometimes enhanced by items.");
                            Console.WriteLine("INVENTORY/INV/I - List items in your inventory.");
                            Console.WriteLine("USE [ITEM] - Make use of an item in your room.");
                            Console.WriteLine("TAKE/PICKUP - Take all items from the room and stow it.");
                            Console.WriteLine("DROP/LEAVE - Drop a specific [ITEM] in the room from your inventory.");
                            Console.WriteLine("EXIT/QUIT - Quit the game.");
                            break;
                        //take items
                        case 4:
                            item_data = Inventory.TakeItems(currentRoom, item_data);
                            break;
                        //drop items
                        case 5:
                            item_data = Inventory.DropItem(currentRoom, item_data);
                            break;
                        //check inventory
                        case 6:
                            Inventory.ListInventory(item_data);
                            break;
                        case 7:
                            
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
            string[] valid = { "MOVE", "M", "GO", "LOOK", "L", "E", "LOOK AROUND", "EXPLORE","HELP", "INVENTORY", "INV", "I", "DROP", "D", "TAKE", "T", "PICKUP" };
            
            string[] move = {"MOVE", "M","GO"};
            string[] look_around = { "LOOK", "L", "LOOK AROUND", "EXPLORE", "E","EXAMINE" };
            string[] help = { "HELP" };
            string[] take = { "TAKE","T","PICKUP" };
            string[] drop = { "DROP", "D"};
            string[] check_inventory = { "INVENTORY", "INV", "I" };



            string userInput = GetString(prompt, valid, "?Invalid response, please reenter");

            if (move.Contains(userInput))
                player_action = 1;
            else if (look_around.Contains(userInput))
                player_action = 2;
            else if (help.Contains(userInput))
                player_action = 3;
            else if (take.Contains(userInput))
                player_action = 4;
            else if (drop.Contains(userInput))
                player_action = 5;
            else if (check_inventory.Contains(userInput))
                player_action = 6;

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
        public static string GetString(string prompt, string[] valid, string error)
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
            //Cases 1-7 are normal endings (text in green)
            //case 8 is true ending (text is white)
            //cases 9-17 are bad endings (deaths) (text in red)
            switch (gameOverNumber)
            {
                case 1:
                    //font: ogre
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Ending 0:");
                    Console.WriteLine("  _____  _           ___                _   _   _       _                         _  _          _ ");
                    Console.WriteLine(" |_   _|| |_   ___  | _ \\ ___  __ _  __| | | | | | _ _ | |_  _ _  __ _ __ __ ___ | || | ___  __| |");
                    Console.WriteLine("   | |  | ' \\ / -_) |   // _ \\/ _` |/ _` | | |_| || ' \\|  _|| '_|/ _` |\\ V // -_)| || |/ -_)/ _` |");
                    Console.WriteLine("   |_|  |_||_|\\___| |_|_\\\\___/\\__,_|\\__,_|  \\___/ |_||_|\\__||_|  \\__,_| \\_/ \\___||_||_|\\___|\\__,_|");




                    break;

                case 2:
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Ending 1: Sightseeing");
                    break;

                case 3:
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Ending 2: Leave It To The Pros");
                    break;

                case 4:
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Ending 3: I'm Out");
                    break;

                case 5:
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Ending 4: Gung Ho");
                    break;

                case 6:
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Ending 5: Overwhelmed");
                    break;

                case 7:
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Ending 6: I'm Rich");
                    break;

                case 8:
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("True Ending: Conspiracy Theorist");
                    break;

                case 9:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Bad End: Cold And Alone");
                    break;

                case 10:
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Bad End 10:\n");
                    Console.WriteLine("▄▄▄█████▓ ██░ ██ ▓█████     ██░ ██  ▒█████   █    ██  ██████ ▓█████     ▄▄▄       ██▓     █     █░ ▄▄▄     ▓██   ██▓  ██████     █     █░ ██▓ ███▄    █   ██████ ");
                    Console.WriteLine("▓  ██▒ ▓▒▓██░ ██▒▓█   ▀    ▓██░ ██▒▒██▒  ██▒ ██  ▓██▒██    ▒ ▓█   ▀    ▒████▄    ▓██▒    ▓█░ █ ░█░▒████▄    ▒██  ██▒▒██    ▒    ▓█░ █ ░█░▓██▒ ██ ▀█   █ ▒██    ▒ ");
                    Console.WriteLine("▒ ▓██░ ▒░▒██▀▀██░▒███      ▒██▀▀██░▒██░  ██▒▓██  ▒██░ ▓██▄   ▒███      ▒██  ▀█▄  ▒██░    ▒█░ █ ░█ ▒██  ▀█▄   ▒██ ██░░ ▓██▄      ▒█░ █ ░█ ▒██▒▓██  ▀█ ██▒░ ▓██▄   ");
                    Console.WriteLine("░ ▓██▓ ░ ░▓█ ░██ ▒▓█  ▄    ░▓█ ░██ ▒██   ██░▓▓█  ░██░ ▒   ██▒▒▓█  ▄    ░██▄▄▄▄██ ▒██░    ░█░ █ ░█ ░██▄▄▄▄██  ░ ▐██▓░  ▒   ██▒   ░█░ █ ░█ ░██░▓██▒  ▐▌██▒  ▒   ██▒");
                    Console.WriteLine("  ▒██▒ ░ ░▓█▒░██▓░▒████▒   ░▓█▒░██▓░ ████▓▒░▒▒█████▓▒██████▒▒░▒████▒    ▓█   ▓██▒░██████▒░░██▒██▓  ▓█   ▓██▒ ░ ██▒▓░▒██████▒▒   ░░██▒██▓ ░██░▒██░   ▓██░▒██████▒▒");
                    Console.WriteLine("  ▒ ░░    ▒ ░░▒░▒░░ ▒░ ░    ▒ ░░▒░▒░ ▒░▒░▒░ ░▒▓▒ ▒ ▒▒ ▒▓▒ ▒ ░░░ ▒░ ░    ▒▒   ▓▒█░░ ▒░▓  ░░ ▓░▒ ▒   ▒▒   ▓▒█░  ██▒▒▒ ▒ ▒▓▒ ▒ ░   ░ ▓░▒ ▒  ░▓  ░ ▒░   ▒ ▒ ▒ ▒▓▒ ▒ ░");
                    Console.WriteLine("    ░     ▒ ░▒░ ░ ░ ░  ░    ▒ ░▒░ ░  ░ ▒ ▒░ ░░▒░ ░ ░░ ░▒  ░ ░ ░ ░  ░     ▒   ▒▒ ░░ ░ ▒  ░  ▒ ░ ░    ▒   ▒▒ ░▓██ ░▒░ ░ ░▒  ░ ░     ▒ ░ ░   ▒ ░░ ░░   ░ ▒░░ ░▒  ░ ░");
                    Console.WriteLine("  ░       ░  ░░ ░   ░       ░  ░░ ░░ ░ ░ ▒   ░░░ ░ ░░  ░  ░     ░        ░   ▒     ░ ░     ░   ░    ░   ▒   ▒ ▒ ░░  ░  ░  ░       ░   ░   ▒ ░   ░   ░ ░ ░  ░  ░  ");
                    Console.WriteLine("          ░  ░  ░   ░  ░    ░  ░  ░    ░ ░     ░          ░     ░  ░         ░  ░    ░  ░    ░          ░  ░░ ░           ░         ░     ░           ░       ░  ");
                    break;

                case 11:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Bad End: No Chances");
                    break;

                case 12:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Bad End: Oops.");
                    break;

                case 13:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Bad End: Incompetence.");
                    break;

                case 14:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Bad End: Broken Will");
                    break;

                case 15:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Bad End: Big Mistake");
                    break;

                case 16:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Bad End: Eternal Service");
                    break;

                case 17:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Bad End: Silenced");
                    break;

            }
            //Console.WriteLine("GAME OVER, YOU REACHED BAD ENDING #" + gameOverNumber + ", THANKS FOR PLAYING");
            Environment.Exit(0);
        }
        //global variables
        public static class MyGlobals
        {
            //public const string Prefix = "ID_"; // cannot change
            public static bool Debug = false; // can change because not const
            public static string playerName;
        }



    }
}
