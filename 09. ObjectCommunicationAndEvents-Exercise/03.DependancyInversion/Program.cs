using _03.DependancyInversion.Controllers;
using System;

namespace _03.DependancyInversion
{
    class Program
    {
        static void Main(string[] args)
        {
            var engine = new Engine();

            engine.Run();
        }
    }
}
