//#1( 1,2)
using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        List<Run_500m> run500 = new List<Run_500m>();

        run500.Add(new Run_500m("Баринова", "Группа 1", "Тренер Вмкторова", 120));
        run500.Add(new Run_500m("Лаврова", "Группа 2", "Тренер Максимова", 110));
        run500.Add(new Run_500m("Нагиева", "Группа 1", "Тренер Дмитриева", 100));
        run500.Add(new Run_500m("Чуганина", "Группа 3", "Тренер Сенева" 90));

        Console.WriteLine("Результаты кросса на 500м:");
        Console.WriteLine("Фамилия\t\t Группа \t\t Преподаватель \t\t Результат в секундах \t\t Норматив");

        foreach (var runner in run500.OrderBy(runner => runner.Result))
        {
            runner.DisplayInfo();
        }

        int passedNorm = run500.Count(runner => runner.Result <= 100);
        Console.WriteLine($"\nОбщее количество участниц, выполнивших норматив: {passedNorm}");

        List<Run_100m> run100 = new List<Run_100m>();

        run100.Add(new Run_100m("Баринова", "Группа 1", "Тренер Вмкторова", 11));
        run100.Add(new Run_100m("Лаврова", "Группа 2", "Тренер Максимова", 7));
        run100.Add(new Run_100m("Нагиева", "Группа 1", "Тренер Дмитриева", 13));
        run100.Add(new Run_100m("Чуганина", "Группа 3", "Тренер Сенева", 8));

        Console.WriteLine("Результаты кросса на 100м:");
        Console.WriteLine("Фамилия\t\t Группа \t\t Преподаватель \t\t Результат в секундах \t\t Норматив");

        foreach (var runner in run100.OrderBy(runner => runner.Result))
        {
            runner.DisplayInfo();
        }

        passedNorm = run100.Count(runner => runner.Result <= 100);
        Console.WriteLine($"\nОбщее количество участниц, выполнивших норматив: {passedNorm}");
    }
}

abstract class Runner
{
    public string Surname { get; private set; }
    public string Group { get; private set; }
    public string TeacherSurname { get; private set; }
    public double Result { get; private set; }

    public Runner(string surname, string group, string teacherSurname, double result)
    {
        Surname = surname;
        Group = group;
        TeacherSurname = teacherSurname;
        Result = result;
    }

    public virtual void DisplayInfo()
    {
        Console.WriteLine($"{Surname}\t\t{Group}\t\t{TeacherSurname}\t\t{Result}");
    }
}

class Run_500m : Runner
{
    public Run_500m(string Surname, string Group, string TeacherSurname, double Result) : base(Surname, Group, TeacherSurname, Result)
    {

    }
    public override void DisplayInfo()
    {
        Console.WriteLine($"{Surname}\t\t{Group}\t\t{TeacherSurname}\t\t{Result:F2}\t\t{(Result <= 100 ? "Выполнен" : "Не выполнен")}");
    }
}

class Run_100m : Runner
{
    public Run_100m(string Surname, string Group, string TeacherSurname, double Result) : base(Surname, Group, TeacherSurname, Result)
    {

    }
    public override void DisplayInfo()
    {
        Console.WriteLine($"{Surname}\t\t{Group}\t\t{TeacherSurname}\t\t{Result:F2}\t\t{(Result <= 10 ? "Выполнен" : "Не выполнен")}");
    }
}

//2 (2,5)
/using System;
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
    protected string dist;
    protected Sportsman[] sportsmen;
    protected double[] indexx;

    public JumpWater(Sportsman[] sportsmen, string dist, double[] indexx)
    {
        this.sportsmen = sportsmen;
        this.dist = dist;
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

    protected void Sorevnovan(Sportsman[] sportsmen)
    {
        Sportsman[] list_sort = Sort(sportsmen);
        Print_table(list_sort);
    }

    protected abstract void Print_table(Sportsman[] sort_list);
}

class Jump3 : JumpWater
{
    public Jump3(string dist, Sportsman[] sportsmen, double[] indexx) : base(sportsmen, dist, indexx)
    {
        this.sportsmen = sportsmen;
        this.dist = dist;
        Sorevnovan(sportsmen);
    }

    protected override void Print_table(Sportsman[] sort_list)
    {
        Console.WriteLine(dist);
        for (int i = 0; i < sort_list.Length; i++)
        {
            Console.Write($"{i + 1} место:");
            Console.Write($"имя: {sort_list[i].Name} результат: {RezultForPerson(sort_list[i].Golosa)}");
            Console.WriteLine();
        }
        Console.WriteLine();
    }
}

