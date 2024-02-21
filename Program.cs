using System;
using AIContinuous;

double MyFunction(double x)
{
    return Math.Pow((x - 1), 2) + Math.Sin(Math.Pow(x, 3));
}

// double MyDer(double x)
// {
//     return x / (2.0 * Math.Sqrt(Math.Abs(x))) + (Math.Sqrt(Math.Abs(x)) - 5.0);
// }

var date = DateTime.Now;
var sol = 0.0;

// date = DateTime.Now;
// sol = Root.Bisection(MyFunction, 0, 10);
// Console.WriteLine($"{sol} | {(DateTime.Now - date).TotalMilliseconds}");

// date = DateTime.Now;
// sol = Root.FalsePosition(MyFunction, 0, 10);
// Console.WriteLine($"{sol} | {(DateTime.Now - date).TotalMilliseconds}");

// date = DateTime.Now;
// sol = Root.Newton(MyFunction, double (double x) => diff.Differentiate(MyFunction, x), 10);
// Console.WriteLine($"{sol} | {(DateTime.Now - date).TotalMilliseconds}");

date = DateTime.Now;
sol = Global.FindMinimum(MyFunction, 10);
Console.WriteLine($"{sol} | {(DateTime.Now - date).TotalMilliseconds}");
