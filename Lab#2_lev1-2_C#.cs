using System;

class Program
{
    static void Main(string[] args)
    {

        //1.1
        string inside = "точка внутри круга";
        string outside = "точка вне круга";
        double x, y, r;
        Console.WriteLine("Введите X");
        x= double.Parse(Console.ReadLine());
        Console.WriteLine("Введите y");
        y = double.Parse(Console.ReadLine());
        int r =2
        if (x * x + y * y - r * r <=0.001)
            Console.WriteLine(inside);
        else
            Console.WriteLine(outside);
        //1.4
        Console.WriteLine("Введите a:");
        int a = int.Parse(Console.ReadLine());

        Console.WriteLine("Введите b:");
        int b = int.Parse(Console.ReadLine());

        Console.WriteLine("Введите c:");
        int c = int.Parse(Console.ReadLine());

        int minAB = Math.Min(a, b);
        int z = Math.Max(minAB, c);

        Console.WriteLine("Результат: z = " + z);


        //1.7

        Console.WriteLine("a:");
        int a = int.Parse(Console.ReadLine());
        Console.WriteLine("b:");
        int b = int.Parse(Console.ReadLine());
        Console.WriteLine("c:");
        int c = int.Parse(Console.ReadLine());
        int min = Math.Min(a, b);
        int z = Math.Max(min, c);
        {
            Console.WriteLine($"z:{z}");
        }



        //2.1
        double sr, r, s = 0;
        int n = 0;
        do
        {
            Console.WriteLine($"Введите рост ученика или 0"); ;
            r = double.Parse(Console.ReadLine());
            if (r == 0) break;
            s = s + r; n = n + 1;
        } 
        while (r > 0);
        sr = s / n;
        {
            Console.WriteLine(sr);
        }

       

        //2.4
      

        double x, y, r1, r2;
        int i, n, k;
        Console.WriteLine("Введите количество точек");
        n = int.Parse(Console.ReadLine());
        Console.WriteLine("Введите радиус1");
        r1 = double.Parse(Console.ReadLine());
        Console.WriteLine("Введите радиус2");
        r2 = double.Parse(Console.ReadLine());
        k = 0；
        for (i = 1; i <= n; i++)
        {
            Console.WriteLine("Введите ×");
            x = double.Parse(Console.ReadLine());
            Console.WriteLine("Введите у");
            y = double.Parse(Console.ReadLine());

    
            double g = Math.Sqrt(x * x + y * y);

            if (g <= r1 && g >= r2)
            {
                K++;
            }
        }

        {
            Console.WriteLine($"{K}"); 
        }
        //2.7
        Console.Write("Введите количество точек: ");
        int n = Convert.ToInt32(Console.ReadLine());
        int u1 = 0;
        int u2 = 0;
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($" {i + 1}: ");
            Console.Write($"x: ");
            double x = Convert.ToDouble(Console.ReadLine());
            Console.Write($"y: ");
            double y = Convert.ToDouble(Console.ReadLine());
            if (x > 0 && y > 0)
            {
                Console.WriteLine($"в 1 кв ");
                u1++;
            }
            else if (x < 0 && y < 0)
            {
                Console.WriteLine($"в 3 кв");
                u2++;
            }
        }

        Console.WriteLine($"кол 1: {u1}");
        Console.WriteLine($"кол 2: {u2}");
    }
}

