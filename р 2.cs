using System;
using System.Text.Json;
using System.Text.Json.Serialization;


abstract class Task
{
    protected string text;
    protected string output;
    public string Text
    {
        get => text;
        protected set => text = value;
    }
    public Task(string text)
    {
        this.text = text;
        ParseText();
    }
    public override string ToString()
    {
        return output;
    }
    protected abstract void ParseText();
}
class Task1 : Task
{
    [JsonConstructor]
    public Task1(string text) : base(text) { }
    protected override void ParseText()
    {
        char[] sep = new char[] { '.', '!', '?' };
        string[] sentences = text.Split(sep, StringSplitOptions.RemoveEmptyEntries);
        string longestSentence = "";
        int maxWordCount = 0;

        foreach (string sentence in sentences)
        {
            string thisSentence = sentence;
            string[] words = thisSentence.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            if (words.Length > maxWordCount)
            {
                maxWordCount = words.Length;
                longestSentence = thisSentence;
            }
        }
        output = longestSentence;
    }

}
class Task2 : Task
{

    [JsonConstructor]
    public Task2(string text) : base(text) { }
    protected override void ParseText()
    {
        char[] Separators = new char[] { ' ', '.', ',', ';', ':', '!', '?', '-', '(', ')', '"', };
        string[] words = text.Split(Separators, StringSplitOptions.RemoveEmptyEntries);
        Dictionary<string, int> wordCount = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);
        foreach (string word in words)
        {
            string this_word = word.ToLower();
            if (wordCount.ContainsKey(this_word))
            {
                wordCount[this_word]++;
            }
            else
            {
                wordCount[this_word] = 1;
            }
        }
        int uniqueWords = 0;
        foreach (var element in wordCount)
        {
            if (element.Value == 1)
            {
                uniqueWords++;
            }
        }
        output = uniqueWords.ToString();
    }
}
class JsonIO
{
    public static void Write<T>(T obj, string filePath)
    {
        using (FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate))
        {
            JsonSerializer.Serialize(fs, obj);
        }
    }
    public static T Read<T>(string filePath)
    {
        using (FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate))
        {
            return JsonSerializer.Deserialize<T>(fs);
        }
    }
}
class Program
{
    static void Main()
    {
        Task[] tasks = {
            new Task1("Text"),
            new Task2("Text")
        };
        Console.WriteLine(tasks[0]);
        Console.WriteLine(tasks[1]);

        string path = @"C:\Users\Downloads";
        string folderName = "Control Work";
        path = Path.Combine(path, folderName);
        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
        }
        string fileName1 = "cw_2_task_1.json";
        string fileName2 = "cw_2_task_2.json";

        fileName1 = Path.Combine(path, fileName1);
        fileName2 = Path.Combine(path, fileName2);
        if (!File.Exists(fileName2))
        {
            JsonIO.Write<Task1>(tasks[0] as Task1, fileName1);
            JsonIO.Write<Task2>(tasks[1] as Task2, fileName1);
        }
        else
        {
            var t1 = JsonIO.Read<Task1>(fileName1);
            var t2 = JsonIO.Read<Task2>(fileName2);
            Console.WriteLine(t1);
            Console.WriteLine(t2);
        }
    }
}
