using System;


{
    //2 уровень 1 задача
    double x = 0.5;
    double epsilon = 0.0001;
    double sum = 0;
    double term = 1;
    double n = 1;

    while (Math.Abs(term) >= epsilon)
    {
        sum += term;
        n++;
        term = Math.Cos(n * x) / (n * n);
    }

    Console.WriteLine("Сумма ряда: " + sum);

    //2.2

    int L2 = 30000;
    int n2 = 1;
    int p2 = 1;

    while (p2 <= L2)
    {
        n2++;
        p2 *= n2;
    }
    n--;
    Console.WriteLine("Наибольшее значение n: " + n2);

    //2.3
    int S3 = 0;
    int n3 = 0;
    int m3;
    int a3 = 2;
    int h3 = 3;
    int p3 = 58;
    while (S3 <= p3)
    {

        m3 = a3 + n3 * h3;
        S3 = S3 + m3;
        n3++;

    }
    n3--;
    Console.WriteLine(n3);

    //2.4
   double s4 = 0;
    Console.WriteLine("Введите x: |x| < 1)");
    double x4 = Convert.ToDouble(Console.ReadLine());
    Console.WriteLine();
    double d4 = 1;
    while (d4 >= 0.0001)
    {
        s4 += d4;
        d4 *= x4 * x4;
    }
    Console.WriteLine($"2.4: {s4}");
    Console.WriteLine();

    //2.5
    double res5 = 0;
    int n5 = Convert.ToInt32(Console.ReadLine());
    int m5 = Convert.ToInt32(Console.ReadLine());

    while (n5 >= m5)
    {
        res5 += 1;
        n5 -= m5;
    }
    Console.WriteLine("частное:" + res5);
    if (n5 < m5)
    {
        if (n5 > 0)
        {
            Console.WriteLine("остаток:" + n5);
        }
        if (n5 == 0)
        {
            Console.WriteLine("остаток:" + 0);
        }
    }
    //2.6
    int n6 = 1;
    int time = 0;

    while (n6 != 105)
    {
        time++;


        n6 += n6;


        if (n6 > 105)
        {
            n6 = 105;
        }
    }

    Console.WriteLine("Время: " + time);
    Console.ReadKey();
    //2.7.1
    double r71 = 10;
    double sum71 = 10;
    for (int kolvo71 = 1; kolvo71 < 7; kolvo71++)
    {
        r71 = r71 + r71 * 0.1;
        sum71 += r71;
    }
    Console.WriteLine(sum71);

    // 7.2
    double r72 = 10;
    double sum72 = 10;
    int kolvo72 = 1;
    for (kolvo72 = 1; sum72 < 100;)
    {
        r72 = r72 + r72 * 0.1;
        sum72 += r72;
        kolvo72 += 1;
    }
    Console.WriteLine(kolvo72);

    //7.3
    double r73 = 10;

    int kolvo73 = 1;
    for (kolvo73 = 1; r73 <= 20;)
    {
        r73 = r73 + r73 * 0.1;
        kolvo73 += 1;
    }
    Console.WriteLine(kolvo73);
    //8
    double s = 10000;
    int d = 0;
    double r = 0.08;
    double s1 = s * 2;
    while (s < s1)
    {
        s += s * r;
        d++;
    }
    Console.WriteLine("Сумма удвоится через {d} месяцев.");

}
