using System;
using System.Drawing;
using System.Windows.Forms;
using MyWinApp.Services;

namespace MyWinApp.Controllers
{
    public static class EventHandler2
    {
        public static void Solution2Button_Click(object sender, EventArgs e, TextBox inputTextBox, Label errorLabel, Label resultLabel)
        {
            string input = inputTextBox.Text;

            // Validate input: check for empty or invalid input using InputValidator
            if (string.IsNullOrWhiteSpace(input) || !InputValidator.IsValidInput(input))
            {
                errorLabel.Text = "Invalid input! Please enter valid comma-separated integers.";
                errorLabel.ForeColor = Color.Red;
                errorLabel.Visible = true;

                resultLabel.Text = "Please fix input errors.";
                resultLabel.ForeColor = Color.Red;
                return;
            }

            // Input is valid, hide error message
            errorLabel.Visible = false;

            // Call hashing-based logic for longest consecutive sequence
            int result = SequenceService2.LongestConsecutiveHashing(input);

            // Display the result
            resultLabel.Text = $"Hashing Longest consecutive sequence length: {result}";
            resultLabel.ForeColor = Color.Black;
        }
    }
}
