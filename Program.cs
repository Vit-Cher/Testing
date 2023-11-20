using System;

class Program
{
    static double Distance(double[] city1, double[] city2)
    {
        return Math.Sqrt(Math.Pow((city1[0] - city2[0]), 2) + Math.Pow((city1[1] - city2[1]), 2));
    }

    static double PathLength(int[] path, double[][] distances)
    {
        double length = 0;
        for (int i = 0; i < path.Length - 1; i++)
        {
            length += distances[path[i]][path[i + 1]];
        }
        length += distances[path[path.Length - 1]][path[0]];
        return length;
    }

    static int[] TSP(double[][] distances, int startCity)
    {
        int n = distances.Length;
        int[] cities = new int[n];
        for (int i = 0; i < n; i++)
        {
            cities[i] = i;
        }
        int[] minPath = null;
        double minLength = double.PositiveInfinity;

        int[] path = new int[n - 1];
        for (int i = 0; i < n - 1; i++)
        {
            if (i < startCity)
            {
                path[i] = i;
            }
            else
            {
                path[i] = i + 1;
            }
        }

        do
        {
            int[] currentPath = new int[n];
            currentPath[0] = startCity;
            Array.Copy(path, 0, currentPath, 1, n - 1);
            double length = PathLength(currentPath, distances);
            if (length < minLength)
            {
                minLength = length;
                minPath = currentPath;
            }
        } while (NextPermutation(path));

        return minPath;
    }

    static bool NextPermutation(int[] arr)
    {
        int i = arr.Length - 2;
        while (i >= 0 && arr[i] >= arr[i + 1])
        {
            i--;
        }
        if (i >= 0)
        {
            int j = arr.Length - 1;
            while (arr[j] <= arr[i])
            {
                j--;
            }
            int temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }
        Array.Reverse(arr, i + 1, arr.Length - (i + 1));
        return i >= 0;
    }

    static void Main()
    {

        // Ввод матрицы расстояний и начального города
        Console.WriteLine("Введите количество городов:\n");
        int n = Convert.ToInt32(Console.ReadLine());

        double[][] distances = new double[n][];

        for (int i = 0; i < n; i++)
        {
            distances[i] = new double[n];
            for (int j = 0; j < n; j++)
            {
                if (i==j)
                {
                    
                    distances[i][j] = 0;
                    continue;
                    
                }
                Console.Write("\nВведите расстояние от города " + i + " до города " + j + ": ");
                distances[i][j] = Convert.ToDouble(Console.ReadLine());
            }
        }


        // Вывод матрицы расстояний
        Console.WriteLine("\nМатрица расстояний:\n");
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                Console.Write(distances[i][j] + "\t");
            }
            Console.WriteLine("\n");
        }


        Console.Write("\nВведите начальный город: ");
        int startCity = Convert.ToInt32(Console.ReadLine());

        // Вызов функции TSP для нахождения самого короткого пути
        int[] shortestPath = TSP(distances, startCity);

        // Вывод итоговой последовательности городов
        Console.Write("\nКратчайший путь: ");
        foreach (int city in shortestPath)
        {
            Console.Write(city + " ");
        }
        Console.WriteLine("\n");
    }
}




