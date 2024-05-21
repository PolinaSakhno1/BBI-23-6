using System.Text.Json.Serialization;
using System.Xml.Serialization;
using lab9.serializers;
using ProtoBuf;

namespace lab9;

// 7 lab lvl 1
[Serializable]
[ProtoContract]
[ProtoInclude(10, typeof(Run_100m))]
[ProtoInclude(20, typeof(Run_500m))]
public abstract class Runner
{
    // делаем публичные сеттеры для сериализации XML
    [ProtoMember(1)] public string Surname { get; set; }
    [ProtoMember(2)] public string Group { get; set; }
    [ProtoMember(3)] public string TeacherSurname { get; set; }
    [ProtoMember(4)] public double Result { get; set; }
    
    public Runner()
    {
    }

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

[Serializable]
[ProtoContract]
public class Run_500m : Runner
{
    public Run_500m()
    {
    }

    public Run_500m(string Surname, string Group, string TeacherSurname, double Result) : base(Surname, Group,
        TeacherSurname, Result)
    {
    }

    public override void DisplayInfo()
    {
        Console.WriteLine(
            $"{Surname}\t\t{Group}\t\t{TeacherSurname}\t\t{Result:F2}\t\t{(Result <= 100 ? "Выполнен" : "Не выполнен")}");
    }
}

[Serializable]
[ProtoContract]
public class Run_100m : Runner
{
    public Run_100m()
    {
    }

    public Run_100m(string Surname, string Group, string TeacherSurname, double Result) : base(Surname, Group,
        TeacherSurname, Result)
    {
    }

    public override void DisplayInfo()
    {
        Console.WriteLine(
            $"{Surname}\t\t{Group}\t\t{TeacherSurname}\t\t{Result:F2}\t\t{(Result <= 10 ? "Выполнен" : "Не выполнен")}");
    }
}

// lvl 2
[Serializable]
[ProtoContract]
public class Result
{
    // делаем публичные сеттеры для сериализации XML
    [ProtoMember(1)] public List<int> Points { get; set; }

    public Result()
    {
    }

    public Result(List<int> points)
    {
        Points = points;
    }
}

[Serializable]
[ProtoContract]
public class Sportsman
{
    // делаем публичные сеттеры для сериализации XML
    [ProtoMember(1)] public string Name { get; set; }
    [ProtoMember(2)] public List<Result> GolosJumps { get; set; }

    public Sportsman()
    {
    }

    public Sportsman(string name, List<Result> jumps)
    {
        Name = name;
        GolosJumps = jumps;
    }
}

[Serializable]
[ProtoContract]
[ProtoInclude(11, typeof(Jump5))]
[ProtoInclude(21, typeof(Jump3))]
public abstract class JumpWater
{
    // делаем публичные сеттеры для сериализации XML
    [ProtoMember(1)] public string Name { get; set; }
    [ProtoMember(2)] public Sportsman[] Sportsmen { get; set; }
    [ProtoMember(3)] public double[] Indexx { get; set; }

    protected JumpWater()
    {
    }

    protected JumpWater(string name, Sportsman[] sportsmen, double[] indexx)
    {
        Name = name;
        Sportsmen = sportsmen;
        Indexx = indexx;
    }

    public double RezultForPerson(List<Result> list)
    {
        for (int number = 0; number < 4; number++)
        {
            for (int i = 1; i < 7; i++)
            {
                int k = list[number].Points[i];
                int j = i - 1;

                while (j >= 0 && list[number].Points[j] < k)
                {
                    list[number].Points[j + 1] = list[number].Points[j];
                    j--;
                }

                list[number].Points[j + 1] = k;
            }
        }

        int[] res_jumps = { 0, 0, 0, 0 };
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 7; j++)
            {
                res_jumps[i] += list[i].Points[j];
            }
        }

        double s = 0;
        for (int i = 0; i < 4; i++)
        {
            s += res_jumps[i] * Indexx[i];
        }

