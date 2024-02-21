using System;
using System.Security.Cryptography.X509Certificates;

namespace AIContinuous;

public static class Root
{
    public static double Bisection(Func<double, double> function, double a, double b, double atol = 1e-4, int maxIter = 1000)
    {
        var date = DateTime.Now;
        double diff = 0;

        for(int i = 0; i < maxIter; i++)
        {
            diff = a + ((b - a)/2);

            if(function(diff) * function(b) < 0)
                a = diff;
            else
                b = diff;
                
            if(Math.Abs(function(diff)) < atol)
                break;
        }

        Console.WriteLine((DateTime.Now - date).TotalMilliseconds);
        return diff;
    }

    public static double FalsePosition(Func<double, double> function, double a, double b, double atol = 1e-4, int maxIter = 1000)
    {
        var date = DateTime.Now;

        double c = 0;
        double m = 0;
        double k = 0;

        for (int i = 0; i < maxIter; i++)
        {
            var fa = function(a);
            var fb = function(b);
            m =  (fb - fa) / (b - a);
            k = m * (-a) + fa;
            c = -k / m;

            if(function(c) * fb < 0)
                a = c;
            else
                b = c;

            if(Math.Abs(function(c)) < atol)
                break;
        }

        Console.WriteLine((DateTime.Now - date).TotalMilliseconds);
        return c;
    }
}
