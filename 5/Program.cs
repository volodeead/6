using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Mood
{
    public Mood(string mood)
    {
        this.MoodName = mood;
    }

    public string MoodName { get; set; }
}

//food

public abstract class Food
{
    public int Happiness { get; set; }
}
public class Apple : Food
{
    public Apple()
    {
        this.Happiness = 1;
    }
}
public class Cram : Food
{
    public Cram()
    {
        this.Happiness = 2;
    }
}
public class Else : Food
{
    public Else()
    {
        this.Happiness = -1;
    }
}
public class HoneyCake : Food
{
    public HoneyCake()
    {
        this.Happiness = 5;
    }
}
public class Lembas : Food
{
    public Lembas()
    {
        this.Happiness = 3;
    }
}
public class Melon : Food
{
    public Melon()
    {
        this.Happiness = 1;
    }
}
public class Mushrooms : Food
{
    public Mushrooms()
    {
        this.Happiness = -10;
    }
}
//food

public static class FoodFactory
{
    public static Food GenerateFood(string food)
    {
        switch (food.ToLower())
        {
            case "apple":
                return new Apple();
            case "cram":
                return new Cram();
            case "honeycake":
                return new HoneyCake();
            case "lembas":
                return new Lembas();
            case "melon":
                return new Melon();
            case "mushrooms":
                return new Mushrooms();
            default:
                return new Else();
        }
    }
}

public static class MoodFactory
{
    public static Mood GenerateMood(int happiness)
    {
        if (happiness < -5)
        {
            return new Mood("Angry");
        }
        else if (happiness <= 0)
        {
            return new Mood("Sad");
        }
        else if (happiness <= 15)
        {
            return new Mood("Happy");
        }
        else
        {
            return new Mood("JavaScript");
        }
    }
}

public class Gandalf
{
    private List<Food> food;
    private Mood mood;

    public Gandalf()
    {
        this.food = new List<Food>();
    }

    private void CalculateMood()
    {
        this.mood = MoodFactory.GenerateMood(this.food.Sum(f => f.Happiness));
    }

    public void TakeFood(string[] foods)
    {
        foreach (var food in foods)
        {
            Food current = FoodFactory.GenerateFood(food);
            this.food.Add(current);
        }

        this.CalculateMood();
    }

    public override string ToString()
    {
        var builder = new StringBuilder();
        builder.AppendLine($"{this.food.Sum(f => f.Happiness)}").Append(this.mood.MoodName);

        return builder.ToString();
    }
}

class Program
{
    static void Main(string[] args)
    {
        string[] input = Console.ReadLine().Split();

        Gandalf gandalf = new Gandalf();
        gandalf.TakeFood(input);
        Console.WriteLine(gandalf);

    }
}