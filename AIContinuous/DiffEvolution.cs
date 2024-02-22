namespace AIContinuous;

public class DiffEvolution
{
    protected Func<double[], double> Fitness { get; }
    protected int Dimension { get; }
    protected int NPop { get; }
    protected List<double[]> Individuals { get; set; }
    protected int BestIndividualIndex { get; set; }
    protected double BestIndividualFitness { get; set; } = double.MaxValue;
    protected List<double[]> Bounds { get; }

    public DiffEvolution(Func<double[], double> fitness, List<double[]> bounds, int npop)
    {
        this.Fitness = fitness;
        this.Dimension = bounds.Count;
        Individuals = new List<double[]>(NPop);
        this.NPop = npop;
        this.Bounds = bounds;
    }

    private void GeneratePopulation()
    {
        int dimension = Dimension;

        for(int i = 0; i < NPop; i++)
        {
            Individuals[i] = new double[dimension];

            for(int j = 0; j < dimension; j++)
                Individuals[i][j] = Utils.Rescale(Random.Shared.NextDouble(), Bounds[j][0], Bounds[j][1]);
        }
    }

    private void FindBestIndividual()
    {
        var fitnessBest = BestIndividualFitness;

        for(int i = 0; i < NPop; i++)
        {
            var fitnessCurrent = Fitness(Individuals[i]);

            if(fitnessCurrent < fitnessBest)
            {
                BestIndividualIndex = i;
                fitnessBest = fitnessCurrent;
            }
        }

        BestIndividualFitness = fitnessBest;
    }

    public double[] Optimize()
    {
        GeneratePopulation();
        FindBestIndividual();
        
        return Individuals[BestIndividualIndex];
    }
}