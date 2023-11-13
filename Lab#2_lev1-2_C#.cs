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
        double sr21, r21, s21 = 0;
        int n21 = 0;
        do
        {
            Console.WriteLine($"Введите рост ученика или 0"); ;
            r21 = double.Parse(Console.ReadLine());
            if (r21 == 0) break;
            s21 = s21 + r21; n21 = n21 + 1;
        } 
        while (r21 > 0);
        sr = s21 / n21;
        {
            Console.WriteLine(sr);
        }

       

        //2.4
      

        double x24, y24, 24r1, 24r2;
        int i24, n24, k24;
        Console.WriteLine("Введите количество точек");
        n24 = int.Parse(Console.ReadLine());
        Console.WriteLine("Введите радиус1");
        24r1 = double.Parse(Console.ReadLine());
        Console.WriteLine("Введите радиус2");
        24r2 = double.Parse(Console.ReadLine());
        k24 = 0；
        for (i24 = 1; i24 <= n24; i24++)
        {
            Console.WriteLine("Введите ×");
            x24 = double.Parse(Console.ReadLine());
            Console.WriteLine("Введите у");
            y24 = double.Parse(Console.ReadLine());

    
            double g24 = Math.Sqrt(x24 * x24 + y24 * y24);

            if (g24 <= 24r1 && g24 >= 24r2)
            {
                k24++;
            }
        }

        {
            Console.WriteLine($"{k24}"); 
        }
        //2.7
        Console.Write("Введите количество точек: ");
        int n27 = Convert.ToInt32(Console.ReadLine());
        int 27u1 = 0;
        int 27u2 = 0;
        for (int i27 = 0; i27 < n27; i27++)
        {
            Console.WriteLine($" {i27 + 1}: ");
            Console.Write($"x: ");
            double x27 = Convert.ToDouble(Console.ReadLine());
            Console.Write($"y: ");
            double y27 = Convert.ToDouble(Console.ReadLine());
            if (x27 > 0 && y27 > 0)
            {
                Console.WriteLine($"в 1 кв ");
                27u1++;
            }
            else if (x27 < 0 && y27 < 0)
            {
                Console.WriteLine($"в 3 кв");
                27u2++;
            }
        }

        Console.WriteLine($"кол 1: {27u1}");
        Console.WriteLine($"кол 2: {27u2}");
    }
}

