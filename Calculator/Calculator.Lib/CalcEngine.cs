using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Calculator.Lib
{
    public class CalcEngine : ICalcEngineInterface
    {
        readonly string[] _operatorsBinary = { "add", "sub", "mul", "div", "+", "-", "*", "/", "^", "logx", "root", "modx" };

        private enum _operatorsUnary { sin, cos, tan, log, loge, sini, cosi, tani, sqrt, cbrt, sqr, sign, cube, rcpl };
        #region Arithmetic Operations
        //Method for Addition operation
        public double Add(double a, double b) {
            return (a + b);
        }
        //Method for Subtraction Operation
        public double Subtract(double a, double b) {
            return (a - b);
        }
        //Method for Multiplication operation
        public double Multiply(double a, double b) {
            return (a * b);
        }
            //Method for Division
        public double Division(double a,double  b) {
            return (a / b);
        }
            //Method that returns remainder
        public int Mod(int a, int b) {
            return (a % b);
        }
            //Method to return the number with its sign changed
        public double Sign(double a) {
            return (-a);
        }


        #endregion

        #region Logarithmic Operations
            //Method to returns Log base 10 of a number
        public double Log10(double a) {
            return (Math.Log10(a));
        }
            //Method that return log with a custom base of a number
        public double LogX(double x, double baseX) {
            return (Math.Log(x, baseX));
        }
            //Method to returns Logarithm with base e of a number
        public double Ln(double a) {
            return (Math.Log(a));
        }
        #endregion

        #region Exponential and Unary Operations

            //Mehtod returns a raised to the power b.
        public double Power(double a, double b) {
            return (Math.Pow(a, b));
        }
            //Method returns x'th root of a number 
        public double XthRoot(double a, double b) {
            return (Math.Pow( a, 1.0 / b));
        }
            //returns reciprocal of a number
        public double Reciprocal(double a) {
            return (1 / a);
        }
        #endregion

        #region Trignometric Operations
            //returns sine of an angle
        public double SinX(double a) {
            return (Math.Sin(a));
        }
            //returns Cosine of an angle
        public double CosX(double a)
        {
            double temp=Math.Cos(a);
            if(temp>0 && temp<0.0000000001)
            {
                return (0);
            }
            return(temp);
        }
            //returns tangent of an angle
        public double TanX(double a)
        {
            return (Math.Sin(a)/CosX(a));
        }
            //returns the angle whose sine value is given
        public double SinInverse(double a)
        {
            return (Math.Asin(a));
        }
            //returns the angle whose cosine value is given
        public double CosInverse(double a)
        {
            return (Math.Acos(a));
        }
            //returns the angle whose tangent value is given
        public double TanInverse(double a) {
            return (Math.Atan(a));
        }
        //coverts degree to radians
        public double ToRadians(double a) {
            return (a * (Math.PI / 180));
        }
        //coverts radians to degree
        public double ToDegree(double a) {
            return (a * (180 / Math.PI));
        }
        #endregion
        
        //method which calls specific function according to the oepration and returns the result.
        public double Calculate(string operation, double operand1, double operand2 = 0)
        {
            switch (operation)
            {
                case "+":
                case "add":
                    return (Add(operand1, operand2));
                case "-":
                case "sub":
                    return (Subtract(operand1, operand2));
                case "*":
                case "mul":
                    return (Multiply(operand1, operand2));
                case "/":
                case "div":
                    if (operand2 == 0)
                    {
                        throw new DivideByZeroException();
                    }
                    else
                    {
                        return (Division(operand1, operand2));
                    }
                case "modx":
                    if (operand2 == 0)
                    {
                        throw new DivideByZeroException();
                    }
                    else
                    {
                        return (Mod(Convert.ToInt32(operand1), Convert.ToInt32(operand2)));
                    }
                case "sign":
                    return (Sign(operand1));
                case "log":
                    return (Log10(operand1));
                case "logx":
                    return (LogX(operand1, operand2));
                case "loge":
                    return (Ln(operand1));
                case "sqr":
                    return (Power(operand1, 2));
                case "cube":
                    return (Power(operand1, 3));
                case "^":
                case "pow":
                    return (Power(operand1, operand2));
                case "sqrt":
                    return (XthRoot(operand1, 2));
                case "cbrt":
                    return (XthRoot(operand1, 3));
                case "root":
                    return (XthRoot(operand1, operand2));
                case "sin":
                    return (SinX(ToRadians(operand1)));
                case "cos":
                    return (CosX(ToRadians(operand1)));
                case "tan":
                    return (TanX(ToRadians(operand1)));
                case "sini":
                    return (ToDegree(SinInverse(operand1)));
                case "cosi":
                    return (ToDegree(CosInverse(operand1)));
                case "tani":
                    return (ToDegree(TanInverse(operand1)));
                case "rcpl":
                    return (Reciprocal(operand1));
                default:
                    Console.WriteLine("\nInvaid Operation");
                    return (0);
            }
        }

        //returns true if operation is valid operation requires one operand
        public bool IsUnary(string operation) {
            
            return(System.Enum.IsDefined(typeof(_operatorsUnary),operation)) ;
        }
        //returns true if operation is valid requires two operands
        public bool IsBinary(string operation) {
            return(_operatorsBinary.Contains(operation)) ;
        }

        //evaluates the expression given and returns the result
        public string Evaluate(string expression) {
            
            if (expression.Length == 0) {
                return ("0");
            }
            
            Stack<string> operators = new Stack<string>();
            Stack<double> operands = new Stack<double>();
            expression = expression.ToLower();
            expression = System.Text.RegularExpressions.Regex.Replace(expression, @"(\/|\*)(\+|\-)([0-9\.]*)", @"$1(0$2$3)");

            for (int i = 0; i < expression.Length; i++) {
               //loop to parse through the expression
                if (expression[i] == ' ') {
                    //ignoring if current character is a space
                    continue;
                }

                if (expression[i] >= '0' && expression[i] <= '9')
                {
                    //if current character is a number push it on operands
                    StringBuilder buffer = new StringBuilder();
                    //there may be many digits of a number or a decimal
                    while (i < expression.Length && (expression[i] >= '0' && expression[i] <= '9' || expression[i] == '.'))
                    {
                        if (expression[i] == '.')
                        {
                            if (buffer.ToString().Contains('.'))
                            {
                                throw new Exception("InvalidInput");
                            }
                        }
                        buffer.Append(expression[i++]);
                    }
                    i--;
                    operands.Push(double.Parse(buffer.ToString()));
                }
                else if (expression[i] == '(')
                {
                    //if current character is a opening bracket push it to operator stack
                    operators.Push(expression[i].ToString());
                }

                else if (expression[i] == ')')
                {//checks for closing brackets
                    while (operators.Peek() != "(")
                    {//performs all operation till an opening bracket is encountered
                        string operation = operators.Pop();
                        operands.Push(PerformOperation(operation, ref operands));

                    }
                    operators.Pop();
                }

                else if (IsBinary(expression[i].ToString()))
                {
                    while (operators.Count > 0 && (Precedence(operators.Peek()) >= Precedence(expression[i].ToString())))
                    {
                        string operation = operators.Pop();
                        operands.Push(PerformOperation(operation, ref operands));
                    }
                    operators.Push(expression[i].ToString());
                }
                else if (expression[i] == '%') {
                    //percentage operation implementation
                    if (operators.Count > 0)
                    {

                        if (operators.Peek() == "+" || operators.Peek() == "-")
                        {
                            double op2 = operands.Pop();
                            double op1 = operands.Peek();
                            operands.Push(op1 * op2 / 100);
                        }
                        else if (operators.Peek() == "*" || operators.Peek() == "/")
                        {
                            double op2 = operands.Pop();
                            operands.Push(op2 / 100);
                        }
                    }
                    else {
                        operands.Push(operands.Pop() / 100);
                    }
                }
                else if (expression.Length - i > 4 && IsBinary(expression.Substring(i, 4)))
                {
                    operators.Push(expression.Substring(i, 4));
                }
                else if (expression.Length - i > 4 && IsUnary(expression.Substring(i, 4)))
                {
                    operators.Push(expression.Substring(i, 4));
                }

                else if (expression.Length - i > 3 && IsUnary(expression.Substring(i, 3)))
                {
                    operators.Push(expression.Substring(i, 3));
                }
            }
            while (operators.Count > 0)
            {//perform operations till operator stack is empty
                string operation = operators.Pop();
                operands.Push(PerformOperation(operation,ref operands));       
            }
            return (operands.Pop().ToString());
        }

        //Checks for type of operations calls calculate method accordingly
        double PerformOperation(string operation,ref Stack<double> operands) {
            if (IsUnary(operation))
            {
                double temp = Calculate(operation, operands.Pop());
                if (double.IsInfinity(temp))
                {
                    throw new InfinityAnswerException();
                }
                else if (double.IsNaN(temp))
                {
                    throw new Exception("Invalid Input");
                }
                else {
                    return (temp);
                }
            }
            try
            {
                double op2 = operands.Pop();
                double op1 = operands.Pop();
                return (Calculate(operation, op1, op2));
            }
            catch (Exception) {
                throw new Exception("Invalid Operation");
            }
                
        }
        
        //returns precedence of an operator
        int Precedence(string op) {
            
            switch (op) {
                case "$":
                    return (0);
                case "+":
                case "-":
                    return (1);
                case "*":
                case "modx":
                case "/":
                    return (2);
                case "^":
                    return (3);
                case "log":
                case "sin":
                case "cos":
                case "tan":
                case "loge":
                case "sini":
                case "cosi":
                case "tani":
                case "sqrt":
                case "cbrt":
                case "sqr":
                case "cube":
                case "rcpl":
                case "sign":
                case "root":
                    return (4);
                case "(":
                    return (0);
                default:
                    return (-1);
            }
        }
    }

    class InfinityAnswerException : Exception
    {
        public InfinityAnswerException()
        { 
        }
        public override string Message {
            get { return ("Answer Reached Infinity"); }
        }
    }
}

