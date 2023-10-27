using System;
using MathNet.Numerics;
using MathNet.Numerics.OdeSolvers;
using MathNet.Numerics.LinearAlgebra;
using System.Numerics;

namespace mathModelingLab5Population
{
    class Program
    {
        static void Main(string[] args)
        {
            double alpha = 0.1;
            double beta = 0.02;
            double delta = 0.01;
            double gamma = 0.1;

            double prey = 40;
            double predator = 9;

            double timeStep = 0.01;
            int steps = 15000;

            List<double> preyList = new List<double>();
            List<double> predatorList = new List<double>();

            for (int i = 0; i < steps; i++)
            {
                double newPrey = prey + timeStep * (alpha * prey - beta * prey * predator);
                double newPredator = predator + timeStep * (delta * prey * predator - gamma * predator);

                prey = newPrey;
                predator = newPredator;

                preyList.Add(prey);
                predatorList.Add(predator);
            }

            DrawGraph(preyList, "Prey");
            DrawGraph(predatorList, "Predator");

            Console.ReadKey();
        }

        static void DrawGraph(List<double> data, string title)
        {
            int width = Console.WindowWidth - 20;
            int height = 20;

            double max = double.MinValue;
            double min = double.MaxValue;

            foreach (var val in data)
            {
                if (val > max) max = val;
                if (val < min) min = val;
            }

            Console.WriteLine(title);
            for (int i = 0; i < height; i++)
            {
                double level = max - (max - min) * i / height;
                Console.Write($"{level,5:F1} |");

                for (int j = 0; j < width; j++)
                {
                    int index = j * data.Count / width;
                    Console.Write(data[index] > level ? '*' : ' ');
                }

                Console.WriteLine();
            }

            Console.WriteLine(new string('-', width + 7));
        }
    }
}