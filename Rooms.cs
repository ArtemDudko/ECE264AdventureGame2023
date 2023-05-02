using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ECE264AdventureGame2023.PlayerPrompt.Directions;
using static ECE264AdventureGame2023.Program;

namespace ECE264AdventureGame2023
{
    class Rooms
    {
        string raw_exit_trigger_data = File.ReadAllText("ExitTriggers.txt");
        //int test = 1;
        public static string[,] LoadRooms(string root_folder)
        {
            //load Rooms.txt and process
            string raw_room_data = File.ReadAllText(root_folder + "\\Rooms.txt");
            raw_room_data = raw_room_data.Remove(0, raw_room_data.IndexOf("&&&") + 3);      //remove unnecessary stuff
            StringBuilder sb = new StringBuilder(raw_room_data);
            sb = sb.Replace("\n", "");
            sb = sb.Replace("\t", "");
            sb = sb.Replace("\r", "");
            var raw_room_data_array = sb.ToString().Split('&');
            
            string[,] room_data = new string[100, 4];
            int item_count = 0;
            for (int row = 1; row < 100; row++)
            {
                for (int col = 0; col < 4; col++)
                {
                    room_data[row, col] = raw_room_data_array[item_count].Trim();
                    item_count++;
                    if (item_count == raw_room_data_array.Length) return room_data;
                }
            }
            //test = 2;
            return room_data;
        }

        public static string[,] LoadExits(string root_folder)
        {
            //load Rooms.txt and process
            string raw_exit_data = File.ReadAllText(root_folder + "\\ExitConditions.txt");
            raw_exit_data = raw_exit_data.Remove(0, raw_exit_data.IndexOf("&&&") + 3);
            StringBuilder sb = new StringBuilder(raw_exit_data);
            sb = sb.Replace("\n", "");
            sb = sb.Replace("\t", "");
            sb = sb.Replace("\r", "");
            //sb = sb.Replace("&&", "&");
            var raw_exit_data_array = sb.ToString().Split("&"); //1d string array with all &'s splitting the data

            string[,] exit_data = new string[100, 11];
            int data_point = 0;
            int room_count = 0;
            int item_count = 0;

            for (int row = 1; row < 100; row++)
            {                                   
                for (int col = 0; col < 11; col++)
                {
                    exit_data[row, col] = raw_exit_data_array[item_count].Trim();
                    item_count++;
                    if (item_count == raw_exit_data_array.Length) return exit_data;                  
                    
                }
            }
            return exit_data;
        }        


        public static int ListExits(int current_room_id, string current_room_name, string[,] exit_data, List<bool> triggers, string[,] item_data)
        {
            List<string> valid_exits = new List<string>();
            int row;       
            int last_exit_row = 0;

            for (row = 0; row < 100; row++)
            {
                if (exit_data[row, 1] == current_room_id.ToString())    //since there are multiples of 
                {
                    last_exit_row = row;
                    int[] specific_exit_triggers = new int[5];
                    bool enterable = true;

                    //triggers has five strings in the array, the number of the string meaning that trigger in trigger data has to be true
                    for (int i = 6; i < 9; i++)
                        if (triggers[Int32.Parse(exit_data[row, i])] == false)
                            enterable = false;

                    for (int i = 9; i < 11; i++)
                        if (item_data[Int32.Parse(exit_data[row, i]), 2] != "0")
                            enterable = false;

                    if (enterable)
                    {
                        //Format: &"" &1			&1		&3	&Helio City Square S	&North  &0
                        Console.WriteLine("[Exit #{0}: {1} to {2}, roomID {3}]", exit_data[row, 2], exit_data[row, 5], exit_data[row, 4], exit_data[row, 3]);
                        valid_exits.Add(exit_data[row, 5].Trim().ToUpper());
                    }
                    else
                        Console.WriteLine("[?????] - Option Locked");



                }
                if (valid_exits.Count >= 4) break;
            }
            
            int chosen_direction;
            
            chosen_direction = GetPlayerDirection("Which direction? ", valid_exits); //returns 0 thru 3 to modify current line of data reading
            int chosen_exit_id = Int32.Parse(exit_data[last_exit_row + 1 - valid_exits.Count + chosen_direction, 3]);
            
            //currentRoom = int.Parse(Console.ReadLine());

            return chosen_exit_id;
        }


        //public static string[,] ()





        ///the data is in a 2d array format, split by the & sign, it will be split into usable data just like we did in 
        ///the shakespeare lab. It's possible we will need a separate long description file.



        //MyGlobals.Debug

