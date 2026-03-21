using System;
using System.Collections.Generic;

namespace QuickSort_Algorithm.Algorithms
{
    /// <summary>
    /// Iterative QuickSort Implementation
    /// 
    /// Advantages:
    /// 1. No recursion overhead (explicit stack instead)
    /// 2. Guaranteed O(log n) stack depth
    /// 3. No risk of stack overflow
    /// 4. Same optimizations as recursive version
    /// 
    /// Performance: Same as optimized recursive, but safer
    /// </summary>
    internal static class QuickSortIterative
    {
        private static long _comparisons;
        private static long _swaps;
        private const int InsertionSortThreshold = 10;

        public static void Sort(int[] array)
        {
            if (array is null)
                throw new ArgumentNullException(nameof(array));

            if (array.Length <= 1)
                return;

            _comparisons = 0;
            _swaps = 0;

            SortIterative(array);
        }

        public static long GetComparisons() => _comparisons;
        public static long GetSwaps() => _swaps;

        private static void SortIterative(int[] array)
        {
            var stack = new Stack<(int, int)>();
            stack.Push((0, array.Length - 1));

            while (stack.Count > 0)
            {
                (int left, int right) = stack.Pop();

                if (right - left < InsertionSortThreshold)
                {
                    InsertionSort(array, left, right);
                    continue;
                }

                int pivot = PartitionHoare(array, left, right);

                // Push smaller partition first (optimization)
                if (pivot - left < right - pivot)
                {
                    stack.Push((pivot + 1, right));
                    stack.Push((left, pivot));
                }
                else
                {
                    stack.Push((left, pivot));
                    stack.Push((pivot + 1, right));
                }
            }
        }

        private static int PartitionHoare(int[] array, int left, int right)
        {
            int pivot = MedianOfThree(array, left, right);

            int i = left - 1;
            int j = right + 1;

            while (true)
            {
                do
                {
                    i++;
                    _comparisons++;
                } while (array[i] < pivot);

                do
                {
                    j--;
                    _comparisons++;
                } while (array[j] > pivot);

                if (i >= j)
                    return j;

                Swap(array, i, j);
            }
        }

        private static int MedianOfThree(int[] array, int left, int right)
        {
            int mid = left + (right - left) / 2;

            if (array[left] > array[mid])
                Swap(array, left, mid);

            if (array[mid] > array[right])
                Swap(array, mid, right);

            if (array[left] > array[mid])
                Swap(array, left, mid);

            return array[mid];
        }

        private static void InsertionSort(int[] array, int left, int right)
        {
            for (int i = left + 1; i <= right; i++)
            {
                int key = array[i];
                int j = i - 1;

                while (j >= left)
                {
                    _comparisons++;
                    if (array[j] <= key)
                        break;

                    array[j + 1] = array[j];
                    _swaps++;
                    j--;
                }

                array[j + 1] = key;
            }
        }

        private static void Swap(int[] array, int i, int j)
        {
            if (i == j)
                return;

            _swaps++;
            (array[i], array[j]) = (array[j], array[i]);
        }
    }
}
