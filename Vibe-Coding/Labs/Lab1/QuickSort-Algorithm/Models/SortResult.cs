namespace QuickSort_Algorithm.Models
{
    /// <summary>
    /// Represents the complete result of a sorting operation
    /// 
    /// This immutable record stores:
    /// - The original unsorted array
    /// - The sorted output array
    /// - Performance metrics (comparisons, swaps, execution time)
    /// 
    /// Using a record provides:
    /// - Immutability (values cannot be changed after creation)
    /// - Automatic equality comparison
    /// - Cleaner value-based semantics
    /// - Built-in ToString() for debugging
    /// 
    /// Usage:
    ///   var result = SortingService.ExecuteQuickSort(array);
    ///   Console.WriteLine($"Sorted: {string.Join(", ", result.Output)}");
    ///   Console.WriteLine($"Metrics: {result.Comparisons} comparisons, {result.Swaps} swaps");
    /// </summary>
    internal sealed record SortResult
    {
        /// <summary>
        /// The original input array (unchanged by the sorting operation)
        /// 
        /// Useful for:
        /// - Comparing before/after sorting
        /// - Verifying the algorithm preserved all elements
        /// - Debugging if unexpected results occur
        /// </summary>
        public int[] Input { get; init; }

        /// <summary>
        /// The sorted output array in ascending order
        /// 
        /// Properties:
        /// - Length matches Input array length
        /// - All elements in ascending order
        /// - Contains exactly the same elements as Input
        /// </summary>
        public int[] Output { get; init; }

        /// <summary>
        /// Total number of element comparisons performed during sorting
        /// 
        /// Indicates computational work done. Lower is better.
        /// 
        /// Expected ranges for random data:
        /// - Small array (n=100):   ~1,000 comparisons
        /// - Medium array (n=1000): ~10,000 comparisons
        /// - Large array (n=10000): ~130,000 comparisons
        /// 
        /// Worst case (reverse sorted):
        /// - n=100:  ~5,000 comparisons
        /// - n=1000: ~500,000 comparisons
        /// 
        /// Formula: Comparisons ≈ n log n (average) or n²/2 (worst)
        /// </summary>
        public long Comparisons { get; init; }

        /// <summary>
        /// Total number of element swaps (exchanges) performed during sorting
        /// 
        /// Indicates memory movement and data access patterns.
        /// 
        /// Expected ranges for random data:
        /// - Generally n/3 to n/2 swaps for random data
        /// - Fewer swaps for already-sorted data
        /// - More swaps for reverse-sorted data
        /// 
        /// Swaps are more expensive than comparisons because they involve:
        /// 1. Reading two values from memory
        /// 2. Writing two values back to memory
        /// </summary>
        public long Swaps { get; init; }

        /// <summary>
        /// Wall-clock execution time in milliseconds
        /// 
        /// Measured using System.Diagnostics.Stopwatch for accuracy.
        /// 
        /// Notes:
        /// - Small arrays (< 10,000 elements) may show 0ms due to precision
        /// - Includes:
        ///   * Actual sorting algorithm execution
        ///   * System overhead
        ///   * Garbage collection (if triggered)
        /// - Does NOT include array copying time
        /// 
        /// For accurate benchmarking:
        /// - Run multiple times and average
        /// - Use larger arrays to reduce precision effects
        /// - Warm up JIT compiler first
        /// </summary>
        public long ExecutionTimeMs { get; init; }

        /// <summary>
        /// Constructor for SortResult
        /// 
        /// Creates an immutable record containing the complete sorting operation details.
        /// 
        /// Parameters correspond to the properties defined above.
        /// All values are captured at result creation time.
        /// </summary>
        /// <param name="input">Original unsorted array</param>
        /// <param name="output">Sorted array in ascending order</param>
        /// <param name="comparisons">Number of element comparisons</param>
        /// <param name="swaps">Number of element swaps</param>
        /// <param name="executionTimeMs">Execution time in milliseconds</param>
        public SortResult(int[] input, int[] output, long comparisons, long swaps, long executionTimeMs)
        {
            Input = input;
            Output = output;
            Comparisons = comparisons;
            Swaps = swaps;
            ExecutionTimeMs = executionTimeMs;
        }
    }
}
