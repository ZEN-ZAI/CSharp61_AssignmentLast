using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pepsi
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize(Console.LargestWindowWidth / 3, (Console.LargestWindowHeight / 2)+10);

            Map Map = new Map(40);
            Player Player = new Player("PS") { Map = Map };
            
            InputHandle Input_Handle = new InputHandle { Map = Map, Player = Player };
            Graph Graph = new Graph();
            GameSystem GameSystem = new GameSystem() { Map = Map, Player = Player , Graph  = Graph };
            Display Display = new Display { GameSystem = GameSystem };

            GameSystem.Setup();
            while (true)
            {

                if (Console.KeyAvailable == true)
                {
                    Input_Handle.myInputHandle();
                    GameSystem.Update();
                    Display.MyDisplay(30);
                }
                else
                {
                    GameSystem.Update();
                    Player.dont_move();
                    Display.MyDisplay(10);
                }

            }

        }
    }
}
