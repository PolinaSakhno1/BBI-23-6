//Задача 1 
using System.Text;

StringBuilder result = new StringBuilder();

foreach (string word in words)
{
    char[] letr = word.ToCharArray();
    Array.Reverse(letr);
    result.Append(new string(letr) + " ");
}
{ 
return result.ToString().Trim();
}

static void Main()
{
    Console.WriteLine("Введите текст:");
    string input = Console.ReadLine();

    string output = reverr(input);

    Console.WriteLine("перевёртыш: ");
    Console.WriteLine(output);
}


//Задача 2

using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Console.WriteLine("Введите слово:");
        string word = Console.ReadLine();

        int Count1 = Count(word);
        Console.WriteLine($"Количество букв: {Count1}");
    }

    static int Count(string word)
    {
        HashSet<char> un_letr = new HashSet<char>();

        foreach (char letter in word)
        {
            if (!un_letr.Contains(letter))
            {
                un_letr.Add(letter);
            }
        }

        return un_letr.Count;
    }
}