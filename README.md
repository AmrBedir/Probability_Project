# Probability & Statistics Assienment Project - Prof. Samir Elmougy


### What is required in the project?

Write a C# program for the following project:
* Input: 
  * n: number of items.
  * Ai: the items values (Not sorted) from i=1 to n 
  
* Output: The median of the values Ai.
  * The mode of the values Ai.
  * The range of the values Ai.
  * The first Quartile of the values Ai.
  * The third Quartile of the values Ai.
  * The P90 of the values Ai.
  * The interquartile of the values Ai.
  * The boundaries of the outlier region.
  * Determine whether an input value is an outlier or not.

[*Project Assignment Details - PDF*](https://github.com/AmrBedir/Probability_Project/blob/main/Project_Assignment_1.pdf)

### Project code in C#

```c#
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
```
[*Code File*](https://github.com/AmrBedir/Probability_Project/blob/main/Probability_and_Statistics_Project_Assignment/Probability_and_Statistics_Project_Assignment/Program.cs)

### Important terms to know
* **[Median](https://en.wikipedia.org/wiki/Median)**, *The statistical median is the middle number in a sequence of numbers. To find the median, organize each number in order by size; the number in the middle is the median.*
* **[Mode](https://en.wikipedia.org/wiki/Mode_(statistics))**, *The mode is the value that appears most often in a set of data values. If X is a discrete random variable, the mode is the value x at which the probability mass function takes its maximum value. In other words, it is the value that is most likely to be sampled.*
* **[Range](https://en.wikipedia.org/wiki/Range_(statistics))**, *In statistics, the range of a set of data is the difference between the largest and smallest values, the result of subtracting the sample maximum and minimum. It is expressed in the same units as the data.*
* **[The First Quartile](https://en.wikipedia.org/wiki/Quartile)**, *(Q1, or the lowest quartile) is the 25th percentile, meaning that 25% of the data falls below the first quartile.*
* **[The Third Quartile](https://en.wikipedia.org/wiki/Quartile)**, *(Q3, or the upper quartile) is the 75th percentile, meaning that 75% of the data falls below the third quartile.*
* **[P90](https://en.wikipedia.org/wiki/Percentile)**, *It means that 90% of the calculated estimates will be equal or exceed P90 estimate.*
* **[Interquartile](https://en.wikipedia.org/wiki/Interquartile_range)**, *In descriptive statistics, the interquartile range is a measure of statistical dispersion, which is the spread of the data. The IQR may also be called the midspread, middle 50%, fourth spread, or H‑spread. It is defined as the difference between the 75th and 25th percentiles of the data.*
* **[Boundaries](https://en.wikipedia.org/wiki/Boundary_value_problem)**, *In statistics, class boundaries are endpoints used to separate the data into classes or groups. The boundary with the lower value is called the lower boundary while the one with a higher value is called the upper boundary*.

### Some references explain probability and statistics
* [Probability and Statistics - Dr. Mervat Mikhail](https://www.youtube.com/playlist?list=PL7snZ0LSsq3g9NUio7xFDtC9IVIj649GV)
* [Probability and Statistics - Dr. Ahmed Hagag ](https://www.youtube.com/playlist?list=PLxIvc-MGOs6gW9SgkmoxE5w9vQkID1_r-)
