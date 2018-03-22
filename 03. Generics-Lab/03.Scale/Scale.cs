using System;
using System.Collections.Generic;
using System.Text;

public class Scale<T> where T : IComparable<T>
{
    private T leftElement;
    private T rightElement;

    public Scale(T leftElement, T rightElement)
    {
        this.leftElement = leftElement;
        this.rightElement = rightElement;
    }

    public T GetHeavier()
    {
        var result = this.leftElement.CompareTo(rightElement);

        if (result > 0)
        {
            return this.leftElement;
        }
        else if(result < 0)
        {
            return this.rightElement;
        }
        else
        {
            return default(T);
        }
    }
}
