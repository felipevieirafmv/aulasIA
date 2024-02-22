using System;
using AIContinuous;

double MyFunction(double[] x)
{
    // return x[0] * x[0] + x[1] * x[1];
    // return Math.Pow((x[0] + x[1] * 2 - 7), 2) + Math.Pow((x[0] * 2 + x[1] - 5), 2);
    double value = 0.0;
    int n = x.Length - 1;

    for(int i = 0; i < n; i++)
        value += 100.0 * ((x[i + 1] - x[i] * x[i]) * (x[i + 1] - x[i] * x[i])) + ((1 - x[i]) * (1 - x[i]));
    
    return value;
}

// double MyDer(double x)
// {
//     return x / (2.0 * Math.Sqrt(Math.Abs(x))) + (Math.Sqrt(Math.Abs(x)) - 5.0);
// }

var date = DateTime.Now;
double[] sol = new double[2];

// date = DateTime.Now;
// sol = Root.Bisection(MyFunction, 0, 10);
// Console.WriteLine($"{sol} | {(DateTime.Now - date).TotalMilliseconds}");

// date = DateTime.Now;
// sol = Root.FalsePosition(MyFunction, 0, 10);
// Console.WriteLine($"{sol} | {(DateTime.Now - date).TotalMilliseconds}");

// date = DateTime.Now;
// sol = Root.Newton(MyFunction, double (double x) => diff.Differentiate(MyFunction, x), 10);
// Console.WriteLine($"{sol} | {(DateTime.Now - date).TotalMilliseconds}");

double[] initialGuess = new double[]{10.0, 10.0};

date = DateTime.Now;
sol = Optimize.GradientDescent(MyFunction, initialGuess, 1e-7, 1e-9);
Console.WriteLine($"{sol[0]}, {sol[1]} | {(DateTime.Now - date).TotalMilliseconds}");
