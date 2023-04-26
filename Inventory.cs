using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECE264AdventureGame2023
{
    class Inventory
    {
        string raw_item_data = File.ReadAllText("Items.txt");

        public static string[,] LoadItems(string root_folder)
        {
            //load Rooms.txt and process
            string raw_item_data = File.ReadAllText(root_folder + "\\Items.txt");
            raw_item_data = raw_item_data.Remove(0, raw_item_data.IndexOf("&&&") + 3);      //remove unnecessary stuff
            StringBuilder sb = new StringBuilder(raw_item_data);
            sb = sb.Replace("\n", "");
            sb = sb.Replace("\t", "");
            sb = sb.Replace("\r", "");
            var raw_item_data_array = sb.ToString().Split('&');

            string[,] item_data = new string[100, 3];
            int item_count = 0;
            for (int row = 1; row < 100; row++) //index array starting at itemID
            {
                for (int col = 0; col < 3; col++)
                {
                    item_data[row, col] = raw_item_data_array[item_count].Trim();
                    item_count++;
                    if (item_count == raw_item_data_array.Length) return item_data;
                }
            }            
            return item_data;
        }

        public static string[,] TakeItems(int current_room_id, string[,] item_data)
        {
            int itemCount = 0;
            for (int row = 1; row < 100; row++)
            {
                
                if(current_room_id.ToString() == item_data[row,2])
                {
                    itemCount++;
                    item_data[row, 2] = "0";
                    Console.WriteLine("You have attained the {0}.", item_data[row, 1]);
                }
            }

            if (itemCount == 0)
                Console.WriteLine("There is nothing of note to take.");

            return item_data;
        }


        public static void ListFloorItems(int current_room_id, string[,] item_data)
        {
            int itemCount = 0;
            for (int row = 1; row < 100; row++)
            {
                if (current_room_id.ToString() == item_data[row, 2])
                {
                    Console.WriteLine("You see a {0} on the ground.", item_data[row, 1]);
                    itemCount++;
                }
            }
            if(itemCount == 0)
                Console.WriteLine("There appears to be nothing of note on the ground.");
        }

        public static void ListInventory(string[,] item_data)
        {
            int itemCount = 0;
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("Current Inventory:");

            for (int row = 1; row < 100; row++)
            {
                if ("0" == item_data[row, 2])
                {
                    Console.WriteLine("[{0}]", item_data[row, 1]);
                    itemCount++;
                }
            }

            if (itemCount == 0)
                Console.WriteLine("[EMPTY]");
            Console.ForegroundColor = ConsoleColor.White;
        }
        public static string[,] DropItem(int current_room_id, string[,] item_data)
        {
            string dropped_item;
            List<string> valid = new List<string>() {"C"};

            for (int row = 1; row < 100; row++)
            {
                if ("0" == item_data[row, 2])
                {
                    valid.Add(item_data[row, 1]);
                }
            }    
            string[] valid_array = valid.ToArray();

            bool OK = false;
            string userInput;
            do
            {
                Console.Write("Which item would you like to drop? (type 'C' to Cancel) ");
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                userInput = Console.ReadLine().ToUpper();
                Console.ForegroundColor = ConsoleColor.White;
                foreach (string s in valid_array) if (userInput == s.ToUpper()) OK = true;
                if (!OK) Console.WriteLine("?invalid item?");

            } while (!OK);
                   
            if (userInput == "C")
                Console.WriteLine("You decide to hold on to your stuff.");

            for (int row = 1; row < 100; row++)
            {
                if (item_data[row, 1] != null)
                {
                    if (userInput == item_data[row, 1].ToUpper())
                    {
                        item_data[row, 2] = current_room_id.ToString();
                        Console.WriteLine("You have dropped the {0}.", item_data[row, 1]);
                        break;
                    }
                }
            }


            return item_data;
        }

    }
}
