using _03.DependancyInversion.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace _03.DependancyInversion.Controllers
{
    public class Engine
    {
        private PrimitiveCalculator calculator;

        public Engine()
        {
            this.calculator = new PrimitiveCalculator();
        }

        public void Run()
        {
            string input;

            while ((input = Console.ReadLine()) != "End")
            {
                var inputArgs = input
                    .Split();

                if (inputArgs[0] == "mode")
                {
                    var @operator = char.Parse(inputArgs[1]);
                    this.calculator.ChangeStrategy(@operator);
                }
                else
                {
                    try
                    {
                        var leftOp = int.Parse(inputArgs[0]);
                        var rightOp = int.Parse(inputArgs[1]);
                        var result = this.calculator.PerformCalculation(leftOp, rightOp);

                        Console.WriteLine(result);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Wrong format provided: " + e.Message);
                    }
                }
            }
        }
    }
}
