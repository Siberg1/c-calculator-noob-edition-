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
    static double ReadAndValidateNumber(string prompt)
    {
        double num;
        Console.Write(prompt);
        while (!double.TryParse(Console.ReadLine(), out num))
        {
            Console.Write("This is not valid input. Please enter a numeric value: ");
        }
        return num;
    }

    static void Main(string[] args)
    {
        bool endApp = false;
        while(!endApp)
        {
            
            double result = 0;


            double cleanNum1 = ReadAndValidateNumber("Type a first number, and then press Enter: ");
            double cleanNum2 = ReadAndValidateNumber("Type a second number, and then press Enter: ");

            Console.WriteLine("Choose an operator from the following list: \ta - Add \ts - Subtract \tm - Multiply \td - Divide \nYour option?");
            string? op = Console.ReadLine();

            if (op == null || !Regex.IsMatch(op, "^[asmd]$"))
            {
                Console.WriteLine("Error: Unrecognized input.");
                continue;  // Пропуск выполнения операции, если ввод некорректен
            }
            else
            { 
                try
                {
                    result = Calculator.DoOperation(cleanNum1, cleanNum2, op);
                    if (double.IsNaN(result))
                    {
                        Console.WriteLine("This operation will result in a mathematical error.\n");
                    }
                    else Console.WriteLine("Your result: {0:0.##}\n", result);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Oh no! An exception occurred trying to do the math.\n - Details: " + e.Message);
                }
            }

            //Цикл, который просит пользователя продолжить или завершить программу   
            Console.Write("Would you like to continue? (Y = yes, N = No): ");
            string? input = Console.ReadLine();
            if (input == null || input.ToUpper() != "Y")
            {
                Console.WriteLine("Bye!");
                break;
            }              
        }
    }           
}
