using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pepsi
{
    class InputHandle
    {
        public Player Player { get; set; }
        public Map Map { get; set; }
        public GameSystem GameSystem { get; set; }

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
                        Player.UnHiding();
                        Player.positionY -= 1;
                        Player.move();
                    }
                    break;

                case ConsoleKey.DownArrow:
                    if (Player.positionY < Map.map.GetLength(0) - 1 && Map.map[Player.positionY + 1, Player.positionX] != "##")
                    {
                        Player.UnHiding();
                        Player.positionY += 1;
                        Player.move();
                    }
                    break;

                case ConsoleKey.LeftArrow:
                    if (Player.positionX > 0 && Map.map[Player.positionY, Player.positionX - 1] != "##")
                    {
                        Player.UnHiding();
                        Player.positionX -= 1;
                        Player.move();
                    }
                    break;

                case ConsoleKey.RightArrow:
                    if (Player.positionX < Map.map.GetLength(1) - 1 && Map.map[Player.positionY, Player.positionX + 1] != "##")
                    {
                        Player.UnHiding();
                        Player.positionX += 1;
                        Player.move();
                    }
                    break;

                case ConsoleKey.Spacebar:
                    Player.Hiding();
                    break;

                case ConsoleKey.F1:
                    Player.inMap = "StageStart";
                    GameSystem.active = (GameSystem.state)(GameSystem.StageStart);
                    GameSystem.active();
                    Map.Clean();
                    break;

                case ConsoleKey.F2:
                    Player.inMap = "Stage1";
                    GameSystem.active = (GameSystem.state)(GameSystem.Stage1);
                    GameSystem.active();
                    Map.Clean();
                    break;

                case ConsoleKey.F3:
                    Player.inMap = "Stage2";
                    GameSystem.active = (GameSystem.state)(GameSystem.Stage2);
                    GameSystem.active();
                    Map.Clean();
                    break;

                case ConsoleKey.F4:
                    Player.inMap = "Stage3";
                    GameSystem.active = (GameSystem.state)(GameSystem.Stage3);
                    GameSystem.active();
                    Map.Clean();
                    break;

                case ConsoleKey.F5:
                    Player.inMap = "StageBoss";
                    GameSystem.active = (GameSystem.state)(GameSystem.StageBoss);
                    GameSystem.active();
                    Map.Clean();
                    break;

                case ConsoleKey.F6:
                    Player.inMap = "End";
                    GameSystem.active = (GameSystem.state)(GameSystem.End);
                    GameSystem.active();
                    Map.Clean();
                    break;

                default:

                    break;

            }
        }
    }
}
