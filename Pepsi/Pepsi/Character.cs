using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pepsi
{
    public abstract class Character
    {
        public string character { get; set; }
        public string inMap { get; set; }
        public int positionX { get; set; }
        public int positionY { get; set; }
        public int old_positionX { get; set; }
        public int old_positionY { get; set; }

        public Character(string character,int x,int y)
        {
            this.character = character;
            positionX = x;
            positionY = y;
        }

        public Character(string character)
        {
            Task.Delay(1).Wait();
            Random aRandom = new Random((int)DateTime.Now.Ticks);

            this.character = character;

            if (character == "BO")
            {
                positionX = 19;
                positionY = 38;
            }
            else
            {
                positionX = aRandom.Next(1, 38);
                positionY = aRandom.Next(1, 38);
            }
        }
    }
}