        return s;
    }

    public Sportsman[] Sort(Sportsman[] list)
    {
        for (int i = 0; i < list.Length; i++)
        {
            for (int j = i; j < list.Length; j++)
                if (RezultForPerson(list[i].GolosJumps) < RezultForPerson(list[j].GolosJumps))
                {
                    Sportsman personNow = list[j]; // меняем
                    list[j] = list[i]; // местами
                    list[i] = personNow; // игроков
                }
        }

        return list;
    }

    public void Sorevnovan()
    {
        Print_table(Sort(Sportsmen));
    }

    private void Print_table(Sportsman[] sortList)
    {
        Console.WriteLine(Name);
        for (int i = 0; i < sortList.Length; i++)
        {
            Console.Write($"{i + 1} место: ");
            Console.WriteLine($"имя: {sortList[i].Name} результат: {RezultForPerson(sortList[i].GolosJumps)}");
        }

        Console.WriteLine();
    }
}

[Serializable]
[ProtoContract]
public class Jump3 : JumpWater
{
    public Jump3()
    {
    }

    public Jump3(string name, Sportsman[] sportsmen, double[] indexx) : base(name, sportsmen, indexx)
    {
    }
}

[Serializable]
[ProtoContract]
public class Jump5 : JumpWater
{
    public Jump5()
    {
    }

    public Jump5(string name, Sportsman[] sportsmen, double[] indexx) : base(name, sportsmen, indexx)
    {
    }
}

// 3 lvl
[Serializable]
[ProtoContract]
[ProtoInclude(12, typeof(MenTeam))]
[ProtoInclude(22, typeof(WomenTeam))]
[XmlInclude(typeof(MenTeam))]
[XmlInclude(typeof(WomenTeam))]
public class Team
{
    // делаем публичные сеттеры для сериализации XML
    [ProtoMember(1)] public string Name { get; set; }
    [ProtoMember(2)] public int Scored { get; set; }
    [ProtoMember(3)] public int Missed { get; set; }
    [ProtoMember(4)] public int Points { get; set; }

    public Team()
    {
    }

    public Team(string name)
    {
        Name = name;
    }

    [JsonConstructor]
    public Team(string name, int scored, int missed, int points)
    {
        Name = name;
        Scored = scored;
        Missed = missed;
        Points = points;
    }

    public void Win(int score1, int score2)
    {
        Scored += Math.Max(score1, score2);
        Missed += Math.Min(score1, score2);
        Points += 3;
    }

    public void Lose(int score1, int score2)
    {
        Scored += Math.Min(score1, score2);
        Missed += Math.Max(score1, score2);
    }

    public void Draw(int score)
    {
        Scored += score;
        Missed += score;
        Points += 1;
    }

    public int Getdiff()
    {
        return Scored - Missed;
    }

    public int Getpoints()
    {
        return Points;
    }

    public void info(int place)
    {
        Console.WriteLine($"{place}\t{Name}\t{Points}");
    }
}

[Serializable]
[ProtoContract]
public class WomenTeam : Team
{
    public WomenTeam()
    {
    }

    [JsonConstructor]
    public WomenTeam(string name, int scored, int missed, int points) : base(name, scored, missed, points)
    {
    }

    public WomenTeam(string name) : base(name + " женская")
    {
    }
}

[Serializable]
[ProtoContract]
public class MenTeam : Team
{
    public MenTeam()
    {
    }

    [JsonConstructor]
    public MenTeam(string name, int scored, int missed, int points) : base(name, scored, missed, points)
    {
    }

