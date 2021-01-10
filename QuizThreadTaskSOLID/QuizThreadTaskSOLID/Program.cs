using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace QuizThreadTaskSOLID
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Quiz,Exception 
            //Student s = new Student();
            //s.Name = "";

            //try
            //{
            //    s.SetAge(1147);
            //}
            //catch (StuException se)
            //{

            //    Console.WriteLine(se.Message);
            //}
            #endregion

            #region THread
            //Thread thread1 = new Thread(Loop1);
            //Thread thread2 = new Thread(Loop2);
            //thread1.Start();
            ////thread1.Join();
            //thread2.Start();
            //Console.WriteLine("Salam");
            #endregion

            #region SOLID
            #region Liskov substitution
            Fruit orange = new Orange();
            Fruit apple = new Apple();
            #endregion

            #region Dependency Injection
            Service service = new Service();
            service.product.GetProductData();
            service.client.GetClientData();
            #endregion
            #endregion
        }

        #region THread
        //static void Loop1()
        //{
        //    for (int i = 0; i < 100; i++)
        //    {
        //        Thread.Sleep(0);
        //        Console.WriteLine($"Loop1: {i}");
        //    }
        //}

        //static void Loop2()
        //{
        //    for (int i = 0; i < 100; i++)
        //    {
        //        Thread.Sleep(1000);
        //        Console.WriteLine($"Loop2: {i}");
        //    }
        //}
        #endregion
    }

    #region SOLID
    #region Single representation
    //class Student
    //{
    //    public string Name { get; set; }
    //    public string Surname { get; set; }
    //    public Group Group { get; set; }
    //}

    //class Group
    //{
    //    public string Name { get; set; }
    //    public int Count { get; set; }
    //    public GroupType Type { get; set; }
    //}

    //class GroupType
    //{
    //    public string Type { get; set; }
    //}
    #endregion

    #region Open/Close

    class Invoice
    {
        public virtual void GetPrice()
        {
            Console.WriteLine("Discount:30%");
        }
    }

    class FinalInvoice: Invoice
    {
        public override void GetPrice()
        {
            Console.WriteLine("Discount:40%");
        }
    }
    //class Invoice
    //{
    //    public void GetPrice(string type)
    //    {
    //        switch (type)
    //        {
    //            case "initial":
    //                Console.WriteLine("Discount:30%");
    //                break;
    //            case "second":
    //                Console.WriteLine("Discount:35%");
    //                break;
    //            case "final":
    //                Console.WriteLine("Discount:40%");
    //                break;
    //        }
    //    }
    //}
    #endregion

    #region Liskov substitution
    abstract class Fruit
    {
        public abstract void Tasty();
    }
    class Apple : Fruit
    {
        public override void Tasty()
        {
            Console.WriteLine("As Apple");
        }
    }

    class Orange : Fruit
    {
        public override void Tasty()
        {
            Console.WriteLine("As Orange"); 
        }
    }
    #endregion

    #region Interface segregation
    //interface ICalculate
    //{
    //    int Sum(int n1, int n2);
    //    int Difference(int n1, int n2);
    //    double Divide(int n1, int n2);
    //    int Multiple(int n1, int n2);
    //}

    interface IDifference
    {
        int Difference(int n1, int n2);
    }

    interface IDivide
    {
        double Divide(int n1, int n2);
    }

    interface IMultiple
    {
        int Multiple(int n1, int n2);
    }

    interface ISum
    {
        int Sum(int n1, int n2);
    }
    class Test : ISum
    {
        public int Sum(int n1, int n2)
        {
            throw new NotImplementedException();
        }
    }

    class Calculate : ISum,IDifference,IDivide,IMultiple
    {
        public int Difference(int n1, int n2)
        {
            throw new NotImplementedException();
        }

        public double Divide(int n1, int n2)
        {
            throw new NotImplementedException();
        }

        public int Multiple(int n1, int n2)
        {
            throw new NotImplementedException();
        }

        public int Sum(int n1, int n2)
        {
            throw new NotImplementedException();
        }
    }
    #endregion

    #region Dependency injection
    interface IDatabase
    {
        void GetData(string str);
    }

    class Database : IDatabase
    {
        public void GetData(string str)
        {
            Console.WriteLine(str);
        }
    }

    class Service
    {
        public Client client;
        public Product product;
        public Service()
        {
            Database context = new Database();
            client = new Client(context);
            product = new Product(context);
        }
    }

    class Product
    {
        private readonly IDatabase _context;
        public Product(IDatabase context)
        {
            _context = context;
        }

        public void GetProductData()
        {
            _context.GetData("Product info");
        }
    }

    class Client
    {
        private readonly IDatabase _context;
        public Client(IDatabase context)
        {
            _context = context;
        }

        public void GetClientData()
        {
            _context.GetData("Client info");
        }
    }
    #endregion
    #endregion


    #region Quiz,Exception
    //class Student
    //{
    //    public string Name { get; set; }
    //    private int Age { get; set; }
    //    public Student()
    //    {
    //        Age = 10;
    //    }

    //    public void SetAge(int age)
    //    {
    //        if(!(age<146 && age > 0))
    //        {
    //            throw new StuException(age);
    //        }
    //        Age = age;
    //    }
    //}

    class StuException:Exception
    {
        public StuException(int age):base($"{age} '0' ve '146' arasinda deyil")
        {
        }
    }
    #endregion
}
