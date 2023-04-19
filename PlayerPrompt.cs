using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ECE264AdventureGame2023.PlayerPrompt.Directions;

namespace ECE264AdventureGame2023
{
    class PlayerPrompt
    {

        /*
         
        need to make big ass switch case statement
        
        0-99 will be room discovery

        100-199 will be dialogue and interactions in rooms

        200-299 will be events

        300-399 will be secret interactions

        400-499 will be 
         
         
         */

        //Libraries




        //Declaring Rooms and CurrentRoom to be in
        static Room room1 = new Room { Name = "Room1", Description = "You are in Helio City Square S" };
        static Room room2 = new Room { Name = "Room2", Description = "You are in Back Ally" };
        static Room room3 = new Room { Name = "Room3", Description = "You are in Helio City Square N" };
        static Room room4 = new Room { Name = "Room4", Description = "You are in Corner Street" };
        static Room room5 = new Room { Name = "Room5", Description = "You are in Academy Road S" };
        static Room room6 = new Room { Name = "Room6", Description = "You are in Side Ally" };
        static Room room7 = new Room { Name = "Room7", Description = "You are in Academy Road N" };
        static Room room8 = new Room { Name = "Room8", Description = "You are in Shelter" };
        static Room room9 = new Room { Name = "Room9", Description = "You are in Courtyard" };
        static Room room10 = new Room { Name = "Room10", Description = "You are in Side Street" };
        static Room room11 = new Room { Name = "Room11", Description = "You are in Dead End" };
        static Room room12 = new Room { Name = "Room12", Description = "You are in Firioris Building" };
        static Room room13 = new Room { Name = "Room13", Description = "You are in Filioris Vault" };
        static Room room14 = new Room { Name = "Room14", Description = "You are in Firioris building office" };
        static Room room15 = new Room { Name = "Room15", Description = "You are in Branching Hallway" };
        static Room room16 = new Room { Name = "Room16", Description = "You are in Pre-Reactor Hall" };
        static Room room17 = new Room { Name = "Room17", Description = "You are in Reactor Core" };
        static Room room18 = new Room { Name = "Room18", Description = "You are in Grand Hall" };
        static Room room19 = new Room { Name = "Room19", Description = "You are in Sanctum" };
        static Room room1001 = new Room { Name = "S-Room1", Description = "You are in Secret Casino" };
        static Room room1002 = new Room { Name = "S-Room2", Description = "You are in Rooftop" };
        static Room room1003 = new Room { Name = "S-Room3", Description = "You are in Secret Casino" };
        static Room room1004 = new Room { Name = "S-Room4", Description = "You are in Private Entrance" };
        static Room room1005 = new Room { Name = "S-Room5", Description = "You are in Torture Chamber" };
        static Room room1006 = new Room { Name = "S-Room6", Description = "You are in Competency Assessment Chamber" };
        static Room room1007 = new Room { Name = "S-Room7", Description = "You are in Hidden Lift" };

        static Room currentRoom = room1;

        public static int Choices(int roomID)
        {
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
            } return 0;
        }

        // GET YES/NO OR Y/N RESPONSE. RETURN TRUE FOR YES/Y, FALSE FOR NO/N
        static bool GetYesNo(string prompt)
        {
            string[] valid = { "YES", "Y", "NO", "N" };
            string ans;
            ans = GetString(prompt, valid, "?Invalid response, please reenter");
            return (ans == "YES" || ans == "Y");
        }

        // UNIVERSAL GET STRING WITH PROMPT, VALID VALUES, AND ERROR MESSAGE
        static string GetString(string prompt, string[] valid, string error)
        {
            // prompt=user prompt, valid=array of valid responses, error=msg to display on invalid entry
            // ALL STRINGS RETURNED UPPER CASE. ALL valid[] ENTRIES MUST BE IN UPPER CASE
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

        class Room //Room being created as a class
        {
            public string Name { get; set; }
            public string Description { get; set; }
        }

        internal static class Directions //Directions being declared as a class
        {
            public enum Direction
            {
                North,
                South,
                East,
                West,
                NorthEast,
                SouthEast,
                NorthWest,
                SouthWest,
                NE,
                NW,
                SE,
                SW,
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
                    case "northeast":
                        return Direction.NorthEast;
                    case "southeast":
                        return Direction.SouthEast;
                    case "northwest":
                        return Direction.NorthWest;
                    case "southwest":
                        return Direction.SouthWest;
                    case "n":
                        return Direction.North;
                    case "s":
                        return Direction.South;
                    case "e":
                        return Direction.East;
                    case "w":
                        return Direction.West;
                    case "ne":
                        return Direction.NorthEast;
                    case "se":
                        return Direction.SouthEast;
                    case "nw":
                        return Direction.NorthWest;
                    case "sw":
                        return Direction.SouthWest;
                    default:
                        Console.WriteLine("Invalid input. Please enter a valid direction.");
                        string newInput = Console.ReadLine();
                        return GetDirection(newInput);
                }
            }

        }
    }
}  