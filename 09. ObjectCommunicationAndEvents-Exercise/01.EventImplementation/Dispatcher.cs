using System;
using System.Collections.Generic;
using System.Text;

namespace _01.EventImplementation
{
    public delegate void NameChangeEventHandler(object sender, NameChangeEventArgs args);

    public class Dispatcher
    {
        public event NameChangeEventHandler NameChange;

        private string name;

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                this.name = value;
                this.OnNameChange(new NameChangeEventArgs(value));
            }
        }

        public void ChangeName(string name)
        {
            this.Name = name;
        }

        private void OnNameChange(NameChangeEventArgs args)
        {
            NameChange(this, args);
        }
    }
}
