using System;
using AIContinuous;

double Rosembrock(double[] x)
{
    double value = 0.0;
    int n = x.Length - 1;

    for(int i = 0; i < n; i++)
        value += 100.0 * ((x[i + 1] - x[i] * x[i]) * (x[i + 1] - x[i] * x[i])) + ((1 - x[i]) * (1 - x[i]));
    
    return value;
}

List<double[]> bounds = new()
{
    new double[] {-10.0, 10.0},
    new double[] {-10.0, 10.0},
    new double[] {-10.0, 10.0},
    new double[] {-10.0, 10.0},
    new double[] {-10.0, 10.0},
    new double[] {-10.0, 10.0},
    new double[] {-10.0, 10.0},
    new double[] {-10.0, 10.0},
    new double[] {-10.0, 10.0},
    new double[] {-10.0, 10.0}
};

var date = DateTime.Now;

date = DateTime.Now;
var diffEvolution = new DiffEvolution(Rosembrock, bounds, 1000);

var res = diffEvolution.Optimize(100);

Console.WriteLine($"{res[0]}, {res[1]} | {(DateTime.Now - date).TotalMilliseconds}");
