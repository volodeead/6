using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Book
{
    private string name;
    private string author;
    private decimal price;
    


    public Book(string author, string name, decimal price)
    {
        this.Name = name;
        this.Author = author;
        this.price = price;
    }

    public virtual string Name
    {
        get
        {
            return this.name;
        }
        set
        {
            if (value.Length < 3)
            {
                throw new ArgumentException("Name < 3 Length");
            }
            this.name = value;
        }

    }
    public virtual string Author
    {
        get
        {
            return this.author;
        }
        set
        {
            if(value.Any(simv => simv>'0' && simv < '9'))
            {
                throw new ArgumentException("Author not a namber");
            }
            this.author = value;
        }
    }
    public virtual decimal Price
    {
        get
        {
            return this.price;
        }
        set
        {
            if (value < 0)
            {
                throw new ArgumentException("Price < 0");
            }
            this.price = value;
        }
    }

    public override string ToString()
    {
        var resultBuilder = new StringBuilder();
        resultBuilder.AppendLine($"Name: {this.GetType().Name}")
        .AppendLine($"Type: {this.Name}")
        .AppendLine($"Author: {this.Author}")
        .AppendLine($"Price: {this.Price:f2}");
        string result = resultBuilder.ToString().TrimEnd();
        return result;
    }

}

class GoldenEditionBook : Book
{
    
    public GoldenEditionBook(string author, string title, decimal price) : base(author, title, price)
    {



    }
    public override decimal Price
    {
        get
        {
            return base.Price * (decimal)1.3;
        }
    }

}











class Program
    {
        static void Main()
        {
            try
            {
                string author = Console.ReadLine();
                string title = Console.ReadLine();
                decimal price = decimal.Parse(Console.ReadLine());
                Book book = new Book(author, title, price);
                GoldenEditionBook goldenEditionBook = new GoldenEditionBook(author, title, price);
                Console.WriteLine(book + Environment.NewLine);
                Console.WriteLine(goldenEditionBook);
                Console.ReadLine();
        }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
                Console.ReadLine();
            }
        }
    }

