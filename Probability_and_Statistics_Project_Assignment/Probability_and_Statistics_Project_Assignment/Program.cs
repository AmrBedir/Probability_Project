using System;
using System.Collections.Generic;
using System.Linq;

class Probability_and_Statistics_Project_Assignment
{
    static void Main(string[] args)
    {
        Console.WriteLine("Probability & Statistics - Project Assignment");
        Console.WriteLine("First Level - Second Semester: 2022-2023\n");
        Console.WriteLine("Name: Amr Bedir Taher");
        Console.WriteLine("ID: 1000264365");
        Console.WriteLine("Group: 2, Section: 14");
        Console.WriteLine("____________________");
        Console.Write("Enter the number of items: ");
        int n = int.Parse(Console.ReadLine());
        List<int> items = new List<int>();
        Console.WriteLine("____________________");

        for (int i = 1; i <= n; i++)
        {
            Console.Write("Enter number #{0}: ", i);
            items.Add(int.Parse(Console.ReadLine()));
        }
        Console.WriteLine("____________________");

        items.Sort();
        double median = ComputeMedian(items);
        int mode = ComputeMode(items);
        int range = ComputeRange(items);
        int q1 = ComputeQuartile(items, 1);
        int q3 = ComputeQuartile(items, 3);
        int p90 = ComputePercentile(items, 90);
        int iqr = q3 - q1;
        int lowerBound = (int)(q1 - (1.5 * iqr));
        int upperBound = (int)(q3 + (1.5 * iqr));

        Console.WriteLine("The Median of the values: {0}", median);
        Console.WriteLine("The Mode of the values: {0}", mode);
        Console.WriteLine("The Range of the values: {0}", range);
        Console.WriteLine("The first Quartile of the values: {0}", q1);
        Console.WriteLine("The third Quartile of the values: {0}", q3);
        Console.WriteLine("The P90 of the values: {0}", p90);
        Console.WriteLine("The interquartile of the values: {0}", iqr);
        Console.WriteLine("The Lower Bound of the values: {0}", lowerBound);
        Console.WriteLine("The Upper Bound of the values: {0}", upperBound);
        Console.WriteLine("____________________");

        Console.Write("Enter a value to check for outliers: ");
        int input = int.Parse(Console.ReadLine());
        if (IsOutlier(input, lowerBound, upperBound))
        {
            Console.WriteLine("{0} is an outlier", input);
        }
        else
        {
            Console.WriteLine("{0} is not an outlier", input);
        }
    }

    static double ComputeMedian(List<int> items)
    {
        int n = items.Count;
        if (n % 2 == 0)
        {
            return (items[n / 2] + items[(n / 2) - 1]) / 2.0;
        }
        else
        {
            return items[n / 2];
        }
    }

    static int ComputeMode(List<int> items)
    {
        var groups = items.GroupBy(x => x);
        int maxCount = groups.Max(g => g.Count());
        return groups.First(g => g.Count() == maxCount).Key;
    }

    static int ComputeRange(List<int> items)
    {
        return items.Max() - items.Min();
    }

    static int ComputeQuartile(List<int> items, int quartile)
    {
        int n = items.Count;
        double index = (n + 1) * quartile / 4.0;
        if (index % 1 == 0)
        {
            return items[(int)index - 1];
        }
        else
        {
            int lower = (int)Math.Floor(index) - 1;
            int upper = (int)Math.Ceiling(index) - 1;
            return (items[lower] + items[upper]) / 2;
        }
    }

    static int ComputePercentile(List<int> items, int percentile)
    {
        int n = items.Count;
        double index = (n + 1) * percentile / 100.0;
        if (index % 1 == 0)
        {
            return items[(int)index - 1];
        }
        else
        {
            int lower = (int)Math.Floor(index) - 1;
            int upper = (int)Math.Ceiling(index) - 1;
            return (items[lower] + items[upper]) / 2;
        }
    }
    static bool IsOutlier(int value, int lowerBound, int upperBound)
    {
        return value < lowerBound || value > upperBound;
    }
}