        public static int Navigate(int roomID)
        {
            switch (roomID)
            {
                case 1:
                    Console.WriteLine("You are in Helio City Square S");
                    break;
                case 2:
                    Console.WriteLine("You are in Back Ally");
                    break;

                    /*
                    while (true) //Infinitly Prompting the user until they wish to exit
                    {
                        //Informs the user their current location and describes the room
                        Console.WriteLine("You are in the " + currentRoom.Name);
                        Console.WriteLine(currentRoom.Description);
                        //Prompts the user to input the direction
                        Console.WriteLine("Which direction would you like to go?");
                        //Stores the direction
                        string input = Console.ReadLine();
                        Directions.Direction direction = Directions.GetDirection(input);

                        //Moves according to the directions from room to room
                        switch (direction)
                        {
                            case Directions.Direction.North:
                                if (currentRoom == room1)
                                {
                                    currentRoom = room2;
                                    Console.WriteLine("You move to the " + currentRoom.Name);
                                }
                                break;
                            case Directions.Direction.South:
                                if (currentRoom == room2)
                                {
                                    currentRoom = room1;
                                    Console.WriteLine("You move to the " + currentRoom.Name);
                                }
                                break;
                            case Directions.Direction.East:
                                if (currentRoom == room1)
                                {
                                    currentRoom = room3;
                                    Console.WriteLine("You move to the " + currentRoom.Name);
                                }

                                break;
                            case Directions.Direction.West:
                                if (currentRoom == room3)
                                {
                                    currentRoom = room1;
                                    Console.WriteLine("You move to the " + currentRoom.Name);
                                }

                                break;
                            case Directions.Direction.NorthEast:
                                if (currentRoom == room1)
                                {
                                    currentRoom = room4;
                                    Console.WriteLine("You move to the " + currentRoom.Name);
                                }
                                break;
                            case Directions.Direction.SouthWest:
                                if (currentRoom == room4)
                                {
                                    currentRoom = room1;
                                    Console.WriteLine("You move to the " + currentRoom.Name);
                                }
                                break;
                            case Directions.Direction.SouthEast:
                                if (currentRoom == room1)
                                {
                                    currentRoom = room5;
                                    Console.WriteLine("You move to the " + currentRoom.Name);
                                }
                                break;
                            case Directions.Direction.NorthWest:
                                if (currentRoom == room5)
                                {
                                    currentRoom = room1;
                                    Console.WriteLine("You move to the " + currentRoom.Name);
                                }
                                break;
                            default:
                                Console.WriteLine("Invalid direction.");
                                break;
                        }

                        //Prompts the user if they wish to continue and exits if they wish to exit
                        if (GetYesNo("Would you like to exit the game?(Y or N): "))
                        {
                            Console.WriteLine("Goodbye!");
                            Environment.Exit(0);
                        }
                    }*/

            }
            return 0;
        }

        //public static int Move(string direction)

        static int GetPlayerDirection(string prompt, List<string> valid_exits)
        {
            string[] valid_cardinal = { "N", "NORTH", "S", "SOUTH", "E", "EAST", "W", "WEST" };
            string[] valid_exits_array = valid_exits.ToArray();

            string userInput;
            bool OKdirection = false;
            bool OKexit = false;
            
            do
            {
                Console.Write(prompt);
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                userInput = Console.ReadLine().ToUpper();
                Console.ForegroundColor = ConsoleColor.White;

                foreach (string s in valid_cardinal) 
                    if (userInput == s.ToUpper()) 
                        OKdirection = true;

                if(OKdirection == true)
                {
                    if (userInput.ToUpper() == "N")
                        userInput = "NORTH";
                    if (userInput.ToUpper() == "S")
                        userInput = "SOUTH";
                    if (userInput.ToUpper() == "E")
                        userInput = "EAST";
                    if (userInput.ToUpper() == "W")
                        userInput = "WEST";
                }
                    

                foreach (string s in valid_exits_array) 
                    if (userInput == s.ToUpper()) 
                        OKexit = true;

                if (!OKdirection)
                { Console.WriteLine("?Invalid response, please reenter"); }
                else if (!OKexit)
                {
                    Console.WriteLine("?Invalid direction, please reenter");
                    OKdirection = false;
                }
            } while (!OKdirection && !OKexit);   

            
            int exit_number = valid_exits.IndexOf(userInput);
            Console.Write("\n");
            return exit_number;

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

        internal static class Directions //Directions being declared as a class
        {
            public enum Direction
            {
                North,
                South,
                East,
                West,
                N,
                S,
                E,
                W
            }

            public static Direction GetDirection(string input) //Functions to get directions being created
            {
                switch (input.ToLower())
                {
                    case "north":
                        return Direction.North;
                    case "south":
                        return Direction.South;
                    case "east":
                        return Direction.East;
                    case "west":
                        return Direction.West;
                    case "n":
                        return Direction.North;
                    case "s":
                        return Direction.South;
                    case "e":
                        return Direction.East;
                    case "w":
                        return Direction.West;
                    default:
                        Console.WriteLine("Invalid input. Please enter a valid direction.");
                        string newInput = Console.ReadLine();
                        return GetDirection(newInput);
                }
            }

        }





    }
}
