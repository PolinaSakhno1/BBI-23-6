using System;
abstract class Task
{
    protected string text;
    public Task(string text)
    {
        this.text = text;
        ParseText();
    }
    protected abstract void ParseText(); // все разные
    protected virtual int Count() // если несколько одинаковых, а один выбивается
    {
        return -1;
    }
    private double CountPersent(int number, int total) // все одинаковые
    {
        return (double)number / (double)total * 100;
    }
}

class Task_2 : Task
{
    public Task_2(string text) : base(text) { }
    public override string ToString()
    {
        return text;
    }
    protected override void ParseText()
    {
        string this_word = "";
        for (int i = 0; i < text.Length; i++)
        {
            if (char.IsLetter(text[i]))
            {
                this_word += text[i];
            }
            else if (this_word.Length != 0)
            {
                text = text.Remove(i - this_word.Length, this_word.Length);
                text = text.Insert(i - this_word.Length, Reverse(this_word));
                this_word = "";
            }
        }
    }
    protected string Reverse(string word)
    {
        string reversed = "";
        for (int i = word.Length - 1; i > -1; i--)
        {
            reversed += word[i];
        }
        return reversed;

    }
}

class Task_4 : Task
{
    private int difficulty = 0;
    public Task_4(string text) : base(text) { }
    public override string ToString()
    {
        return "Сложность данного предложения - " + difficulty;
    }
    protected override void ParseText()
    {
        string symbols = ".,!?()«»:;";
        foreach (char symbol in text)
        {
            if (symbols.Contains(symbol)) difficulty++;
        }
        string[] words = text.Split();
        difficulty += words.Length;
    }
}

class Task_6 : Task
{
    private string output;
    public Task_6(string text) : base(text) { }
    public override string ToString()
    {
        return output;
    }
    protected override int Count()
    {
        return 0;
    }
    protected override void ParseText()
    {
        text = text.ToLower();
        string[] words = text.Split();
        int[] count_letters = new int[10];
        string letters = "аеёиоуыэюя";
        foreach (string word in words)
        {
            int count = 0;
            foreach (char symbol in word)
            {
                if (letters.Contains(symbol)) count++;
            }
            if (count > 0) count_letters[count - 1]++;
        }
        MakeOutput(count_letters);
    }
    protected void MakeOutput(int[] count_letters)
    {
        output = "В тексте найдено:\n";
        for (int i = 0; i < count_letters.Length; i++)
        {
            output += (i + 1) + "-cложных слов: " + count_letters[i] + "\n";
        }
    }
}

class Task_8 : Task
{
    private string splitted_text = "";
    public Task_8(string text) : base(text) { }
    public override string ToString()
    {
        return splitted_text;
    }
    protected override void ParseText()
    {
        string[] words = text.Split();
        List<string> lines = new List<string>();
        string this_line = "";
        foreach(string word in words)
        {
            if((this_line + word).Length > 50)
            {
                lines.Add(this_line.Remove(this_line.Length-1));
                this_line = "";
            }
            this_line += word + " ";
        }
        foreach(string line in lines)
        {
            int total_spaces = 50 - line.Length;
            int required_spaces = total_spaces / (line.Split().Length - 1);
            int extra_spaces = total_spaces % (line.Split().Length - 1);
            string new_line = line;
            for(int i = 0; i < line.Length; i++)
            {
                if (new_line[i] == ' ')
                {
                    new_line = new_line.Insert(i, new string(' ', required_spaces));
                    i += required_spaces;
                    if(extra_spaces > 0)
                    {
                        new_line = new_line.Insert(i, " ");
                        extra_spaces--;
                        i++;
                    }
                }
            }
            splitted_text += new_line + "\n";
        }
    }

}

