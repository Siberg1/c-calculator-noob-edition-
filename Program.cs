using System.ComponentModel;
using System.Globalization;
using System.Text.RegularExpressions;
class Calculator
{
    public static double DoOperation(double num1, double num2, string op)
    {
    switch (op)
        {
            case"a":
                return num1 + num2;
            case"s":
                return num1 - num2;
            case"m":
                return num1 * num2;
            case"d":
                if (num2 == 0)
                {
                    throw new DivideByZeroException("Division by zero is not allowed.");
                }
                return num1 / num2;

            default:
            throw new ArgumentException("Invalid operator");
        }
    }
}
class Program
{
    static void Main(string[] args)
    {
        
    }
} 
