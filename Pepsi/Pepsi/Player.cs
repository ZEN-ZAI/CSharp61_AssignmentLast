using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pepsi
{
    class Player: Character
    {
        public Map Map { get; set; }

        public Player(string character) : base(character) { }

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
