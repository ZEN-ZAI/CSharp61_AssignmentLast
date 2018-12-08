using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pepsi
{
    public class Graph
    {
        public Data[,] graph = new Data[5, 5];

        public Graph()
        {
            for (int i = 0; i < graph.GetLength(0); i++)
            {
                for (int j = 0; j < graph.GetLength(1); j++)
                {
                    graph[i, j] = new Data();
                }
            }

            AddGraph(0, 1, new Data { y = 20, x = 37, map = "Stage1" }, new Data { y = 19, x = 2, map = "StageStart" });
            AddGraph(1, 2, new Data { y = 20, x = 37, map = "Stage2" }, new Data { y = 19, x = 2, map = "Stage1" });
            AddGraph(2, 3, new Data { y = 37, x = 19, map = "Stage3" }, new Data { y = 2, x = 19, map = "Stage2" });
            AddGraph(3, 4, new Data { y = 20, x = 2, map = "StageBoss" }, new Data { y = 0, x = 0, map = "Stage3" });
        }

        public void AddGraph(int map1, int map2, Data map1to2, Data map2to1)
        {
            graph[map1, map2].x = map1to2.x;
            graph[map1, map2].y = map1to2.y;
            graph[map1, map2].map = map1to2.map;


            graph[map2, map1].x = map2to1.x;
            graph[map2, map1].y = map2to1.y;
            graph[map2, map1].map = map2to1.map;
        }
    }
    public class Data
    {
        public int x;
        public int y;
        public string map;
    }
}