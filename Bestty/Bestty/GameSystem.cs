using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bestty
{
    class GameSystem
    {
        public Player Player { get; set; }
        public Map Map { get; set; }
        public Graph Graph { get; set; }

        public delegate void state();
        public state active;

        public GameSystem()
        {
        }

        public void Setup()
        {
            Player.inMap = "Map0";
            active = (state)(Map0);
            active();
        }

        private void CheckingMap(int dimention)
        {
            for (int i = 0; i < Graph.graph.GetLength(1); i++)
            {
                if (Player.positionX == Graph.graph[dimention, i].x &&
                    Player.positionY == Graph.graph[dimention, i].y)
                {
                    Player.positionY = Graph.graph[dimention, i].y-1;
                    Player.inMap = Graph.graph[dimention, i].map;
                    Map.Clean();
                }
            }
        }

        public void Update()
        {
            if (Player.inMap == "Map0")
            {
                CheckingMap(0);
            }
            else if (Player.inMap == "Map1")
            {
                CheckingMap(1);
            }
            else if (Player.inMap == "Map2")
            {
                CheckingMap(2);
            }
            else if (Player.inMap == "Map3")
            {
                CheckingMap(3);
            }
            else if (Player.inMap == "Map4")
            {
                CheckingMap(4);
            }


            WarpPosition();
        }

        public void WarpPosition()
        {
            if (active == Map0 && Player.inMap == "Map0")
            {
                active = (state)(Map0);
            }
            else if (active == Map0 && Player.inMap == "Map1")
            {
                active = (state)(Map1);
            }
            else if (active == Map0 && Player.inMap == "Map2")
            {
                active = (state)(Map2);
            }
            else if (active == Map0 && Player.inMap == "Map3")
            {
                active = (state)(Map3);
            }
            else if (active == Map0 && Player.inMap == "Map4")
            {
                active = (state)(Map4);
            }

            else if (active == Map1 && Player.inMap == "Map1")
            {
                active = (state)(Map1);
            }
            else if (active == Map2 && Player.inMap == "Map2")
            {
                active = (state)(Map2);
            }
            else if (active == Map3 && Player.inMap == "Map3")
            {
                active = (state)(Map3);
            }
            else if (active == Map4 && Player.inMap == "Map4")
            {
                active = (state)(Map4);
            }

            else if (active == Map1 && Player.inMap == "Map0")
            {
                active = (state)(Map0);
            }
            else if (active == Map2 && Player.inMap == "Map0")
            {
                active = (state)(Map0);
            }
            else if (active == Map3 && Player.inMap == "Map0")
            {
                active = (state)(Map0);
            }
            else if (active == Map4 && Player.inMap == "Map0")
            {
                active = (state)(Map0);
            }

            active();
        }

        public void Map0()
        {
            Map.map[5, 5] = "M1";
            Map.map[5, 20] = "M2";
            Map.map[20, 5] = "M3";
            Map.map[20, 20] = "M4";

        }
        public void Map1()
        {
            Map.map[5, 5] = "M0";

            if (!Player.keyM1)
            {
                Map.map[14, 7] = "-+";

                if (Player.positionY == 14 && Player.positionX == 7)
                {
                    Player.keyM1 = true;
                    Map.Clean();
                }
            }
        }
        public void Map2()
        {
            Map.map[5, 20] = "M0";

            if (!Player.keyM2)
            {
                Map.map[23, 23] = "-+";
                if (Player.positionY == 23 && Player.positionX == 23)
                {
                    Player.keyM2 = true;
                    Map.Clean();
                }
            }
        }
        public void Map3()
        {
            Map.map[20, 5] = "M0";
        }
        public void Map4()
        {
            Map.map[20, 20] = "M0";
        }
    }
}
