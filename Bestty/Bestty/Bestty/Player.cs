using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bestty
{
    class Player
    {
        public Map Map { get; set; }

        public string character { get; set; }
        public string inMap { get; set; }
        public int positionX { get; set; } = 2;
        public int positionY { get; set; } = 2;
        public int old_positionX { get; set; }
        public int old_positionY { get; set; }

        public bool keyM1 = false;
        public bool keyM2 = false;

        public Player(string character)
        {
            this.character = character;
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

        public void Display()
        {
            Console.WriteLine("Player in Map: "+inMap);
        }
        
    }
}
