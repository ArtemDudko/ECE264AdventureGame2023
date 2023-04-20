using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECE264AdventureGame2023
{
    class Rooms
    {
        string raw_exit_trigger_data = File.ReadAllText("ExitTriggers.txt");
        //int test = 1;
        public static string[,] LoadRooms()
        {
            //load Rooms.txt and process
            string raw_room_data = File.ReadAllText("U:\\ECE264\\Adventure23\\Rooms.txt");
            raw_room_data = raw_room_data.Remove(0, raw_room_data.IndexOf("&&&") + 3);
            StringBuilder sb = new StringBuilder(raw_room_data);
            sb = sb.Replace("\n", "");
            sb = sb.Replace("\t", "");
            sb = sb.Replace("\r", "");
            var raw_room_data_array = sb.ToString().Split('&');
            
            string[,] room_data = new string[100, 4];
            int item_count = 0;
            for (int i = 0; i < 100; i++)
            {
                for (int k = 0; k < 4; k++)
                {
                    room_data[i, k] = raw_room_data_array[item_count];
                    item_count++;
                    if (item_count == raw_room_data_array.Length) return room_data;
                }
            }
            //test = 2;
            return room_data;
        }

        public static string[,] LoadExits()
        {
            //load Rooms.txt and process
            string raw_exit_data = File.ReadAllText("U:\\ECE264\\Adventure23\\ExitsConditions.txt");
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
                
            for (int row = 0; row < 100; row++)
            {                                         

                for (int col = 0; col < 11; col++)
                {           
                    


                    if (row * 11 + col + 1 > raw_exit_data_array.Length) 
                    {
                    break;
                    }

                    
                    

                    exit_data[row, col] = raw_exit_data_array[row * 11 + col]; 
                    
                }
            }
            return exit_data;
        }


        /*
        public static bool[] LoadExitTriggers()
        {
            string raw_exit_trigger_data = File.ReadAllText("U:\\ECE264\\Adventure23\\Rooms.txt");


            return
        }
        */


        public static int ListExits(int current_room_id, string[,] exit_data)
        {
            List<string> valid_exits = new List<string>();
            int row;
            Console.WriteLine("Here are your exits: ");

            
            int last_exit_row = 0;
            for (row = 1; row < 100; row++)
            {
                if (exit_data[row, 1] == current_room_id.ToString())    //sine there are multiples of 
                {
                    
                    last_exit_row = row;
                    //Int32.TryParse(l, out length);
                    //if (MyGlobals.Debug) Console.WriteLine("");
                    //if (exit_data[i, 4] == )
                    //Format: &"" &1			&1		&3	&Helio City Square S	&North  &0
                    Console.WriteLine("Exit #{0}: {1} to {2}, roomID {3}", exit_data[row, 2], exit_data[row, 5], exit_data[row, 4], exit_data[row, 3]);
                    valid_exits.Append(exit_data[row, 5]);
                    

                }
            }
            Console.WriteLine();
            int chosen_direction;
            chosen_direction = GetPlayerDirection("Where would you like to go?", valid_exits); //returns 0 thru 3 ot modify current line of data reading
            int chosen_exit_id = Int32.Parse(exit_data[last_exit_row - valid_exits.Count + chosen_direction, 3]);
            
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
            string[] valid = { "N", "NORTH", "S", "SOUTH", "E", "EAST", "W", "WEST" };
            string ans;
            int exit_number = 0;

            ans = GetString(prompt, valid, "?Invalid response, please reenter");

            foreach (string s in valid_exits)
            {
                if (ans == s)
                {
                    break;
                }
                exit_number++;
            }

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





        public void LoadRoom()
        {

        }

    }
}
