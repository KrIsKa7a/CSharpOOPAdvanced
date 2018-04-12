using _03.DependancyInversion.Contracts;
using _03.DependancyInversion.Factories;
using _03.DependancyInversion.Models.Strategies;

namespace _03.DependancyInversion.Models
{
    public class PrimitiveCalculator
    {
        private IStrategy strategy;
        private StrategyFactory strategyFactory;

        public PrimitiveCalculator()
        {
            this.strategyFactory = new StrategyFactory();
            this.strategy = new AdditionStrategy();
        }

        public void ChangeStrategy(char @operator)
        {
            this.strategy = this.strategyFactory.CreateStrategy(@operator);
        }

        public int PerformCalculation(int firstOperand, int secondOperand)
        {
            return this.strategy.Calculate(firstOperand, secondOperand);
        }
    }
}
