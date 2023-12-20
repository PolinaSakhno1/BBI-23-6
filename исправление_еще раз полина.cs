//1.15
using System;
class Program
{
    static void Main(string[] args)
    {

        double[] x = new double[10];
        double[] y1_15 = new double[10];
        Console.WriteLine("Введите массив: ");
        for (int i = 0; i < x.Length; i++)
        {
            x[i] = double.Parse(Console.ReadLine());
        }
        int j = 0;
        for (int i = 0; i < y1_15.Length; i++)
        {
            y1_15[i] = 0.5 * Math.Log(x[j]);
            j++;
        }
        Console.WriteLine("№1_15: ");
        for (int i = 0; i < x.Length; i++)
        {
            Console.WriteLine($"{x[i]}    {y1_15[i]}");
        }
    }
}
//2.6
using System;

class Program
{
    static void Main()
    {
        int k = Int32.Parse(Console.ReadLine());
        double[] array26 = new double[k];
        double P = 10;
        double sum = 0;
        double count = 0;
        int ni = 0;
        for (int i = 0; i < array26.Length; i++)
        {
            array26[i] = double.Parse(Console.ReadLine());
            sum += array26[i];
            count++;
        }
        double sr = sum / count;
        double max = 1000000000;
        for (int i = 0; i < array26.Length; i++)
        {
            if (Math.Abs(P - array26[i]) < max)
            {
                max = Math.Abs(P - array26[i]);
                ni = i;
            }
        }
        double[] array = new double[k + 1];
        int f = 0;
        for (int i = 0; i <= ni; i++)
        {
            array[i] = array26[f];
            f++;
        }
        array[ni + 1] = P;
        int c = ni + 1;
        for (int i = ni + 2; i < array.Length; i++)
        {
            array[i] = array26[c];
            c++;
        }
        for (int i = 0; i < array.Length; i++)
        {
            Console.Write(array[i] + " ");
        }
    }
}


//2.8
using System;

class Programm
{
    static void Main(string[] args)
    {
        Console.WriteLine("введите количество элементов массива");
        int n = Convert.ToInt32(Console.ReadLine());
        double[] array28 = new double[n];
        Console.WriteLine("введите массив a");
        for (int i = 0; i < array28.Length; i++)
        {
            array28[i] = double.Parse(Console.ReadLine());
        }
        double amax = -1000000;
        int imax = 0;
        for (int i = 0; i < array28.Length; i++)
        {
            if (array28[i] > amax)
            {
                amax = array28[i];
                imax = i;
            }
        }
        double amin = 100000000;
        int imin = 0;
        for (int i = imax + 1; i < array28.Length; i++)
        {
            if (array28[i] < amin)
            {
                amin = array28[i];
                imin = i;
            }
        }
        if (imin == 0)
        {
            Console.WriteLine("максимальный последний, за ним нет минимального");
        }
        else
        {
            double t = 0;
            for (int i = 0; i < array28.Length; i++)
            {
                t = amin;
                array28[imin] = amax;
                array28[imax] = t;
            }
            for (int i = 0; i < array28.Length; i++)
            {
                Console.WriteLine($"{array28[i]} ");
            }
        }

    }
}

//2.19

using System;

class Programm
{
    static void Main(string[] args)
    {
        string p;
        Console.WriteLine("введите кол-во элементов массива ");
        int n = Convert.ToInt32(Console.ReadLine());
        double[] array219 = new double[n];
        Console.WriteLine("введите массив A");
        for (int i = 0; i < n; i++)
        {
            p = Console.ReadLine();
            array219[i] = double.Parse(p);
        }
        double sum = 0;
        int m = 0;
        double amax = -1000000;
        int imax = 0;
        for (int i = 0; i < array219.Length; i++)
        {
            if (array219[i] > amax)
            {
                amax = array219[i];
                imax = i;
            }
            sum = sum + array219[i];
        }
        Console.WriteLine("сумма");
        Console.WriteLine(sum);
        Console.WriteLine("максимальный элемент");
        Console.WriteLine(amax);
        if (amax > sum)
        {
            array219[imax] = 0;
        }
        else
        {
            array219[imax] *= 2;
        }
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"{array219[i]} ");
        }
    }
}


