
//3.10
using System;

class Program
{

        static void Main(string[] args)
        {
            Console.Write("n");
            int m = int.Parse(Console.ReadLine());
            Console.Write("m");
            int n = int.Parse(Console.ReadLine());
            int[,] array = new int[m, n];
            Random random = new Random();
            Console.WriteLine("Mатрица до преобразований: ");
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    array[i, j] = random.Next(100);
                    Console.Write(array[i, j] + "  ");
                }
                Console.WriteLine();
            }

            int t;
            for (int k = 0; k < m; k++)
            {
                for (int i = 0; i < n; i += 2)
                {
                    for (int j = i + 2; j < n; j += 2)
                    {
                        if (array[k, i] < array[k, j])
                        {
                            t = array[k, i];
                            array[k, i] = array[k, j];
                            array[k, j] = t;
                        }
                    }
                }
                for (int i = 1; i < n; i += 2)
                {
                    for (int j = i + 2; j < n; j += 2)
                    {
                        if (array[k, i] > array[k, j])
                        {
                            t = array[k, i];
                            array[k, i] = array[k, j];
                            array[k, j] = t;
                        }
                    }
                }
            }
            Console.WriteLine();

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(array[i, j]);
                }
                Console.WriteLine();
            }
        }
    
}
