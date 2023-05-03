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


            string root_folder = "U:\\ECE264\\Adventure-ver4"; //CHANGE ME TO ROOT FOLDER




            
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
            //MyGlobals.Debug = GetYesNo("Would you like to enable Debug mode? ");  //Check if this is on using ifs, debug messages are surrounded by brackets
            //EX:
            if (MyGlobals.Debug){Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("[Debug Mode Enabled]"); Console.ForegroundColor = ConsoleColor.White;}


            //setup stuff
            int currentRoom = 1;
            int chosen_exit_id;
            int playerAction = 0; //0 = start, 1 = move, 2 = look around
            int money = 150;
            bool money_ending = true;

            Console.ForegroundColor = ConsoleColor.Blue;
            //font: slant
            Console.WriteLine("Welcome to...");
            Console.WriteLine("   ______      __                 ______                       _                      ");
            Console.WriteLine("  / ____/_  __/ /_  ___  _____   / ____/___  ____  _________  (_)________ ________  __");
            Console.WriteLine(" / /   / / / / __ \\/ _ \\/ ___/  / /   / __ \\/ __ \\/ ___/ __ \\/ / ___/ __ `/ ___/ / / /");
            Console.WriteLine("/ /___/ /_/ / /_/ /  __/ /     / /___/ /_/ / / / (__  ) /_/ / / /  / /_/ / /__/ /_/ / ");
            Console.WriteLine("\\____/\\__, /_.___/\\___/_/      \\____/\\____/_/ /_/____/ .___/_/_/   \\__,_/\\___/\\__, /  ");
            Console.WriteLine("     /____/                                         /_/                      /____/   ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();



            //GAME START
            Console.Write("PA: Hello. Welcome to the Uprall Transport Hub. Please enter your name: ");
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            MyGlobals.playerName = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White;
                        
            trigger_switch = PlayerPrompt.FirstEntry(ref currentRoom, trigger_data, ref item_data, ref money);
            foreach(var flip in trigger_switch) trigger_data[flip] = true;
            



            while (true)   //main game loop
            {
                
                

                playerAction = 0;       //reset action to trigger loop
                while(!(playerAction == 1))
                {

                    if (money > 1000 && money_ending)
                    {
                        if(GetYesNo("You: This is a lot of money I've got here, should I just cut my losses and leave?"))
                        {
                            PlayerPrompt.YouSay("Ah, whatever happens here happens. I'm outta here!");
                            trigger_switch.Add(150);
                            trigger_switch.Add(150 + 6); //ending 3   
                        }
                        else
                        {
                            money_ending = false;
                            PlayerPrompt.YouSay("Nah, I'm not done here in Uprall yet.");
                        }


                                           
                    
                    }
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
                                trigger_switch = PlayerPrompt.FirstEntry(ref currentRoom, trigger_data, ref item_data, ref money);
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

                        case 8:
                            break;




                    }
                        

               




                }
                
            }






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

        public static bool GetYesNo(string prompt)
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
                    Console.WriteLine("Ending 1:");
                    Console.WriteLine("  ________            ____                  __   __  __      __                        ____         __");
                    Console.WriteLine(" /_  __/ /_  ___     / __ \\____  ____ _____/ /  / / / /___  / /__________ __   _____  / / /__  ____/ /");
                    Console.WriteLine("  / / / __ \\/ _ \\   / /_/ / __ \\/ __ `/ __  /  / / / / __ \\/ __/ ___/ __ `/ | / / _ \\/ / / _ \\/ __  / ");
                    Console.WriteLine(" / / / / / /  __/  / _, _/ /_/ / /_/ / /_/ /  / /_/ / / / / /_/ /  / /_/ /| |/ /  __/ / /  __/ /_/ /  ");
                    Console.WriteLine("/_/ /_/ /_/\\___/  /_/ |_|\\____/\\__,_/\\__,_/   \\____/_/ /_/\\__/_/   \\__,_/ |___/\\___/_/_/\\___/\\__,_/   ");


                    break;

                case 2:
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Ending 2:");
                    Console.WriteLine(" __ _       _     _                 _             ");
                    Console.WriteLine("/ _(_) __ _| |__ | |_ ___  ___  ___(_)_ __   __ _ ");
                    Console.WriteLine("\\ \\| |/ _` | '_ \\| __/ __|/ _ \\/ _ \\ | '_ \\ / _` |");
                    Console.WriteLine("_\\ \\ | (_| | | | | |_\\__ \\  __/  __/ | | | | (_| |");
                    Console.WriteLine("\\__/_|\\__, |_| |_|\\__|___/\\___|\\___|_|_| |_|\\__, |");
                    Console.WriteLine("      |___/                                 |___/ ");

                    break;

                case 3:
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Ending 3:");
                    Console.WriteLine("   __                         _____ _     _____        _____ _              ___               ");
                    Console.WriteLine("  / /  ___  __ ___   _____    \\_   \\ |_  /__   \\___   /__   \\ |__   ___    / _ \\_ __ ___  ___ ");
                    Console.WriteLine(" / /  / _ \\/ _` \\ \\ / / _ \\    / /\\/ __|   / /\\/ _ \\    / /\\/ '_ \\ / _ \\  / /_)/ '__/ _ \\/ __|");
                    Console.WriteLine("/ /__|  __/ (_| |\\ V /  __/ /\\/ /_ | |_   / / | (_) |  / /  | | | |  __/ / ___/| | | (_) \\__ \\");
                    Console.WriteLine("\\____/\\___|\\__,_| \\_/ \\___| \\____/  \\__|  \\/   \\___/   \\/   |_| |_|\\___| \\/    |_|  \\___/|___/");
                    break;

                case 4:
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Ending 4:");
                    Console.WriteLine("  _____ _              ___       _   ");
                    Console.WriteLine("  \\_   ( ) __ ___     /___\\_   _| |_ ");
                    Console.WriteLine("   / /\\// '_ ` _ \\   //  // | | | __|");
                    Console.WriteLine("/\\/ /_  | | | | | | / \\_//| |_| | |_ ");
                    Console.WriteLine("\\____/  |_| |_| |_| \\___/  \\__,_|\\__|");
                    break;

                case 5:
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Ending 5:");
                    Console.WriteLine("   ___                                 ");
                    Console.WriteLine("  / _ \\_   _ _ __   __ _    /\\  /\\___  ");
                    Console.WriteLine(" / /_\\/ | | | '_ \\ / _` |  / /_/ / _ \\ ");
                    Console.WriteLine("/ /_\\\\| |_| | | | | (_| | / __  / (_) |");
                    Console.WriteLine("\\____/ \\__,_|_| |_|\\__, | \\/ /_/ \\___/ ");
                    Console.WriteLine("                   |___/               ");
                    break;

                case 6:
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Ending 6:");
                    Console.WriteLine("   ___                         _          _                    _ ");
                    Console.WriteLine("  /___\\_   _____ _ ____      _| |__   ___| |_ __ ___   ___  __| |");
                    Console.WriteLine(" //  /| \\ / / _ \\ '__\\ \\ /\\ / / '_ \\ / _ \\ | '_ ` _ \\ / _ \\/ _` |");
                    Console.WriteLine("/ \\_// \\ V /  __/ |   \\ V  V /| | | |  __/ | | | | | |  __/ (_| |");
                    Console.WriteLine("\\___/   \\_/ \\___|_|    \\_/\\_/ |_| |_|\\___|_|_| |_| |_|\\___|\\__,_|");
                    break;

                case 7:
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Ending 7:");
                    
                    Console.WriteLine("  _____ _              __ _      _     ");
                    Console.WriteLine("  \\_   ( ) __ ___     /__(_) ___| |__  ");
                    Console.WriteLine("   / /\\// '_ ` _ \\   / \\// |/ __| '_ \\ ");
                    Console.WriteLine("/\\/ /_  | | | | | | / _  \\ | (__| | | |");
                    Console.WriteLine("\\____/  |_| |_| |_| \\/ \\_/_|\\___|_| |_|");
                    break;

                case 8:
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("True Ending:");
                    Console.WriteLine("   ______                       _                          ________                    _      __ ");
                    Console.WriteLine("  / ____/___  ____  _________  (_)________ ________  __   /_  __/ /_  ___  ____  _____(_)____/ /_");
                    Console.WriteLine(" / /   / __ \\/ __ \\/ ___/ __ \\/ / ___/ __ `/ ___/ / / /    / / / __ \\/ _ \\/ __ \\/ ___/ / ___/ __/");
                    Console.WriteLine("/ /___/ /_/ / / / (__  ) /_/ / / /  / /_/ / /__/ /_/ /    / / / / / /  __/ /_/ / /  / (__  ) /_  ");
                    Console.WriteLine("\\____/\\____/_/ /_/____/ .___/_/_/   \\__,_/\\___/\\__, /    /_/ /_/ /_/\\___/\\____/_/  /_/____/\\__/  ");
                    Console.WriteLine("                     /_/                      /____/                                             ");
                    break;

                case 9:
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Bad End 9:");                    
                    Console.WriteLine(" ▄████▄  ▒█████   ██▓    ▓█████▄     ▄▄▄      ███▄    █ ▓█████▄     ▄▄▄       ██▓     ▒█████   ███▄    █▓█████ ");
                    Console.WriteLine("▒██▀ ▀█ ▒██▒  ██▒▓██▒    ▒██▀ ██▌   ▒████▄    ██ ▀█   █ ▒██▀ ██▌   ▒████▄    ▓██▒    ▒██▒  ██▒ ██ ▀█   █▓█   ▀ ");
                    Console.WriteLine("▒▓█    ▄▒██░  ██▒▒██░    ░██   █▌   ▒██  ▀█▄ ▓██  ▀█ ██▒░██   █▌   ▒██  ▀█▄  ▒██░    ▒██░  ██▒▓██  ▀█ ██▒███   ");
                    Console.WriteLine("▒▓▓▄ ▄██▒██   ██░▒██░    ░▓█▄   ▌   ░██▄▄▄▄██▓██▒  ▐▌██▒░▓█▄   ▌   ░██▄▄▄▄██ ▒██░    ▒██   ██░▓██▒  ▐▌██▒▓█  ▄ ");
                    Console.WriteLine("▒ ▓███▀ ░ ████▓▒░░██████▒░▒████▓     ▓█   ▓██▒██░   ▓██░░▒████▓     ▓█   ▓██▒░██████▒░ ████▓▒░▒██░   ▓██░▒████▒");
                    Console.WriteLine("░ ░▒ ▒  ░ ▒░▒░▒░ ░ ▒░▓  ░ ▒▒▓  ▒     ▒▒   ▓▒█░ ▒░   ▒ ▒  ▒▒▓  ▒     ▒▒   ▓▒█░░ ▒░▓  ░░ ▒░▒░▒░ ░ ▒░   ▒ ▒░░ ▒░ ░");
                    Console.WriteLine("  ░  ▒    ░ ▒ ▒░ ░ ░ ▒  ░ ░ ▒  ▒      ▒   ▒▒ ░ ░░   ░ ▒░ ░ ▒  ▒      ▒   ▒▒ ░░ ░ ▒  ░  ░ ▒ ▒░ ░ ░░   ░ ▒░░ ░  ░");
                    Console.WriteLine("░       ░ ░ ░ ▒    ░ ░    ░ ░  ░      ░   ▒     ░   ░ ░  ░ ░  ░      ░   ▒     ░ ░   ░ ░ ░ ▒     ░   ░ ░   ░   ");
                    Console.WriteLine("░ ░         ░ ░      ░  ░   ░             ░  ░        ░    ░             ░  ░    ░  ░    ░ ░           ░   ░  ░");
                    Console.WriteLine("░                         ░                              ░                                                     ");
                    break;

                    break;

                case 10:
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Bad End 10:");
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
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Bad End 11:");
                    Console.WriteLine(" ███▄    █ ▒█████      ▄████▄   ██░ ██  ▄▄▄      ███▄    █  ▄████▄ ▓█████   ██████ ");
                    Console.WriteLine(" ██ ▀█   █▒██▒  ██▒   ▒██▀ ▀█  ▓██░ ██▒▒████▄    ██ ▀█   █ ▒██▀ ▀█ ▓█   ▀ ▒██    ▒ ");
                    Console.WriteLine("▓██  ▀█ ██▒██░  ██▒   ▒▓█    ▄ ▒██▀▀██░▒██  ▀█▄ ▓██  ▀█ ██▒▒▓█    ▄▒███   ░ ▓██▄   ");
                    Console.WriteLine("▓██▒  ▐▌██▒██   ██░   ▒▓▓▄ ▄██▒░▓█ ░██ ░██▄▄▄▄██▓██▒  ▐▌██▒▒▓▓▄ ▄██▒▓█  ▄   ▒   ██▒");
                    Console.WriteLine("▒██░   ▓██░ ████▓▒░   ▒ ▓███▀ ░░▓█▒░██▓ ▓█   ▓██▒██░   ▓██░▒ ▓███▀ ░▒████▒▒██████▒▒");
                    Console.WriteLine("░ ▒░   ▒ ▒░ ▒░▒░▒░    ░ ░▒ ▒  ░ ▒ ░░▒░▒ ▒▒   ▓▒█░ ▒░   ▒ ▒ ░ ░▒ ▒  ░░ ▒░ ░▒ ▒▓▒ ▒ ░");
                    Console.WriteLine("░ ░░   ░ ▒░ ░ ▒ ▒░      ░  ▒    ▒ ░▒░ ░  ▒   ▒▒ ░ ░░   ░ ▒░  ░  ▒   ░ ░  ░░ ░▒  ░ ░");
                    Console.WriteLine("   ░   ░ ░░ ░ ░ ▒     ░         ░  ░░ ░  ░   ▒     ░   ░ ░ ░          ░   ░  ░  ░  ");
                    break;

                case 12:
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Bad End 12:");
                    Console.WriteLine(" ▒█████   ▒█████   ██▓███    ██████ ");
                    Console.WriteLine("▒██▒  ██▒▒██▒  ██▒▓██░  ██▒▒██    ▒ ");
                    Console.WriteLine("▒██░  ██▒▒██░  ██▒▓██░ ██▓▒░ ▓██▄   ");
                    Console.WriteLine("▒██   ██░▒██   ██░▒██▄█▓▒ ▒  ▒   ██▒");
                    Console.WriteLine("░ ████▓▒░░ ████▓▒░▒██▒ ░  ░▒██████▒▒");
                    Console.WriteLine("░ ▒░▒░▒░ ░ ▒░▒░▒░ ▒▓▒░ ░  ░▒ ▒▓▒ ▒ ░");
                    Console.WriteLine("  ░ ▒ ▒░   ░ ▒ ▒░ ░▒ ░     ░ ░▒  ░ ░");
                    Console.WriteLine("░ ░ ░ ▒  ░ ░ ░ ▒  ░░       ░  ░  ░  ");
                    Console.WriteLine("    ░ ░      ░ ░                 ░  ");
                    break;

                case 13:
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Bad End 13:");
                    Console.WriteLine(" ██▓ ███▄    █  ▄████▄  ▒█████   ███▄ ▄███▓ ██▓███  ▓█████▄▄▄█████▓▓█████ ███▄    █  ▄████▄ ▓█████ ");
                    Console.WriteLine("▓██▒ ██ ▀█   █ ▒██▀ ▀█ ▒██▒  ██▒▓██▒▀█▀ ██▒▓██░  ██▒▓█   ▀▓  ██▒ ▓▒▓█   ▀ ██ ▀█   █ ▒██▀ ▀█ ▓█   ▀ ");
                    Console.WriteLine("▒██▒▓██  ▀█ ██▒▒▓█    ▄▒██░  ██▒▓██    ▓██░▓██░ ██▓▒▒███  ▒ ▓██░ ▒░▒███  ▓██  ▀█ ██▒▒▓█    ▄▒███   ");
                    Console.WriteLine("░██░▓██▒  ▐▌██▒▒▓▓▄ ▄██▒██   ██░▒██    ▒██ ▒██▄█▓▒ ▒▒▓█  ▄░ ▓██▓ ░ ▒▓█  ▄▓██▒  ▐▌██▒▒▓▓▄ ▄██▒▓█  ▄ ");
                    Console.WriteLine("░██░▒██░   ▓██░▒ ▓███▀ ░ ████▓▒░▒██▒   ░██▒▒██▒ ░  ░░▒████▒ ▒██▒ ░ ░▒████▒██░   ▓██░▒ ▓███▀ ░▒████▒");
                    Console.WriteLine("░▓  ░ ▒░   ▒ ▒ ░ ░▒ ▒  ░ ▒░▒░▒░ ░ ▒░   ░  ░▒▓▒░ ░  ░░░ ▒░ ░ ▒ ░░   ░░ ▒░ ░ ▒░   ▒ ▒ ░ ░▒ ▒  ░░ ▒░ ░");
                    Console.WriteLine(" ▒ ░░ ░░   ░ ▒░  ░  ▒    ░ ▒ ▒░ ░  ░      ░░▒ ░      ░ ░  ░   ░     ░ ░  ░ ░░   ░ ▒░  ░  ▒   ░ ░  ░");
                    Console.WriteLine(" ▒ ░   ░   ░ ░ ░       ░ ░ ░ ▒  ░      ░   ░░          ░    ░         ░     ░   ░ ░ ░          ░   ");
                    Console.WriteLine(" ░           ░ ░ ░         ░ ░         ░               ░  ░           ░  ░        ░ ░ ░        ░  ░");
                    Console.WriteLine("               ░                                                                    ░              ");
                    break;

                case 14:
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Bad End 14:");
                    Console.WriteLine("");
                    Console.WriteLine(" ▄▄▄▄    ██▀███   ▒█████   ██ ▄█▀▓█████ ███▄    █     █     █░ ██▓ ██▓     ██▓    ");
                    Console.WriteLine("▓█████▄ ▓██ ▒ ██▒▒██▒  ██▒ ██▄█▒ ▓█   ▀ ██ ▀█   █    ▓█░ █ ░█░▓██▒▓██▒    ▓██▒    ");
                    Console.WriteLine("▒██▒ ▄██▓██ ░▄█ ▒▒██░  ██▒▓███▄░ ▒███  ▓██  ▀█ ██▒   ▒█░ █ ░█ ▒██▒▒██░    ▒██░    ");
                    Console.WriteLine("▒██░█▀  ▒██▀▀█▄  ▒██   ██░▓██ █▄ ▒▓█  ▄▓██▒  ▐▌██▒   ░█░ █ ░█ ░██░▒██░    ▒██░    ");
                    Console.WriteLine("░▓█  ▀█▓░██▓ ▒██▒░ ████▓▒░▒██▒ █▄░▒████▒██░   ▓██░   ░░██▒██▓ ░██░░██████▒░██████▒");
                    Console.WriteLine("░▒▓███▀▒░ ▒▓ ░▒▓░░ ▒░▒░▒░ ▒ ▒▒ ▓▒░░ ▒░ ░ ▒░   ▒ ▒    ░ ▓░▒ ▒  ░▓  ░ ▒░▓  ░░ ▒░▓  ░");
                    Console.WriteLine("▒░▒   ░   ░▒ ░ ▒░  ░ ▒ ▒░ ░ ░▒ ▒░ ░ ░  ░ ░░   ░ ▒░     ▒ ░ ░   ▒ ░░ ░ ▒  ░░ ░ ▒  ░");
                    Console.WriteLine(" ░    ░   ░░   ░ ░ ░ ░ ▒  ░ ░░ ░    ░     ░   ░ ░      ░   ░   ▒ ░  ░ ░     ░ ░   ");
                    Console.WriteLine(" ░         ░         ░ ░  ░  ░      ░  ░        ░        ░     ░      ░  ░    ░  ░");
                    break;

                case 15:
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Bad End 15:");
                    Console.WriteLine(" ▄▄▄▄    ██▓ ▄████     ███▄ ▄███▓ ██▓  ██████ ▄▄▄█████▓ ▄▄▄       ██ ▄█▀▓█████ ");
                    Console.WriteLine("▓█████▄ ▓██▒██▒ ▀█▒   ▓██▒▀█▀ ██▒▓██▒▒██    ▒ ▓  ██▒ ▓▒▒████▄     ██▄█▒ ▓█   ▀ ");
                    Console.WriteLine("▒██▒ ▄██▒██▒██░▄▄▄░   ▓██    ▓██░▒██▒░ ▓██▄   ▒ ▓██░ ▒░▒██  ▀█▄  ▓███▄░ ▒███   ");
                    Console.WriteLine("▒██░█▀  ░██░▓█  ██▓   ▒██    ▒██ ░██░  ▒   ██▒░ ▓██▓ ░ ░██▄▄▄▄██ ▓██ █▄ ▒▓█  ▄ ");
                    Console.WriteLine("░▓█  ▀█▓░██░▒▓███▀▒   ▒██▒   ░██▒░██░▒██████▒▒  ▒██▒ ░  ▓█   ▓██▒▒██▒ █▄░▒████▒");
                    Console.WriteLine("░▒▓███▀▒░▓  ░▒   ▒    ░ ▒░   ░  ░░▓  ▒ ▒▓▒ ▒ ░  ▒ ░░    ▒▒   ▓▒█░▒ ▒▒ ▓▒░░ ▒░ ░");
                    Console.WriteLine("▒░▒   ░  ▒ ░ ░   ░    ░  ░      ░ ▒ ░░ ░▒  ░ ░    ░      ▒   ▒▒ ░░ ░▒ ▒░ ░ ░  ░");
                    Console.WriteLine(" ░    ░  ▒ ░ ░   ░    ░      ░    ▒ ░░  ░  ░    ░        ░   ▒   ░ ░░ ░    ░   ");
                    Console.WriteLine(" ░       ░       ░           ░    ░        ░                 ░  ░░  ░      ░  ░");
                    break;

                case 16:
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Bad End 16:");
                    Console.WriteLine("▓█████▄▄▄█████▓▓█████  ██▀███   ███▄    █  ▄▄▄       ██▓         ██████ ▓█████  ██▀███   ██▒   █▓ ██▓ ▄████▄ ▓█████ ");
                    Console.WriteLine("▓█   ▀▓  ██▒ ▓▒▓█   ▀ ▓██ ▒ ██▒ ██ ▀█   █ ▒████▄    ▓██▒       ▒██    ▒ ▓█   ▀ ▓██ ▒ ██▒▓██░   █▒▓██▒▒██▀ ▀█ ▓█   ▀ ");
                    Console.WriteLine("▒███  ▒ ▓██░ ▒░▒███   ▓██ ░▄█ ▒▓██  ▀█ ██▒▒██  ▀█▄  ▒██░       ░ ▓██▄   ▒███   ▓██ ░▄█ ▒ ▓██  █▒░▒██▒▒▓█    ▄▒███   ");
                    Console.WriteLine("▒▓█  ▄░ ▓██▓ ░ ▒▓█  ▄ ▒██▀▀█▄  ▓██▒  ▐▌██▒░██▄▄▄▄██ ▒██░         ▒   ██▒▒▓█  ▄ ▒██▀▀█▄    ▒██ █░░░██░▒▓▓▄ ▄██▒▓█  ▄ ");
                    Console.WriteLine("░▒████▒ ▒██▒ ░ ░▒████▒░██▓ ▒██▒▒██░   ▓██░ ▓█   ▓██▒░██████▒   ▒██████▒▒░▒████▒░██▓ ▒██▒   ▒▀█░  ░██░▒ ▓███▀ ░▒████▒");
                    Console.WriteLine("░░ ▒░ ░ ▒ ░░   ░░ ▒░ ░░ ▒▓ ░▒▓░░ ▒░   ▒ ▒  ▒▒   ▓▒█░░ ▒░▓  ░   ▒ ▒▓▒ ▒ ░░░ ▒░ ░░ ▒▓ ░▒▓░   ░ ▐░  ░▓  ░ ░▒ ▒  ░░ ▒░ ░");
                    Console.WriteLine(" ░ ░  ░   ░     ░ ░  ░  ░▒ ░ ▒░░ ░░   ░ ▒░  ▒   ▒▒ ░░ ░ ▒  ░   ░ ░▒  ░ ░ ░ ░  ░  ░▒ ░ ▒░   ░ ░░   ▒ ░  ░  ▒   ░ ░  ░");
                    Console.WriteLine("   ░    ░         ░     ░░   ░    ░   ░ ░   ░   ▒     ░ ░      ░  ░  ░     ░     ░░   ░      ░░   ▒ ░░          ░   ");
                    Console.WriteLine("   ░  ░           ░  ░   ░              ░       ░  ░    ░  ░         ░     ░  ░   ░           ░   ░  ░ ░        ░  ░");
                    break;

                case 17:
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Bad End 17:");
                    Console.WriteLine("  ██████  ██▓ ██▓    ▓█████ ███▄    █  ▄████▄ ▓█████ ▓█████▄ ");
                    Console.WriteLine("▒██    ▒ ▓██▒▓██▒    ▓█   ▀ ██ ▀█   █ ▒██▀ ▀█ ▓█   ▀ ▒██▀ ██▌");
                    Console.WriteLine("░ ▓██▄   ▒██▒▒██░    ▒███  ▓██  ▀█ ██▒▒▓█    ▄▒███   ░██   █▌");
                    Console.WriteLine("  ▒   ██▒░██░▒██░    ▒▓█  ▄▓██▒  ▐▌██▒▒▓▓▄ ▄██▒▓█  ▄ ░▓█▄   ▌");
                    Console.WriteLine("▒██████▒▒░██░░██████▒░▒████▒██░   ▓██░▒ ▓███▀ ░▒████▒░▒████▓ ");
                    Console.WriteLine("▒ ▒▓▒ ▒ ░░▓  ░ ▒░▓  ░░░ ▒░ ░ ▒░   ▒ ▒ ░ ░▒ ▒  ░░ ▒░ ░ ▒▒▓  ▒ ");
                    Console.WriteLine("░ ░▒  ░ ░ ▒ ░░ ░ ▒  ░ ░ ░  ░ ░░   ░ ▒░  ░  ▒   ░ ░  ░ ░ ▒  ▒ ");
                    Console.WriteLine("░  ░  ░   ▒ ░  ░ ░      ░     ░   ░ ░ ░          ░    ░ ░  ░ ");
                    Console.WriteLine("      ░   ░      ░  ░   ░  ░        ░ ░ ░        ░  ░   ░    ");
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
