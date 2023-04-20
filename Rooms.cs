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
            return room_data;
        }
        public static string[,] LoadExits()
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
            return room_data;
        }

        public static void ListExits(int current_room, )
        {

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








        public void LoadRoom()
        {

        }

    }
}
