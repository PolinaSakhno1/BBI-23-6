
internal class Program
{
    private static void Main(string[] args)
    {
        {

            //1задача
            {
                int sum = 0;
                for (int i = 2; i < 38; i += 3)
                {
                    sum = sum + i;
                }
                Console.WriteLine(sum);

                //2
                double sum2 = 0;
                for (double i = 1; i <= 10; i += 1)
                    sum2 = sum2 + 1 / i;
                Console.WriteLine(sum2);

                //3
                double A = 0;
                for (double i = 2; i <= 112; i += 2)
                {
                    A += i / (i + 1);
                }
                Console.WriteLine(A);
                //4
                double sum4 = 0;
                int x = 10;
                for (int i = 0; i <= 8; i += 1)
                {
                    sum4 += Math.Cos((i + 1) * x) / Math.Pow(x, 0);
                }
                Console.WriteLine(sum4);
                //5
                int p = 1;
                int sum5 = 0;
                for (int h = 0; h <= 9; h++)
                {
                    int ph = p + h;
                    sum5 = (int)(sum5 + Math.Pow(ph, 2));
                }
                Console.WriteLine(sum5);
                //6
                double number = 0;
                for (double i = -4; i <= 4; i += 0.5)
                {
                    number = Math.Pow(0.5 * i, 2) - 7 * i;
                    Console.WriteLine($"{number} {i}");
                }
                //7.1
                int proizv = 1;
                for (int i = 1; i <= 6; i++)
                {
                    proizv = proizv * i;
                }
                Console.WriteLine(proizv);
                //7.2
                double r = 10;
                double sum7 = 10;
                int kolvo = 1;
                for (kolvo = 1; sum7 < 100;)
                {
                    r = r + r * 0.1;
                    sum7 += r;
                    kolvo += 1;
                }
                Console.WriteLine(kolvo);
                //7.3
                double r73 = 10;
                double sum73 = 10;
                int kolvo73 = 1;
                for (kolvo73 = 1; sum < 100;)
                {
                    r73 = r73 + r73 * 0.1;
                    sum73 += r73;
                    kolvo73 += 1;
                }
                Console.WriteLine(kolvo73);
                //8
                int A8 = 1;
                for (int b = 2; b <= 6; b++)
                {
                    A8 = A8 * b;
                }
                Console.WriteLine(A);
                //9
                int Factorial(int n)
                {
                    if (n == 1) return 1;

                    return n * Factorial(n - 1);
                }
                int sum9 = 0;
                int number9 = 0;
                for (int i = 1; i <= 6; i++)
                {
                    number9 = (int)(Math.Pow(-1, i) * Math.Pow(5, i) / Factorial(i));
                    sum9 += number9;
                }
                Console.WriteLine(number9);
                //10
                int number10 = 1;
                for (int i = 1; i <= 7; i++)
                {
                    number10 *= 3;
                }
                Console.WriteLine(number10);
                //11.1
                for (int A11 = 1; A11 < 7; A11++)
                {
                    Console.Write(A11);
                }
                Console.WriteLine(" ");

                //11.2
                for (int j = 0; j < 6; j++)
                {
                    Console.Write("5");
                }
                Console.WriteLine(" ");
                //12
                double sum12 = 0;
                int x12 = 2;
                for (int i = 0; i <= 10; i++)
                {
                    sum12 += 1 / Math.Pow(x12, i);
                }
                Console.WriteLine(sum12);
                //13
                Console.WriteLine("x     y");
                double y13 = 0;
                for (double x13 = -1.5; x13 < 1.6; x13 += 0.1)
                {
                    if (x13 <= -1) y13 = 1;
                    else if (x13 > -1 && x13 <= 1)
                    {
                        if (x13 == 0) y13 = 0;
                        else y13 = -x13;
                    }
                    else if (x13 > 1) y13 = -1;

                    Console.WriteLine($"{Math.Round(x13, 2)}    {Math.Round(y13, 2)}");

                }
                //14
                int n = 8;

                int first = 1;
                int second = 1;

                Console.Write(first + " " + second + " ");

                for (int i = 3; i <= n; i++)
                {
                    int next = first + second;
                    Console.Write(next + " ");

                    first = second;
                    second = next;
                }
                Console.WriteLine(" ");
                //15


                int n15 = 5;

                int numerator1 = 1;
                int denominator1 = 1;

                int numerator2 = 2;
                int denominator2 = 1;

                int numerator = 0;
                int denominator = 0;

                for (int i = 3; i <= n15; i++)
                {
                    numerator = numerator1 + numerator2;
                    denominator = denominator1 + denominator2;


                    numerator1 = numerator2;
                    denominator1 = denominator2;
                    numerator2 = numerator;
                    denominator2 = denominator;
                }

                Console.WriteLine("5th: " + (double)numerator / denominator);


            }
        }
    }
}