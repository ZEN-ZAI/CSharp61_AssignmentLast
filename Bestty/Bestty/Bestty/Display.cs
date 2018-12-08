using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bestty
{
    class Display
    {
        public GameSystem GameSystem { get; set; }

        public void MyDisplay(int flame)
        {
            Task.Delay(1000 / flame).Wait();
            Console.Clear();
            GameSystem.Player.Display();
            GameSystem.Map.Draw();
        }
    }
}
