using System;
using System.Collections.Generic;
using System.Threading;

class ExerciseMethods
{
    static void Main()
    {
        int number = int.Parse(Console.ReadLine());
        ulong[] arr = new ulong[number];
        arr = Sequence(number, arr);
        Console.WriteLine(string.Join(" ", arr));

    }
    static ulong[] Sequence(int number, ulong[] array)
    {
        ulong[] newArray = new ulong[array.Length];

        switch (number)
        {
            case 1:
                newArray[0] = 1;
                break;
            case 2:
                newArray[0] = 1;
                newArray[1] = 1;
                break;
            case 3:
                newArray[0] = 1;
                newArray[1] = 1;
                newArray[2] = 2;
                break;
            default:
                newArray[0] = 1;
                newArray[1] = 1;
                newArray[2] = 2;
                for (int i = 3; i < newArray.Length; i++)
                {
                    newArray[i] = newArray[i - 3] + newArray[i - 2] + newArray[i - 1];
                }
                break;
        }

        return newArray;
    }




}
