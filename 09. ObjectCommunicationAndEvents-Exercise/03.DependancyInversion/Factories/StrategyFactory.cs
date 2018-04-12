using _03.DependancyInversion.Contracts;
using _03.DependancyInversion.Models.Strategies;
using System;
using System.Collections.Generic;
using System.Text;

namespace _03.DependancyInversion.Factories
{
    public class StrategyFactory
    {
        public IStrategy CreateStrategy(char @operator)
        {
            IStrategy strategy = null;

            switch (@operator)
            {
                case '+':
                    strategy = new AdditionStrategy();
                    break;
                case '-':
                    strategy = new SubtractionStrategy();
                    break;
                case '*':
                    strategy = new MultiplyStrategy();
                    break;
                case '/':
                    strategy = new DevideStrategy();
                    break;
            }

            return strategy;
        }
    }
}
