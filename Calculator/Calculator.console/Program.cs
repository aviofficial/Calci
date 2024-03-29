﻿using System;
using System.IO;
using System.Reflection;
using System.Resources;

namespace Calculator.Console
{
    class Program
    {
        static readonly string _menuFile = "Calculator.console.MainMenu.txt";
        static readonly string _expressionMenuFile = "Calculator.console.ExpressionMenu.txt";
        static Lib.CalcEngine _calculation = new Lib.CalcEngine();
        static void Main(string[] args)
        {
            //if command line argument is there
            if (args.Length > 0)
            {
                System.Console.WriteLine(console.MessageToUser.exp+String.Join("", args));
                try
                {
                    System.Console.WriteLine(console.MessageToUser.ans+_calculation.Evaluate((string.Join("", args))));
                }
                catch (Exception e) {
                    System.Console.WriteLine(e.Message);
                }
                System.Console.WriteLine(console.MessageToUser.continuePrompt);
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
                ReadData(_menuFile);
                operation = System.Console.ReadLine().Trim();

                if (operation == "0")
                {
                    System.Environment.Exit(0);
                }
                else if (operation == "e") {
                    ExpressionEvaluator();
                }
                bool validity = true;
                do
                {
                    try
                    {
                        if (_calculation.IsUnary(operation))
                        {
                            System.Console.WriteLine(console.MessageToUser.askOperand);
                            double op1 = Convert.ToDouble(System.Console.ReadLine());
                            System.Console.WriteLine(console.MessageToUser.ans + _calculation.Calculate(operation, op1));
                        }
                        else if (_calculation.IsBinary(operation))
                        {
                            System.Console.WriteLine(console.MessageToUser.askOperand);
                            double op1 = Convert.ToDouble(System.Console.ReadLine());
                            System.Console.WriteLine(console.MessageToUser.askOperand2);
                            double op2 = Convert.ToDouble(System.Console.ReadLine());
                            System.Console.WriteLine(console.MessageToUser.ans + _calculation.Calculate(operation, op1, op2));
                            
                        }
                        validity = true;
                    }
                    catch (FormatException)
                    {
                        validity = false;
                        System.Console.WriteLine(console.MessageToUser.OpInvalid);
                    }
                } while (validity == false);

                System.Console.WriteLine(console.MessageToUser.continuePrompt);
                choice = System.Console.ReadLine();
            } while (choice.ToLower() == "y" || choice.ToLower() == "yes");
        }
        //method to display info about expression evaluator use which displays answer when a expression is input.
        static void ExpressionEvaluator() {
            System.Console.Clear();
            System.Console.ForegroundColor = ConsoleColor.Green;

            ReadData(_expressionMenuFile);
            string expression = System.Console.ReadLine().Trim();

            try
            {
                System.Console.WriteLine(console.MessageToUser.ans + _calculation.Evaluate(expression));
            }
            catch (Exception e) {
                System.Console.WriteLine(e.Message);
            }
        }

        //reads data from embedded resources
        private static void ReadData(string fileName) {
            Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(fileName);
            StreamReader reader = new StreamReader(stream);
            string result = reader.ReadToEnd();
            System.Console.WriteLine(result);
        }
    }
}
