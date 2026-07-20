using System;
using System.Collections.Generic;
static class MyExtensions
{
    //this keyword allows this to be an extension method
    public static void ShuffleList<T>(this IList<T> list)
    {
        //Fisher Yates shuffle
        Random rng = new Random();
        int count = list.Count;
        for (int index = count - 1; index > 0; index--)
        {
            int target = rng.Next(0, index + 1);
            T temp = list[index];
            list[index] = list[target];
            list[target] = temp;
        }
    }

    public static void MergeSortedWeightedLists<T>(
        List<T> elements1, List<float> weights1,
        List<T> elements2, List<float> weights2,
        out List<T> mergedElements, out List<float> mergedWeights)
    {
            int n = elements1.Count;
            int m = elements2.Count;
            mergedElements = new List<T>(n + m);
            mergedWeights = new List<float>(n + m);
            
            int i = 0;
            int j = 0;

            while (i < n && j < m)
            {
                float scaledWeight1 = weights1[i] * 0.5f;
                float scaledWeight2 = weights2[j] * 0.5f;
                if (scaledWeight1 <= scaledWeight2)
                {
                    mergedElements.Add(elements1[i]);
                    mergedWeights.Add(scaledWeight1);
                    i++;
                }
                else
                {
                    mergedElements.Add(elements2[j]);
                    mergedWeights.Add(scaledWeight2);
                    j++;
                }
            }

            while (i < n)
            {
                mergedElements.Add(elements1[i]);
                mergedWeights.Add(weights1[i] * 0.5f);
                i++;
            }

            while (j < m)
            {
                mergedElements.Add(elements2[j]);
                mergedWeights.Add(weights2[j] * 0.5f);
                j++;
            }
    }
}