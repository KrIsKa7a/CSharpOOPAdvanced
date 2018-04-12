using _03.DependancyInversion.Contracts;

namespace _03.DependancyInversion.Models.Strategies
{
	public class AdditionStrategy : IStrategy
    {
        public int Calculate(int firstOperand, int secondOperand)
        {
            return firstOperand + secondOperand;
        }
    }
}
