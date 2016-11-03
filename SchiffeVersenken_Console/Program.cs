using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SchiffeVersenken.Logic;
using SchiffeVersenken.Data;

namespace SchiffeVersenken_Console
{
    class Program
    {
        private static ConsoleColor bg_default = Console.BackgroundColor;
        private static bool isRunning = true;
        private static int maxHits = 30;
        private static int maxShots = 55;
        private static int firedShots = 0;
        private static int hits = 0;
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
            while (isRunning)
            {
                Console.WriteLine(intro);
                Console.WriteLine("Schiffeversenken");
                Console.WriteLine("_______________ Menue _______________\nBitte Ziffer eingeben fuer Auswahl.");
                Console.WriteLine("(1) Neues Spiel\n(2) Hilfe\n(3) Beenden");
                
                int userInput = Int32.Parse(Console.ReadLine());
                switch (userInput)
                {
                    case 1: //Start Game
                        StartMatch();
                        break;
                    case 2: //Print Info
                        Console.WriteLine("\nIn diesem Spiel geht es darum alle gegnerischen Schiffe vollstaendig zu\n"
                            + "zerstoeren bevor. Sie haben nur 50 Kanonenkugeln um alle 10 Schiffe zu versenken.\n"
                            + "Die gegnerische Flotte besteht aus den folgenden Schiffen:\n"
                            + "1 x Schlachtschiff (Groesse: 5)\n"
                            + "2 x Kreuzer (Groesse: 4)\n"
                            + "3 x Zerstoerer (Groesse: 3)\n"
                            + "4 x U-Boote (Groesse: 1)\n");
                        break;
                    case 3: Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Oooops!");
                        break;
                    
                }
            }
        }

        private static void StartMatch()
        {
            LogicHandler gameLogic = new LogicHandler();
            GameMap map = gameLogic.GetMap();
            int[,] spielFeld = new Int32[10,10];
            
            while (firedShots < maxShots && hits < maxHits)
            {
                Console.WriteLine("\n\n\n\n");
                DrawMap(map);
                Console.WriteLine("_____ Treffer: " + hits + "/" + maxHits + " __________ Kanonenkugeln: " + (maxShots - firedShots) + " _____");
                int x, y;
                Console.Write("Wir brauchen die Koordinaten Kaept'n!\nX:");
                x = Int32.Parse(Console.ReadLine());
                Console.Write("Y:");
                y = Int32.Parse(Console.ReadLine());
                Console.WriteLine("Arrrr! Feuer auf [" + x + " , " + y + "]!");
                firedShots++;
                switch (map[y, x])
                {
                    case 0:
                        map[y, x] = -2;
                        Console.WriteLine("Verfehlt!");
                        break;
                    case 1:
                        hits++;
                        map[y, x] = -1;
                        Console.WriteLine("Treffer!");
                        break;
                    case -1:
                        Console.WriteLine("Kaept'n, da hatten wir bereits getroffen...");
                        break;
                    case -2:
                        Console.WriteLine("Kaept'n, da ist immer noch nur Wasser...");
                        break;
                }
            }
            if( hits == maxHits)
            {
                Console.WriteLine("\n\n~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                Console.WriteLine("~~~~~~~~~~~~~~~~~GEWONNEN! (" + firedShots + " Kugeln benoetigt)~~~~~~~~~~~~~~~~");
                Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~\n\n");
            }
            else
            {
                Console.WriteLine("\n\n~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~NIEDERLAGE!~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~\n\n");
            }

        }

        private static void DrawMap(GameMap map)
        {
            Console.BackgroundColor = bg_default;
            Console.WriteLine("    0  1  2  3  4  5  6  7  8  9   X");
            for (int i = 0; i < map.Length; i++)
            {
                Console.BackgroundColor = bg_default;
                Console.Write(" " + i + " ");
                for (int j = 0; j < map.Height; j++)
                {
                    switch (map[i, j])
                    {
                        case -1:
                            Console.BackgroundColor = ConsoleColor.Red; break;
                        case -2:
                            Console.BackgroundColor = ConsoleColor.Blue; break;
                        default:
                            Console.BackgroundColor = ConsoleColor.Green; break;
                    }
                    Console.Write("   ");
                    //Console.BackgroundColor = bg_default;
                    //Console.Write(" ");
                }
                Console.WriteLine();
            }
            Console.BackgroundColor = bg_default;
            Console.WriteLine(" Y");
        }
    }
}
