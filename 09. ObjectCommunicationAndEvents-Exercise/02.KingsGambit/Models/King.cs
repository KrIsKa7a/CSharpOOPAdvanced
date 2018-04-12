using _02.KingsGambit.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _02.KingsGambit.Models
{
    public delegate void KingRespondEventHandler(object sender, RespondEventArgs args);

    public class King : Figure
    {
        private event KingRespondEventHandler KingRespond;

        private List<ISlave> slaves;

        public King(string name) 
            : base(name)
        {
            this.slaves = new List<ISlave>();
            this.KingRespond += KingRespondHandler;
        }

        public void AddSlave(ISlave slave)
        {
            this.slaves.Add(slave);
        }

        public void KillSlave(string name)
        {
            var wantedSlave = this.slaves
                .FirstOrDefault(s => s.Name == name);

            if (wantedSlave != null)
            {
                this.slaves.Remove(wantedSlave);
            }
        }

        public void Respond()
        {
            this.OnRespond();
        }

        private void OnRespond()
        {
            KingRespond(this, new RespondEventArgs(this.Name));

            var royalGuars = this.slaves
                .Where(s => s.GetType() == typeof(RoyalGuard))
                .ToList();
            var footmans = this.slaves
                .Where(s => s.GetType() == typeof(Footman))
                .ToList();

            royalGuars
                .ForEach(rg => rg.Respond());
            footmans
                .ForEach(f => f.Respond());
        }

        private void KingRespondHandler(object sender, RespondEventArgs args)
        {
            Console.WriteLine($"King {args.Name} is under attack!");
        }
    }
}
