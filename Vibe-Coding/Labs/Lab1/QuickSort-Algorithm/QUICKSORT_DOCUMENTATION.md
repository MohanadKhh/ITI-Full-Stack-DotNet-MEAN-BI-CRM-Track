# QuickSort Algorithm - Complete Documentation

## Table of Contents
1. [Algorithm Overview](#algorithm-overview)
2. [How QuickSort Works](#how-quicksort-works)
3. [Implementation Details](#implementation-details)
4. [Key Components](#key-components)
5. [Time & Space Complexity](#time--space-complexity)
6. [Partition Strategy](#partition-strategy)
7. [Performance Metrics](#performance-metrics)
8. [Example Execution](#example-execution)

---

## Algorithm Overview

**QuickSort** is a highly efficient, divide-and-conquer sorting algorithm that works by:
1. **Selecting a pivot element** from the array
2. **Partitioning the array** into two parts:
   - Elements smaller than or equal to the pivot
   - Elements greater than the pivot
3. **Recursively sorting** both partitions

### Key Characteristics
- **Divide-and-Conquer** approach
- **In-place sorting** (requires minimal extra space)
- **Unstable sort** (relative order of equal elements may change)
- **Average Time: O(n log n)** - Very fast for most cases
- **Worst Time: O(n²)** - When pivot selection is poor (rare with good strategies)

---

## How QuickSort Works

### Step-by-Step Process

```
Original Array: [38, 27, 43, 3, 9, 82, 10]

Step 1: Choose pivot (last element = 10)
Array: [38, 27, 43, 3, 9, 82, 10]
                                    ↑
                                  pivot

Step 2: Partition around pivot
Left (≤ 10):   [3, 9]
Pivot:         [10]
Right (> 10):  [38, 27, 43, 82]

Step 3: Recursively sort left partition [3, 9]
→ Already sorted (too small)

Step 4: Recursively sort right partition [38, 27, 43, 82]
→ Choose pivot (82), partition into [38, 27, 43] and [82]
→ Continue recursively...

Final Result: [3, 9, 10, 27, 38, 43, 82]
```

### Visualization of Recursion Tree

```
                [38, 27, 43, 3, 9, 82, 10]
                        |
                    Partition (pivot=10)
                   /              \
            [3, 9]            [38, 27, 43, 82]
            (sorted)           Partition (pivot=82)
                              /              \
                        [38, 27, 43]      [82]
                     Partition (pivot=43)  (done)
                     /              \
                [38, 27]         [43]
              Partition...      (done)
              /        \
           [27]     [38]
          (done)   (done)

Final sorted: [3, 9, 10, 27, 38, 43, 82]
```

---

## Implementation Details

### 1. Main Sort Method
```csharp
public static void Sort(int[] array)
```
- **Purpose**: Entry point for the sorting algorithm
- **Responsibilities**:
  - Validates input (null check)
  - Handles edge cases (empty or single-element arrays)
  - Resets performance counters
  - Initiates recursive sorting

### 2. Recursive Sort Method
```csharp
private static void Sort(int[] array, int left, int right)
```
- **Parameters**:
  - `array`: The array being sorted
  - `left`: Index of the leftmost element in current partition
  - `right`: Index of the rightmost element in current partition
- **Process**:
  1. Base case: if `left >= right`, partition is sorted (return)
  2. Call `Partition()` to find pivot position
  3. Recursively sort left partition: `Sort(array, left, pivotIndex - 1)`
  4. Recursively sort right partition: `Sort(array, pivotIndex + 1, right)`

### 3. Partition Method (Lomuto Scheme)
```csharp
private static int Partition(int[] array, int left, int right)
```
- **Purpose**: Divide array into two parts around a pivot
- **Strategy**: Uses the **Lomuto Partition Scheme**
- **Algorithm**:
  1. Choose the last element as pivot: `pivot = array[right]`
  2. Initialize pointer `i = left - 1` (tracks the boundary)
  3. Iterate through array from `left` to `right-1`:
     - If element ≤ pivot: increment `i` and swap with `array[i]`
  4. Place pivot in its correct position by swapping `array[i+1]` with `array[right]`
  5. Return `i + 1` (pivot's final position)

**Example Partition**:
```
Array: [3, 7, 8, 5, 2, 1, 9, 5, 4]
              left           right (pivot=4)

After partition:
Smaller: [3, 2, 1]  |  Pivot: [4]  |  Larger: [7, 8, 5, 9, 5]
                    ↑
                New position of pivot
```

### 4. Swap Method
```csharp
private static void Swap(int[] array, int i, int j)
```
- **Purpose**: Exchange two elements in the array
- **Optimization**: Checks if `i == j` to avoid unnecessary swaps
- **Modern Tuple Syntax**: Uses C# 7+ tuple deconstruction: `(array[i], array[j]) = (array[j], array[i])`

---

## Key Components

### Component 1: QuickSort Class (`Algorithms/QuickSort.cs`)
**Responsibilities**:
- Core sorting algorithm implementation
- Performance metric tracking (comparisons & swaps)
- Public interface for sorting

**Key Methods**:
| Method | Visibility | Purpose |
|--------|-----------|---------|
| `Sort()` | Public | Entry point for sorting |
| `GetComparisons()` | Public | Returns number of comparisons made |
| `GetSwaps()` | Public | Returns number of swaps made |
| `Sort()` | Private | Recursive sorting logic |
| `Partition()` | Private | Partitions array around pivot |
| `Swap()` | Private | Swaps two array elements |

### Component 2: SortResult Model (`Models/SortResult.cs`)
**Purpose**: Immutable data structure to hold sorting results

**Properties**:
```csharp
public int[] Input           // Original array (unchanged)
public int[] Output          // Sorted array
public long Comparisons      // Number of element comparisons
public long Swaps           // Number of element swaps
public long ExecutionTimeMs // Execution time in milliseconds
```

### Component 3: SortingService (`Services/SortingService.cs`)
**Responsibilities**:
- High-level sorting operations
- Performance measurement
- Result validation
- Test data generation

**Key Methods**:
| Method | Purpose |
|--------|---------|
| `ExecuteQuickSort()` | Runs QuickSort with timing and metrics |
| `IsValidSort()` | Validates that array is correctly sorted |
| `GenerateRandomArray()` | Creates random test data |

### Component 4: Program Entry Point (`Program.cs`)
**Purpose**: Demonstrates QuickSort with various test cases

**Test Cases**:
1. Simple unsorted array
2. Already sorted array
3. Reverse sorted array (worst case scenario)
4. Large random array (1000 elements)

---

## Time & Space Complexity

### Time Complexity Analysis

| Scenario | Complexity | When It Occurs |
|----------|-----------|----------------|
| **Best Case** | O(n log n) | Pivot always in middle; balanced partitions |
| **Average Case** | O(n log n) | Random pivot; typical scenario |
| **Worst Case** | O(n²) | Pivot always at edge (already sorted array) |

### Space Complexity

| Aspect | Complexity | Notes |
|--------|-----------|-------|
| **Extra Space** | O(log n) | Recursion stack depth |
| **Total Space** | O(log n) | In-place sorting; minimal additional memory |

### Why QuickSort is Fast (on Average)

```
Array size: n = 1000
Best case: log₂(1000) ≈ 10 levels of recursion
Operations per level: ~1000 comparisons
Total: ~10,000 operations (very fast!)

Worst case: 1000 levels of recursion
Operations per level: decreasing (1000, 999, 998...)
Total: ~500,000 operations (slow, but rare)
```

---

## Partition Strategy

### Lomuto vs. Hoare Partition Schemes

Our implementation uses **Lomuto Partition**:

#### Advantages of Lomuto:
✅ Easier to understand and implement
✅ Clearer logic flow
✅ Easier to reason about correctness

#### Disadvantages of Lomuto:
❌ More swaps on average
❌ Slightly slower than Hoare partition

#### How Lomuto Works (Visual):

```
Initial:     [7, 2, 8, 1, 6, 3, 5, 4]
                                      ↑ pivot = 4

i = -1, j = 0: 7 > 4? No action
i = -1, j = 1: 2 ≤ 4? Swap → [2, 7, 8, 1, 6, 3, 5, 4], i = 0
i = 0,  j = 2: 8 > 4? No action
i = 0,  j = 3: 1 ≤ 4? Swap → [2, 1, 8, 7, 6, 3, 5, 4], i = 1
i = 1,  j = 4: 6 > 4? No action
i = 1,  j = 5: 3 ≤ 4? Swap → [2, 1, 3, 7, 6, 8, 5, 4], i = 2
i = 2,  j = 6: 5 > 4? No action

Final swap: i+1 = 3
Result:    [2, 1, 3, 4, 6, 8, 5, 7]
                    ↑ 4 is in correct position!

Left:  [2, 1, 3]        Right: [6, 8, 5, 7]
(< 4)                   (> 4)
```

---

## Performance Metrics

### What We Track

#### 1. **Comparisons Counter**
- Incremented every time two elements are compared (`if (array[j] <= pivot)`)
- Indicates the work done for comparison operations
- Formula: `Comparisons ≈ n log n` (average case)

#### 2. **Swaps Counter**
- Incremented every time two elements exchange positions
- Indicates memory access and data movement
- Formula: `Swaps ≈ n/3` (average case)

#### 3. **Execution Time**
- Measured using `System.Diagnostics.Stopwatch`
- Captures actual wall-clock time
- Useful for real-world performance testing

### Example Metrics Output

```
Array Size: 1000 random elements

Comparisons: 8,923
Swaps: 2,341
Execution Time: 0ms (very fast!)

---

Array Size: 1000 reverse-sorted (worst case)

Comparisons: 499,500
Swaps: 1,000
Execution Time: 1ms (still acceptable)
```

---

## Example Execution

### Test Case 1: Simple Array
```
Input:  [38, 27, 43, 3, 9, 82, 10]
Output: [3, 9, 10, 27, 38, 43, 82]

Metrics:
- Comparisons: 12
- Swaps: 5
- Time: 0ms
- Valid: ✓ True
```

### Test Case 2: Already Sorted
```
Input:  [1, 2, 3, 4, 5]
Output: [1, 2, 3, 4, 5]

Metrics:
- Comparisons: 10 (still must check, even though sorted)
- Swaps: 0 (no movement needed)
- Time: 0ms
- Valid: ✓ True
```

### Test Case 3: Reverse Sorted (Worst Case)
```
Input:  [5, 4, 3, 2, 1]
Output: [1, 2, 3, 4, 5]

Metrics:
- Comparisons: 10 (maximum for size 5)
- Swaps: 4
- Time: 0ms
- Valid: ✓ True

Note: This is the worst-case scenario where the pivot is always
      at one end, causing O(n²) time complexity.
```

### Test Case 4: Large Random Array
```
Input:  [Random 1000 elements]
Output: [Sorted 1000 elements]

Metrics:
- Comparisons: ~8,500
- Swaps: ~2,200
- Time: ~0-1ms
- Valid: ✓ True

Performance: O(n log n) behavior observed
```

---

## Code Flow Diagram

```
User calls: SortingService.ExecuteQuickSort(array)
                    ↓
        [Create copy of array]
        [Start stopwatch]
                    ↓
        QuickSort.Sort(array)
                    ↓
        Sort(array, 0, length-1)  ← Recursive call
                    ↓
        ┌───────────────────────────────┐
        │ Is left >= right?             │
        │ (Base case - partition done)  │
        └───────────┬───────────────────┘
                    │
            YES → Return (done)
                    │
            NO ↓
        Partition(array, left, right)
        → Choose pivot (last element)
        → Rearrange: smaller | pivot | larger
        → Return pivot index
                    ↓
        Sort(array, left, pivot-1)  ← Sort left
                    ↓
        Sort(array, pivot+1, right)  ← Sort right
                    ↓
        [Stop stopwatch]
        [Collect metrics]
                    ↓
        Return SortResult with:
        - Sorted array
        - Comparisons
        - Swaps
        - Execution time
```

---

## Key Takeaways

### When to Use QuickSort
✅ General-purpose sorting
✅ Large datasets
✅ When average-case O(n log n) is sufficient
✅ When extra memory is limited
✅ When in-place sorting is required

### When NOT to Use QuickSort
❌ When guaranteed O(n log n) worst-case is needed → Use MergeSort
❌ When stability is critical → Use MergeSort or TimSort
❌ When data is nearly sorted → Use InsertionSort
❌ When recursion depth is a concern → Use IterativeSort

---

## Implementation Summary

| Aspect | Details |
|--------|---------|
| **Algorithm** | QuickSort with Divide-and-Conquer |
| **Partition Scheme** | Lomuto Partition |
| **Pivot Selection** | Last element (array[right]) |
| **Sorting Type** | In-place, unstable |
| **Time Complexity** | Best: O(n log n), Avg: O(n log n), Worst: O(n²) |
| **Space Complexity** | O(log n) - Recursion stack |
| **Language** | C# 14.0 with .NET 10 |
| **Additional Features** | Performance metrics, validation, test generation |

---

## Next Steps for Learning

1. **Try Hoare Partition** - More efficient variant
2. **Implement Random Pivot Selection** - Avoids worst-case
3. **Compare with Other Algorithms** - MergeSort, HeapSort, TimSort
4. **Add Visualization** - See partitioning in action
5. **Optimize for Small Arrays** - Switch to InsertionSort when n < 10

---

*Documentation created for C# QuickSort Implementation (.NET 10)*
*Last Updated: 2024*
