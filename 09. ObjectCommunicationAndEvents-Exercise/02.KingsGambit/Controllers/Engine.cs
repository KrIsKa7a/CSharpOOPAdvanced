using _02.KingsGambit.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace _02.KingsGambit.Controllers
{
    public class Engine
    {
        public Engine()
        {

        }

        public void Run()
        {
            var king = CreateKing();
            AddRoyalGuards(king);
            AddFootmans(king);

            string input;

            while ((input = Console.ReadLine()) != "End")
            {
                var inputArgs = input
                    .Split(' ');

                if (input == "Attack King")
                {
                    king.Respond();
                }
                else if (inputArgs[0] == "Kill")
                {
                    var name = inputArgs[1];

                    king.KillSlave(name);
                }
            }
        }

        private static void AddFootmans(King king)
        {
            var footmansNames = Console.ReadLine()
                            .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            foreach (var name in footmansNames)
            {
                var footman = new Footman(name);
                king.AddSlave(footman);
            }
        }

        private static void AddRoyalGuards(King king)
        {
            var rgNames = Console.ReadLine()
                            .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            foreach (var name in rgNames)
            {
                var rg = new RoyalGuard(name);
                king.AddSlave(rg);
            }
        }

        private King CreateKing()
        {
            var kingsName = Console.ReadLine();
            var king = new King(kingsName);

            return king;
        }
    }
}
