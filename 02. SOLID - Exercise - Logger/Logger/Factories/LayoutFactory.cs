using Logger.Models.Interfaces;
using Logger.Models.Layouts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logger.Factories
{
    public class LayoutFactory
    {
        public ILayout GetLayout(string type)
        {
            ILayout layout;

            switch (type)
            {
                case "SimpleLayout":
                    layout = new SimpleLayout();
                    break;
                case "XmlLayout":
                    layout = new XMLLayout();
                    break;
                default:
                    throw new ArgumentException("Invalid Layout Type!");
            }

            return layout;
        }
    }
}
