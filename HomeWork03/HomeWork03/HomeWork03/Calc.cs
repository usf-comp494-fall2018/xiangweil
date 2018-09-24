using System;

namespace HomeWork03
{
    public class Calc
    {
        int number1;

        int number2;

        int result;
        public Calc()
        {
        }

        public Calc(int num01, int num02)
        {
            number1 = num01;
            number2 = num02;
        }

        // Add
        public int Add(int num01, int num02)
        {
            result = (this.number1 + this.number2);
            return result;
        }

        // Subtract
        public int Subtract(int num01, int num02)
        {
            if (number1 > number2)
            {
                return number1 - number2;
            }
            return number2 - number1;
        }

        // Divide
        public int Divide(int num01, int num02)
        {
            return num01 / num02;
        }

        // Multiply
        public int Multiply(int num01, int num02)
        {
            return num01 * num02;
        }
    }
}
