//уровень/номер 1/2
using System;
using System.Collections.Generic;
using System.Linq;
class Program
{
    static void Main(string[] args)
    {
        List<Runner> runners = new List<Runner>();

        runners.Add(new Runner("Баринова", "Группа 1", "Тренер Вмкторова", 12));
        runners.Add(new Runner("Лаврова", "Группа 2", "Тренер Максимова", 11));
        runners.Add(new Runner("Нагиева", "Группа 1", "Тренер Дмитриева", 10));
        runners.Add(new Runner("Чуганина", "Группа 3", "Тренер Сенева", 9));
        Console.WriteLine("Результаты кросса:");
        Console.WriteLine("Фамилия\t\t Группа \t\t Преподаватель \t\t Результат в секундах \t\t Норматив");

        foreach (var runner in runners.OrderBy(runner => runner.Result))
        {
            runner.DisplayInfo();
        }
        int passedNorm = runners.Count(runner => runner.Result <= 10);
        Console.WriteLine($"\nОбщее количество участниц, выполнивших норматив: {passedNorm}");
    }
}

class Runner
{
    public string Name { get;set; }
    public string Group { get;set; }
    public string TeacherName { get;set; }
    public double Result { get;set; }

    public Runner(string name, string group, string teacherSurname, double result)
    {
        Name = name;
        Group = group;
        TeacherName = teacherSurname;
        Result = result;
    }
    public void DisplayInfo()
    {
        Console.WriteLine($"{Name}\t\t{Group}\t\t{TeacherName}\t\t{Result:F2}\t\t{(Result <= 10 ? "Выполнен" : "Не выполнен")}");
    }
}

// уровень/номер 2/5
using System;
using System.Collections.Generic;
using System.Text;

struct Sportsman
{
    private string name;
    private double jump_1;
    private double jump_2;
    private double jump_3;
    private double jump_4;
    public Sportsman(string name, double one, double two, double three, double four)
    {
        this.name = name;
        jump_1 = one;
        jump_2 = two;
        jump_3 = three;
        jump_4 = four;
    }


    public double End_result()
    {
        return jump_1 + jump_2 + jump_3 + jump_4;
    }

    public void Info()
    {
        Console.WriteLine($"Итог прыжка: {jump_1 + jump_2 + jump_3 + jump_4}  {name} ");
    }
}

public class Program
{

    public static int[] SortedGolosa(int[] checklist, int n)
    {
        for (int i = 1; i < n; i++)
        {
            for (int j = 0; j < n - i; j++)
            {
                if (checklist[j + 1] > checklist[j])
                {
                    int now = checklist[j];
                    checklist[j] = checklist[j + 1];
                    checklist[j + 1] = now;
                }
            }
        }
        return checklist;
    }

    static Sportsman[] Sort(Sportsman[] checklist)
    {
        for (int i = 0; i < checklist.Length; i++)
        {
            for (int j = i; j < checklist.Length; j++)
                if (checklist[i].End_result() < checklist[j].End_result())
                {
                    Sportsman person_now = checklist[j]; 
                    checklist[j] = checklist[i]; 
                    checklist[i] = person_now; 
                }
        }
        return checklist;
    }


    public static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        Sportsman[] peoplelist = new Sportsman[n];

        for (int i = 0; i < n; i++) 
        {
            string nam_pep = Console.ReadLine();
            double[] result_jumps = new double[4];
            for (int j = 0; j < 4; j++) 
            {
                double index = double.Parse(Console.ReadLine()); 
                int[] voices = new int[7];
                for (int s = 0; s < 7; s++)
                {
                    int voise = int.Parse(Console.ReadLine());
                    voices[s] = voise;
                }

                voices = SortedGolosa(voices, 7); 
                int sum_gol = 0;
                for (int k = 1; k < 6; k++)
                {
                    sum_gol += voices[k];
                }

                result_jumps[j] = sum_gol * index;
            }

            Sportsman person = new Sportsman(nam_pep, result_jumps[0], result_jumps[1], result_jumps[2], result_jumps[3]);
            peoplelist[i] = person;
        }

        peoplelist = Sort(peoplelist);

        for (int i = 0; i < n; i++)
        {
            Console.Write($"{i + 1} место:"); ;
            peoplelist[i].Info();
            Console.WriteLine();
        }
        Console.WriteLine();
    }
}
//уровень/номер 3/5
using System;
class Program
{
    private struct Team
    {
        public string team;
        public int scored;
        public int missed;
        public int points;
    }

    static void Main(string[] args)
    {
        Team[] teams = {
            new Team { team = "Head", scored = 2, missed = 1 },
            new Team { team = "Sholders", scored = 1, missed = 1 },
            new Team { team = "Knees", scored = 0, missed = 3 },
            new Team { team = "Tose", scored = 3, missed = 0 }
        };


        for (int i = 0; i < teams.Length; i++)
        {
            teams[i].points = teams[i].scored > teams[i].missed ? 3 : teams[i].scored == teams[i].missed ? 1 : 0;
        }
        for (int i = 0; i < teams.Length - 1; i++)
        {
            for (int j = 0; j < teams.Length - i - 1; j++)
            {
                if (teams[j].points < teams[j + 1].points || (teams[j].points == teams[j + 1].points && (teams[j].scored - teams[j].missed) < (teams[j + 1].scored - teams[j + 1].missed)))
                {
                    Team x = teams[j];
                    teams[j] = teams[j + 1];
                    teams[j + 1] = x;
                }
            }
        }

        Console.WriteLine("Результирующая таблица:");
        Console.WriteLine("Место-\tКоманда-\tОчки-");
        for (int i = 0; i < teams.Length; i++)
        {
            Console.WriteLine($"{i + 1}\t{teams[i].team}\t{teams[i].points}");
        }

    }
}
