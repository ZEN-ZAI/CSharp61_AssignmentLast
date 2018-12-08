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

        public Player(string character) : base(character,2,2)
        {
            current = hp;
        }
        public bool hide = false;

        public int current;
        public int hp = 5;

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

        public void Hiding()
        {
            if (!hide)
            {
                hide = true;
            }
            else if (hide)
            {
                hide = false;
            }
        }

        public void UnHiding()
        {
            hide = false;
        }

        public void Display()
        {
            Console.WriteLine();
            Console.WriteLine("           Pepsi in map: "+inMap+"   |   HP: "+ current + "/"+ hp + "   |  [Hiding: "+hide.ToString()+"]");
            Console.WriteLine();
        }
        
    }
}
