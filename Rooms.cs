using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECE264AdventureGame2023
{
    class Rooms
    {
        string room_data = File.ReadAllText("Rooms.txt");
        string exit_trigger_data = File.ReadAllText("ExitTriggers.txt");
        ///the data is in a 2d array format, split by the & sign, it will be split into usable data just like we did in 
        ///the shakespeare lab. It's possible we will need a separate long description file.
    }
}