class Task_9 : Task
{
    private string[] codes = new string[] { "@", "$", "&", "*", "€", "£", "¥", "#", "§", "_" };
    public string[] Codes
    {
        get { return codes; }
    }
    private string[] keys;
    public string[] Keys
    {
        get { return keys; }
    }
    int[] values;
    private string table = "\n";
    public string Text
    {
        get { return text; }
    }
    public Task_9(string text) : base(text)
    {
    }
    public override string ToString()
    {
        return text + table;
    }
    protected override void ParseText()
    {
        Dictionary<string, int> dict = new Dictionary<string, int>();
        for(int i = 0; i < text.Length - 1; i++)
        {
            if (char.IsLetter(text[i]) && char.IsLetter(text[i+1]))
            {
                string str = text[i] + text[i + 1].ToString();
                if (dict.ContainsKey(str))
                {
                    dict[str]++;
                }
                else
                {
                    dict[str] = 1;
                }
            }
        }
        keys = new string[dict.Count];
        values = new int[dict.Count];
        int k = 0;
        foreach(var item in dict)
        {
            keys[k] = item.Key;
            values[k] = item.Value;
            k++;
        }
        for(int i = 0; i < 10; i++)
        {
            for(int j = 0; j < 9; j++)
            {
                if (values[j] > values[j+1])
                {
                    int t1 = values[j];
                    values[j] = values[j + 1];
                    values[j + 1] = t1;
                    string t2 = keys[j];
                    keys[j] = keys[j + 1];
                    keys[j + 1] = t2;
                }
            }
        }
        for(int i = 0; i < 10; i++)
        {
            text = text.Replace(keys[i], codes[i]);
            table += keys[i] + " : " + codes[i] + "\n";
        }
    }
}

class Task_10 : Task
{
    private string[] keys;
    private string[] codes;
    public Task_10(string text, string[] keys, string[] codes) : base(text)
    {
        this.keys = keys;
        this.codes = codes;
        Decode();
    }
    public override string ToString()
    {
        return text;
    }
    protected override void ParseText()
    {
        
    }
    protected void Decode()
    {
        for (int i = 9; i >= 0; i--)
        {
            text = text.Replace(codes[i], keys[i]);
        }
    }
}

class Program
{
    public static void Main()
    {
        Task_2 task2 = new Task_2("В извечном споре истории и литературы я в какой-то момент определился со стороной. Для себя я понял, что намного интереснее изучать мир не по списку дат исторических событий, а по произведениям искусства, во времена этих событий созданных. Искусство – это зеркало общества. Для меня не так важно, из какой посуды ели люди тысячу лет назад, чем резали скот и как строили храмы – важнее то, о чем они думали, чего они хотели, во что они верили.");
        Task_4 task4 = new Task_4("В извечном споре истории и литературы я в какой-то момент определился со стороной. Для себя я понял, что намного интереснее изучать мир не по списку дат исторических событий, а по произведениям искусства, во времена этих событий созданных. Искусство – это зеркало общества. Для меня не так важно, из какой посуды ели люди тысячу лет назад, чем резали скот и как строили храмы – важнее то, о чем они думали, чего они хотели, во что они верили.");
        Task_6 task6 = new Task_6("В извечном споре истории и литературы я в какой-то момент определился со стороной. Для себя я понял, что намного интереснее изучать мир не по списку дат исторических событий, а по произведениям искусства, во времена этих событий созданных. Искусство – это зеркало общества. Для меня не так важно, из какой посуды ели люди тысячу лет назад, чем резали скот и как строили храмы – важнее то, о чем они думали, чего они хотели, во что они верили.");
        Task_8 task8 = new Task_8("В извечном споре истории и литературы я в какой-то момент определился со стороной. Для себя я понял, что намного интереснее изучать мир не по списку дат исторических событий, а по произведениям искусства, во времена этих событий созданных. Искусство – это зеркало общества. Для меня не так важно, из какой посуды ели люди тысячу лет назад, чем резали скот и как строили храмы – важнее то, о чем они думали, чего они хотели, во что они верили.");
        Task_9 task9 = new Task_9("В извечном споре истории и литературы я в какой-то момент определился со стороной. Для себя я понял, что намного интереснее изучать мир не по списку дат исторических событий, а по произведениям искусства, во времена этих событий созданных. Искусство – это зеркало общества. Для меня не так важно, из какой посуды ели люди тысячу лет назад, чем резали скот и как строили храмы – важнее то, о чем они думали, чего они хотели, во что они верили.");
        Task_10 task10 = new Task_10(task9.Text, task9.Keys, task9.Codes);

        //Console.WriteLine(task2);
        //Console.WriteLine(task4);
        //Console.WriteLine(task6);
        //Console.WriteLine(task8);
        Console.WriteLine(task9);
        Console.WriteLine(task10);

        Console.ReadKey();
    }
}
