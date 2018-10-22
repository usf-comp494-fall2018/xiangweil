using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace Midterm_project
{
    class Program
    {
        static void Main(string[] args)
        {
            string dir = System.IO.Path.GetDirectoryName(
             System.Reflection.Assembly.GetExecutingAssembly().Location);
            string filePath = dir + @"\CalcInput.txt";

            if (System.IO.File.Exists("CalcInput.txt") == true)
            {
               string text = System.IO.File.ReadAllText(filePath);
               int lines = File.ReadAllLines(filePath).Length;
               string[] rows = text.Split("\r".ToCharArray());
               double[] parametersArray = new double[lines];

               for (int i = 0; i < lines; i++)
               {
                double.TryParse(rows[i].ToString(), out parametersArray[i]);
               }
                Calc data = new Calc(parametersArray);
                data.GetMean(parametersArray, lines);
                data.GetMedian(parametersArray);
  
            }
            else
            {
                Console.WriteLine("File not found");
            }
        }
    }
}
