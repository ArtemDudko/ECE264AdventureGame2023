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
        
        public void LoadRooms()
        {
            //load Rooms.txt and process
            string raw_room_data = File.ReadAllText("Rooms.txt");
            StringBuilder sb = new StringBuilder(raw_room_data);
            var result = sb.ToString().Split('&');




            string[,] room_data = new string[100, 4];

            for (int i = 0; i < 100; i++)
            {
                for (int k = 0; k < 4; k++)
                {
                    
                }
            }
            //return room_data;
        }
        
        




        ///the data is in a 2d array format, split by the & sign, it will be split into usable data just like we did in 
        ///the shakespeare lab. It's possible we will need a separate long description file.
        ///


        public void LoadRoom()
        {

        }
    }
}
