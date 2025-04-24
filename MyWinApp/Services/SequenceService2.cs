using System;
using System.Collections.Generic;
using System.Linq;

namespace MyWinApp.Services
{
    public static class SequenceService2
    {
        public static int LongestConsecutiveHashing(string input)
        {
            // Split input by comma, remove empty entries and trim spaces before parsing
            int[] nums = input
                .Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(s => int.Parse(s.Trim()))
                .ToArray();

            HashSet<int> numSet = new HashSet<int>(nums);
            int longest = 0;

            foreach (int num in numSet)
            {
                // Only check for start of sequence
                if (!numSet.Contains(num - 1))
                {
                    int currentNum = num;
                    int count = 1;

                    while (numSet.Contains(currentNum + 1))
                    {
                        currentNum++;
                        count++;
                    }

                    longest = Math.Max(longest, count);
                }
            }

            return longest;
        }
    }
}
