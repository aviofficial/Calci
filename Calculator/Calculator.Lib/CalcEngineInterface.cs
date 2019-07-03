using System;

namespace Calculator.Lib
{
    interface ICalcEngineInterface
    {
        double Add(double a, double b);
        double Subtract(double a, double b);
        double Multiply(double a, double b);
        double Division(double a, double b);
        int Mod(int a, int b);
        double Sign(double a);

        double Power(double a, double b);
        double XthRoot(double a, double b);
        double Reciprocal(double a);

        double LogX(double a, double b);
        double Log10(double a);
        double Ln(double a);

        double SinX(double a);
        double CosX(double a);
        double TanX(double a);
        double SinInverse(double a);
        double CosInverse(double a);
        double TanInverse(double a);
        double ToRadians(double a);
        double ToDegree(double a);

        double Calculate(string operation, double op1, double op2);

        string Evaluate(string expression);

        bool IsBinary(string operation);
        bool IsUnary(string operation);
    }
}
