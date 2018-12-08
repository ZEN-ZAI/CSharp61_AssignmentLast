using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bestty
{
    class InputHandle
    {
        public Player Player { get; set; }
        public Map Map { get; set; }

        public void myInputHandle()
        {
            ConsoleKeyInfo Ckey = Console.ReadKey(true);
            Player.old_positionX = Player.positionX;
            Player.old_positionY = Player.positionY;

            switch (Ckey.Key)
            {

                case ConsoleKey.UpArrow:
                    if (Player.positionY > 0 && Map.map[Player.positionY - 1, Player.positionX] != "##")
                    {
                        Player.positionY -= 1;
                        Player.move();
                    }
                    break;

                case ConsoleKey.DownArrow:
                    if (Player.positionY < Map.map.GetLength(0) - 1 && Map.map[Player.positionY + 1, Player.positionX] != "##")
                    {
                        Player.positionY += 1;
                        Player.move();
                    }
                    break;

                case ConsoleKey.LeftArrow:
                    if (Player.positionX > 0 && Map.map[Player.positionY, Player.positionX - 1] != "##")
                    {
                        Player.positionX -= 1;
                        Player.move();
                    }
                    break;

                case ConsoleKey.RightArrow:
                    if (Player.positionX < Map.map.GetLength(1) - 1 && Map.map[Player.positionY, Player.positionX + 1] != "##")
                    {
                        Player.positionX += 1;
                        Player.move();
                    }
                    break;

                default:

                    break;

            }
        }
    }
}
