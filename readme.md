This repository contains two implementations of the Longest Consecutive Sequence problem:

Command Line Interface (CLI) Application

Accepts an input array of integers via command line arguments

Supports two different algorithmic solutions selectable with a switch (--solution 1 or --solution 2)

Easy to run and test different inputs from the command line

Windows Application (WinApp)

GUI-based Windows application with a splash screen and main interface

Implements the same two solutions in service classes

Contains input validation and event handlers for buttons to trigger calculations

Displays the result on the main page and handles empty or invalid inputs gracefully



No unit tests are included in this version.

The WinApp shares the core logic implemented in service classes reused from the CLI application.


Approach 1: Sorting-Based Solution
How it works:
Sort the array.

Iterate through the sorted array to find the longest streak of consecutive numbers.

Skip duplicates to avoid counting them multiple times.

Steps:
Sort the array (e.g., std::sort).

Initialize two counters: longest and current.

Traverse the array:

If the current number is exactly 1 greater than the previous, increment current.

If it's a duplicate, continue.

Otherwise, reset current to 1.

Track the maximum current value in longest.

Return longest.

Time Complexity:
Sorting takes O(n log n)

Single pass through the array is O(n)

Overall: O(n log n)

Space Complexity:
Sorting can be done in-place.

Extra space: O(1) or O(n) depending on sorting implementation.

Trade-offs:
Easy to implement.

Uses sorting, which may be costly for very large arrays.

Handles duplicates naturally by skipping them.

Approach 2: HashSet-Based Solution (Optimal)
How it works:
Insert all numbers into a hash set (std::unordered_set) for O(1) lookups.

For each number, only start counting a sequence if the previous number (num - 1) is not in the set — this means the current number is the start of a sequence.

Count consecutive numbers by checking the presence of num + 1, num + 2, ... in the set.

Track the longest consecutive sequence length.

Steps:
Insert all elements into an unordered_set.

For each number:

If (num - 1) is not in the set, start counting consecutive numbers from num.

Track and update the maximum sequence length.

Time Complexity:
Building the set: O(n)

Each number is visited at most twice: once to check if it’s a sequence start, and once while counting the sequence.

Overall: O(n)

Space Complexity:
Hash set uses O(n) space.

Trade-offs:
More efficient for large datasets.

Uses extra memory for the hash set.

Slightly more complex logic.

Edge Cases Handled
Empty array: Return 0.

Array with all duplicates: Longest consecutive sequence is 1.

Single element array: Return 1.

Negative numbers: Works as usual.

Unsorted input: Both approaches handle this.

Summary and Comparison

Approach	Time Complexity	Space Complexity	Pros	Cons
Sorting-Based	O(n log n)	O(1) or O(n)	Simple, easy to implement	Slower for large inputs
HashSet-Based	O(n)	O(n)	Fastest approach, linear time	Extra space required