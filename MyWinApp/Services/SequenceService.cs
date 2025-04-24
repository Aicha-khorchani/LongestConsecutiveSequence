using System;
using System.Linq;

namespace MyWinApp.Services
{
    public static class SequenceService
    {
        /// <summary>
        /// Calculates the longest consecutive sequence length from a comma-separated integer string.
        /// </summary>
        /// <param name="input">Comma-separated integers string</param>
        /// <returns>Length of longest consecutive sequence</returns>
        public static int LongestConsecutiveSequence(string input)
        {
            // Parse input to int array
            var numbers = input.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                               .Select(s => int.Parse(s.Trim()))
                               .ToArray();

            if (numbers.Length == 0)
                return 0;

            Array.Sort(numbers);

            int longest = 1;
            int current = 1;

            for (int i = 1; i < numbers.Length; i++)
            {
                if (numbers[i] == numbers[i - 1] + 1)
                {
                    current++;
                }
                else if (numbers[i] != numbers[i - 1]) // skip duplicates but reset current
                {
                    current = 1;
                }

                if (current > longest)
                {
                    longest = current;
                }
            }

            return longest;
        }
    }
}
