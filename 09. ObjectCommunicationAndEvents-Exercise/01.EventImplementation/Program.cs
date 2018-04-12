using System;

namespace _01.EventImplementation
{
    class Program
    {
        static void Main(string[] args)
        {
            var handler = new Handler();
            var dispatcher = new Dispatcher();

            dispatcher.NameChange += handler.OnDispatcherNameChange;

            string name;

            while ((name = Console.ReadLine()) != "End")
            {
                dispatcher.ChangeName(name);
            }
        }
    }
}
