using System;
using System.Diagnostics;
using System.Linq;
using QuickSort_Algorithm.Models;
using QuickSort_Algorithm.Algorithms;

namespace QuickSort_Algorithm.Services
{
    /// <summary>
    /// Service for performing sorting operations and collecting performance metrics
    /// 
    /// This service provides a higher-level interface to the QuickSort algorithm,
    /// including:
    /// - Execution with timing measurements
    /// - Performance metric collection
    /// - Result validation
    /// - Test data generation
    /// </summary>
    internal static class SortingService
    {
        /// <summary>
        /// Executes QuickSort on a copy of the input array and returns detailed metrics
        /// 
        /// Process:
        /// 1. Validates the input array
        /// 2. Creates a copy to preserve the original
        /// 3. Starts a stopwatch for timing
        /// 4. Calls QuickSort.Sort() to perform the sorting
        /// 5. Stops the stopwatch
        /// 6. Collects and returns comprehensive metrics
        /// 
        /// Why we copy the input:
        /// - QuickSort modifies the array in-place
        /// - We want to preserve the original for comparison in results
        /// - The SortResult includes both input and output
        /// 
        /// Time Complexity: O(n log n) average, O(n²) worst case
        /// Space Complexity: O(n) for the copy + O(log n) recursion stack
        /// </summary>
        /// <param name="input">The array to be sorted (not modified)</param>
        /// <returns>SortResult containing sorted array, original, and performance metrics</returns>
        /// <exception cref="ArgumentNullException">Thrown if input is null</exception>
        public static SortResult ExecuteQuickSort(int[] input)
        {
            if (input is null)
                throw new ArgumentNullException(nameof(input));

            // Create a copy of the input array
            // This preserves the original and allows QuickSort to work in-place on the copy
            int[] data = (int[])input.Clone();

            // Create and start a stopwatch to measure execution time
            // Stopwatch provides high-resolution timing (more accurate than DateTime)
            var stopwatch = Stopwatch.StartNew();

            // Call QuickSort to perform the actual sorting
            // After this call:
            // - data array is sorted
            // - Performance counters are updated in QuickSort class
            QuickSort.Sort(data);

            // Stop the stopwatch and record the elapsed time
            stopwatch.Stop();

            // Construct and return a SortResult object with:
            // - Original input array (unchanged)
            // - Sorted output array
            // - Number of comparisons made
            // - Number of swaps made
            // - Execution time in milliseconds
            return new SortResult(
                input: input,
                output: data,
                comparisons: QuickSort.GetComparisons(),
                swaps: QuickSort.GetSwaps(),
                executionTimeMs: stopwatch.ElapsedMilliseconds
            );
        }

        /// <summary>
        /// Validates that an array is correctly sorted in ascending order
        /// 
        /// Algorithm:
        /// 1. Handle edge cases (null, empty, or single-element arrays)
        /// 2. Iterate through array comparing each element with the next
        /// 3. If any element is greater than the next, array is not sorted
        /// 4. If all comparisons pass, array is sorted
        /// 
        /// Use case: Verify that QuickSort produced correct results
        /// 
        /// Time Complexity: O(n) - must check all elements in worst case
        /// Space Complexity: O(1) - constant extra space
        /// </summary>
        /// <param name="array">The array to validate</param>
        /// <returns>True if array is sorted in ascending order, false otherwise</returns>
        public static bool IsValidSort(int[] array)
        {
            // Edge case: null, empty, or single-element arrays are considered sorted
            if (array is null || array.Length <= 1)
                return true;

            // Check each pair of adjacent elements
            for (int i = 0; i < array.Length - 1; i++)
            {
                // If any element is greater than the next, array is not sorted
                if (array[i] > array[i + 1])
                    return false;
            }

            // All adjacent pairs are in order, so array is sorted
            return true;
        }

        /// <summary>
        /// Generates a random array of integers for testing purposes
        /// 
        /// Use cases:
        /// - Performance testing with various array sizes
        /// - Stress testing the QuickSort implementation
        /// - Comparing performance across different data patterns
        /// 
        /// Implementation uses LINQ for concise code:
        /// - Enumerable.Range() generates sequence of integers [0...size-1]
        /// - Select() transforms each to a random value in [minValue...maxValue]
        /// - ToArray() converts to array
        /// 
        /// Time Complexity: O(n) - generates n random numbers
        /// Space Complexity: O(n) - returns array of size n
        /// </summary>
        /// <param name="size">Number of elements to generate</param>
        /// <param name="minValue">Minimum value for random numbers (inclusive)</param>
        /// <param name="maxValue">Maximum value for random numbers (inclusive)</param>
        /// <returns>Array of random integers in specified range</returns>
        /// <exception cref="ArgumentException">Thrown if size is negative</exception>
        public static int[] GenerateRandomArray(int size, int minValue = 0, int maxValue = 1000)
        {
            if (size < 0)
                throw new ArgumentException("Size must be non-negative.", nameof(size));

            // Create a new Random instance for this generation
            var random = new Random();

            // Generate size random numbers in range [minValue...maxValue]
            return Enumerable.Range(0, size)
                .Select(_ => random.Next(minValue, maxValue + 1))
                .ToArray();
        }
    }
}
