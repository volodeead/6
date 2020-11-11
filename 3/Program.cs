using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Person
{
    private string name;
    private string secname;

    public virtual string Name
    {
        set
        {
            this.name = value;
        }
        get
        {
            return this.name;
        }
    }
    public virtual string Secname
    {
        set
        {
            this.secname = value;
        }
        get
        {
            return this.secname;
        }
    }

}
class Student : Person
{
    private string code;

    public Student(string a , string b , string ccode)
    {
        this.Name = a;
        this.Secname = b;
        this.Code = ccode;
    }

    public string Code
    {
        get
        {
            return this.code;
        }
        set
        {
            if (value.Length < 4 && value.Length > 11)
            {
                throw new ArgumentException("Invalid code");
            }
            this.code = value;
        }
    }

    public override string ToString()
    {
        var resultBuilder = new StringBuilder();
        resultBuilder.AppendLine($"Name: {this.Name}")
        .AppendLine($"SerName: {this.Secname}")
        .AppendLine($"Code: {this.Code}");
        
        string result = resultBuilder.ToString().TrimEnd();
        return result;
    }

}

class Worker : Person
{
    private decimal wSalary;
    private decimal hour;

    public Worker(string name , string sername, decimal WS, decimal hour)
    {

        this.Name = name;
        this.Secname = sername;
        this.Hour = hour;
        this.WSalary = WS;

    }

    public decimal WSalary
    {
        get
        {
            return this.wSalary;
        }
        set
        {
            if(value < 10)
            {
                throw new ArgumentException("err in worker");
            }
            this.wSalary = value;
        }
    }
    public decimal Hour
    {
        get
        {
            return this.hour;
        }
        set
        {
            if (value < 1 && value > 12)
            {
                throw new ArgumentException("err in worker");
            }
            this.hour = value;
        }
    }
    public override string ToString()
    {
        var resultBuilder = new StringBuilder();
        resultBuilder.AppendLine($"Name: {this.Name}")
        .AppendLine($"SerName: {this.Secname}")
        .AppendLine($"Week Salary: {this.WSalary}")
        .AppendLine($"Hour: {this.Hour}")
        .AppendLine($"Sal per Hour: {this.WSalary/(this.Hour*5)}");

        string result = resultBuilder.ToString().TrimEnd();
        return result;
    }






}

    class Program
    {
        static void Main(string[] args)
        {
            try
            {

            string name = Console.ReadLine();
            string sername = Console.ReadLine();
            string code = Console.ReadLine();
            Student stud = new Student(name, sername, code);
            Console.WriteLine(stud + Environment.NewLine);

             name = Console.ReadLine();
             sername = Console.ReadLine();

            decimal ws = decimal.Parse(Console.ReadLine());
            decimal h = decimal.Parse(Console.ReadLine());

            Worker work = new Worker(name, sername, ws, h);
            Console.WriteLine(work + Environment.NewLine);
            Console.ReadLine();

        }
            catch (ArgumentException ae)
            {
            Console.WriteLine(ae.Message);
            Console.ReadLine();
            }

        }
    }

