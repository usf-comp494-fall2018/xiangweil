
/*//////////////////////////////////////////////////////////////////////////////////////////////
HomeWork #2: Your program should take an array of strings and check each element for the name “Waldo”. 
If you find “Waldo” print out a message stating that you have found Waldo and at which position you found it. 

Title:				Home Work #2
Writeen by:			Shawn/Xiangwei Li
Writeen for:		COMP 494A C#
Date				09/12/2018
Enviorment:			VS 2017

///////////////////////////////////////////////////////////////////////////////////////////////*/
///
using System;

namespace HomeWork02
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] names = { "Tom", "Bob", "Dana", "Julie", "Sarah", "Fred", "Waldo", "Jenny", "Cathy" };
            var target = "Waldo";
            int pos = Array.IndexOf(names, target); // find the position by IndexOf method
            Console.WriteLine("Waldo has been found at position: " + pos); 
        }
    }
}
