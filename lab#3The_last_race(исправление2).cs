//1.15
using System;
class Program
{
    static void Main(string[] args)
    {

        double[] x = new double[10];
        double[] y = new double[10];
        string k;
        Console.WriteLine("Введите массив x");
        for (int i = 0; i < 10; i++)
        {
            k = Console.ReadLine();
        }
        for (int i = 0; i < 10; i++)
        {
            y[i] = 0.5 * Math.Log(x[i]);
        }
        Console.WriteLine("№1_15: ");
        for (int i = 0; i < 10; i++)
        {
            Console.WriteLine($"{x[i]} {y[i]}");
        }
    }
}
//2.6
using System;

class Program
{
    static void Main()
    {
        int[] array26 = { 9 }; 
        int P = 10;
        int sum = 0;
        for (int i = 0; i < 9; i++)
        {
            sum += array26[i];
        }
        double x = (double)sum / 9;
        int index26 = 0;
        int num26 = Math.Abs(array26[0] - (int)x);
        for (int i = 1; i < 9; i++)
        {
            int d = Math.Abs(array26[i] - (int)x);
            if (d < num26)
            {
                num26 = d;
                index26 = i;
            }
        }
        int[] n = new int[9 + 1];
        Array.Copy(array26, 0, n, 0, index26 + 1);
        n[index26 + 1] = P;
        Array.Copy(array26, index26 + 1, n, index26 + 2, 8 - index26 - 1);
        for (int i = 0; i < n.Length; i++)
        {
            Console.Write(n[i] + " ");
        }
    }
}
//277
double[] a = new double[7];
            //Console.WriteLine("ведите количество элементов массива: ");
            //int n = int.Parse(Console.ReadLine());
            //Console.WriteLine("введите массив: ");
            //int[] a = new int[n];
            //string s;
            //for (int i = 0; i < n; i++)
            //{
            //    s = Console.ReadLine();
            //    a[i] = int.Parse(s);
            //}
            //int amax = a[0];
            //int imax = 0;
            //for (int i = 0; i < n; i++)
            //{
            //    if (a[i] > amax)
            //    {
            //        amax = a[i];
            //        imax = i;
            //    }
            //}

            //if (imax < n - 1)
            //{
            //    a[imax + 1] *= 2;
            //    Console.WriteLine("элемент, увеличенный в 2 раза: ");
            //    Console.WriteLine(a[imax + 1]);
            //}
            //else
            //{
            //    Console.WriteLine("максимальный элемент находится в последней позиции массива");
            //}
//2.7
using System;
class Program
{
    static void Main(string[] args)
    {
        int[] array2_7 = new int[5];
        int max2_7 = -100000;
        int ni2_7 = 0;
        Console.WriteLine("Введите массив: ");
        for (int i = 0; i < array2_7.Length; i++)
        {
            array2_7[i] = int.Parse(Console.ReadLine());
            if (array2_7[i] > max2_7)
            {
                max2_7 = array2_7[i];
                ni2_7 = i;
            }
        }
        Console.WriteLine($"№2_7: {array2_7[ni2_7 + 1] * 2}");
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
        string k;
        Console.WriteLine("введите массив a");
        for (int i = 0; i < n; i++)
        {
            k = Console.ReadLine();
            array28[i] = double.Parse(k);
        }
        double amax = array28[0];
        int imax = 0;
        for (int i = 0; i < n; i++)
        {
            if (array28[i] > amax)
            {
                amax = array28[i];
                imax = i;
            }
        }
        double amin = array28[imax+1];
        int imin = imax+1;
        Console.WriteLine("максимальный элемент массива");
        Console.WriteLine(amax);
        for (int i = imax+1 ; i < n ; i++)
        {
            if (array28[i]<amin)
            {
                amin = array28[i];
                imin = i;
            }
        }
        Console.WriteLine("минимальный элемент массива");
        Console.WriteLine(amin);
        double v = amin;
        array28[imin] = amax;
        array28[imax] = v;
        Console.WriteLine("полученный массив");
        for (int i = 0; i < n; i++)
        {
            Console.Write($"{array28[i]} ");
        }

    }
}
//2.14
using System;
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("введите количество элементов массива: ");
        int n = int.Parse(Console.ReadLine());
        Console.WriteLine("введите элемены массива: ");
        int[] array214 = new int[n];
        for (int i = 0; i < n; i++)
        {
            string s = Console.ReadLine();
            array214[i] = int.Parse(s);
        }
        int amax = array214[0];
        int imax = 0;
        for (int i = 0; i < n; i++)
        {
            if (array214[i] > amax)
            {
                amax = array214[i];
                imax = i;
            }
        }
        int k = -1;
        for (int i = 0; i < n; i++)
        {
            if (array214[i] < 0)
            {
                k = i;
                break;
            }
        }
        if (imax >= 0 && k >= 0)
        {
            int t = array214[imax];
            array214[imax] = array214[k];
            array214[k] = t;
            Console.WriteLine("полученный массив:");
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine(array214[i]);
            }
        }
        else
        {
            Console.WriteLine("нет максимальных или отрицательных элементов.");
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
        double amax = array219[0];
        int imax = 0;
        for (int i = 0; i < n; i++)
        {
            if (array219[i] > amax)
            {
                amax = array219[i];
                imax = i;
            }
            sum=sum+ array219[i];
        }
        Console.WriteLine("сумма");
        Console.WriteLine(sum);
        Console.WriteLine("максимальный элемент");
        Console.WriteLine(amax);
        for (int i = 0; i < n; i++)
        {
            if (amax>sum)
            {
                array219[imax] = 0;
            }
            else
            {
                array219[imax] = amax * amax;
            }
        }
        Console.WriteLine("");
        for (int i=0; i<n; i++)
        {
            Console.WriteLine(array219[i]);
        }
    }
}

//3.1

using System;
class Program
{
    static void Main()
    {
        int[] array31 = { 1, 3, 2, 5, 4, 3, 6, 3 };
        int maxx31 = array31[0];
        int maxCou = 1;      
        for (int i = 1; i < array31.Length; i++)
        {
            if (array31[i] > maxx31)
            {
                maxx31 = array31[i];
                maxCou = 1;
            }
            else if (array31[i] == maxx31)
            {
                maxCou++;
            }
        }
        int[] indexes = new int[maxCou];
        int index = 0;
        for (int i = 0; i < array31.Length; i++)
        {
            if (array31[i] == maxx31)
            {
                indexes[index] = i;
                index++;
            }
        }
        Console.WriteLine("индексы максимальных элементов: ");
        for (int i = 0; i < indexes.Length; i++)
        {
            Console.Write(indexes[i] + " ");
        }
        Console.ReadLine();
    }
}
