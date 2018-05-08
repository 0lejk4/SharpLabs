using System;
using System.Collections.Generic;
using System.Linq;

namespace laba1
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            int[,] matrix;

            Console.Write("Input number of cities: ");
            var n = int.Parse(Console.ReadLine() ?? "2");

            if (n < 1) throw new FormatException("Number of cities should be bigger than 1");


            Console.Write("If you want to generate matrix with random numbers input - 0\n" +
                          "If you want to input matrix with hands input - 1\n");

            switch (Console.ReadLine())
            {
                case "0":
                    matrix = GenerateMatrix(n);
                    Console.WriteLine("Generated matrix:");
                    PrintMatrix(matrix, n);
                    break;
                case "1":
                    Console.WriteLine("Input matrix using space delim from new line for each row");
                    matrix = InputMatrix(n);
                    break;
                default:
                    throw new ArgumentException("You shoud`ve choosen 1 or 2");
            }


            var result = FindShortestPath(matrix, n);


            Console.WriteLine("\nBest way to connect cities:");
            PrintMatrix(result, n);
        }

        private static int[,] GenerateMatrix(int size)
        {
            var matrix = new int[size, size];
            var random = new Random();

            for (var i = 0; i < size; i++)
            {
                for (var j = 0; j < i; j++) matrix[i, j] = matrix[j, i];

                var maxCon = size - i - 1;
                var totalCon = random.Next(0, maxCon);

                var conIndexses = new int[totalCon];

                for (var j = 0; j < totalCon; j++)
                    while (true)
                    {
                        var index = random.Next(i + 1, size);
                        if (Array.IndexOf(conIndexses, index) != -1) continue;
                        conIndexses[j] = index;
                        break;
                    }

                foreach (var index in conIndexses) matrix[i, index] = random.Next(1, 100);

                if (i != size - 1 && matrix[i, i + 1] == 0) matrix[i, i + 1] = random.Next(1, 100);
            }

            return matrix;
        }

        private static int[,] InputMatrix(int size)
        {
            var matrix = new int[size, size];


            for (var i = 0; i < size; i++)
            {
                var row = (Console.ReadLine() ?? "").Split();

                if (row.Length != size)
                    throw new ArgumentException($"Input length={row.Length}; size = {size}; length != size");

                for (var j = 0; j < size; j++)
                    try
                    {
                        matrix[i, j] = int.Parse(row[j]);
                    }
                    catch (FormatException e)
                    {
                        Console.WriteLine($"Number format for index = {j} not correct, matrix[{i}][{j}] = 0");
                    }
            }

            return matrix;
        }

        private static void PrintMatrix(int[,] matrix, int size)
        {
            for (var i = 0; i < size; i++) Console.Write($"\t{i + 1})");

            Console.WriteLine();
            for (var i = 0; i < size; i++)
            {
                Console.Write($"{i + 1})\t");
                for (var j = 0; j < size; j++) Console.Write($"{matrix[i, j]}\t");

                Console.WriteLine();
            }
        }

        private static int[,] FindShortestPath(int[,] matrix, int numberV)
        {
            var roads = MatrixToRoads(matrix, numberV);

            var finalRoads = new List<Road>();

            var notUsedRoads = new List<Road>(roads);

            var usedV = new List<int>();
            var notUsedV = new List<int>();


            notUsedV.AddRange(Enumerable.Range(0, numberV));

            var random = new Random();

            usedV.Add(random.Next(0, numberV));
            notUsedV.RemoveAt(usedV[0]);

            while (notUsedV.Count > 0)
            {
                var minE = -1;

                for (var i = 0; i < notUsedRoads.Count; i++)
                    if (usedV.IndexOf(notUsedRoads[i].V1) != -1 && notUsedV.IndexOf(notUsedRoads[i].V2) != -1 ||
                        usedV.IndexOf(notUsedRoads[i].V2) != -1 && notUsedV.IndexOf(notUsedRoads[i].V1) != -1)
                        if (minE == -1 || notUsedRoads[i].Weight < notUsedRoads[minE].Weight)
                            minE = i;

                if (usedV.IndexOf(notUsedRoads[minE].V1) != -1)
                {
                    usedV.Add(notUsedRoads[minE].V2);
                    notUsedV.Remove(notUsedRoads[minE].V2);
                }
                else
                {
                    usedV.Add(notUsedRoads[minE].V1);
                    notUsedV.Remove(notUsedRoads[minE].V1);
                }

                finalRoads.Add(notUsedRoads[minE]);
                notUsedRoads.RemoveAt(minE);
            }

            return RoadsToMatrix(finalRoads, numberV);
        }

        private static List<Road> MatrixToRoads(int[,] matrix, int size)
        {
            var roads = new List<Road>();

            for (var i = 0; i < size; i++)
            for (var j = i + 1; j < size; j++)
                if (matrix[i, j] > 0)
                    roads.Add(new Road(i, j, matrix[i, j]));

            return roads;
        }

        private static int[,] RoadsToMatrix(List<Road> roads, int size)
        {
            var matrix = new int[size, size];

            foreach (var road in roads)
            {
                matrix[road.V1, road.V2] = road.Weight;
                matrix[road.V2, road.V1] = road.Weight;
            }

            return matrix;
        }

        private class Road
        {
            public readonly int V1, V2;
            public readonly int Weight;

            public Road(int v1, int v2, int weight)
            {
                V1 = v1;
                V2 = v2;
                Weight = weight;
            }
        }
    }
}