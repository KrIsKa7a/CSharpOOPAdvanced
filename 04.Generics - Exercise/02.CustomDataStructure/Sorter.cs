using System;
using System.Collections.Generic;
using System.Text;

public class Sorter
{
    public static List<T> Sort<T>(List<T> data) where T : IComparable<T>
    {
        data = BubbleSort(data);

        return data;
    }

    private static List<T> BubbleSort<T>(List<T> list) where T : IComparable<T>
    {
        int n = list.Count;

        for (int i = 0; i < n - 1; i++)
        {
            for (int j = 0; j < n - i - 1; j++)
            {
                if (list[j].CompareTo(list[j + 1]) > 0)
                {
                    // swap temp and arr[i]
                    T temp = list[j];
                    list[j] = list[j + 1];
                    list[j + 1] = temp;
                }
            }
        }

        return list;
    }
}
