//Вариант 13 номер 1 
using System;
using System.Linq;

struct Good
{
    public string Name;
    public string des;
    public double pri;
    public string art;

    public Good(string name, double price)
    {
        Name = name;
        des = $"Для товара {name} описание не задано.";
        pri = price;
        art = Guid.NewGuid().ToString();
    }

    public void Inp_Des()
    {
        Console.WriteLine("Введите описание товара (от 20 до 200 символов):");
        string input = Console.ReadLine();

        if (input.Length >= 20 && input.Length <= 200)
        {
            des = input;
        }
        else
        {
            Console.WriteLine("Описание должно содержать от 20 до 200 символов.");
        }
    }
}

class Program
{
    static void Main()
    {
        Good[] goods = new Good[5];

        goods[0] = new Good("Товар 1", 100.0);
        goods[1] = new Good("Товар 2", 50.0);
        goods[2] = new Good("Товар 3", 75.0);
        goods[3] = new Good("Товар 4", 120.0);
        goods[4] = new Good("Товар 5", 80.0);

        for (int i = 0; i < 3; i++)
        {
            goods[i].Inp_Des();
        }

        Array.Sort(goods, (x, y) => x.pri.CompareTo(y.pri));

        Console.WriteLine("Товары:");
        Console.WriteLine("{0,-10} {1,-30} {2,-10} {3,-40}", "Артикул", "Название", "Цена", "Описание");
        foreach (var good in goods)
        {
            Console.WriteLine("{0,-10} {1,-30} {2,-10} {3,-40}", good.art, good.Name, good.pri, good.des);
        }
    }
}





































//напиши код на C# по этому условию: создайте структуру Good,в которой записано название , описание и стоимость товара, а так же уникальный арткул.Реализуйте методы для ввода инфоормации о товаре и изменения описания товара.Сделать проверку на то , чтобы вводимое описание было не короче 20 символов, и не длннее, чем 200 символов( строка является массивом символов).В конструктор передавать название и стоимость товара. По умолчанию заполнять описание фразой "для товара [ название товара] описание не заданно ".в основной программе сделать ммассив из 5 товаров , трём из них изменить описание. Отсортировать по возростанию цены и ввести ввиде таблицы.