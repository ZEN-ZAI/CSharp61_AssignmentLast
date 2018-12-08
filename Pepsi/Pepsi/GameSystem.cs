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

        private List<Monster> monsterList0 = new List<Monster>();
        private List<Monster> monsterList1 = new List<Monster>();
        private List<Monster> monsterList2 = new List<Monster>();
        private List<Monster> monsterList3 = new List<Monster>();
        private List<Monster> monsterList4 = new List<Monster>();
        private bool spawn0 = false;
        private bool spawn1 = false;
        private bool spawn2 = false;
        private bool spawn3 = false;
        private bool spawn4 = false;

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

                    Player.positionX = Graph.graph[i, dimention].x + 1;
                    Player.positionY = Graph.graph[i, dimention].y;

                    Player.inMap = Graph.graph[dimention, i].map;
                    Map.Clean();


                }
            }
        }

        private void CheckWarp()
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

        }

        public void Update()
        {
            CombatSystem();
            MonsterSystem();
            CheckWarp();
            StateMap();

        }

        private List<Monster> aMonster_list = new List<Monster>();
        public void CombatSystem()
        {
            if (Player.inMap == "StageStart")
            {
                aMonster_list = monsterList0;
            }
            else if (Player.inMap == "Stage1")
            {
                aMonster_list = monsterList1;
            }
            else if (Player.inMap == "Stage2")
            {
                aMonster_list = monsterList2;
            }
            else if (Player.inMap == "Stage3")
            {
                aMonster_list = monsterList3;
            }
            else if (Player.inMap == "StageBoss")
            {
                aMonster_list = monsterList4;
            }
            int Count = aMonster_list.Count;
            int index = aMonster_list.FindLastIndex(element => element.positionX == Player.positionX &&
                                                           element.positionY == Player.positionY);

            if (index >= 0)
            {

                Player.current--;
                if (aMonster_list[index].character == "BO")
                {

                }
                else
                {


                    aMonster_list.RemoveAt(index);
                }


                if (Player.current <= 0)
                {
                    Player.current = 0;
                    Player.inMap = "End";
                    Console.WriteLine("     {{{{{{{{{{{{{{{{{{{{{{ [GAME OVER] }}}}}}}}}}}}}}}}}}}}}}");


                }
            }

        }

        public void MonsterSystem()
        {
            if (Player.inMap == "StageStart")
            {
                if (!spawn0)
                {
                    for (int i = 0; i < 2; i++)
                    {
                        Monster monster = new Monster("MO", Map, Player);
                        monsterList0.Add(monster);
                        monster.Setup();
                    }
                    spawn0 = true;
                }
                else
                {
                    Console.WriteLine("monsterList0 " + monsterList0.Count);

                    foreach (var item in monsterList0)
                    {
                        Task.Delay(1).Wait();
                        item.update();
                        Console.WriteLine("mon " + item.positionX + " " + item.positionY);
                    }
                }
            }
            if (Player.inMap == "Stage1")
            {
                if (!spawn1)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        Monster monster = new Monster("MO", Map, Player);
                        monsterList1.Add(monster);
                        monster.Setup();
                    }
                    spawn1 = true;
                }
                else
                {
                    Console.WriteLine("monsterList1 " + monsterList1.Count);

                    foreach (var item in monsterList1)
                    {
                        Task.Delay(1).Wait();
                        item.update();
                        Console.WriteLine("mon " + item.positionX + " " + item.positionY);
                    }
                }
            }
            else if (Player.inMap == "Stage2")
            {
                if (!spawn2)
                {
                    for (int i = 0; i < 4; i++)
                    {
                        Monster monster = new Monster("MO", Map, Player);
                        monsterList2.Add(monster);
                        monster.Setup();
                    }
                    spawn2 = true;
                }
                else
                {
                    Console.WriteLine("monsterList2 " + monsterList2.Count);

                    foreach (var item in monsterList2)
                    {
                        Task.Delay(1).Wait();
                        item.update();
                        Console.WriteLine("mon " + item.positionX + " " + item.positionY);
                    }
                }
            }
            else if (Player.inMap == "Stage3")
            {
                if (!spawn3)
                {
                    for (int i = 0; i < 5; i++)
                    {
                        Monster monster = new Monster("MO", Map, Player);
                        monsterList3.Add(monster);
                        monster.Setup();
                    }
                    spawn3 = true;
                }
                else
                {
                    Console.WriteLine("monsterList3 " + monsterList3.Count);

                    foreach (var item in monsterList3)
                    {
                        Task.Delay(1).Wait();
                        item.update();
                        Console.WriteLine("mon " + item.positionX + " " + item.positionY);
                    }
                }
            }
            else if (Player.inMap == "StageBoss")
            {
                if (!spawn4)
                {
                    Monster monster = new Monster("BO", Map, Player);
                    monsterList4.Add(monster);
                    monster.Setup();

                    spawn4 = true;
                }
                else
                {
                    Console.WriteLine("monsterList4 " + monsterList4.Count);

                    foreach (var item in monsterList4)
                    {
                        Task.Delay(1).Wait();
                        item.update();
                        Console.WriteLine("mon " + item.positionX + " " + item.positionY);
                    }
                }
            }
        }

        public void StateMap()
        {
            if (active == StageStart && Player.inMap == "StageStart")
            {
                active = (state)(StageStart);
            }
            else if (active == StageStart && Player.inMap == "Stage1")
            {
                active = (state)(Stage1);
            }
            else if (active == StageStart && Player.inMap == "End")
            {
                active = (state)(End);
            }

            //
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
            else if (active == Stage1 && Player.inMap == "End")
            {
                active = (state)(End);
            }

            //
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
            else if (active == Stage2 && Player.inMap == "End")
            {
                active = (state)(End);
            }

            //
            else if (active == Stage3 && Player.inMap == "Stage3")
            {
                active = (state)(Stage3);
            }
            else if (active == Stage3 && Player.inMap == "Stage2")
            {
                active = (state)(Stage2);
            }
            else if (active == Stage3 && Player.inMap == "StageBoss")
            {
                active = (state)(StageBoss);
            }
            else if (active == Stage3 && Player.inMap == "End")
            {
                active = (state)(End);
            }

            //
            else if (active == StageBoss && Player.inMap == "StageBoss")
            {
                active = (state)(StageBoss);
            }
            else if (active == StageBoss && Player.inMap == "End")
            {
                active = (state)(End);
            }
            else if (active == StageBoss && Player.inMap == "End")
            {
                active = (state)(End);
            }

            active();
        }

        public void StageStart()
        {
            Map.map[20, 37] = "S1";
            Map.map[19, 2] = "  ";
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
            Map.map[2, 19] = "S3";

            for (int i = 25; i < 30; i++)
            {
                for (int j = 25; j < 30; j++)
                {
                    Map.map[i, j] = "La";

                    try
                    {
                        if (monsterList4[0].positionX == j &&
                            monsterList4[0].positionY == i)
                        {
                            Player.inMap = "End";
                        }
                    }
                    catch (Exception)
                    {

                        Console.WriteLine("Exception");
                    }

                }
            }

        }
        public void End()
        {

            if (Player.current <= 0)
            {
                Map.map[19, 17] = "Ga";
                Map.map[19, 18] = "me";
                Map.map[19, 19] = " O";
                Map.map[19, 20] = "ve";
                Map.map[19, 21] = "r.";
            }
            else
            {
                Map.map[19, 17] = " E";
                Map.map[19, 18] = "ND";
                Map.map[19, 19] = " G";
                Map.map[19, 20] = "AM";
                Map.map[19, 21] = "E.";
            }
        }
    }
}
