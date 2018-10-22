using System;
using System.Collections.Generic;
using System.Text;

namespace Midterm_project
{
   public class Calc
    {
        // Default constructors
        public Calc() { }

        //constructors
        public Calc(double[] num)
        {
            this.number = num;
        }


        //get the mean
        public double GetMean(double[] arr, int size)
        {
            double sum = 0;
            double average = 0;
            for (int i = 0; i < size; i++)
            {
                sum += arr[i];
            }
            average = sum / size;
            Console.WriteLine("The mean of array is : " + average);
            return average;
        }

        //get the median
        public double GetMedian(double[] arr)
        {
 
            double[] sortedArr = (double[])arr.Clone();
            Array.Sort(sortedArr);

            int size = sortedArr.Length;
            int mid = size / 2;
            double median = (size % 2 != 0) ? (double)sortedArr[mid] : ((double)sortedArr[mid] + (double)sortedArr[mid - 1]) / 2;

            Console.WriteLine("The median of array is : " + median);
            return median;
        }

        //
        public double[] number { get; set; }
    }
}
