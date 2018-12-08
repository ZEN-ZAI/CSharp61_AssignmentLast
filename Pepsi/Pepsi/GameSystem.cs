using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pepsi
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
            Player.inMap = "StageStart";
            active = (state)(StageStart);
            active();
        }

        private void CheckingMap(int dimention)
        {
            for (int i = 0; i < Graph.graph.GetLength(1); i++)
            {
                if (Player.positionX == Graph.graph[dimention, i].x &&
                    Player.positionY == Graph.graph[dimention, i].y)
                {
                    Player.positionY = Graph.graph[i, dimention].y;
                    Player.positionX = Graph.graph[i, dimention].x + 1;

                    Player.inMap = Graph.graph[dimention, i].map;
                    Map.Clean();
                }
            }
        }

        public void Update()
        {
            if (Player.inMap == "StageStart")
            {
                CheckingMap(0);
            }
            else if (Player.inMap == "Stage1")
            {
                CheckingMap(1);
            }
            else if (Player.inMap == "Stage2")
            {
                CheckingMap(2);
            }
            else if (Player.inMap == "Stage3")
            {
                CheckingMap(3);
            }
            else if (Player.inMap == "StageBoss")
            {
                CheckingMap(4);
            }


            WarpPosition();
        }

        public void WarpPosition()
        {
            if (active == StageStart && Player.inMap == "StageStart")
            {
                active = (state)(StageStart);
            }
            else if (active == StageStart && Player.inMap == "Stage1")
            {
                active = (state)(Stage1);
            }


            else if (active == Stage1 && Player.inMap == "Stage1")
            {
                active = (state)(Stage1);
            }
            else if (active == Stage1 && Player.inMap == "Stage2")
            {
                active = (state)(Stage2);
            }
            else if (active == Stage2 && Player.inMap == "StageStart")
            {
                active = (state)(StageStart);
            }

            else if (active == Stage2 && Player.inMap == "Stage2")
            {
                active = (state)(Stage2);
            }
            else if (active == Stage2 && Player.inMap == "Stage1")
            {
                active = (state)(Stage1);
            }
            else if (active == Stage2 && Player.inMap == "Stage3")
            {
                active = (state)(Stage3);
            }

            else if (active == Stage3 && Player.inMap == "Stage3")
            {
                active = (state)(Stage3);
            }
            else if (active == Stage3 && Player.inMap == "Stage2")
            {
                active = (state)(Stage2);
            }
            else if (active == StageBoss && Player.inMap == "StageBoss")
            {
                active = (state)(StageBoss);
            }

            active();
        }

        public void StageStart()
        {
            Map.map[20, 37] = "S1";

        }
        public void Stage1()
        {
            Map.map[19, 2] = "ST"; 
            Map.map[20, 37] = "S2";
        }
        public void Stage2()
        {
            Map.map[19, 2] = "S1";
            Map.map[37, 19] = "S3";
        }
        public void Stage3()
        {
            Map.map[2, 19] = "S2";
            Map.map[20, 2] = "SB";
        }
        public void StageBoss()
        {
            //Map.map[20, 37] = "S3";
        }
    }
}
