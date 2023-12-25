using System;

class Program
{

    static void Main(string[] args)
    {

        Console.Write("n = ");
        int n = int.Parse(Console.ReadLine());
        Console.Write("m = ");
        int m = int.Parse(Console.ReadLine());
        int[,] a = new int[n, m];
        Random random = new Random();
        Console.WriteLine("Исходная матрица: ");
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                a[i, j] = random.Next(-10, 10);
                Console.Write(a[i, j] + " ");
            }
            Console.WriteLine();
        }
        static int[] Insert(int[] a)
        {
            int index; int num;
            for (int i = 0; i < a.Length; i++)
            {
                index = i; 
                num = a[i];
                while (index > 0 && num < a[index - 1])
                {
                    a[index] = a[index - 1];
                    index--;
                }
                a[index] = num;
            }
            return a;
        }
        static int[] Insert_ub(int[] a)
        {
            int index; 
            int num;
            for (int i = 0; i < a.Length; i++)
            {
                index = i;
                num = a[i];
                while (index > 0 && num > a[index - 1])
                {
                    a[index] = a[index - 1];
                    index--;
                }
                a[index] = num;
            }
            return a;
        }
        int m_nch = m / 2;
        if (m % 2 != 0) 
        {
            m_nch = (m / 2) + 1;
        }
        int[] ch = new int[m_nch];
        int[] nch = new int[m / 2];
        for (int i = 0; i < n; i++)
        {
            int ch_k = 0;
            int nch_k = 0;
            for (int j = 0; j < m; j++)
            {
                if (j % 2 == 0)
                {
                    ch[ch_k] = a[i, j]; 
                    ch_k++;
                }
                else
                {
                    nch[nch_k] = a[i, j];
                    nch_k++;
                }
            }
            Insert_ub(ch);
            Insert(nch);
            ch_k = 0;
            nch_k = 0;
            for (int j = 0; j < m; j += 2)
            {
                a[i, j] = ch[ch_k]; ch_k++;
            }
            for (int j = 1; j < m; j += 2)
            {
                a[i, j] = nch[nch_k];
                nch_k++;
            }
        }
        Console.WriteLine("Result: ");
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                Console.Write(a[i, j] + " ");
            }
            Console.WriteLine();
        }
    }
}