class Jump5 : JumpWater
{
    public Jump5(string dist, Sportsman[] sportsmen, double[] indexx) : base(sportsmen, dist, indexx)
    {
        this.sportsmen = sportsmen;
        this.dist = dist;
        Sorevnovan(sportsmen);
    }
    protected override void Print_table(Sportsman[] sort_list)
    {
        Console.WriteLine(dist);
        for (int i = 0; i < sort_list.Length; i++)
        {
            Console.Write($"{i + 1} место:");
            Console.Write($"имя: {sort_list[i].Name} результат: {RezultForPerson(sort_list[i].Golosa)}");
            Console.WriteLine();
        }
        Console.WriteLine();
    }
}


public class Program
{
    public static void Main(string[] args)
    {
        string dist = Console.ReadLine();
        int n = int.Parse(Console.ReadLine());
        Sportsman[] peoplelist = new Sportsman[n];

        double[] Indexx = new double[4];
        for (int i = 0; i < 4; i++)
        {
            Indexx[i] = double.Parse(Console.ReadLine());
        }

        for (int i = 0; i < n; i++) //каждый спортсмен
        {
            string name_people = Console.ReadLine();
            int[,] golosa_jumps = new int[4, 7];
            for (int j = 0; j < 4; j++) //для каждого прыжка
            {
                for (int s = 0; s < 7; s++)
                {
                    int golos = int.Parse(Console.ReadLine());
                    golosa_jumps[j, s] = golos;
                }
            }
            Sportsman person = new Sportsman(name_people, golosa_jumps);
            peoplelist[i] = person;
        }
        Jump3 Sorev = new Jump3(dist, peoplelist, Indexx);

        string dist2 = Console.ReadLine();
        int n2 = int.Parse(Console.ReadLine());
        Sportsman[] peoplelist2 = new Sportsman[n2];

        double[] Indexx2 = new double[4];
        for (int i = 0; i < 4; i++)
        {
            Indexx2[i] = double.Parse(Console.ReadLine());
        }

        for (int i = 0; i < n2; i++) 
        {
            string name_people2 = Console.ReadLine();
            int[,] golosa_jumps2 = new int[4, 7];
            for (int j = 0; j < 4; j++) 
            {
                for (int s = 0; s < 7; s++)
                {
                    int golos2 = int.Parse(Console.ReadLine());
                    golosa_jumps2[j, s] = golos2;
                }
            }
            Sportsman person = new Sportsman(name_people2, golosa_jumps2);
            peoplelist2[i] = person;
        }

        Jump5 Sorev2 = new Jump5(dist2, peoplelist2, Indexx2);

    }
}
 //3
﻿using System;
class Program
{
    class Team
    {
        private string team;
        private int scored;
        private int missed;
        private int points;
        private string gender;
        public Team(string name, int Scored, int Missed, int Points, string Gender)
        {
            team = name;
            scored = Scored;
            missed = Missed;
            points = Points;
            gender = Gender;
        }
        public int Getpoints()
        {
            return points;
        }
        public int Getscored()
        {
            return scored;
        }
        public int Getmissed()
        {
            return missed;
        }
        public virtual void calculatepoints(int Scored, int Missed)
        {
            scored += Scored;
            missed += Missed;
            points = scored > missed ? 3 : scored == missed ? 1 : 0;
        }
        public virtual void info(int place)
        {
            Console.WriteLine($"{place}\t{team}\t{gender}\t{points}");
        }
    }
    class WomenTeam : Team
    {
        public WomenTeam(string name, int Scored, int Missed) : base(name, Scored, Missed, 0, "Ж")
        {
        }
    }
    class MenTeam : Team
    {
        public MenTeam(string name, int Scored, int Missed) : base(name, Scored, Missed, 0, "M")
        {
        }
    }


    static void Main(string[] args)
    {
        Team Head = new WomenTeam("Head", 0, 0);
        Team Sholders = new WomenTeam("Sholders", 0, 0);
        Team Knees = new MenTeam("Knees", 0, 0);
        Team Tose = new MenTeam("Tose", 0, 0);

        Head.calculatepoints(4, 0);
        Sholders.calculatepoints(0, 4);
        Tose.calculatepoints(3, 1);
        Knees.calculatepoints(1, 3);

        Team[] teams =
        {
           Head, Sholders, Knees, Tose
        };

        sort(teams);
        res(teams);
    }


    private static void sort(Team[] teams)
    {
        for (int i = 0; i < 4 - 1; i++)
        {
            for (int j = 0; j < 4 - i - 1; j++)
            {
                if (teams[j].Getpoints() < teams[j + 1].Getpoints() || (teams[j].Getpoints() == teams[j + 1].Getpoints() && (teams[j].Getscored() - teams[j].Getmissed()) < (teams[j + 1].Getscored() - teams[j + 1].Getmissed())))
                {
                    Team t = teams[j];
                    teams[j] = teams[j + 1];
                    teams[j + 1] = t;
                }
            }
        }
    }
    private static void res(Team[] teams)
    {

        Console.WriteLine("Результирующая таблица:");
        Console.WriteLine("Место\tКоманда\tПол\tОчки");
        for (int i = 0; i < teams.Length; i++)
        {
            teams[i].info(i + 1);
        }
    }
}