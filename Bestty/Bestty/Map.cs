using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bestty
{
    class Map
    {
        public string[,] map;

        public int keyPositionX;
        public int keyPositionY;

        public int ExitPositionX;
        public int ExitPositionY;

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
                    Console.Write(map[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}
