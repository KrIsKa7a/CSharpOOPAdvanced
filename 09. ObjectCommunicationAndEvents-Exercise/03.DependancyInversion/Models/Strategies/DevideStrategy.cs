using _03.DependancyInversion.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace _03.DependancyInversion.Models.Strategies
{
    public class DevideStrategy : IStrategy
    {
        public int Calculate(int firstOperand, int secondOperand)
        {
            return firstOperand / secondOperand;
        }
    }
}
