using System;
using AIContinuous;

double MyFunction(double x)
{
    return Math.Sqrt(x) - Math.Cos(x);
}

var sol = Root.FalsePosition(MyFunction, 0, 200);

Console.WriteLine(sol);