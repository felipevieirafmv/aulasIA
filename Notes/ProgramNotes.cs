// using System;
// using AIContinuous;
// // using AIContinuous.Nuenv;
// using AIContinuous.Optimize;
// using AIContinuous.Utils;
// using AIDiscrete.Search;

// // double Rosembrock(double[] x)
// // {
// //     double value = 0.0;
// //     int n = x.Length - 1;

// //     for(int i = 0; i < n; i++)
// //         value += 100.0 * ((x[i + 1] - x[i] * x[i]) * (x[i + 1] - x[i] * x[i])) + ((1 - x[i]) * (1 - x[i]));

// //     return value;
// // }

// // var numberOfPoints = 51;
// // var timeData = Space.Geometric(1.0, 1001.0, numberOfPoints).Select(x => x - 1).ToArray();

// // double Simulate(double[] massFlowData)
// // {
// //     var rocket = new Rocket(750.0, System.Math.PI * 0.6 * 0.6 / 4.0, 1916.0, 0.8, timeData, massFlowData);

// //     return rocket.LaunchUntilMax(1e-3);
// // }

// // double FitnessDiffEvol(double[] x) => -1.0 * Simulate(x);

// // double FitnessGD(double[] x)
// // {
// //     var combTotal = Integrate.Romberg(timeData, x);
// //     double penalty = combTotal - 3500.0;
// //     var minimize = -1.0 * Simulate(x);

// //     return minimize + penalty;
// // }

// // List<double[]> bounds = new(numberOfPoints);
// // for(int i = 0; i < numberOfPoints; i++)
// //     bounds.Add(new double[] {0.0, 1000.0});

// // double Restriction(double[] x)
// //     => Integrate.Romberg(timeData, x) - 3500;

// var date = DateTime.Now;

// // var diffEvolution = new DiffEvolution(FitnessDiffEvol, Restriction, bounds, 15 * numberOfPoints);

// // var sol = diffEvolution.Optimize(10000);

// // foreach(var i in sol)
// //     System.Console.WriteLine(i);

// // System.Console.WriteLine($"Altitude maxima: {Simulate(sol)}");

// // System.Console.WriteLine($"Tempo total: {(DateTime.Now - date).TotalMilliseconds}");

// var list = new List<float> {1.8f, 2.5f, 3.8f, 5.4f, 7.4f, 8.1f, 9.3f};

// date = DateTime.Now;
// var sol = Search.BinarySearch(list, 5.4f);
// System.Console.WriteLine((DateTime.Now - date).TotalMilliseconds);

// Console.WriteLine(sol);
