//Artem Dudko, Nikolas Tapanainen, Thomas J Ryan, Sai Abhishek Bhattiprolu - started 3/29/23
//ECE264 - Advneture Game Final Project
//Referneces:
/*
 * For working on github;
 * pull new changes;
 * make more changes;
 * commit new changes with summary message;
 * push changes to the master;
 * 
 * 
 * 
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
            bool debug = GetYesNo("Would you like to enable Debug mode?");  //Check if this is on using ifs, debug messages are surrounded by brackets
            //EX:
            if (debug) Console.WriteLine("[Debug Mode Enabled]");

            string playerName = WelcomePlayer();
            Console.WriteLine("Hi, " + playerName);


            int currentRoomID = 1;

            while (true)   //game loop
            { 
                
            
            
            
            
            
                
            }










        }









        static string WelcomePlayer()
        {
            ///Insert other introductory stuff here
            Console.WriteLine("Welcome to Cyber Conspiracy!");
            Console.WriteLine("Please enter your name: ");            
            string userInput = Console.ReadLine();
            return userInput;

        }
        static bool GetYesNo(string prompt)
        {
            string[] valid = { "YES", "Y", "NO", "N" };
            string ans;
            ans = GetString(prompt, valid, "?Invalid response, please reenter");
            return (ans == "YES" || ans == "Y");

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

        static void GameOver(int gameOverNumber)
        {
            switch (gameOverNumber)
            {
                case 1:
                    Console.WriteLine("Your connections were not strong enough to get you out of this bind, \nCyclone will make sure nobody hears of you.");
                    break;
                case 2:
                    Console.WriteLine("'Sorry, but the house always wins, and you can no longer pay your debt.'");
                    break;
            }
            Console.WriteLine("GAME OVER, YOU REACHED BAD ENDING #" + gameOverNumber + ", THANKS FOR PLAYING");

        }





    }
}
