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
            if (Math.Abs(sr - array26[i]) < max)
            {
                max = Math.Abs(sr - array26[i]);
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
