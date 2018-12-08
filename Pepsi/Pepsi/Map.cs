using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pepsi
{
    class Map
    {
        public string[,] map;

        public Map(int size)
        {
            map = new string[size, size];

            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    map[i, j] = "  ";
                    if (i == 0 || j == 0 || i == map.GetLength(0)-1 || j == map.GetLength(1)-1)
                    {
                        map[i, j] = "##";
                    }
                }
            }
        }

        public void Clean()
        {
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    map[i, j] = "  ";

                    if (i == 0 || j == 0 || i == map.GetLength(0) - 1 || j == map.GetLength(1) - 1)
                    {
                        map[i, j] = "##";
                    }
                }
            }
        }

        public void InsertCharacter(int positionX, int positionY, string character)
        {
            map[positionY, positionX] = character;
        }

        public void Draw()
        {
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    if (map[i, j] == "  ")
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.BackgroundColor = ConsoleColor.DarkGreen;
                        Console.Write(map[i, j]);
                    }
                    else if (map[i, j] == "ST" ||map[i, j] == "S1" || map[i, j] == "S2" || map[i, j] == "S3" || map[i, j] == "SB")
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.Write(map[i, j]);
                    }
                    else if(map[i, j] == "##")
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.Write(map[i, j]);
                    }
                    else if (map[i, j] == "PS")
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.BackgroundColor = ConsoleColor.DarkGreen;
                        Console.Write(map[i, j]);
                    }
                    else if (map[i, j] == "MO")
                    {
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.BackgroundColor = ConsoleColor.DarkGreen;
                        Console.Write(map[i, j]);
                    }
                    else if (map[i, j] == "BO")
                    {
                        Console.ForegroundColor = ConsoleColor.DarkBlue;
                        Console.BackgroundColor = ConsoleColor.DarkGreen;
                        Console.Write(map[i, j]);
                    }
                    else if (map[i, j] == "La")
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.Write(map[i, j]);
                    }
                    else
                    {
                        Console.ResetColor();
                        Console.Write(map[i, j]);
                        
                    }

                }
                Console.WriteLine();
                Console.ResetColor();
            }
        }
    }
}
