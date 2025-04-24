using System;
using System.Collections.Generic;
using System.Linq;

namespace LongestConsecutiveSequenceCLI
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = null;
            int solution = 1;
            bool runTests = false;

            try
            {
                // Simple arg parsing with validation
                for (int i = 0; i < args.Length; i++)
                {
                    switch (args[i].ToLower())
                    {
                        case "--input":
                            if (i + 1 < args.Length)
                            {
                                input = args[i + 1];
                                i++;
                            }
                            else
                            {
                                Console.Error.WriteLine("Error: --input requires a comma-separated string.");
                                Environment.Exit(1);
                            }
                            break;
                        case "--solution":
                            if (i + 1 < args.Length && int.TryParse(args[i + 1], out int sol))
                            {
                                if (sol == 1 || sol == 2)
                                {
                                    solution = sol;
                                    i++;
                                }
                                else
                                {
                                    Console.Error.WriteLine("Error: --solution must be 1 or 2.");
                                    Environment.Exit(1);
                                }
                            }
                            else
                            {
                                Console.Error.WriteLine("Error: --solution requires 1 or 2.");
                                Environment.Exit(1);
                            }
                            break;
                        case "--test":
                            runTests = true;
                            break;
                        case "--help":
                            PrintHelp();
                            return;
                        default:
                            Console.Error.WriteLine($"Unknown argument: {args[i]}");
                            PrintHelp();
                            Environment.Exit(1);
                            break;
                    }
                }

                if (runTests)
                {
                    RunUnitTests();
                    return;
                }

                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.Error.WriteLine("Error: No input specified.");
                    PrintHelp();
                    Environment.Exit(1);
                }

                // Validate and parse input before calling solution
                int[] numbers;
                try
                {
                    numbers = input.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                                   .Select(s =>
                                   {
                                       if (!int.TryParse(s.Trim(), out int num))
                                           throw new FormatException($"Invalid integer value: '{s}'");
                                       return num;
                                   })
                                   .ToArray();
                }
                catch (FormatException fex)
                {
                    Console.Error.WriteLine("Error parsing input: " + fex.Message);
                    Environment.Exit(1);
                    return;
                }

                if (numbers.Length == 0)
                {
                    Console.WriteLine("Result: 0 (empty input)");
                    return;
                }

                int result = solution == 1
                    ? SequenceService.LongestConsecutiveSequence(numbers)
                    : SequenceService2.LongestConsecutiveHashing(numbers);

                Console.WriteLine($"Solution {solution} result: {result}");
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine("Unexpected error: " + ex.Message);
                Environment.Exit(1);
            }
        }

        static void PrintHelp()
        {
            Console.WriteLine("Usage:");
            Console.WriteLine("  --input \"100,4,200,1,3,2\"     Comma-separated integers");
            Console.WriteLine("  --solution 1|2                Choose solution 1 (sort) or 2 (hash)");
            Console.WriteLine("  --test                       Run unit tests");
            Console.WriteLine("  --help                       Show this help");
        }

        static void RunUnitTests()
        {
            var tests = new List<(string input, int expected)>
            {
                ("100,4,200,1,3,2", 4),
                ("", 0),
                ("1,1,1,1", 1),
                ("10,5,6,7,8,9", 5),
                ("5,4,3,2,1", 5),
                ("20,30,40", 1)
            };

            foreach (var test in tests)
            {
                try
                {
                    var nums = test.input.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                                         .Select(s => int.Parse(s.Trim()))
                                         .ToArray();

                    int res1 = SequenceService.LongestConsecutiveSequence(nums);
                    int res2 = SequenceService2.LongestConsecutiveHashing(nums);

                    bool pass1 = res1 == test.expected;
                    bool pass2 = res2 == test.expected;

                    Console.WriteLine($"Input: [{test.input}] Expected: {test.expected}");
                    Console.WriteLine($" Solution 1 (Sort)  => Result: {res1} {(pass1 ? "PASS" : "FAIL")}");
                    Console.WriteLine($" Solution 2 (Hash)  => Result: {res2} {(pass2 ? "PASS" : "FAIL")}");
                    Console.WriteLine();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Test failed for input '{test.input}': {ex.Message}");
                }
            }
        }
    }

    public static class SequenceService
    {
        // Modified to accept int[] instead of string input
        public static int LongestConsecutiveSequence(int[] numbers)
        {
            if (numbers == null || numbers.Length == 0
