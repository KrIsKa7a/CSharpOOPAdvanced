using System;
using System.Collections.Generic;
using System.Text;

namespace _04.BubbleSort
{
    public static class Bubble
    {
        public static int[] Sort(int[] numbers)
        {
            int temp;

            for (int i = 0; i <= numbers.Length - 2; i++)
            {
                for (int j = 0; j <= numbers.Length - 2; j++)
                {
                    if (numbers[j] > numbers[j + 1])
                    {
                        temp = numbers[j + 1];
                        numbers[j + 1] = numbers[j];
                        numbers[j] = temp;
                    }
                }
            }

            return numbers;
        }
    }
}
