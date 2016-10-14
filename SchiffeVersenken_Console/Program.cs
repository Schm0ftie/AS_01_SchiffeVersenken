using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SchiffeVersenken.Logic;

namespace SchiffeVersenken_Console
{
    class Program
    {
        private static ConsoleColor bg_default = Console.BackgroundColor;
        private static string intro =
         @"                     " +  "\n" +
         @"      ./|\.          " +  "\n" +
         @"    ./ /| `\.        " +  "\n" +
         @"   /  | |   `\.      " +  "\n" +
         @"  |   | |     `\.    " +  "\n" +
         @"  |    \|       `\.  " +  "\n" +
         @".  `----|__________\." +  "\n" +
         @" \-----''----.....___" +  "\n" +
         @"  \               ""/" +  "\n" +
         @"~^~^~^~^~^`~^~^`^~^~^" +  "\n" +
         @"~^~^~`~~^~^`~^~^~`~~^";   
        static void Main(string[] args)
        {
            Console.WriteLine(intro);
            Console.WriteLine("Schiffeversenken 0.3 Alpha Build 12345");
            LogicHandler gameLogic = new LogicHandler();
            Console.ReadLine();
        }
    }
}
