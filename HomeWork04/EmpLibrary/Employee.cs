using System;

namespace EmpLibrary
{
    public class Employee
    {
        // Default constructors
        public Employee()
        {
            FirstName = "Default first name";
            LastName = "Default last name";
            EmployeeCode = "0";
            DateHired = new DateTime();
        }
        // Constructors
        public Employee(string fname, string lname, string ecode, DateTime htime)
        {
            this.FirstName = fname;
            this.LastName = lname;
            this.EmployeeCode = ecode;
            this.DateHired = htime;
        }

        // Methods
        public void WriteToConsole()
        {
            Console.WriteLine("==============================");
            Console.WriteLine("EMPLOYEE NAME: " + FirstName + " " + LastName);
            Console.WriteLine("==============================");
            Console.WriteLine("EMPLOYEE ID: " + EmployeeCode);
            Console.WriteLine("==============================");
            Console.WriteLine("HIRED DATE: " + DateHired);
            Console.WriteLine("==============================");

        }

        // Properties
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmployeeCode { get; set; }
        public DateTime DateHired { get; set; }

    }


        public class SalariedEmployee : Employee
        {
            // Default constructors
            public SalariedEmployee() { }

            // constructors
            public SalariedEmployee(string fname, string lname, string ecode, DateTime htime, int asalary)
            {
                this.FirstName = fname;
                this.LastName = lname;
                this.EmployeeCode = ecode;
                this.DateHired = htime;
                this.AnnualSalary = asalary;
            }

            // Methods
            public void WriteToConsole()
            {
                base.WriteToConsole();
                Console.WriteLine("ANNUAL SALARY: " + AnnualSalary);
                Console.WriteLine("==============================");
            }

            // Properties
            public int AnnualSalary { get; set; }
        }

    

        public class PartTimeEmployee : Employee
        {
            // Default constructors
            public PartTimeEmployee() { }
            // Constructors
            public PartTimeEmployee(string fname, string lname, string ecode, DateTime htime, int hrate)
            {
                this.FirstName = fname;
                this.LastName = lname;
                this.EmployeeCode = ecode;
                this.DateHired = htime;
                this.HourlyRate = hrate;
            }

            // Methods
            public void WriteToConsole()
            {
                base.WriteToConsole();
                Console.WriteLine("HOURLY RATE: " + HourlyRate);
                Console.WriteLine("==============================");
            }

            // Properties
            public int HourlyRate { get; set; }
        }
    
}



