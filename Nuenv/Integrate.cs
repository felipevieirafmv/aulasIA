namespace AIContinuous.Nuenv;

public static class Integrate
{
    public static double Romberg(double[] x, double[] y)
    {
        if(x.Length != y.Length)
            throw new ArgumentException("X and Y must have the same length");
        double sum = 0.0;
        var size = x.Length - 1;

        for(int i = 0; i < size; i++)
            sum += 0.5 * (x[i + 1] - x[i]) * (y[i] + y[i + 1]);

        return sum;
    }
}