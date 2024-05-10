
using System;

class Program
{
    class Team
    {
        private string name;
        public string Name
        {
            get { return name; }
        }
        private int scored;
        private int missed;
        private int points;

        public int Points
        {
            get { return points; }
        }

        public Team(string name)
        {
            this.name = name;
            points = 0;
            scored = 0;
            missed = 0;
        }

        public void Win(int score1, int score2)
        {
            scored += Math.Max(score1, score2);
            missed += Math.Min(score1, score2);
            points += 3;
        }

        public void Lose(int score1, int score2)
        {
            scored += Math.Min(score1, score2);
            missed += Math.Max(score1, score2);
        }

        public void Draw(int score)
        {
            scored += score;
            missed += score;
            points += 1;
        }

        public int Getdiff()
        {
            return scored - missed;
        }

        public void info(int place)
        {
            Console.WriteLine($"{place}\t{name}\t{points}");
        }

        
        public static void MergeSort(Team[] teams)
        {
            if (teams.Length <= 1)
                return;

            int mid = teams.Length / 2;
            Team[] array2 = new Team[mid];
            Team[] array1 = new Team[teams.Length - mid];

            for (int i = 0; i < mid; i++)
            {
                array2[i] = teams[i];
            }
            for (int i = mid; i < teams.Length; i++)
            {
                array1[i - mid] = teams[i];
            }

            MergeSort(array2);
            MergeSort(array1);
            Merge(teams, array2, array1);
        }

        private static void Merge(Team[] teams, Team[] array2, Team[] array1)
        {
            int array2Index = 0;
            int array1Index = 0;
            int teamsIndex = 0;

            while (array2Index < array2.Length && array1Index < array1.Length)
            {
                if (array2[array2Index].Points > array1[array1Index].Points)
                {
                    teams[teamsIndex] = array2[leftIndex];
                    array2Index++;
                }
                else
                {
                    teams[teamsIndex] = array1[rightIndex];
                    array1Index++;
                }
                teamsIndex++;
            }

            while (array2Index < array2.Length)
            {
                teams[teamsIndex] = array2[leftIndex];
                array2Index++;
                teamsIndex++;
            }

            while (array1Index < array2.Length)
            {
                teams[teamsIndex] = array2[array1Index];
                array1Index++;
                teamsIndex++;
            }
        }
    }

    class WomenTeam : Team
    {
        public WomenTeam(string name) : base(name + " женская")
        {
        }
    }

    class MenTeam : Team
    {
        public MenTeam(string name) : base(name + " мужская")
        {
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

    static void Main(string[] args)
    {
        Team[] womenteams = new Team[4]
        {
            new WomenTeam("1"), new WomenTeam("2"),
            new WomenTeam("3"), new WomenTeam("4")
        };
        Team[] menteams = new Team[4]
        {
            new MenTeam("1"), new MenTeam("2"),
            new MenTeam("3"), new MenTeam("4")
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

        Team.MergeSort(teams); 
        res(teams);

        Console.ReadKey();
    }
}
