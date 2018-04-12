using _02.KingsGambit.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace _02.KingsGambit.Models
{
    public delegate void FootmanRespondEventHandler(object sender, RespondEventArgs args);

    public class Footman : Figure, ISlave
    {
        private event FootmanRespondEventHandler FootmanRespond;

        public Footman(string name) 
            : base(name)
        {
            this.FootmanRespond += FootmanRespondHandler;
        }

        public void Respond()
        {
            this.OnRespond();
        }

        private void OnRespond()
        {
            this.FootmanRespond(this, new RespondEventArgs(this.Name));
        }

        private void FootmanRespondHandler(object sender, RespondEventArgs args)
        {
            Console.WriteLine($"Footman {args.Name} is panicking!");
        }
    }
}
