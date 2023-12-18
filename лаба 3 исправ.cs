//1.14
using System;
class Programm
{
    static void Main(string[] args)
    {
        double[] a = new double[11];
        string k;
        double sum = 0;
        Console.WriteLine("Введите массив a");
        for (int i = 0; i < 11; i++)
        {
            k = Console.ReadLine();
            a[i] = double.Parse(k);
        }
        for (int i = 0; i < 11; i++)
        {
            if (a[i]>0)
            {
              sum = sum + a[i] * a[i];
            }
            else
            {
                break;
            }
        }
        Console.WriteLine(sum);
    }
}
//2.3
using System;
class Program
{
    static void Main(string[] args)
    {
        string s;
        Console.WriteLine("Введите n");
        int n = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Введите массив a");
        double[] a = new double[n];
        for (int i = 0; i < n; i++)
        {
            s = Console.ReadLine();
            a[i] = double.Parse(s);
        }
        double amin = a[0];
        int imin = 0;
        for (int i = 0; i < n; i++)
        {
            if (a[i] < amin)
            {
                amin = a[i];
                imin = i;
            }
        }
        Console.WriteLine("Минимальный элемент и его индекс");
        Console.WriteLine($"{amin}, {imin}");
        for (int i = 0; i < n; i++)
        {
            if (i < imin)
            {
                a[i] = a[i] * 2;
            }
        }
        Console.WriteLine("Изменённый массив");
        for (int i = 0; i < n; i++)
        {
            Console.Write(a[i]);
        }
    }
}
//2.4
using System;

