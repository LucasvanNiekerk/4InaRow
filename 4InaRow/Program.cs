using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace _4InaRow
{
    class Program
    {
        static void Main(string[] args)
        {
            FourInARow game = new FourInARow();
            game.Addplayers();
            game.Play();

            Console.ReadKey();
        }
    }
}
