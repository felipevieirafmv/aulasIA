using System;
using AIContinuous;

double MyFunction(double x)
{
    return (Math.Sqrt(Math.Abs(x)) - 5) * x + 10;
}

double MyDer(double x)
{
    return (1 / (2 * Math.Sqrt(Math.Abs(x)))) * x + (Math.Sqrt(Math.Abs(x)) - 5);
}

var date = DateTime.Now;
var sol = 0.0;

date = DateTime.Now;
sol = Root.Bisection(MyFunction, 0, 10);
Console.WriteLine($"{sol} | {(DateTime.Now - date).TotalMilliseconds}");

date = DateTime.Now;
sol = Root.FalsePosition(MyFunction, 0, 10);
Console.WriteLine($"{sol} | {(DateTime.Now - date).TotalMilliseconds}");

date = DateTime.Now;
sol = Root.Newton(MyFunction, MyDer, 10);
Console.WriteLine($"{sol} | {(DateTime.Now - date).TotalMilliseconds}");