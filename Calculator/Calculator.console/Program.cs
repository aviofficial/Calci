using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Console
{
    class Program
    {
        static readonly string _menuFile = @".\MainMenu.txt";
        static readonly string _expressionMenuFile = @".\ExpressionMenu.txt";
        static Lib.CalcEngine _calculation = new Lib.CalcEngine();
        static void Main(string[] args)
        {
            
            if (args.Length > 0)
            {//if command line argument is there
                System.Console.WriteLine("Expression = {0}", String.Join("", args));
                try
                {
                    System.Console.WriteLine("Answer = {0}", _calculation.Evaluate((string.Join("", args))));
                }
                catch (DivideByZeroException)
                {
                    System.Console.WriteLine("Cannot Divide By Zero");
                }
                catch (Exception e) {
                    System.Console.WriteLine(e.Message);
                }
                System.Console.WriteLine("Do you wish to continue(y/n):--");
                String choice = System.Console.ReadLine().Trim().ToLower();
                switch (choice.ToLower())
                {
                    case "n":
                    case "no":
                        System.Environment.Exit(0);
                        break;
                    case "y":
                    case "yes":
                        MainMenu();
                        break;
                }

            }
            else
            {
                MainMenu();
            }

        }

        //method to display main menu and perform operations according to the user.
        static void MainMenu()
        {
            string operation, choice;
            do
            {
                System.Console.Clear();
                System.Console.ForegroundColor = ConsoleColor.Cyan;
                if (System.IO.File.Exists(_menuFile))
                {
                    System.Console.WriteLine(System.IO.File.ReadAllText(_menuFile));
                }
                else {
                    System.Console.WriteLine("Menu Data File Not Found.");
                }

                operation = System.Console.ReadLine().Trim();

                if (operation == "0")
                {
                    System.Environment.Exit(0);
                }
                else if (operation == "e") {
                    ExpressionEvaluator();
                }

                try
                {
                    if (_calculation.IsUnary(operation))
                    {
                        System.Console.WriteLine("Enter Operand:-");
                        double op1 = Convert.ToDouble(System.Console.ReadLine());
                        System.Console.WriteLine("Answer " + _calculation.Calculate(operation, op1));
                    }
                    else if (_calculation.IsBinary(operation))
                    {
                        System.Console.WriteLine("Enter first operands");
                        double op1 = Convert.ToDouble(System.Console.ReadLine());
                        System.Console.WriteLine("Enter second operands");
                        double op2 = Convert.ToDouble(System.Console.ReadLine());
                        System.Console.WriteLine("Answer: " + _calculation.Calculate(operation, op1, op2));
                    }
                }
                catch (FormatException) {
                    System.Console.WriteLine("!!!!!!Invalid Operand Entered!!!!!");
                        }
                System.Console.WriteLine("Do you wish to continue(y/n):--");
                choice = System.Console.ReadLine();
            } while (choice.ToLower() == "y");
        }
        //method to display info about expression evaluator use which displays answer when a expression is input.
        static void ExpressionEvaluator() {
            System.Console.Clear();
            System.Console.ForegroundColor = ConsoleColor.Green;

            if (System.IO.File.Exists(_expressionMenuFile))
            {
                System.Console.WriteLine(System.IO.File.ReadAllText(_expressionMenuFile));
            }
            else {
                System.Console.WriteLine("Expression Menu Data File Not Found.");
            }
            string expression = System.Console.ReadLine().Trim();

            try
            {
                System.Console.WriteLine("Answer: " + _calculation.Evaluate(expression));
            }
            catch (Exception e) {
                System.Console.WriteLine(e.Message);
            }
        }

    }
}
