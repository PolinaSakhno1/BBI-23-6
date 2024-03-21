using System;
using System.Collections.Generic;

public abstract class Good
{
    protected string name;
    protected string des;
    protected double price;
    protected string articleNumber;

    public Good(string name, double price)
    {
        this.name = name;
        this.price = price;
        this.des = $"Для товара {name} описание не задано";
    }

    public abstract void SetDescription(string newDescription);

    public string GetName()
    {
        return name;
    }

    public string GetDes()
    {
        return des;
    }

    public double GetPrice()
    {
        return price;
    }

    public override string ToString()
    {
        return $"{name}\t{des}\t{price}\t{articleNumber}";
    }
}

public class Beverage : Good
{
    protected double sugarConcentration;

    public Beverage(string name, double price, double sugarConcentration) : base(name, price)
    {
        this.sugarConcentration = sugarConcentration;
    }

    public double GetSugarConcentration()
    {
        return sugarConcentration;
    }

}

public class Food : Good
{
    protected int expirationDays;

    public Food(string name, double price, int expirationDays) : base(name, price)
    {
        this.expirationDays = expirationDays;
    }

    public int GetExpirationDays()
    {
        return expirationDays;
    }

}

class Program
{
    static void Main()
    {
        Good[] goods = new Good[5];

        goods[0] = new Beverage("сок апельсин", 2.5, 10);
        goods[1] = new Food("хлеб", 1.0, 3);
        goods[2] = new Food("масло", 1.5, 5);
        goods[3] = new Beverage("Сок яблоко", 2.0, 15);
        goods[4] = new Beverage("вода", 1.0, 0);

        foreach (Good good in goods)
        {
            good.SetDescription("Новое описание товара");
        }

        Array.Sort(goods, (x, y) => x.GetPrice().CompareTo(y.GetPrice()));

        Console.WriteLine("Название\tОписание\t\t\t\tСтоимость\tАртикул");
        foreach (Good good in goods)
        {
            Console.WriteLine(good.ToString());
        }
    }
}

