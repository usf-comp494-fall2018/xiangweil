using System;
using System.Collections.Generic;
using System.Text;

namespace Homework4
{
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

        // methods
        public new void WriteToConsole()
        {
            base.WriteToConsole();
            Console.WriteLine("ANNUAL SALARY: " + AnnualSalary);
            Console.WriteLine("==============================");
        }

        // Properties
        public int AnnualSalary { get; set; }
    }
}
