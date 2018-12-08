using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bestty
{
    class Program
    {
        static void Main(string[] args)
        {
            Map Map = new Map(25);
            Player Player = new Player("BB") { Map = Map };
            
            InputHandle InputHandle = new InputHandle { Map = Map, Player = Player };
            Graph Graph = new Graph();
            GameSystem GameSystem = new GameSystem() { Map = Map, Player = Player , Graph  = Graph };
            Display Display = new Display { GameSystem = GameSystem };
            //Map.insertKey(21, 9);
            //Map.insertExit(11, 19);
            GameSystem.Setup();
            while (true)
            {

                if (Console.KeyAvailable == true && GameSystem.active != GameSystem.End)
                {
                    InputHandle.myInputHandle();
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
