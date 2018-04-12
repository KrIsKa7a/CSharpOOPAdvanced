using System;
using System.Collections.Generic;
using System.Text;

namespace _02.KingsGambit.Models
{
    public abstract class Figure
    {
        public Figure(string name)
        {
            this.Name = name;
        }

        public string Name { get; }
    }
}
