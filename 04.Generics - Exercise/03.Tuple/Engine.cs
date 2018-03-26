using System;
using System.Collections.Generic;
using System.Text;

public class Engine
{
    public Engine()
    {

    }

    public void Run()
    {
        var names = Console.ReadLine()
            .Split();

        var name = names[0] + " " + names[1];
        var adress = names[2];
        var town = names[3];

        var tuplePersonInfo = new _03.Tuple.MyOwnTuple.Tuple<string, string, string>(name, adress, town);

        var beerInput = Console.ReadLine()
            .Split();

        var beerName = beerInput[0];
        var count = int.Parse(beerInput[1]);
        var drunkOrNotString = beerInput[2];
        var drunkOrNotBoolean = drunkOrNotString == "drunk" ? true : false;

        var beerTuple = new _03.Tuple.MyOwnTuple.Tuple<string, int, bool>(beerName, count, drunkOrNotBoolean);

        var bankInput = Console.ReadLine()
            .Split();

        var clientName = bankInput[0];
        var balance = double.Parse(bankInput[1]);
        var bankName = bankInput[2];

        var intDoubleTuple = new _03.Tuple.MyOwnTuple.Tuple<string, double, string>(clientName, balance, bankName);


        Console.WriteLine(tuplePersonInfo);
        Console.WriteLine(beerTuple);
        Console.WriteLine(intDoubleTuple);
    }
}
