using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace MyWinApp.Views
{
    public class SplashScreen : Form
    {
        private PictureBox logo;
        private Label welcomeLabel1;
        private Label welcomeLabel2;
        private ProgressBar progressBar;
private System.Windows.Forms.Timer fadeTimer;
        private float opacityStep = 0.05f;

        public SplashScreen()
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.ClientSize = new Size(1000, 800);
            this.Opacity = 0;
            this.BackColor = Color.White;

            // Load logo
            logo = new PictureBox
            {
                Size = new Size(200, 200),
                Location = new Point((this.Width - 200) / 2, 30),
                Image = Image.FromFile("Assets/logo.png"),
                SizeMode = PictureBoxSizeMode.Zoom,
                BackColor = Color.Transparent
            };

            // Progress bar under logo
            progressBar = new ProgressBar
            {
                Size = new Size(200, 10),
                Location = new Point((this.Width - 200) / 2, logo.Bottom + 10),
                Style = ProgressBarStyle.Marquee,
                MarqueeAnimationSpeed = 30,
                BackColor = Color.White,
                ForeColor = Color.Crimson // Bar color (doesn't show in classic theme)
            };

            // First welcome label
            welcomeLabel1 = CreateShadowedLabel("Welcome to MyWinApp!", new Font("Segoe UI", 14, FontStyle.Bold), Color.Black, 240);

            // Second welcome label
            welcomeLabel2 = CreateShadowedLabel("Aicha Khorchani test", new Font("Segoe UI", 14, FontStyle.Bold), Color.Red, 270);

            // Timer for fade in
fadeTimer = new System.Windows.Forms.Timer();
            fadeTimer.Interval = 50;
            fadeTimer.Tick += FadeIn;

            // Add controls
            this.Controls.Add(logo);
            this.Controls.Add(progressBar);
            this.Controls.Add(welcomeLabel1);
            this.Controls.Add(welcomeLabel2);
        }

        private Label CreateShadowedLabel(string text, Font font, Color color, int y)
        {
            // Shadow label (behind)
            var shadow = new Label
            {
                Text = text,
                Font = font,
                ForeColor = Color.Gray,
                BackColor = Color.White,
                AutoSize = true,
            };
            shadow.Location = new Point((this.Width - shadow.PreferredWidth) / 2 + 2, y + 2);
            this.Controls.Add(shadow);

            // Main label
            var label = new Label
            {
                Text = text,
                Font = font,
                ForeColor = color,
                BackColor = Color.White,
                AutoSize = true,
            };
            label.Location = new Point((this.Width - label.PreferredWidth) / 2, y);
            return label;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            fadeTimer.Start();
        }

        private void FadeIn(object? sender, EventArgs e)
        {
            if (this.Opacity < 1)
            {
                this.Opacity += opacityStep;
            }
            else
            {
                fadeTimer.Stop();

                // Optional: wait before transitioning to MainForm
var waitTimer = new System.Windows.Forms.Timer();
                waitTimer.Interval = 1500;
                waitTimer.Tick += (s, ev) =>
                {
                    waitTimer.Stop();
                    this.Close();

                };
                waitTimer.Start();
            }
        }
    }
}
