using System;
using System.Diagnostics;

namespace QuickSort_Algorithm.Algorithms
{
    /// <summary>
    /// QuickSort Algorithm Implementation
    /// 
    /// QuickSort is a highly efficient, divide-and-conquer sorting algorithm that works by:
    /// 1. Selecting a pivot element from the array
    /// 2. Partitioning the array into elements smaller/equal and greater than the pivot
    /// 3. Recursively sorting both partitions
    /// 
    /// Time Complexity:
    /// - Best/Average Case: O(n log n) - Pivot divides array evenly
    /// - Worst Case: O(n²) - Pivot always at edge (rare with good pivot selection)
    /// 
    /// Space Complexity: O(log n) - Recursion stack depth
    /// 
    /// This implementation uses the Lomuto Partition Scheme and tracks:
    /// - Number of element comparisons
    /// - Number of element swaps
    /// for performance analysis
    /// </summary>
    internal static class QuickSort
    {
        // Performance counters
        private static long _comparisons;  // Tracks element comparisons
        private static long _swaps;        // Tracks element swaps

        /// <summary>
        /// Public entry point for the QuickSort algorithm
        /// 
        /// Validates input and initiates the recursive sorting process
        /// </summary>
        /// <param name="array">The array to be sorted (modified in-place)</param>
        /// <exception cref="ArgumentNullException">Thrown if array is null</exception>
        public static void Sort(int[] array)
        {
            if (array is null)
                throw new ArgumentNullException(nameof(array));

            // Edge case: arrays with 0 or 1 element are already sorted
            if (array.Length <= 1)
                return;

            // Reset performance counters for this sort operation
            _comparisons = 0;
            _swaps = 0;

            // Initiate recursive sorting from index 0 to Length-1
            Sort(array, left: 0, right: array.Length - 1);
        }

        /// <summary>
        /// Gets the total number of element comparisons performed in the last sort operation
        /// 
        /// Used for performance analysis. More comparisons = more work done.
        /// For random data: typically O(n log n) comparisons
        /// </summary>
        public static long GetComparisons() => _comparisons;

        /// <summary>
        /// Gets the total number of element swaps performed in the last sort operation
        /// 
        /// Used for performance analysis. Swaps involve memory movement.
        /// For random data: typically O(n/3) swaps on average
        /// </summary>
        public static long GetSwaps() => _swaps;

        /// <summary>
        /// Recursive quicksort implementation using divide-and-conquer
        /// 
        /// Algorithm:
        /// 1. Base case: if left >= right, this partition is sorted (return)
        /// 2. Partition the array around a pivot element
        /// 3. Recursively sort the left partition (elements < pivot)
        /// 4. Recursively sort the right partition (elements > pivot)
        /// 
        /// Example:
        /// Original: [38, 27, 43, 3, 9, 82, 10]
        /// After partition with pivot 10: [3, 9, 10, 27, 38, 43, 82]
        ///                                          ↑
        ///                              Pivot in correct position
        /// </summary>
        /// <param name="array">The array being sorted</param>
        /// <param name="left">Index of the leftmost element in current partition</param>
        /// <param name="right">Index of the rightmost element in current partition</param>
        private static void Sort(int[] array, int left, int right)
        {
            // Base case: if left >= right, this partition has 0 or 1 element (already sorted)
            if (left >= right)
                return;

            // Partition the array and get the pivot's final position
            // After partition:
            // - All elements at indices [left...pivot-1] are <= pivot
            // - Pivot element is at its correct sorted position
            // - All elements at indices [pivot+1...right] are > pivot
            int pivotIndex = Partition(array, left, right);

            // Recursively sort the left partition (elements smaller than pivot)
            // Range: [left...pivotIndex-1]
            Sort(array, left, pivotIndex - 1);

            // Recursively sort the right partition (elements larger than pivot)
            // Range: [pivotIndex+1...right]
            Sort(array, pivotIndex + 1, right);
        }

        /// <summary>
        /// Partitions the array using the Lomuto Partition Scheme
        /// 
        /// This method rearranges the array so that:
        /// - All elements <= pivot come before the pivot
        /// - All elements > pivot come after the pivot
        /// - Returns the final position of the pivot
        /// 
        /// Lomuto Partition Details:
        /// 1. Choose the last element as the pivot
        /// 2. Initialize pointer i to left-1 (tracks boundary)
        /// 3. Scan from left to right-1:
        ///    - If element <= pivot: increment i and swap with array[i]
        /// 4. Place pivot in its correct position by swapping array[i+1] with array[right]
        /// 5. Return i+1 (pivot's final position)
        /// 
        /// Example:
        /// Input:  [3, 7, 8, 5, 2, 1, 9, 5, 4] (pivot = 4 at right)
        /// Output: [3, 2, 1, 4, 5, 9, 5, 8, 7]
        ///                    ↑
        ///              Pivot in correct position
        ///
        /// Time: O(n) - single pass through array
        /// Space: O(1) - in-place rearrangement
        /// </summary>
        /// <param name="array">The array to partition</param>
        /// <param name="left">Starting index of partition</param>
        /// <param name="right">Ending index of partition (pivot location)</param>
        /// <returns>The final index of the pivot element</returns>
        private static int Partition(int[] array, int left, int right)
        {
            // Choose the last element as pivot
            int pivot = array[right];
            
            // Initialize i to left-1
            // i tracks the boundary between "processed and <= pivot" and "not yet processed"
            int i = left - 1;

            // Scan through all elements from left to right-1
            for (int j = left; j < right; j++)
            {
                // Increment comparison counter for performance analysis
                _comparisons++;

                // If current element is less than or equal to pivot
                if (array[j] <= pivot)
                {
                    // Move i forward to next position
                    i++;

                    // Swap current element with element at position i
                    // This ensures smaller elements move toward the left
                    Swap(array, i, j);
                }
                // If array[j] > pivot, do nothing (leave it on the right)
            }

            // Place pivot in its correct sorted position
            // All elements from [left...i] are <= pivot
            // All elements from [i+1...right] should be > pivot
            // So pivot goes to position i+1
            Swap(array, i + 1, right);

            // Return the final position of the pivot
            return i + 1;
        }

        /// <summary>
        /// Swaps two elements in the array
        /// 
        /// Uses tuple deconstruction (C# 7+ feature) for a clean swap:
        /// (array[i], array[j]) = (array[j], array[i])
        /// 
        /// Optimization: Checks if i == j to avoid unnecessary operation
        /// </summary>
        /// <param name="array">The array containing elements</param>
        /// <param name="i">Index of first element</param>
        /// <param name="j">Index of second element</param>
        private static void Swap(int[] array, int i, int j)
        {
            // Skip swap if indices are the same
            if (i == j)
                return;

            // Increment swap counter for performance analysis
            _swaps++;

            // Swap using tuple deconstruction (modern C# syntax)
            // This is equivalent to: int temp = array[i]; array[i] = array[j]; array[j] = temp;
            (array[i], array[j]) = (array[j], array[i]);
        }
    }
}