class Program
{
    static void Main(string[] args)
    {
        string s;
        Console.WriteLine("Введите n");
        int n = Convert.ToInt32(Console.ReadLine());
        double[] a = new double[n];
        Console.WriteLine("Введите массив a");
        for (int i = 0; i < n; i++)
        {
            s = Console.ReadLine();
            a[i] = double.Parse(s);
        }
        double sum = 0;
        int k = 0;
        for (int i = 0; i < n; i++)
        {
            sum = sum + a[i];
            k += 1;
        }
        double sr = sum / k;
        Console.WriteLine("Среднее арифметическое");
        Console.WriteLine(sr);
        double amax = a[0];
        int imax = 0;
        for (int i = 0; i < n; i++)
        {
            if (a[i] > amax)
            {
                amax = a[i];
                imax = i;
            }

        }
        Console.WriteLine("Максимальный элемент массива и его индекс");
        Console.WriteLine($"{amax}, {imax}");
        for (int i = 0; i < n; i++)
        {
            if (i > imax)
            {
                a[i] = sr;
            }
        }
        Console.WriteLine("Изменённый массив");
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine(a[i]);
        }
    }
}
//2.8
using System;
class Program
{
    static void Main(string[] args)
    {
        string s;
        int n = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Введите n");
        double[] a = new double[n];
        Console.WriteLine("Введите массив a");
        for (int i = 0; i < n; i++)
        {
            s = Console.ReadLine();
            a[i] = double.Parse(s);
        }
        double amax = a[0];
        int imax = 0;
        for (int i = 0; i < n; i++)
        {
            if (a[i] > amax)
            {
                amax = a[i];
                imax = i;
            }
        }
        Console.WriteLine("Максимальный элемент и его индекс");
        Console.WriteLine($"{amax}, {imax}");
        double amin = a[0];
        int imin = 0;
        for (int i = 0; i < n; i++)
        {
            if (a[i] < amin && i > imax)
            {
                amin = a[i];
                imin = i;
            }
        }
        Console.WriteLine("Минимальный элемент после максимального и его индекс");
        Console.WriteLine($"{amin}, {imin}");
        int p;
        for (int i = 0; i < n; i++)
        {
            p = amax;
            amax = amin;
            amin = p;
        }
        Console.WriteLine("Изменённый массив");
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine(a[i]);
        }
    }
}
//2.15
using System;
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Введите n: ");
        int n = int.Parse(Console.ReadLine());
        Console.WriteLine("Введите массив: ");
        int[] a = new int[n];
        for (int i = 0; i < n; i++)
        {
            string s = Console.ReadLine();
            a[i] = int.Parse(s);
        }
        Console.WriteLine("Введите m: ");
        int m = int.Parse(Console.ReadLine());
        Console.WriteLine("Введите массив: ");
        int[] b = new int[m];
        for (int i = 0; i < m; i++)
        {
            string s1 = Console.ReadLine();
            b[i] = int.Parse(s1);
        }
        int[] c = new int[n + m];
        Console.WriteLine("Введите k: ");
        int k = int.Parse(Console.ReadLine());
        if (k >= a.Length)
        {
            Console.WriteLine("Не существует такого элемента в массиве а");
        }
        else
        {
            for (int i = 0; i <= k; i++)
            {
                c[i] = a[i];
            }
            for (int i = 0; i < m; i++)
            {
                c[k + i + 1] = b[i];
            }
            for (int i = k + m + 1; i < m + n; i++)
            {
                c[i] = a[i - m];
            }
            Console.WriteLine("Получившийся массив: ");
            for (int i = 0; i < m + n; i++)
            {
                Console.WriteLine(c[i]);
            }

        }
    }
}
//2.19
using System;
class Program
{
    static void Main(string[] args)
    {
        string s;
        int n = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Введите n");
        double[] a = new double[n];
        Console.WriteLine("Введите массив a");
        for (int i = 0; i < n; i++)
        {
            s = Console.ReadLine();
            a[i] = double.Parse(s);
        }
        double amax = a[0];
        for (int i = 0; i < n; i++)
        {
            if (a[i] > amax)
            {
                amax = a[i];
            }
        }
        Console.WriteLine("Максимальное значение");
        Console.WriteLine(amax);
        double sum = 0;
        for (int i = 0; i < n; i++)
        {
            sum += a[i];
        }
        Console.WriteLine("Сумма элементов массива");
        Console.WriteLine(sum);
        for (int i = 0; i < n; i++)
        {
            if (amax > sum)
            {
                amax = 0;
            }
            else
            {
                amax = amax * 2;
            }
        }
        Console.WriteLine("Изменённый массив");
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine(a[i]);
        }
    }
}
//2.20
using System;
class Program
{
    static void Main(string[] args)
    {
        string s;
        int n = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Введите n");
        double[] a = new double[n];
        Console.WriteLine("Введите массив a");
        for (int i = 0; i < n; i++)
        {
            s = Console.ReadLine();
            a[i] = double.Parse(s);
        }
        double otr = a[0];
        int iotr = 0;
        for (int i = 0; i < n; i++)
        {
            if (a[i] < 0)
            {
                otr = a[i];
                iotr = i;
                break;
            }
        }
        Console.WriteLine("Первый отрицательный элемент и его индекс");
        Console.WriteLine($"{otr}, {iotr}");
        double amin = a[0];
        int imin = 0;
        for (int i = 0; i < n; i++)
        {
            if (a[i] < amin)
            {
                amin = a[i];
                imin = i;
            }
        }
        Console.WriteLine("Минимальный элемент и его индекс");
        Console.WriteLine($"{amin}, {imin}");
        double sum = 0;
        for (int i = 0; i < n; i++)
        {
            if (iotr < imin)
            {
                if (i % 2 == 0)
                {
                    sum += a[i];
                }
            }
            else
            {
                if (i % 2 != 0)
                {
                    sum = sum + a[i];
                }
            }
        }
        Console.WriteLine(sum);
    }
}
//3.1
using System;
class Programm
{
    static void Main(string[] args)
    {
        string s;
        Console.WriteLine("Введите кол-во элементов массива A");
        int n = Convert.ToInt32(Console.ReadLine());
        double[] a = new double[n];
        Console.WriteLine("Введите массив A");
        for (int i = 0; i < n; i++)
        {
            s = Console.ReadLine();
            a[i] = double.Parse(s);
        }
        double[] b = new double[n];
        double amax = a[0];
        int m = 0;
        for (int i = 0; i < n; i++)
        {
            if (a[i] > amax)
            {
                amax = a[i];
                m = 0;
                b[m] = a[i];
                m++;
            }
            else if (a[i] == amax)
            {
                b[m] = a[i];
                m++;
            }
        }
        Console.WriteLine("Измененный массив");
        for (int i = 0; i < n; i++)
        {
            Console.Write($"{b[i]} ");
        }
    }
}