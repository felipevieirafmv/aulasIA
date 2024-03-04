namespace AIContinuous.Utils;

public static class Maths
{
    public static double Rescale(double x, double min, double max)
        => (max - min) * x + min;
}