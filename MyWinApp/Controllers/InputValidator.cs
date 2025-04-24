using System;
using System.Linq;

namespace MyWinApp.Controllers
{
    public static class InputValidator
    {
        /// <summary>
        /// Validates input string for the problem:
        /// - Non-empty
        /// - Comma-separated integers only
        /// - Handles empty array (after split) gracefully
        /// </summary>
        /// <param name="input"></param>
        /// <returns>true if valid, false otherwise</returns>
        public static bool IsValidInput(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return false;

            // Split by comma and remove empty entries, trim spaces
            var parts = input.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                             .Select(s => s.Trim())
                             .ToArray();

            // Empty array after splitting is invalid
            if (parts.Length == 0)
                return false;

            // Check each part can parse to an integer
            foreach (var part in parts)
            {
                if (!int.TryParse(part, out _))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
