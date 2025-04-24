using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using MyWinApp.Controllers;

namespace MyWinApp.Views
{
    public static class InputValidator
    {
        public static bool IsValidInput(string input)
        {
            return input.All(c => char.IsDigit(c) || c == ',' || char.IsWhiteSpace(c));
        }
    }

    public class MainForm : Form
    {
        private TextBox inputTextBox;
        private Label errorLabel;
        private Label resultLabel;
        private Button solution1Button;
        private Button solution2Button;

        public MainForm()
        {
            this.Text = "Longest Consecutive Sequence Tester";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.ClientSize = new Size(1000, 800);
            this.BackColor = Color.FromArgb(245, 245, 245);

            InitializeUI();
        }

        private void InitializeUI()
        {
            // Main layout
            var mainLayout = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                RowCount = 2,
                ColumnCount = 1,
            };
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 60));
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));

            // NavBar Panel (VERY LIGHT GREY)
            var navBar = new Panel
            {
                Height = 60,
                Dock = DockStyle.Top,
                BackColor = Color.White,
                Padding = new Padding(15, 10, 15, 10),
            };

            var logo = new PictureBox
            {
                Image = Image.FromFile("Assets/logo.png"),
                SizeMode = PictureBoxSizeMode.Zoom,
                Size = new Size(120, 40),
                Dock = DockStyle.Left,
                Margin = new Padding(0, 0, 15, 0)
            };

            var nameLabel = new Label
            {
                Text = "Aicha Khorchani",
                ForeColor = Color.Black,
                Font = new Font("Segoe UI", 14F, FontStyle.Bold),
                AutoSize = true,
                Dock = DockStyle.Left,
                Padding = new Padding(10, 10, 0, 0)
            };

            navBar.Controls.Add(nameLabel);
            navBar.Controls.Add(logo);
            mainLayout.Controls.Add(navBar);

            // Content layout with 1 column
            var layout = new TableLayoutPanel
            {
                RowCount = 5,
                ColumnCount = 1,
                Dock = DockStyle.Fill,
                Padding = new Padding(30),
                AutoSize = false
            };

            layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 40)); // title
            layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 50)); // input textbox
            layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 30)); // error label
            layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 70)); // buttons row
            layout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F)); // result label fills remaining space

            // Title label
            var titleLabel = new Label
            {
                Text = "Enter Comma-Separated Integers:",
                Font = new Font("Segoe UI", 16F, FontStyle.Bold),
                AutoSize = true,
                Anchor = AnchorStyles.Left,
                ForeColor = Color.Black,
                Margin = new Padding(0, 0, 0, 15)
            };
            layout.Controls.Add(titleLabel, 0, 0);

            // Input textbox - left aligned, fixed width
            inputTextBox = new TextBox
            {
                Font = new Font("Consolas", 14F),
                Width = 540,
                Height = 36,
                BackColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle,
                Margin = new Padding(0, 0, 0, 10),
            };
            inputTextBox.TextChanged += InputTextBox_TextChanged;

            // Focus colors
            inputTextBox.GotFocus += (s, e) => inputTextBox.BackColor = Color.FromArgb(230, 240, 255);
            inputTextBox.LostFocus += (s, e) => inputTextBox.BackColor = Color.White;

            // Wrap the input textbox inside a panel to align left
            var inputPanel = new Panel { Dock = DockStyle.Fill };
            inputPanel.Controls.Add(inputTextBox);
            inputTextBox.Location = new Point(0, (inputPanel.Height - inputTextBox.Height) / 2);
            inputTextBox.Anchor = AnchorStyles.Left;

            layout.Controls.Add(inputPanel, 0, 1);

            // Error label
            errorLabel = new Label
            {
                Text = "❌ Invalid input! Use only numbers, commas, and spaces.",
                ForeColor = Color.FromArgb(231, 76, 60),
                Font = new Font("Segoe UI", 11F, FontStyle.Bold),
                AutoSize = true,
                Visible = false,
                Anchor = AnchorStyles.Left,
                Margin = new Padding(0, 0, 0, 15)
            };
            layout.Controls.Add(errorLabel, 0, 2);

            // Buttons panel for horizontal alignment of buttons next to each other and aligned with input textbox
            var buttonsPanel = new Panel
            {
                Dock = DockStyle.Fill,
            };

            solution1Button = new Button
            {
                Text = "▶ Run Solution 1",
                Font = new Font("Segoe UI", 14F, FontStyle.Bold),
                BackColor = Color.FromArgb(52, 152, 219),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Height = 52,
                Width = 260,
                Enabled = false,
                Margin = new Padding(0),
            };
            solution1Button.FlatAppearance.BorderSize = 0;
            solution1Button.Click += (s, e) => EventHandler1.Solution1Button_Click(s, e, inputTextBox, errorLabel, resultLabel);
            solution1Button.Paint += Button_PaintWithShadow;
            solution1Button.MouseEnter += Button_MouseEnter;
            solution1Button.MouseLeave += Button_MouseLeave;

            solution2Button = new Button
            {
                Text = "▶ Run Solution 2",
                Font = new Font("Segoe UI", 14F, FontStyle.Bold),
                BackColor = Color.FromArgb(231, 76, 60),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Height = 52,
                Width = 260,
                Enabled = false,
                Margin = new Padding(20, 0, 0, 0), // space between buttons
            };
            solution2Button.FlatAppearance.BorderSize = 0;
            solution2Button.Click += (s, e) => EventHandler2.Solution2Button_Click(s, e, inputTextBox, errorLabel, resultLabel);
            solution2Button.Paint += Button_PaintWithShadow;
            solution2Button.MouseEnter += Button_MouseEnter;
            solution2Button.MouseLeave += Button_MouseLeave;

            // Position buttons horizontally aligned with input textbox
            buttonsPanel.Controls.Add(solution1Button);
            buttonsPanel.Controls.Add(solution2Button);

            // Position buttons inside buttonsPanel horizontally
            solution1Button.Location = new Point(0, (buttonsPanel.Height - solution1Button.Height) / 2);
            solution1Button.Anchor = AnchorStyles.Left;

            solution2Button.Location = new Point(solution1Button.Right + 20, (buttonsPanel.Height - solution2Button.Height) / 2);
            solution2Button.Anchor = AnchorStyles.Left;

            // To keep buttons aligned when resizing, handle buttonsPanel resize event:
            buttonsPanel.Resize += (s, e) =>
            {
                solution1Button.Location = new Point(0, (buttonsPanel.Height - solution1Button.Height) / 2);
                solution2Button.Location = new Point(solution1Button.Right + 20, (buttonsPanel.Height - solution2Button.Height) / 2);
            };

            layout.Controls.Add(buttonsPanel, 0, 3);

            // Result label
            resultLabel = new Label
            {
                Text = "Result will appear here.",
                Font = new Font("Segoe UI", 16F, FontStyle.Bold),
                ForeColor = Color.Black,
                AutoSize = false,
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter,
                Padding = new Padding(10)
            };
            layout.Controls.Add(resultLabel, 0, 4);

            mainLayout.Controls.Add(layout, 0, 1);
            this.Controls.Add(mainLayout);
        }

        // Draw subtle shadow effect around button
        private void Button_PaintWithShadow(object sender, PaintEventArgs e)
        {
            if (sender is not Button btn) return;

            var shadowColor = Color.FromArgb(60, 0, 0, 0);
            var shadowRect = new Rectangle(3, 3, btn.Width - 6, btn.Height - 6);

            using var shadowBrush = new SolidBrush(shadowColor);
            e.Graphics.FillRectangle(shadowBrush, shadowRect);
        }

        // Hover effect: lighten button background
        private void Button_MouseEnter(object sender, EventArgs e)
        {
            if (sender is Button btn)
            {
                btn.BackColor = ControlPaint.Light(btn.BackColor);
                btn.Cursor = Cursors.Hand;
            }
        }

        private void Button_MouseLeave(object sender, EventArgs e)
        {
            if (sender is Button btn)
            {
                if (btn == solution1Button)
                    btn.BackColor = Color.FromArgb(52, 152, 219);
                else if (btn == solution2Button)
                    btn.BackColor = Color.FromArgb(231, 76, 60);

                btn.Cursor = Cursors.Default;
            }
        }

        private void InputTextBox_TextChanged(object sender, EventArgs e)
        {
            string input = inputTextBox.Text;
            bool isValid = InputValidator.IsValidInput(input);

            errorLabel.Visible = !isValid;
            solution1Button.Enabled = isValid;
            solution2Button.Enabled = isValid;

            resultLabel.Text = isValid ? "Ready to run solutions." : "Please fix input errors.";
        }
    }
}
