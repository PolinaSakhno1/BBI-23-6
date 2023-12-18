using System;
//4 задача
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Матрица a:");
        int[,] attay = new int[5, 5];
        Random random = new Random();
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                attay[i, j] = random.Next(50);
            }
        }
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                Console.Write(attay[i, j] + "\t");
            }
            Console.WriteLine();
        }
        Console.WriteLine("Матрица b:");
        int[,] b = new int[5, 5];
        Random random1 = new Random();
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                b[i, j] = random.Next(100);
            }
        }
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                Console.Write(b[i, j] + "\t");
            }
            Console.WriteLine();
        }
        int[,] c = new int[5, 5];
        for (int i = 0;i < 5; i++)
        {
            for (int j = 0;j < 5; j++)
            {
                c[i,j] = attay[i, j];
            }
        }
        int imaxa = 0, jmaxb = 0;
        Max(attay, b, out c, out imaxa, out jmaxb);
        Console.WriteLine("Получившаяся матрица: ");
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                Console.Write(c[i, j] + "\t");
            }
            Console.WriteLine();
        }
    }
    static void Max(int[,] a, int[,] b, out int[,] c, out int imaxa, out int jmaxb)
    {
        imaxa = 0;
        jmaxb = 0;
        int maxA = a[0, 0];
        for (int i = 0; i < 5; i++)
        {
            if (a[i, i] > maxA)
            {
                maxA = a[i, i];
                imaxa = i;
            }
        }
        int maxB = b[0, 0];
        for (int i = 0; i < 5; i++)
        {
            if (b[i, i] > maxB)
            {
                maxB = b[i, i];
                jmaxb = i;
            }
        }
        c = a;
        for (int i = 0; i < 5; i++)
        {
            int temp = c[imaxa, i];
            c[imaxa, i] = b[i, jmaxb];
            c[i, jmaxb] = temp;
        }
    }
}
using System;
//10 задача
class Program
{
    static void S(out int[,] b, int[,] a, int index)
    {
        b = new int[a.GetLength(0), a.GetLength(1) - 1];
        for (int j = 0; j < index; j++)
        {
            for (int i = 0; i < a.GetLength(0); i++)
            {
                b[i, j] = a[i, j];
            }
        }
        for (int j = index; j < a.GetLength(1) - 1; j++)
        {
            for (int i = 0; i < a.GetLength(0); i++)
            {
                b[i, j] = a[i, j + 1];
            }
        }
    }
    static void Main()
    {
        Console.WriteLine("Введите n: ");
        int n = int.Parse(Console.ReadLine());
        if (n > 0)
        {
            int[,] a = new int[n, n];
            Random random = new Random();
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    a[i, j] = random.Next(100);
                }
            }
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(a[i, j] + "\t");
                }
                Console.WriteLine();
            }
            int amax = a[0, 0]; int jmax = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (a[i, j] > amax)
                    {
                        amax = a[i, j];
                        jmax = j;
                    }
                }
            }
            Console.WriteLine("Максимальный элемент матрицы среди элементов,расположенных ниже главной диагонали (включая диагональ):");
            Console.WriteLine(amax);
            int amin = a[0, 1]; int jmin = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    if (a[i, j] < amin)
                    {
                        jmin = j;
                        amin = a[i, j];
                    }
                }
            }
            Console.WriteLine("минимальный элемент среди матрицы элементов, расположенных выше главной диагонали:");
            Console.WriteLine(amin);
            S(out a, a, jmax);
            if (jmax > jmin) S(out a, a, jmin);
            else if (jmax < jmin) S(out a, a, jmin - 1);
            Console.WriteLine("Получившаяся матрица");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n - 2; j++)
                {
                    Console.Write(a[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }
        else
        {
            Console.WriteLine("В матрице 0 элементов, дальнейшие действия невозможны");
        }
    }
}
using System;
//16 задача
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Введите n: ");
        int n = int.Parse(Console.ReadLine());
        Console.WriteLine("Введите m: ");
        int m = int.Parse(Console.ReadLine());
        if (n > 0 || m > 0)
        {
            Console.WriteLine("Массив а:");
            int[] a = new int[n];
            Random random = new Random();
            for (int i = 0; i < n; i++)
            {
                a[i] = random.Next(-50, 50);
            }
            for (int i = 0; i < n; i++)
            {
                Console.Write(a[i] + "\t");
            }
            Console.WriteLine();
            Console.WriteLine("Массив b:");
            int[] b = new int[m];
            Random random1 = new Random();
            for (int i = 0; i < m; i++)
            {
                b[i] = random1.Next(-50, 30);
            }
            for (int i = 0; i < m; i++)
            {
                Console.Write(b[i] + "\t");
            }
            Console.WriteLine();
            Console.WriteLine("Получившийся массив а:");
            Y(a, n);
            for (int i = 0; i < n; i++)
            {
                Console.Write(a[i] + "\t");
            }
            Console.WriteLine();
            Console.WriteLine("Получившийся массив b:");
            Y(b, m);
            for (int i = 0; i < m; i++)
            {
                Console.Write(b[i] + "\t");
            }
            Console.WriteLine();
        }
        else
        {
            Console.WriteLine("В массивах 0 элементов, дальнейшие действия невозможны");
        }
    }
    static void Y(int[] arr, int length)
    {
        for (int i = 0; i < length - 1; i++)
        {
            if (arr[i] < 0)
            {
                int min = arr[i];
                int minIndex = i;
                for (int j = i + 1; j < length; j++)
                {
                    if (arr[j] < 0 && arr[j] > min)
                    {
                        min = arr[j];
                        minIndex = j;
                    }
                }
                int t = arr[minIndex];
                arr[minIndex] = arr[i];
                arr[i] = t;
            }
        }
    }
}
using System;
//22 
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Введите n: ");
        int n = int.Parse(Console.ReadLine());
        Console.WriteLine("Введите m: ");
        int m = int.Parse(Console.ReadLine());
        if (n > 0 && m > 0)
        {
            int[,] a = new int[n, m];
            Random random = new Random();
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    a[i, j] = random.Next(-100, 50);
                }
            }
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write(a[i, j] + "\t");
                }
                Console.WriteLine();
            }
            int[] b = new int[n];
            int[] c = new int[m];
            b = H(a);
            c = L(a);
            Console.WriteLine("Получившийся массив b:");
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine(b[i] + "\t");
            }
            Console.WriteLine("Получившийся массив c:");
            for (int i = 0; i < m; i++)
            {
                Console.WriteLine(c[i] + "\t");
            }
        }
        else
        {
            Console.WriteLine("В массивах 0 элементов, дальнейшие действия невозможны");
        }
    }
    static int[] H(int[,] k)
    {
        int Count = 0;
        int[] f = new int[k.GetLength(0)];
        for (int i = 0; i < k.GetLength(0); i++)
        {
            for (int j = 0; j < k.GetLength(1); j++)
            {
                if (k[i, j] < 0)
                {
                    Count++;
                }
            }
            f[i] = Count;
            Count = 0;
        }
        return f;
    }
    static int[] L(int[,] k)
    {
        int[] f = new int[k.GetLength(1)];
        int max = 0;
        for (int j = 0; j < k.GetLength(1); j++)
        {
            for (int i = 0; i < k.GetLength(0); i++)
            {
                if (k[i, j] < 0 && max == 0)
                {
                    max = k[i, j];
                }
                if (k[i, j] < 0 && k[i, j] > max)
                {
                    max = k[i, j];
                }
            }
            f[j] = max;
            max = 0;
        }
        return f;
    }
}
