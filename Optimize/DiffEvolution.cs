using AIContinuous.Utils;

namespace AIContinuous.Optimize;

public class DiffEvolution
{
    protected Func<double[], double> Fitness { get; }
    protected Func<double[], double> Restriction { get; }
    protected int Dimension { get; }
    protected double MutationMin { get; set; }
    protected double MutationMax { get; set; }
    protected double Recombination { get; set; }
    protected int NPop { get; }
    protected List<double[]> Individuals { get; set; }
    protected int BestIndividualIndex { get; set; }
    protected List<double[]> Bounds { get; }
    private double[] IndividualsRestrictions { get; set; }
    private double[] IndividualsFitness { get; set; }

    public DiffEvolution(
        Func<double[], double> fitness,
        Func<double[], double> restriction,
        List<double[]> bounds,
        int npop,
        double mutationMin = 0.5,
        double mutationMax = 0.9,
        double recombination = 0.8)
    {
        this.Fitness = fitness;
        this.Restriction = restriction;
        this.Dimension = bounds.Count;
        Individuals = new List<double[]>(NPop);
        this.NPop = npop;
        this.Bounds = bounds;
        this.MutationMin = mutationMin;
        this.MutationMax = mutationMax;
        this.Recombination = recombination;
        this.IndividualsRestrictions = new double[NPop];
        this.IndividualsFitness = new double[NPop];
    }

    private void GeneratePopulation()
    {
        int dimension = Dimension;

        for(int i = 0; i < NPop; i++)
        {
            Individuals.Add(new double[dimension]);

            for(int j = 0; j < dimension; j++)
                Individuals[i][j] = Maths.Rescale(Random.Shared.NextDouble(), Bounds[j][0], Bounds[j][1]);

            IndividualsRestrictions[i] = Restriction(Individuals[i]);
            IndividualsFitness[i] = IndividualsRestrictions[i] <= 0.0 ? Fitness(Individuals[i]) : double.MaxValue;
        }
        FindBestIndividual();
    }

    private void FindBestIndividual()
    {
        var fitnessBest = IndividualsFitness[BestIndividualIndex];

        for(int i = 0; i < NPop; i++)
        {
            if(IndividualsFitness[i] < fitnessBest)
            {
                BestIndividualIndex = i;
                fitnessBest = IndividualsFitness[i];
            }
        }

        IndividualsFitness[BestIndividualIndex] = fitnessBest;
    }

    private void EnsureBounds(double[] individual)
    {
        for(int i = 0; i < Dimension; i++)
        {
            if(individual[i] < Bounds[i][0] || individual[i] > Bounds[i][1])
                individual[i] = Maths.Rescale(Random.Shared.NextDouble(), Bounds[i][0], Bounds[i][1]);
        }
    }

    private double[] Mutate(int index)
    {
        int individualRand1;
        int individualRand2;

        do individualRand1 = Random.Shared.Next(NPop);
        while(individualRand1 == index);

        do individualRand2 = Random.Shared.Next(NPop);
        while(individualRand1 == individualRand2);

        var newIndividual = (double[])Individuals[BestIndividualIndex].Clone();
        for(int i = 0; i < Dimension; i++)
        {
            newIndividual[i] += Maths.Rescale(Random.Shared.NextDouble(), MutationMin, MutationMax)
                                * (Individuals[individualRand1][i] - Individuals[individualRand2][i]);
        }

        return newIndividual;
    }

    protected double[] Crossover(int index)
    {
        var trial = Mutate(index);
        var trial2 = (double[])Individuals[index].Clone();

        for(int i = 0; i < Dimension; i++)
        {
            if(!(Random.Shared.NextDouble() < Recombination) || (i == Random.Shared.Next(Dimension)))
                trial2[i] = trial[i];
        }

        EnsureBounds(trial2);

        return trial2;
    }
    
    protected void Iterate()
    {
        for(int i = 0; i < NPop; i++)
        {
            var trial = Crossover(i);
            var restTrial = Restriction(trial);

            double fitnessTrial = restTrial <= 0.0 ? Fitness(trial) : double.MaxValue;

            var restIndividual = IndividualsRestrictions[i];

            if((restIndividual > 0.0 && (restTrial < restIndividual))
                || (restTrial <= 0.0 && restIndividual > 0.0)
                || (restTrial <= 0.0 && fitnessTrial < IndividualsFitness[i]))
                {
                    Individuals[i] = trial;
                    IndividualsRestrictions[i] = restTrial;
                    IndividualsFitness[i] = fitnessTrial;
                }
        }

        FindBestIndividual();
    }

    public double[] Optimize(int n)
    {
        GeneratePopulation();

        for(int i = 0; i < n; i++)
        {
            System.Console.WriteLine($"Generation {i + 1}");
            Iterate();
        }

        return Individuals[BestIndividualIndex];
    }
}
