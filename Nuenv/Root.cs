namespace AIContinuous.Nuenv;

public static class Root
{
    public static double Bisection(Func<double, double> function, double a, double b, double atol = 1e-4, int maxIter = 1000)
    {
        double diff = 0;

        for(int i = 0; i < maxIter; i++)
        {
            diff = a + ((b - a)/2);

            if(function(diff) * function(b) < 0)
                a = diff;
            else
                b = diff;
                
            if(System.Math.Abs(function(diff)) < atol)
                break;
        }

        return diff;
    }

    public static double FalsePosition(Func<double, double> function, double a, double b, double atol = 1e-4, int maxIter = 1000)
    {
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

            if(System.Math.Abs(function(c)) < atol)
                break;
        }

        return c;
    }

    public static double Newton(
        Func<double, double> function,
        Func<double, double> der,
        double x0,
        double atol = 1e-4,
        int maxIter = 10000 )
    {
        double xp = x0;

        for(int i = 0; i < maxIter; i++)
        {
            var fp = function(xp);
            xp -= fp / der(xp);

            if(System.Math.Abs(fp) < atol)
                break;
        }

        return xp;
    }
}
