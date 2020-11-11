using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Person
{
    private string name;
    private int age;

    public Person(string name, int age)
    {
        this.Name = name;
        this.Age = age;
    }


    public virtual string Name
    {
        get
        {
            return this.name;
        }
        set
        {
            if (value == "")
            {
                throw new ArgumentException("Age must be positive!");
            }

            this.name = value;
        }
    }

    public virtual int Age
    {
        get
        {
            return this.age;
        }
        set
        {

            if (value < 0)
            {
                throw new ArgumentException("Age must be positive!");
            }

            this.age = value;
        }
    }

    public override string ToString()
    {
        StringBuilder stringBuilder = new StringBuilder();
        stringBuilder.Append(String.Format("Name: {0}, Age: {1}",
        this.Name,
       this.Age));
        return stringBuilder.ToString();
    }



}
class Child : Person
{


    public Child(string name, int age):base(name, age)
    {

    }

    public override int Age
    {
        get
        {
            return base.Age;
        }
        set
        {
            if (value > 15)
            {
                throw new ArgumentException("Age cant be >15");
            }

            base.Age = value;
        }
    }


}




class Program
    {
    static void Main(){
        string name = Console.ReadLine();
        int age = int.Parse(Console.ReadLine());
        try
        {
            Child child = new Child(name, age);
            Console.WriteLine(child);
            Console.ReadLine();
        }
        catch (ArgumentException ae)
        {
            Console.WriteLine(ae.Message);
            Console.ReadLine();
        }
    }
    }

