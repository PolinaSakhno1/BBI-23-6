
using System;
class HelloWorld
{
    static void Main()
    {
        //3
        double a = 0.1, b = 1, h = 0.1, s, y, ln = 0;
        int f, i;
        for (double x = a; x <= b; x += h)
        {
            i = 1;
            s = 1;
            f = 1;
            do
            {
                f *= i;
                ln = Math.Cos(i * x) / f;
                s += ln;
                i++;
            } while (Math.Abs(ln) >= 0.0001);
            y = Math.Exp(Math.Cos(x)) * Math.Cos(Math.Sin(x));
            Console.WriteLine(x);
            Console.WriteLine(s);
            Console.WriteLine(y);
            Console.WriteLine();
        }
        Console.ReadKey();
    }


}
