//2 (2,5)
using System;
using System.Collections.Generic;
using System.Text;

public struct Sportsman
{
    private string name;
    private int[,] golos_jumps;
    public int[,] Golosa { get { return golos_jumps; } }
    public string Name { get { return name; } }
    public Sportsman(string name, int[,] jumps_)
    {
        this.name = name;
        golos_jumps = jumps_;
    }

}

public abstract class JumpWater
{
    protected string name;
    protected string dist;
    protected Sportsman[] sportsmen;
    protected double[] indexx;

    public JumpWater(Sportsman[] sportsmen, double[] indexx)
    {
        name = "Прыжки в воду";
        this.sportsmen = sportsmen;
        this.indexx = indexx;
    }
    protected double RezultForPerson(int[,] list)
    {
        for (int number = 0; number < 4; number++)
        {
            for (int i = 1; i < 7; i++)
            {
                int k = list[number, i];
                int j = i - 1;

                while (j >= 0 && list[number, j] < k)
                {
                    list[number, j + 1] = list[number, j];
                    j--;
                }
                list[number, j + 1] = k;
            }
        }
        int[] res_jumps = new int[4] { 0, 0, 0, 0 };
        for (int i = 0; i < 4; i++)
        {
            for (int j = 1; j < 6; j++)
            {
                res_jumps[i] += list[i, j];
            }
        }
        double s = 0;
        for (int i = 0; i < 4; i++)
        {
            s += res_jumps[i] * indexx[i];
        }
        return s;
    }
    protected Sportsman[] Sort(Sportsman[] list)
    {
        for (int i = 0; i < list.Length; i++)
        {
            for (int j = i; j < list.Length; j++)
                if (RezultForPerson(list[i].Golosa) < RezultForPerson(list[j].Golosa))
                {
                    Sportsman person_now = list[j]; // меняем
                    list[j] = list[i]; // местами
                    list[i] = person_now; // игроков
                }
        }
        return list;
    }

    public void Sorevnovan()
    {
        Sportsman[] list_sort = Sort(sportsmen);
        Print_table(list_sort);
    }

    protected void Print_table(Sportsman[] sort_list)
    {
        Console.WriteLine(name);
        for (int i = 0; i < sort_list.Length; i++)
        {
            Console.Write($"{i + 1} место: ");
            Console.WriteLine($"имя: {sort_list[i].Name} результат: {RezultForPerson(sort_list[i].Golosa)}");
        }
        Console.WriteLine();
    }
}

class Jump3 : JumpWater
{
    public Jump3(Sportsman[] sportsmen, double[] indexx) : base(sportsmen, indexx)
    {
        name = "Прыжки в воду c 3 м";
    }
}

class Jump5 : JumpWater
{
    public Jump5(Sportsman[] sportsmen, double[] indexx) : base(sportsmen, indexx)
    {
        name = "Прыжки в воду c 5 м";
    }
}


public class Program
{
    static double[] FillIndexx()
    {
        double[] indexx = new double[4];
        for (int i = 0; i < 4; i++)
        {
            indexx[i] = double.Parse(Console.ReadLine());
        }
        return indexx;
    }

    static Sportsman FillInfo()
    {
        string name = Console.ReadLine();
        int[,] golosa = new int[4, 7];
        for (int j = 0; j < 4; j++) //для каждого прыжка
        {
            for (int s = 0; s < 7; s++)
            {
                int golos = int.Parse(Console.ReadLine());
                golosa[j, s] = golos;
            }
        }
        return new Sportsman(name, golosa);
    }
    public static void Main(string[] args)
    {

        int n = int.Parse(Console.ReadLine());
        Sportsman[] peoplelist = new Sportsman[n];
        double[] indexx = FillIndexx();
        for (int i = 0; i < n; i++) //каждый спортсмен
        {
            peoplelist[i] = FillInfo();
        }
        Jump3 Sorev = new Jump3(peoplelist, indexx);
        Sorev.Sorevnovan();
        Console.WriteLine("!");

        int n2 = int.Parse(Console.ReadLine());
        Sportsman[] peoplelist2 = new Sportsman[n2];
        double[] indexx2 = FillIndexx();
        for (int i = 0; i < n2; i++)
        {
            peoplelist2[i] = FillInfo();
        }
        Jump5 Sorev2 = new Jump5(peoplelist2, indexx2);
        Sorev2.Sorevnovan();
        Console.ReadKey();
    }
}
