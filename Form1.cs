namespace _30_05_23
{
    public partial class Form1 : Form
    {
        int milliseconds = 0;
        DateTime timeStart;
        DateTime newYear = new DateTime(DateTime.Now.Year + 1, 1, 1);

        public Color targetColor = Color.Red;
        public Color originalColor = Color.White;
        private float persent = 0;

        int score = 0;
        int recordScore = 0;
        int time = 20;

        public Form1()
        {
            InitializeComponent();
            timer1.Start();
        }

        private Color FadeToColor(Color first, Color second, float persent)
        {
            int r = (int)(second.R * persent + first.R * (1f - persent));
            int g = (int)(second.G * persent + first.G * (1f - persent));
            int b = (int)(second.B * persent + first.B * (1f - persent));
            return Color.FromArgb(r, g, b);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timeStart = DateTime.Now;
            if (newYear <= timeStart)
            {
                timer1.Stop();
            }
            label1.Text = "New year through - " + (newYear - timeStart);

            milliseconds += 1000;
            this.Text = $"{milliseconds}";


            this.BackColor = FadeToColor(originalColor, targetColor, persent);
            persent += 0.01f;
            if (persent >= 1)
            {
                originalColor = targetColor;
                Random r = new Random();
                targetColor = Color.FromArgb(r.Next(256), r.Next(256), r.Next(256));
                persent = 0;
            }
        }

        private void clickerButton_Click(object sender, EventArgs e)
        {
            if (recordScore < score)
            {
                recordScore = score;
                recordLabel.Text = "Record: " + recordScore.ToString();
            }
            if (time == 20)
            {
                timerButtonActive.Start();
                return;
            }
            if (time >= 0 && time < 20)
            {
                score++;
                scoreLabel.Text ="Score: " + (score);
            }
        }

        private void timerButtonActive_Tick(object sender, EventArgs e)
        {
            time -= 1;
            if (time < 0)
            {
                score = 0;
                time = 20;
                timerButtonActive.Stop();
            }

            secondsButton.Text = "Seconds: " + time.ToString();
            scoreLabel.Text = "Score: " + score.ToString();
        }
    }
}
