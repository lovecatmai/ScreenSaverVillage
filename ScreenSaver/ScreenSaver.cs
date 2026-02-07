using ScreenSaver.Properties;

namespace ScreenSaver
{
    /// <summary>
    /// Основная форма ScreenSaver.
    /// </summary>
    public partial class ScreenSaver : Form
    {
        private const int NumOfSnowflakes = 150;
        private const int snowflakeMinSideSize = 10;
        private const int snowflakeMaxSideSize = 30;
        private const int timerInterval = 10;
        private const int snowflakeInitialYMaxY = 0;
        private const int snowflakeInitialYMinY = -200;

        private Random rand = new Random();
        private Bitmap backgroundImg;
        private Bitmap snowflakeImg;
        private Bitmap frameBuffer;
        private Graphics frameBufferGraphics;
        private System.Windows.Forms.Timer timer;

        private Snowflake[] snowflakes;

        public ScreenSaver()
        {
            InitializeComponent();

            timer = new System.Windows.Forms.Timer();
            timer.Interval = timerInterval;
            timer.Tick += Timer_Tick;

            backgroundImg = Resources.BackgroundImg;
            snowflakeImg = Resources.SnowflakeImg;

            snowflakes = new Snowflake[NumOfSnowflakes];
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            for (var i = 0; i < snowflakes.Length; i++)
            {
                snowflakes[i].Y += snowflakes[i].Speed;

                if (snowflakes[i].Y > ClientSize.Height)
                {
                    SetSingleSnowflake(i);
                }
            }

            RenderFrame();
        }

        private void ScreenSaver_Load(object sender, EventArgs e)
        {
            SetSnowflakes();

            frameBuffer = new Bitmap(ClientSize.Width, ClientSize.Height);
            frameBufferGraphics = Graphics.FromImage(frameBuffer);

            timer.Start();
        }

        private void RenderFrame()
        {
            if (frameBufferGraphics != null)
            {
                frameBufferGraphics.DrawImage(
                backgroundImg,
                0, 0, frameBuffer.Width, frameBuffer.Height);

                foreach (var snowflake in snowflakes)
                {
                    if (snowflakeImg != null)
                    {
                        frameBufferGraphics.DrawImage(snowflakeImg, snowflake.X, snowflake.Y,
                                      snowflake.Size, snowflake.Size);
                    }
                }

                using (var g = this.CreateGraphics())
                {
                    g.DrawImage(frameBuffer, 0, 0);
                }
            }
        }

        private void SetSingleSnowflake(int index)
        {
            var sideSize = rand.Next(snowflakeMinSideSize, snowflakeMaxSideSize);

            var X = rand.Next(0, ClientSize.Width - sideSize);

            var Y = rand.Next(snowflakeInitialYMinY, snowflakeInitialYMaxY - sideSize);

            snowflakes[index].Size = sideSize;
            snowflakes[index].X = X;
            snowflakes[index].Y = Y;
        }

        private void SetSnowflakes()
        {
            for (var i = 0; i < snowflakes.Length; i++)
            {
                SetSingleSnowflake(i);
            }
        }

        private void ScreenSaver_KeyDown(object sender, KeyEventArgs e)
        {
            Close();
        }

        private void ScreenSaver_MouseClick(object sender, MouseEventArgs e)
        {
            Close();
        }
    }
}
