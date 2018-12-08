using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pepsi
{
    public abstract class Character
    {
        public string character { get; set; }
        public string inMap { get; set; }
        public int positionX { get; set; } = 2;
        public int positionY { get; set; } = 2;
        public int old_positionX { get; set; }
        public int old_positionY { get; set; }

        public Character(string character)
        {
            this.character = character;
        }
    }
}