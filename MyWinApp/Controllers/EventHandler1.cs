using System;
using System.Drawing;
using System.Windows.Forms;
using MyWinApp.Services;

namespace MyWinApp.Controllers
{
    public static class EventHandler1
    {
        // Event handler method for Solution1 button click
        public static void Solution1Button_Click(object sender, EventArgs e, TextBox inputTextBox, Label errorLabel, Label resultLabel)
        {
            string input = inputTextBox.Text;

            // Validate input
            if (!InputValidator.IsValidInput(input))
            {
                errorLabel.Text = "Invalid input! Please enter valid comma-separated integers.";
                errorLabel.ForeColor = Color.Red;
                errorLabel.Visible = true;

                resultLabel.Text = "Please fix input errors.";
                resultLabel.ForeColor = Color.Red;
                return;
            }

            // Input valid, hide error message
            errorLabel.Visible = false;

            // Calculate longest consecutive sequence
            int result = SequenceService.LongestConsecutiveSequence(input);

            // Show result
            resultLabel.Text = $"Longest consecutive sequence length: {result}";
            resultLabel.ForeColor = Color.Black;
        }
    }
}
