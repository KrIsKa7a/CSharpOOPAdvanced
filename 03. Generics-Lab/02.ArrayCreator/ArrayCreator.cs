using System;
using System.Collections.Generic;
using System.Text;

public class ArrayCreator
{
    public static T[] Create<T>(int lenght, T item)
    {
        return new T[lenght]; 
    }
}