    public MenTeam(string name) : base(name + " мужская")
    {
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        // 1 lvl
        List<Run_500m> run500 = new List<Run_500m>();

        run500.Add(new Run_500m("Баринова", "Группа 1", "Тренер Вмкторова", 120));
        run500.Add(new Run_500m("Лаврова", "Группа 2", "Тренер Максимова", 110));
        run500.Add(new Run_500m("Нагиева", "Группа 1", "Тренер Дмитриева", 100));
        run500.Add(new Run_500m("Чуганина", "Группа 3", "Тренер Сенева", 90));



        string dirBinary = "C:/Users/Сахно Полина/Source/Repos/lab9/lab9/files/binary_files/";
        string dirJson = "C:/Users/Сахно Полина/Source/Repos/lab9/lab9/files/json_files/Jump3.json";
        string dirXml = "C:/Users/Сахно Полина/Source/Repos/lab9/lab9/files/xml_files/Jump3.xml";
        string filename1Bin = "run_500.bin";
        string filename1Json = "run_500.json";
        string filename1Xml = "run_500.xml";
        MyJsonSerializer<List<Run_500m>> myJsonSerializer = new MyJsonSerializer<List<Run_500m>>();
        MyXmlSerializer<List<Run_500m>> myXmlSerializer = new MyXmlSerializer<List<Run_500m>>();
        MyBinarySerializer<List<Run_500m>> myBinarySerializer = new MyBinarySerializer<List<Run_500m>>();

        run500 = run500.OrderBy(runner => runner.Result).ToList();

        myXmlSerializer.Write(run500, dirXml + filename1Xml);
        myJsonSerializer.Write(run500, dirJson + filename1Json);
        myBinarySerializer.Write(run500, dirBinary + filename1Bin);

        Console.WriteLine("Json file:");
        Console.WriteLine("Результаты кросса на 500м:");
        Console.WriteLine("Фамилия\t\t Группа \t\t Преподаватель \t\t Результат в секундах \t\t Норматив");
        foreach (var runner in myJsonSerializer.Read(dirJson + filename1Json))
        {
            runner.DisplayInfo();
        }

        Console.WriteLine("Bin file:");
        Console.WriteLine("Результаты кросса на 500м:");
        Console.WriteLine("Фамилия\t\t Группа \t\t Преподаватель \t\t Результат в секундах \t\t Норматив");
        foreach (var runner in myBinarySerializer.Read(dirBinary + filename1Bin))
        {
            runner.DisplayInfo();
        }

        Console.WriteLine("Xml file:");
        Console.WriteLine("Результаты кросса на 500м:");
        Console.WriteLine("Фамилия\t\t Группа \t\t Преподаватель \t\t Результат в секундах \t\t Норматив");
        foreach (var runner in myXmlSerializer.Read(dirXml + filename1Xml))
        {
            runner.DisplayInfo();
        }

        int passedNorm = run500.Count(runner => runner.Result <= 100);
        Console.WriteLine($"\nОбщее количество участниц, выполнивших норматив: {passedNorm}");


        string filename2Bin = "run_100.bin";
        string filename2Json = "run_100.json";
        string filename2Xml = "run_100.xml";
        MyJsonSerializer<List<Run_100m>> myJsonSerializer2 = new MyJsonSerializer<List<Run_100m>>();
        MyXmlSerializer<List<Run_100m>> myXmlSerializer2 = new MyXmlSerializer<List<Run_100m>>();
        MyBinarySerializer<List<Run_100m>> myBinarySerializer2 = new MyBinarySerializer<List<Run_100m>>();

        List<Run_100m> run100 = new List<Run_100m>();

        run100.Add(new Run_100m("Баринова", "Группа 1", "Тренер Вмкторова", 11));
        run100.Add(new Run_100m("Лаврова", "Группа 2", "Тренер Максимова", 7));
        run100.Add(new Run_100m("Нагиева", "Группа 1", "Тренер Дмитриева", 13));
        run100.Add(new Run_100m("Чуганина", "Группа 3", "Тренер Сенева", 8));

        run100 = run100.OrderBy(runner => runner.Result).ToList();

        myXmlSerializer2.Write(run100, dirXml + filename2Xml);
        myJsonSerializer2.Write(run100, dirJson + filename2Json);
        myBinarySerializer2.Write(run100, dirBinary + filename2Bin);

        Console.WriteLine("Json file");
        Console.WriteLine("Результаты кросса на 100м:");
        Console.WriteLine("Фамилия\t\t Группа \t\t Преподаватель \t\t Результат в секундах \t\t Норматив");

        foreach (var runner in myJsonSerializer2.Read(dirJson + filename2Json))
        {
            runner.DisplayInfo();
        }

        Console.WriteLine("Bin file");
        Console.WriteLine("Результаты кросса на 100м:");
        Console.WriteLine("Фамилия\t\t Группа \t\t Преподаватель \t\t Результат в секундах \t\t Норматив");

        foreach (var runner in myBinarySerializer2.Read(dirBinary + filename2Bin))
        {
            runner.DisplayInfo();
        }


        Console.WriteLine("Xml file");
        Console.WriteLine("Результаты кросса на 100м:");
        Console.WriteLine("Фамилия\t\t Группа \t\t Преподаватель \t\t Результат в секундах \t\t Норматив");

        foreach (var runner in myXmlSerializer2.Read(dirXml + filename2Xml))
        {
            runner.DisplayInfo();
        }

        passedNorm = run100.Count(runner => runner.Result <= 100);
        Console.WriteLine($"\nОбщее количество участниц, выполнивших норматив: {passedNorm}");


        //lvl 2

        string filename3Bin = "Jump3.bin";
        string filename3Json = "Jump3.json";
        string filename3Xml = "Jump3.xml";
        MyJsonSerializer<Jump3> myJsonSerializer3 = new MyJsonSerializer<Jump3>();
        MyXmlSerializer<Jump3> myXmlSerializer3 = new MyXmlSerializer<Jump3>();
        MyBinarySerializer<Jump3> myBinarySerializer3 = new MyBinarySerializer<Jump3>();

        List<int> list = new List<int>() { 1, 2, 3 };
        Sportsman[] sportsmen =
        {
            new Sportsman("Katya",
                new List<Result>()
                {
                    new Result(new List<int>() { 1, 2, 3, 4, 5, 6, 7 }),
                    new Result(new List<int>() { 1, 2, 3, 4, 5, 6, 7 }),
                    new Result(new List<int>() { 1, 2, 3, 4, 5, 6, 7 }),
                    new Result(new List<int>() { 1, 2, 3, 4, 5, 6, 7 })
                }),
            new Sportsman("Roma",
                new List<Result>()
                {
                    new Result(new List<int>() { 7, 2, 3, 4, 5, 6, 7 }),
                    new Result(new List<int>() { 7, 2, 3, 4, 5, 6, 7 }),
                    new Result(new List<int>() { 7, 2, 3, 4, 5, 6, 7 }),
                    new Result(new List<int>() { 7, 2, 3, 4, 5, 6, 7 })
                }),
            new Sportsman("Armen",
                new List<Result>()
                {
                    new Result(new List<int>() { 1, 2, 3, 4, 5, 6, 0 }),
                    new Result(new List<int>() { 1, 2, 3, 4, 5, 6, 0 }),
                    new Result(new List<int>() { 1, 2, 3, 4, 5, 6, 0 }),
                    new Result(new List<int>() { 1, 2, 3, 4, 5, 6, 0 })
                })
        };

        double[] index = { 0.5, 0.6, 0.7, 0.8 };
        Jump3 jump3 = new Jump3("Jump3", sportsmen, index);

        myBinarySerializer3.Write(jump3, dirBinary + filename3Bin);
        myJsonSerializer3.Write(jump3, dirJson + filename3Json);
        myXmlSerializer3.Write(jump3, dirXml + filename3Xml);

        Console.WriteLine("Binary");
        myBinarySerializer3.Read(dirBinary + filename3Bin).Sorevnovan();
        Console.WriteLine("Xml");
        myXmlSerializer3.Read(dirXml + filename3Xml).Sorevnovan();
        Console.WriteLine("Json");
        myJsonSerializer3.Read(dirJson + filename3Json).Sorevnovan();


        string filename4Bin = "Jump5.bin";
        string filename4Json = "Jump5.json";
        string filename4Xml = "Jump5.xml";
        MyJsonSerializer<Jump5> myJsonSerializer4 = new MyJsonSerializer<Jump5>();
        MyXmlSerializer<Jump5> myXmlSerializer4 = new MyXmlSerializer<Jump5>();
        MyBinarySerializer<Jump5> myBinarySerializer4 = new MyBinarySerializer<Jump5>();
        Jump5 jump5 = new Jump5("Jump 5", sportsmen, index);

        myBinarySerializer4.Write(jump5, dirBinary + filename4Bin);
        myJsonSerializer4.Write(jump5, dirJson + filename4Json);
        myXmlSerializer4.Write(jump5, dirXml + filename4Xml);

        Console.WriteLine("Binary");
        myBinarySerializer4.Read(dirBinary + filename4Bin).Sorevnovan();
        Console.WriteLine("Xml");
        myXmlSerializer4.Read(dirXml + filename4Xml).Sorevnovan();
        Console.WriteLine("Json");
        myJsonSerializer4.Read(dirJson + filename4Json).Sorevnovan();


        // 3 lvl

        Team[] womenteams = new Team[4]
        {
            new WomenTeam("1"),
            new WomenTeam("2"),
            new WomenTeam("3"),
            new WomenTeam("4")
        };
        Team[] menteams = new Team[4]
        {
            new MenTeam("1"),
            new MenTeam("2"),
            new MenTeam("3"),
            new MenTeam("4")
        };
        Tournament(menteams);
        Console.WriteLine();
        Tournament(womenteams);
        Console.WriteLine();
        Team[] teams = new Team[menteams.Length + womenteams.Length];
        for (int i = 0, j = 0; i < womenteams.Length; i++)
        {
            teams[j] = menteams[i];
            j++;
            teams[j] = womenteams[i];
            j++;
        }

        sort(teams);


        string filename5Bin = "Team.bin";
        string filename5Json = "Team.json";
        string filename5Xml = "Team.xml";
        MyJsonSerializer<Team[]> myJsonSerializer5 = new MyJsonSerializer<Team[]>();
        MyXmlSerializer<Team[]> myXmlSerializer5 = new MyXmlSerializer<Team[]>();
        MyBinarySerializer<Team[]> myBinarySerializer5 = new MyBinarySerializer<Team[]>();

        myBinarySerializer5.Write(teams, dirBinary + filename5Bin);
        myJsonSerializer5.Write(teams, dirJson + filename5Json);
        myXmlSerializer5.Write(teams, dirXml + filename5Xml);

        Console.WriteLine("Bin");
        res(myBinarySerializer5.Read(dirBinary + filename5Bin));
        Console.WriteLine("Json");
        res(myJsonSerializer5.Read(dirJson + filename5Json));
        Console.WriteLine("Xml");
        res(myXmlSerializer5.Read(dirXml + filename5Xml));
    }

