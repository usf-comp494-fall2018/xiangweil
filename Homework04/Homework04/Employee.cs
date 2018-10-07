// Written by: Shawn
using System;
using System.Collections.Generic;
using System.Text;

namespace Homework04
{
    public class Employee
    {
        public Employee()
        {
            FirstName = "Default first name";
            LastName = "Default last name";
            EmployeeCode = "0";
            DateHired = new DateTime();
        }
        // constructors
        public Employee(string fname, string lname, string ecode, DateTime htime)
        {
            this.FirstName = fname;
            this.LastName = lname;
            this.EmployeeCode = ecode;
            this.DateHired = htime;
        }

        // methods
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
}
