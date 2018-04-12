using System;
using System.Collections.Generic;
using System.Text;

namespace _03.DependancyInversion.Contracts
{
    public interface IStrategy
    {
        int Calculate(int firstOperand, int secondOperand);
    }
}
