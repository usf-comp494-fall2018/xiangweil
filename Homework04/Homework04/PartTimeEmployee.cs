// Written by: Shawn
using System;
using System.Collections.Generic;
using System.Text;

namespace Homework04
{
    public class PartTimeEmployee : Employee
    {
        // Default constructors
        public PartTimeEmployee() { }
        // constructors
        public PartTimeEmployee(string fname, string lname, string ecode, DateTime htime, int hrate)
        {
            this.FirstName = fname;
            this.LastName = lname;
            this.EmployeeCode = ecode;
            this.DateHired = htime;
            this.HourlyRate = hrate;
        }

        // methods
        public new void WriteToConsole()
        {
            base.WriteToConsole();
            Console.WriteLine("HOURLY RATE: " + HourlyRate);
            Console.WriteLine("==============================");
        }

        // Properties
        public int HourlyRate { get; set; }
    }
}
