using System;


namespace Homework04
{
    class Program
    {
        static void Main(string[] args)
        {
            Employee emp01 = new Employee("Ronaldo", "Cristiano", "60031", new DateTime(2008, 12, 25));
            SalariedEmployee emp02 = new SalariedEmployee("Lionel", "Messi", "10000", new DateTime(1998, 09, 12), 200);
            PartTimeEmployee emp03 = new PartTimeEmployee("David", "Beckham", "00021", new DateTime(2000, 10, 09), 14);

            emp01.WriteToConsole();
            Console.WriteLine("\n");
            emp02.WriteToConsole();
            Console.WriteLine("\n");
            emp03.WriteToConsole();
            Console.WriteLine("\n");

        }
    }
}
