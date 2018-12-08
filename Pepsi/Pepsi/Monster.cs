using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pepsi
{
    class Monster: Character
    {
        public Map Map { get; set; }
        public Player enemy { get; set; }
        Random aRandom = new Random();

        public Monster(string character,Map Map,Player player) : base(character)
        {
            enemy = player;
            this.Map = Map;
        }

        public delegate void state();
        public state active;

        public int distanceToEnemy { get; set; }

        public void Setup()
        {
            active = (state)(WalkState);
            active();
        }

        public void move()
        {
            Map.InsertCharacter(positionX, positionY, character);
            Map.InsertCharacter(old_positionX, old_positionY, "  ");
        }
        public void dont_move()
        {
            old_positionX = positionX;
            old_positionY = positionY;
            Map.InsertCharacter(positionX, positionY, character);
        }

        public void update()
        {
            distanceToEnemy = heuristic(this.positionX, this.positionY, enemy.positionX, enemy.positionY);

            if (active == WalkState && distanceToEnemy > 10 || enemy.hide)
            {
                active = (state)(WalkState);
                active();
            }
            else if (active == WalkState && distanceToEnemy <= 10 && !enemy.hide)
            {
                active = (state)(moveto_state);
                active();
            }
            else if (active == moveto_state && distanceToEnemy <= 10 && !enemy.hide)
            {
                active = (state)(moveto_state);
                active();
            }

        }

        public void WalkState()
        {
            old_positionX = positionX;
            old_positionY = positionY;

            int rotation = aRandom.Next(0, 4);

            switch (rotation)
            {
                case 0://up
                    if (positionY > 0 && Map.map[positionY - 1, positionX] != "##" &&
                        positionY > 0 && Map.map[positionY - 1, positionX] != "La")
                    {
                        positionY -= 1;
                        move();
                    }
                    break;

                case 1://down
                    if (positionY < Map.map.GetLength(0) - 1 && Map.map[positionY + 1, positionX] != "##" &&
                        positionY < Map.map.GetLength(0) - 1 && Map.map[positionY + 1, positionX] != "La")
                    {
                        positionY += 1;
                        move();
                    }
                    break;

                case 2://left
                    if (positionX > 0 && Map.map[positionY, positionX - 1] != "##" &&
                        positionX > 0 && Map.map[positionY, positionX - 1] != "La")
                    {
                        positionX -= 1;
                        move();
                    }
                    break;

                case 3://right
                    if (positionX < Map.map.GetLength(1) - 1 && Map.map[positionY, positionX + 1] != "##"&&
                        positionX < Map.map.GetLength(1) - 1 && Map.map[positionY, positionX + 1] != "La")
                    {
                        positionX += 1;
                        move();
                    }
                    break;

            }
        }

        public void moveto_state()
        {
            old_positionX = positionX;
            old_positionY = positionY;

            if (positionY < enemy.positionY && Map.map[positionY + 1, positionX] != "##")
            {
                positionY++;
            }
            else if (positionY > enemy.positionY && Map.map[positionY - 1, positionX] != "##")
            {
                positionY--;
            }
            else if (positionX < enemy.positionX && Map.map[positionY, positionX + 1] != "##")
            {
                positionX++;
            }
            else if (positionX > enemy.positionX && Map.map[positionY, positionX - 1] != "##")
            {
                positionX--;
            }


            move();
        }

        public int heuristic(int x1, int y1, int x2, int y2)
        {
            int result;

            if (Math.Abs(x1 - x2) > Math.Abs(y1 - y2))
                result = Math.Abs(x1 - x2);
            else
                return Math.Abs(y1 - y2);

            return result;
        }

    }
}
