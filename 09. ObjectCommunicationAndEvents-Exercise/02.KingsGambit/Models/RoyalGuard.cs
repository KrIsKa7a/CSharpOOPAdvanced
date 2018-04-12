using _02.KingsGambit.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace _02.KingsGambit.Models
{
    public delegate void RoyalGuardEventHandler(object sender, RespondEventArgs args);

    public class RoyalGuard : Figure, ISlave
    {
        private event RoyalGuardEventHandler RoyalGuardRespond; 

        public RoyalGuard(string name) 
            : base(name)
        {
            this.RoyalGuardRespond += RoyalGuardRespondHandler;
        }

        public void Respond()
        {
            this.OnRespond();
        }

        private void OnRespond()
        {
            this.RoyalGuardRespond(this, new RespondEventArgs(this.Name));
        }

        private void RoyalGuardRespondHandler(object sender, RespondEventArgs args)
        {
            Console.WriteLine($"Royal Guard {args.Name} is defending!");
        }
    }
}
