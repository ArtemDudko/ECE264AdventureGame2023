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
        public static Dictionary<int, bool> LoadTriggers(string root_folder)
        {
            //load Rooms.txt and process
            
            string raw_trigger_data = File.ReadAllText(root_folder + "\\Triggers.txt");
            raw_trigger_data = raw_trigger_data.Remove(0, raw_trigger_data.IndexOf("&&&") + 3);      //remove unnecessary stuff
            StringBuilder sb = new StringBuilder(raw_trigger_data);
            sb = sb.Replace("\n", "");
            sb = sb.Replace("\t", "");
            sb = sb.Replace("\r", "");
            var raw_trigger_data_array = sb.ToString().Split('&');
            var trigger_data_dic = new Dictionary<int, bool>() { };
            for (int trigger_id = 1; trigger_id < raw_trigger_data_array.Length / 2; trigger_id++)
            {
                trigger_data_dic.Add(trigger_id, bool.Parse(raw_trigger_data_array[trigger_id * 2 - 1]));
            }
            return trigger_data_dic;

        }


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

            //-Prior to entering room 1:-
            //PA: Hello. Welcome to the Uprall Transport Hub. Please enter your name"
            //player prompt for name
            //PA: Hello (player name), where would you like to go?
            //present choices for {Helio City} {I don't know where}

            // -if {Helio City}: -
            //You: Helio City, please
            //PA: Travelling to Helio City,please take your seat.
            //-enter room 1-

            //-if {I don't know where}-
            //You: Uh, I'm not really sure. Maybe I'll visit Uprall some other time.
            //PA: Thank you, have a good day
            //Ending 0: The Road Untravelled
            static Room room1 = new Room { Name = "Room1", Description = "You've made it to Helio City, Uprall's capital" };

        static Room room2 = new Room { Name = "Room2", Description = "You enter the back ally" };
        /*You: That guy in the hood. Who is he?
          As you step toward him, he turns around and sharpens his gaze
          ???: Who are you?

          -present choice-
            //{I'm nobody}
                //You: Oh, uh, I'm just nobody
                //???: Uh huh. And a "nobody" followed a hooded man into a back ally? Is "nobody" stupid?
                //You: Uh, no. Curiosity I guess. My name's {name}. Can I ask yours?
            //{I'm passing through}
                //You: I'm just passing through. My name's {name}
                //???: Just passing through huh? Getting seen with me is dangerous here in Uprall.
                //You: And who exactly are you?

        //???: ...You can call me Zrkka.
          Zrrka stares at you for a short time, and eventually asks;
        //Zrkka: 'The Steel Reaper'. Does that name mean anything to you?

        //-present choice- 
            //{Yes}
                //You: Yes, I know exactly who that is.
                //Zrkka: In that case...
                //Zrrka extends his arm toward you, sharp blades extending out from his wrist.
                //Zrrka: Their reach has gone farther than I thought. You're clearly a new recruit, so let me give you some advice: Don't follow me, if you value your life.
                  You: What are you-?
                  Zrkka walks toward you, blades extended
                  Zrkka: If I were you, I'd keep walking.
                  You: Ok, ok, I'm going.
                  Zrkka keeps his eye on you as he leaves the ally by climbing over a gate. Given the gate's height, he clearly wasn't human.
                  You: Ok then...moving on.
           {No}
                You: No, it doesn't. Is...that some kind of superhero?
                Zrkka stares at you some more, you notice his eyes glow red.
                Zrkka: Heartbeat stable, minimal perspiration. Unless you're a professional liar, you're telling me the truth.
                You: Are you the Steel Reaper?
                Zrkka: I suppose since you're here, you've gotten yourself roped into everything. Yes, I am.
                Zrkka removes his hood to reveal an almost completely cybernetic body
                Zrkka: I used to be a member of the Cyber Directive, a group of Uprallans who belive they can cyberize the whole world, so they can bend it to their will. 
                You: 'Used to be'? Why'd you quit?
                Zrkka: During a mission, something went wrong, and I got my autonomy back. Whatever control they had over me is gone, and now I fight back against them.
                You: Wait...you said I'm roped up in all this now?
                Zrkka: They've got eyes everywhere, they're after you now. So your best bet is to help me out.
                You: Yeah...I guess so.
                Zrkka: Here, take this. It'll help you see things in Uprall that they don't want you to see. It'll come in handy, I'm sure.
                You recieved the Cyber Lens!
                Zrkka: A friend of mine is patrolling the city as well. It's likely you'll run into him. He'll need your trust, or else he'll kill you. 
                You: That's comforting. How do I get his trust?
                Zrkka: He'll ask you a question, you give him the answer. The answer is '112'.
                You: 112. Got It. How will I know this friend of yours.
                Zrkka: Oh, you'll know. His bite is a lot worse than his bark.
                With a chuckle, Zrkka left the ally by jumping over a large gate.
                */

        static Room room3 = new Room { Name = "Room3", Description = "You continue through the square" };

        static Room room4 = new Room { Name = "Room4", Description = "You reach a road leading east" };
        /*
            -occurs when you try to go East WITH the coin or secret coin in inventory-
                Out of nowhere, a cyborg steps out of the shadows
                ???: That coin you've got there doesn't belong to you         */

        static Room room5 = new Room { Name = "Room5", Description = "You've reached a long road" };
        static Room room6 = new Room { Name = "Room6", Description = "You've entered an empty ally" };
        static Room room7 = new Room { Name = "Room7", Description = "You continue down the long road" };
        static Room room8 = new Room { Name = "Room8", Description = "You enter a shelter" };
        static Room room9 = new Room { Name = "Room9", Description = "You enter what appears to be a courtyard" };
        static Room room10 = new Room { Name = "Room10", Description = "You find your way into an ally" };
        static Room room11 = new Room { Name = "Room11", Description = "You've reached a dead end" };
        static Room room12 = new Room { Name = "Room12", Description = "You walked into the Firioris building foyer" };
        static Room room13 = new Room { Name = "Room13", Description = "You enter a vault" };
        static Room room14 = new Room { Name = "Room14", Description = "You walk into an office" };
        static Room room15 = new Room { Name = "Room15", Description = "You enter a room" };
        static Room room16 = new Room { Name = "Room16", Description = "You continue down the hall" };
        static Room room17 = new Room { Name = "Room17", Description = "You enter the reactor" };
        static Room room18 = new Room { Name = "Room18", Description = "You walk into a large room" };
        static Room room19 = new Room { Name = "Room19", Description = "You've made it to the Sanctum" };
        static Room room1001 = new Room { Name = "S-Room1", Description = "Wow, a casino!" };
        static Room room1002 = new Room { Name = "S-Room2", Description = "You grappled to the rooftop" };
        static Room room1003 = new Room { Name = "S-Room3", Description = "Wow, a casino!" };
        static Room room1004 = new Room { Name = "S-Room4", Description = "You enter another hallway" };
        static Room room1005 = new Room { Name = "S-Room5", Description = "You enter a dimly lit room" };
        static Room room1006 = new Room { Name = "S-Room5", Description = "You enter what appears to be a torture chamber" };
        static Room room1007 = new Room { Name = "S-Room6", Description = "You find what appears to be a testing facility." };
        static Room room1008 = new Room { Name = "S-Room7", Description = "You walk into an elevator" };

        static Room currentRoom = room1;

        



            

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