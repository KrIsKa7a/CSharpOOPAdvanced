using System;
using System.Collections.Generic;
using System.Text;

namespace _01.Database
{
    public class Database
    {
        private const int MAX_ARRAY_SIZE = 16;

        private int[] values;
        private int currentIndex;

        private Database()
        {
            this.values = new int[MAX_ARRAY_SIZE];
            this.currentIndex = 0;
        }

        public Database(params int[] initialValues)
            : this()
        {
            SetValues(initialValues);
        }

        public void Add(int element)
        {
            if (this.currentIndex >= MAX_ARRAY_SIZE)
            {
                throw new InvalidOperationException("The array is full!");
            }

            this.values[this.currentIndex] = element;
            this.currentIndex++;
        }

        public int Remove()
        {
            if (this.currentIndex == 0)
            {
                throw new InvalidOperationException("The array is empty!");
            }

            this.currentIndex--;

            var elementToRemove = this.values[this.currentIndex];

            this.values[this.currentIndex] = 0;

            return elementToRemove;
        }

        public int[] Fetch()
        {
            var newArray = new int[this.currentIndex];

            Array.Copy(this.values, newArray, this.currentIndex);

            return newArray;
        }

        private void SetValues(int[] initialValues)
        {
            if (initialValues.Length > MAX_ARRAY_SIZE)
            {
                throw new InvalidOperationException("Count of the initial values are bigger than max count provided!");
            }

            for (int i = 0; i < initialValues.Length; i++)
            {
                this.values[this.currentIndex] = initialValues[i];
                this.currentIndex++;
            }
        }
    }
}