    private static void sort(Team[] teams)
    {
        for (int i = 0; i < teams.Length; i++)
        {
            for (int j = 0; j < teams.Length - 1; j++)
            {
                if (teams[j].Getpoints() < teams[j + 1].Getpoints() ||
                    ((teams[j].Getpoints() == teams[j + 1].Getpoints()) &&
                     (teams[j].Getdiff() < teams[j + 1].Getdiff())))
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

    static void calculatepoints(Team team1, Team team2, int score1, int score2)
    {
        if (score1 > score2)
        {
            team1.Win(score1, score2);
            team2.Lose(score1, score2);
        }
        else if (score1 < score2)
        {
            team2.Win(score1, score2);
            team1.Lose(score1, score2);
        }
        else
        {
            team1.Draw(score1);
            team2.Draw(score1);
        }
    }

    static void Tournament(Team[] teams)
    {
        Random random = new Random();
        for (int i = 0; i < teams.Length; i++)
        {
            for (int j = i + 1; j < teams.Length; j++)
            {
                int score1 = random.Next(0, 10);
                int score2 = random.Next(0, 10);
                Console.WriteLine($"{teams[i].Name} - {teams[j].Name} {score1}:{score2}");
                calculatepoints(teams[i], teams[j], score1, score2);
            }
        }
    }
}