using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bestty
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

            AddGraph(0, 1, new Data { y = 5, x = 5, map = "Map1" }, new Data { y = 5, x = 5, map = "Map0" });
            AddGraph(0, 2, new Data { y = 5, x = 20, map = "Map2" }, new Data { y = 5, x = 20, map = "Map0" });
            AddGraph(0, 3, new Data { y = 20, x = 5, map = "Map3" }, new Data { y = 20, x = 5, map = "Map0" });
            AddGraph(0, 4, new Data { y = 20, x = 20, map = "Map4" }, new Data { y = 20, x = 20, map = "Map0" });
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
